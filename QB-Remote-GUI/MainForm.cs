using QB_Remote_GUI.API.Clients;
using QB_Remote_GUI.API.Interfaces;
using QB_Remote_GUI.API.Models.Sync;
using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Forms;
using QB_Remote_GUI.GUI.Utils;
using QB_Remote_GUI.GUI.Views;
using System.Diagnostics;
using System.Text.RegularExpressions;
using QB_Remote_GUI.GUI.Models;

namespace QB_Remote_GUI.GUI
{
    public partial class MainForm : Form
    {
        private readonly LanguageLoader _lang;
        
        private IQBittorrentClient? _client;
        private int _lastRid;
        private readonly Dictionary<string, TorrentInfo> _torrents = [];
        private TorrentInfo? _selectedTorrent;
        private bool _isConnected;
        private ConnectionProfile? _currentConnection;
        // hook to trigger event when timerSync is ticked

        // Peer data management
        private readonly Dictionary<string, PeerInfo> _peers = [];
        private int _lastPeerRid;

        // Connection management
        private readonly string _connectionsPath;
        private readonly List<ConnectionProfile> _connections = [];

        // View managers
        private readonly TorrentListViewManager _torrentListViewManager;
        private readonly PeerListViewManager _peerListViewManager;
        private readonly FileListViewManager _fileListViewManager;

        private int _sortColumn = 0;
        private bool _sortAscending = true;

        public MainForm()
        {
            _lang = LanguageLoader.GetInstance();

            // Set up connections path
            _connectionsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "QB-Remote-GUI",
                "Connections");

            InitializeComponent();

            // Initialize view managers
            _torrentListViewManager = new TorrentListViewManager(torrentListView);
            _peerListViewManager = new PeerListViewManager(peerListView);
            _fileListViewManager = new FileListViewManager(fileListView, imgFiles);

            InitializeControls();
            LoadConnections();
        }

        private void InitializeControls()
        {
            // Set up menu items
            menuTorrent.Text = _lang.GetTranslation("&Torrent");
            menuitemConnect.Text = _lang.GetTranslation("Connect to Transmission") + LanguageLoader.Dots;
            menuitemDisconnect.Text = _lang.GetTranslation("Disconnect from Transmission");
            menuitemAddTorrent.Text = _lang.GetTranslation("&Add torrent") + LanguageLoader.Dots;
            menuitemStartTorrent.Text = _lang.GetTranslation("Start");
            menuitemPauseTorrent.Text = _lang.GetTranslation("Stop");
            menuitemDeleteTorrent.Text = _lang.GetTranslation("Remove") + LanguageLoader.Dots;
            menuitemExit.Text = _lang.GetTranslation("E&xit");
            tsddManageConnection.Text = _lang.GetTranslation("Manage connections") + LanguageLoader.Dots;

            InitializeToolbar();
            InitializeTorrentListMenu();

            // Set up tabs
            generalTab.Text = _lang.GetTranslation("General");
            trackersTab.Text = _lang.GetTranslation("Trackers");
            peersTab.Text = _lang.GetTranslation("Peers");
            filesTab.Text = _lang.GetTranslation("Files");

            // Set up state tree view
            stateTreeView.Nodes.Add("all", _lang.GetTranslation("All torrents"), "tr_t_all", "tr_t_all");
            stateTreeView.Nodes.Add("downloading", _lang.GetTranslation("Downloading"), "tr_t_down", "tr_t_down");
            stateTreeView.Nodes.Add("completed", _lang.GetTranslation("Completed"), "tr_t_up", "tr_t_up");
            stateTreeView.Nodes.Add("active", _lang.GetTranslation("Active"), "tr_active", "tr_active");
            stateTreeView.Nodes.Add("inactive", _lang.GetTranslation("Inactive"), "tr_t_busy", "tr_t_busy");
            stateTreeView.Nodes.Add("stopped", _lang.GetTranslation("Stopped"), "tr_t_pause", "tr_t_pause");
            stateTreeView.Nodes.Add("error", _lang.GetTranslation("Error"), "tr_t_error", "tr_t_error");
            stateTreeView.Nodes.Add("waiting", _lang.GetTranslation("Waiting"), "tr_queue", "tr_queue");

            tsConfigurePeerColumns.Text = _lang.GetTranslation("Setup columns") + LanguageLoader.Dots;

            // Set up tracker list view
            trackerListView.View = View.Details;
            trackerListView.FullRowSelect = true;
            trackerListView.GridLines = true;

            urlColumn.Text = "URL";
            statusColumn2.Text = _lang.GetTranslation("Status");

            urlColumn.Width = 400;
            statusColumn2.Width = 100;

            torrentListView.SetDoubleBuffered();
            trackerListView.SetDoubleBuffered();
            peerListView.SetDoubleBuffered();
            fileListView.SetDoubleBuffered();
            torrentListView.ListViewItemSorter = new ListViewItemComparer(_sortColumn, _sortAscending);
            torrentListView.Sort();
            UpdateControlState();
        }

        private void TorrentListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColumn)
            {
                // Same column, toggle sort order
                _sortAscending = !_sortAscending;
            }
            else
            {
                // New column, sort ascending
                _sortColumn = e.Column;
                _sortAscending = true;
            }

            torrentListView.ListViewItemSorter = new ListViewItemComparer(_sortColumn, _sortAscending);
            torrentListView.Sort();
        }

        private void LoadConnections()
        {
            _connections.Clear();

            if (!Directory.Exists(_connectionsPath))
            {
                Directory.CreateDirectory(_connectionsPath);
                return;
            }

            foreach (var file in Directory.GetFiles(_connectionsPath, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var connection = System.Text.Json.JsonSerializer.Deserialize<ConnectionProfile>(json);
                    if (connection != null)
                    {
                        _connections.Add(connection);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"加载连接配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Update menu items
            while (tsbspConnect.DropDownItems.Count > 0 && tsbspConnect.DropDownItems[0] != sepTsbConnect)
            {
                tsbspConnect.DropDownItems[0].Dispose();
            }
            while (menuitemConnect.DropDownItems.Count > 0 && menuitemConnect.DropDownItems[0] != sepTsddMenuConnect)
            {
                menuitemConnect.DropDownItems[0].Dispose();
            }

            foreach (var connection in _connections.OrderByDescending(c => c.LastUsed))
            {
                foreach (var itemCollection in (ReadOnlySpan<ToolStripItemCollection>)[menuitemConnect.DropDownItems, tsbspConnect.DropDownItems])
                {
                    var menuItem = new ToolStripMenuItem(connection.Name);
                    menuItem.Tag = connection;
                    menuItem.Click += async (s, _) =>
                    {
                        if (s is ToolStripMenuItem { Tag: ConnectionProfile connectionProfile })
                            await ConnectToProfile(connectionProfile);
                    };
                    itemCollection.Insert(0, menuItem);
                }
            }
        }

        private async Task ConnectToProfile(ConnectionProfile connection)
        {
            if (_isConnected)
            {
                await Disconnect();
            }
            try
            {
                // Create new client with the connection options
                var options = new QBittorrentClientOptions
                {
                    BaseUrl = connection.GetBaseUrl(),
                    Username = connection.Username,
                    Password = connection.Password,
                    TimeoutSeconds = connection.TimeoutSeconds
                };

                _client = new QBittorrentClient(new Microsoft.Extensions.Options.OptionsWrapper<QBittorrentClientOptions>(options));

                // Try to log in with new connection
                if (await _client.LoginAsync())
                {
                    _currentConnection = connection;
                    _currentConnection.LastUsed = DateTime.Now;

                    // Save the last used time
                    SaveConnection(_currentConnection);

                    _isConnected = true;
                    UpdateControlState();
                    await CleanRefreshData();
                }
                else
                {
                    MessageBox.Show("登录失败，请检查连接设置。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Disconnect(object? sender, EventArgs e)
        {
            _ = Disconnect();
        }
        private async Task Disconnect()
        {
            if (_client == null) return;
            try
            {
                timerSync.Stop();
                await _client.LogoutAsync();
                _isConnected = false;
                _torrents.Clear();
                UpdateTorrentList();
                UpdateControlState();

                // Dispose the client
                if (_client is IDisposable disposable)
                {
                    disposable.Dispose();
                }
                _client = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"断开连接失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SyncData()
        {
            if (_client == null) return;

            try
            {
                if (_lastRid == 0)
                    Debug.WriteLine(_lastRid);
                var mainData = await _client.GetMainDataAsync(_lastRid);
                _lastRid = mainData.Rid;

                if (mainData.IsFullUpdate)
                {
                    _torrents.Clear();
                }

                // Remove deleted torrents
                foreach (var hash in mainData.RemovedTorrents)
                {
                    _torrents.Remove(hash);
                }

                // Update torrents
                foreach (var (hash, torrent) in mainData.Torrents)
                {
                    if (_torrents.TryGetValue(hash, out var existingTorrent))
                    {
                        existingTorrent.Update(torrent);
                    }
                    else
                    {
                        torrent.Hash = hash;
                        _torrents[hash] = torrent;
                    }
                }

                UpdateTorrentList();
                UpdateStatusBar(mainData.ServerState);

                // 仅在有选中的种子时更新详情
                if (_selectedTorrent != null)
                {
                    await RefreshSelectedTorrentDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"同步数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timerSync.Stop();
                _isConnected = false;
                UpdateControlState();
            }
        }

        private async Task RefreshSelectedTorrentDetails()
        {
            if (_selectedTorrent == null || _client == null) return;
            var hash = _selectedTorrent.Hash;
            if (hash == null) return;

            try
            {
                // 仅在 General 标签页可见时更新常规信息
                if (tabControl.SelectedTab == generalTab)
                {
                    var properties = await _client.GetTorrentPropertiesAsync(hash);
                    torrentInfoView1.Render(_selectedTorrent, properties);

                    var pieces = await _client.GetTorrentPiecesStatesAsync(hash);
                    torrentPieceView1.Render([.. pieces]);
                }

                // 仅在 Peers 标签页可见时更新对等点信息
                if (tabControl.SelectedTab == peersTab)
                {
                    await UpdatePeerList();
                }

                // 仅在 Files 标签页可见时更新文件信息
                if (tabControl.SelectedTab == filesTab)
                {
                    var files = await _client.GetTorrentContentsAsync(hash);
                    _fileListViewManager?.UpdateFileList(files, hash);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取种子详情失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTorrentList()
        {
            var filteredTorrents = FilterTorrents();
            _torrentListViewManager.UpdateTorrents(filteredTorrents);
        }

        private Dictionary<string, TorrentInfo> FilterTorrents()
        {
            if (stateTreeView.SelectedNode == null)
                return _torrents;

            return stateTreeView.SelectedNode.Name switch
            {
                "downloading" => _torrents.Where(t => t.Value.State == "downloading").ToDictionary(t => t.Key, t => t.Value),
                "completed" => _torrents.Where(t => t.Value.Progress >= 1).ToDictionary(t => t.Key, t => t.Value),
                "active" => _torrents.Where(t => t.Value.DownloadSpeed > 0 || t.Value.UploadSpeed > 0).ToDictionary(t => t.Key, t => t.Value),
                "inactive" => _torrents.Where(t => t.Value is { DownloadSpeed: 0, UploadSpeed: 0 }).ToDictionary(t => t.Key, t => t.Value),
                "stopped" => _torrents.Where(t => t.Value.State == "pausedUP").ToDictionary(t => t.Key, t => t.Value),
                "error" => _torrents.Where(t => t.Value.State == "error").ToDictionary(t => t.Key, t => t.Value),
                "waiting" => _torrents.Where(t => t.Value.State == "waiting").ToDictionary(t => t.Key, t => t.Value),
                _ => _torrents
            };
        }

        private void UpdateStatusBar(ServerState state)
        {
            downloadSpeedLabel.Text = $"↓ {FormatSpeed(state.DownloadSpeed)}";
            uploadSpeedLabel.Text = $"↑ {FormatSpeed(state.UploadSpeed)}";
            connectionStatusLabel.Text = state.ConnectionStatus;
        }

        private void UpdateControlState()
        {
            var hasSelection = torrentListView.SelectedItems.Count > 0;

            Text = _currentConnection != null ? $"QB Remote GUI - {_currentConnection.Name}" : "QB Remote GUI";

            menuitemDisconnect.Enabled = _isConnected;
            menuitemAddTorrent.Enabled = _isConnected;
            menuitemStartTorrent.Enabled = _isConnected && hasSelection;
            menuitemPauseTorrent.Enabled = _isConnected && hasSelection;
            menuitemDeleteTorrent.Enabled = _isConnected && hasSelection;

            tsbDisconnect.Enabled = _isConnected;
            tsbAddTorrent.Enabled = _isConnected;
            tsbStartTorrent.Enabled = _isConnected && hasSelection;
            tsbPauseTorrent.Enabled = _isConnected && hasSelection;
            tsbDeleteTorrent.Enabled = _isConnected && hasSelection;
        }

        private async void TorrentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_client == null) return;

            UpdateControlState();

            if (torrentListView.SelectedItems.Count != 1)
            {
                _selectedTorrent = null;
                trackerListView.Items.Clear();
                peerListView.Items.Clear();
                _fileListViewManager.ClearFileList();
                return;
            }

            _selectedTorrent = torrentListView.SelectedItems[0].Tag as TorrentInfo;
            if (_selectedTorrent?.Hash == null) return;

            try
            {
                // Update general properties
                var properties = await _client.GetTorrentPropertiesAsync(_selectedTorrent.Hash);
                torrentInfoView1.Render(_selectedTorrent, properties);

                var pieces = await _client.GetTorrentPiecesStatesAsync(_selectedTorrent.Hash);
                torrentPieceView1.Render([.. pieces]);

                // Update trackers
                var trackers = await _client.GetTorrentTrackersAsync(_selectedTorrent.Hash);
                trackerListView.BeginUpdate();
                trackerListView.Items.Clear();
                foreach (var tracker in trackers)
                {
                    var item = new ListViewItem(tracker.Url);
                    item.SubItems.Add(tracker.Status.ToString());
                    trackerListView.Items.Add(item);
                }

                trackerListView.EndUpdate();

                // Reset peer data and update peers
                _lastPeerRid = 0;
                _peers.Clear();
                await UpdatePeerList();

                // Update files
                var files = await _client.GetTorrentContentsAsync(_selectedTorrent.Hash);
                _fileListViewManager?.UpdateFileList(files, _selectedTorrent.Hash);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取种子详情失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StateTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateTorrentList();
        }

        private static string FormatSize(long bytes)
        {
            string[] sizes = ["B", "KB", "MB", "GB", "TB"];
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        private static string FormatSpeed(long bytesPerSecond)
        {
            return $"{FormatSize(bytesPerSecond)}/s";
        }

        private async Task CleanRefreshData()
        {
            try
            {
                _lastRid = 0;
                _torrents.Clear();
                await SyncData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刷新数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isConnected = false;
                UpdateControlState();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerSync.Stop();
            timerSync.Dispose();

            // Dispose the client if it exists
            if (_client is IDisposable disposable)
            {
                disposable.Dispose();
            }

            base.OnFormClosing(e);
        }

        private async void ManageConnections(object sender, EventArgs e)
        {
            using var form = new ConnectionManager(_connections);
            if (form.ShowDialog() != DialogResult.OK) return;
            SyncFromModifiedConnections(form.DuplicatedConnections);
            if (!_isConnected && form.SelectedConnection != null)
            {
                await ConnectToProfile(form.SelectedConnection);
            }
        }

        private async void ConnectLastConn(object sender, EventArgs e)
        {
            if (_isConnected || _currentConnection == null)
            {
                tsbspConnect.ShowDropDown();
            }
            else
            {
                await ConnectToProfile(_currentConnection);
            }
        }

        private void SyncFromModifiedConnections(List<ConnectionProfile> modifiedConnections)
        {
            if (!Directory.Exists(_connectionsPath))
            {
                Directory.CreateDirectory(_connectionsPath);
            }

            var allExistingConnections = _connections.ToList();
            foreach (var connection in modifiedConnections)
            {
                var existingConnection = _connections.FirstOrDefault(c => c.Name == connection.Name);
                if (existingConnection == null)
                {
                    existingConnection = _connections.FirstOrDefault(c => c.Host == connection.Host && c.Port == connection.Port);
                }
                if (existingConnection != null)
                {
                    if (existingConnection.Name != connection.Name)
                    {
                        // Connection name changed, delete old connection file
                        File.Delete(Path.Combine(_connectionsPath, $"{existingConnection.Name}.json"));
                        existingConnection.Name = connection.Name;
                    }
                    if (existingConnection.Host != connection.Host)
                    {
                        existingConnection.Host = connection.Host;
                    }
                    if (existingConnection.Port != connection.Port)
                    {
                        existingConnection.Port = connection.Port;
                    }
                    if (existingConnection.Username != connection.Username)
                    {
                        existingConnection.Username = connection.Username;
                    }
                    if (existingConnection.Password != connection.Password)
                    {
                        existingConnection.Password = connection.Password;
                    }
                    if (existingConnection.TimeoutSeconds != connection.TimeoutSeconds)
                    {
                        existingConnection.TimeoutSeconds = connection.TimeoutSeconds;
                    }

                    SaveConnection(existingConnection);
                    allExistingConnections.Remove(existingConnection);
                }
            }
            foreach (var connection in allExistingConnections)
            {
                DeleteConnection(connection);
            }
        }

        private void DeleteConnection(ConnectionProfile connection)
        {
            _connections.Remove(connection);
            var normalizedName = Regex.Replace(connection.Name, "[^a-zA-Z0-9]", "_");
            File.Delete(Path.Combine(_connectionsPath, $"{normalizedName}.json"));
        }

        private void SaveConnection(ConnectionProfile connection)
        {
            // Normalize file name, remove all special characters
            var normalizedName = Regex.Replace(connection.Name, "[^a-zA-Z0-9]", "_");
            var filePath = Path.Combine(_connectionsPath, $"{normalizedName}.json");
            var json = System.Text.Json.JsonSerializer.Serialize(connection, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        private void ConfigureTorrentListViewColumns(object sender, EventArgs e)
        {
            using var form = new ListViewColumnSelector(torrentListView, _torrentListViewManager.GetColumnConfig());
            if (form.ShowDialog() != DialogResult.OK) return;
            _torrentListViewManager.SetColumnConfig(form.SelectedColumns);
            _torrentListViewManager.SaveColumnConfig();
        }

        private void ConfigurePeerListViewColumns(object sender, EventArgs e)
        {
            using var form = new ListViewColumnSelector(peerListView, _peerListViewManager.GetColumnConfig());
            if (form.ShowDialog() != DialogResult.OK) return;
            _peerListViewManager.SetColumnConfig(form.SelectedColumns);
            _peerListViewManager.SaveColumnConfig();
        }

        private void ConfigureFileListViewColumns(object sender, EventArgs e)
        {
            using var form = new ListViewColumnSelector(fileListView, _fileListViewManager.GetColumnConfig());
            if (form.ShowDialog() != DialogResult.OK) return;
            _fileListViewManager.SetColumnConfig(form.SelectedColumns);
            _fileListViewManager.SaveColumnConfig();
        }

        private void TimerSync_Tick(object sender, EventArgs e)
        {
            _ = SyncData();
        }

        private async Task UpdatePeerList()
        {
            if (_selectedTorrent == null || _client == null) return;
            if (_selectedTorrent.Hash == null) return;

            try
            {
                var peerData = await _client.GetPeersDataAsync(_selectedTorrent.Hash, _lastPeerRid);
                _lastPeerRid = peerData.Rid ?? 0;

                if (peerData.IsFullUpdate)
                {
                    _peers.Clear();
                }

                // Remove peers that are no longer connected
                if (peerData.RemovedPeers != null)
                {
                    foreach (var peer in peerData.RemovedPeers)
                    {
                        _peers.Remove(peer);
                    }
                }

                // Update or add new peers
                if (peerData.Peers != null)
                {
                    foreach (var (key, peer) in peerData.Peers)
                    {
                        if (_peers.TryGetValue(key, out var existingPeer))
                        {
                            existingPeer.Update(peer);
                        }
                        else
                        {
                            _peers[key] = peer;
                        }
                    }
                }

                // Update the ListView
                _peerListViewManager.UpdatePeers(_peers.Values);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取对等节点信息失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
