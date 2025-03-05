using QB.Remote.API.Clients;
using QB.Remote.API.Interfaces;
using QB.Remote.API.Models.Sync;
using QB.Remote.API.Models.Torrents;
using QB.Remote.GUI.Models;
using QB_Remote_GUI.Forms;
using QB_Remote_GUI.Models;
using QB_Remote_GUI.Views;
using System.Text.RegularExpressions;

namespace QB_Remote_GUI
{
    public partial class MainForm : Form
    {
        private IQBittorrentClient? _client;
        private System.Windows.Forms.Timer _syncTimer;
        private int _lastRid;
        private Dictionary<string, TorrentInfo> _torrents = new();
        private TorrentInfo? _selectedTorrent;
        private bool _isConnected;
        private ConnectionProfile? _currentConnection;

        // Peer data management
        private Dictionary<string, PeerInfo> _peers = new();
        private int _lastPeerRid;

        // Connection management
        private readonly string _connectionsPath;
        private readonly List<ConnectionProfile> _connections = new();

        // View managers
        private TorrentListViewManager? _torrentListViewManager;
        private PeerListViewManager? _peerListViewManager;
        private FileListViewManager? _fileListViewManager;

        // Column configuration
        private readonly string _torrentColumnsConfigPath;
        private readonly string _peerColumnsConfigPath;
        internal List<ColumnInfo> _torrentColumnConfig;
        internal List<ColumnInfo> _peerColumnConfig;

        public MainForm()
        {
            // Set up connections path
            _connectionsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "QB-Remote-GUI",
                "Connections");

            // Set up columns config path
            _torrentColumnsConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "QB-Remote-GUI",
                "torrent_columns.json");
            _peerColumnsConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "QB-Remote-GUI",
                "peer_columns.json");

            InitializeComponent();
            LoadTorrentColumnConfig();
            LoadPeerColumnConfig();
            InitializeControls();
            LoadConnections();
        }

        private void InitializeControls()
        {
            var lang = LanguageLoader.Instance;

            // Set up menu items
            menuTorrent.Text = lang.GetTranslation("&Torrent");
            menuitemConnect.Text = lang.GetTranslation("Connect to Transmission") + "...";
            menuitemDisconnect.Text = lang.GetTranslation("Disconnect from Transmission");
            menuitemAddTorrent.Text = lang.GetTranslation("&Add torrent") + "...";
            menuitemStartTorrent.Text = lang.GetTranslation("Start");
            menuitemPauseTorrent.Text = lang.GetTranslation("Stop");
            menuitemDeleteTorrent.Text = lang.GetTranslation("Remove") + "...";
            menuitemExit.Text = lang.GetTranslation("E&xit");
            tsddManageConnection.Text = lang.GetTranslation("Manage connections") + "...";

            // Set up tool strip buttons
            tsbspConnect.Text = lang.GetTranslation("Connect to Transmission");
            tsbDisconnect.Text = lang.GetTranslation("Disconnect from Transmission");
            tsbAddTorrent.Text = lang.GetTranslation("&Add torrent");
            tsbStartTorrent.Text = lang.GetTranslation("Start");
            tsbPauseTorrent.Text = lang.GetTranslation("Stop");
            tsbDeleteTorrent.Text = lang.GetTranslation("Remove");
            tsbManageConnection.Text = lang.GetTranslation("Manage connections") + "...";

            // Set up tabs
            generalTab.Text = lang.GetTranslation("General");
            trackersTab.Text = lang.GetTranslation("Trackers");
            peersTab.Text = lang.GetTranslation("Peers");
            filesTab.Text = lang.GetTranslation("Files");

            // Set up state tree view
            stateTreeView.Nodes.Add("all", lang.GetTranslation("All torrents"), "tr_t_all", "tr_t_all");
            stateTreeView.Nodes.Add("downloading", lang.GetTranslation("Downloading"), "tr_t_down", "tr_t_down");
            stateTreeView.Nodes.Add("completed", lang.GetTranslation("Completed"), "tr_t_up", "tr_t_up");
            stateTreeView.Nodes.Add("active", lang.GetTranslation("Active"), "tr_active", "tr_active");
            stateTreeView.Nodes.Add("inactive", lang.GetTranslation("Inactive"), "tr_t_busy", "tr_t_busy");
            stateTreeView.Nodes.Add("stopped", lang.GetTranslation("Stopped"), "tr_t_pause", "tr_t_pause");
            stateTreeView.Nodes.Add("error", lang.GetTranslation("Error"), "tr_t_error", "tr_t_error");
            stateTreeView.Nodes.Add("waiting", lang.GetTranslation("Waiting"), "tr_queue", "tr_queue");

            // Initialize view managers
            _torrentListViewManager = new TorrentListViewManager(torrentListView, imgTorrent);
            _peerListViewManager = new PeerListViewManager(peerListView);
            _fileListViewManager = new FileListViewManager(fileListView);

            tsConfigureTorrentColumns.Text = lang.GetTranslation("Setup columns") + "...";
            tsConfigurePeerColumns.Text = lang.GetTranslation("Setup columns") + "...";

            // Set up tracker list view
            trackerListView.View = View.Details;
            trackerListView.FullRowSelect = true;
            trackerListView.GridLines = true;

            urlColumn.Text = "URL";
            statusColumn2.Text = lang.GetTranslation("Status");

            urlColumn.Width = 400;
            statusColumn2.Width = 100;

            // Set up peer list view
            //peerListView.View = View.Details;
            //peerListView.FullRowSelect = true;
            //peerListView.GridLines = true;

            //ipColumn.Text = "IP";
            //clientColumn.Text = lang.GetTranslation("Client");
            //flagsColumn.Text = lang.GetTranslation("Flags");
            //progressColumn2.Text = lang.GetTranslation("Progress");
            //downloadSpeedColumn2.Text = lang.GetTranslation("Download speed");
            //uploadSpeedColumn2.Text = lang.GetTranslation("Upload speed");

            //ipColumn.Width = 150;
            //clientColumn.Width = 150;
            //flagsColumn.Width = 100;
            //progressColumn2.Width = 100;
            //downloadSpeedColumn2.Width = 100;
            //uploadSpeedColumn2.Width = 100;

            // Set up file tree view
            //fileListView.CheckBoxes = true;

            torrentListView.SetDoubleBuffered();
            trackerListView.SetDoubleBuffered();
            peerListView.SetDoubleBuffered();
            fileListView.SetDoubleBuffered();
            torrentListView.ListViewItemSorter = new ListViewItemComparer(_sortColumn, _sortAscending);
            torrentListView.Sort();
            UpdateControlState();
        }

        private int _sortColumn = 0;
        private bool _sortAscending = true;

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
                var menuItem = new ToolStripMenuItem(connection.Name);
                menuItem.Tag = connection;
                menuItem.Click += async (s, e) => await ConnectToProfile((ConnectionProfile)((ToolStripMenuItem)s).Tag);
                tsbspConnect.DropDownItems.Insert(0, menuItem);
                menuItem = new ToolStripMenuItem(connection.Name);
                menuItem.Tag = connection;
                menuItem.Click += async (s, e) => await ConnectToProfile((ConnectionProfile)((ToolStripMenuItem)s).Tag);
                menuitemConnect.DropDownItems.Insert(0, menuItem);
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

                // Try to login with new connection
                if (await _client.LoginAsync())
                {
                    _currentConnection = connection;
                    _currentConnection.LastUsed = DateTime.Now;

                    // Save the last used time
                    SaveConnection(_currentConnection);

                    _isConnected = true;
                    UpdateControlState();
                    await RefreshData();
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

        private async void Disconnect(object? sender, EventArgs e)
        {
            await Disconnect();
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

        private async void AddTorrent(object? sender, EventArgs e)
        {
            if (_client == null) return;

            using var dialog = new OpenFileDialog
            {
                Filter = "Torrent 文件|*.torrent|所有文件|*.*",
                Multiselect = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var torrentFiles = new List<byte[]>();
                    foreach (var file in dialog.FileNames)
                    {
                        torrentFiles.Add(await File.ReadAllBytesAsync(file));
                    }

                    await _client.AddTorrentAsync(new AddTorrentOptions
                    {
                        TorrentFiles = torrentFiles,
                        Stopped = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"添加种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void StartTorrents(object? sender, EventArgs e)
        {
            if (_client == null) return;

            var selectedHashes = GetSelectedTorrentHashes();
            if (selectedHashes.Any())
            {
                try
                {
                    await _client.ResumeTorrentsAsync(selectedHashes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"开始种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void PauseTorrents(object? sender, EventArgs e)
        {
            if (_client == null) return;

            var selectedHashes = GetSelectedTorrentHashes();
            if (selectedHashes.Any())
            {
                try
                {
                    await _client.PauseTorrentsAsync(selectedHashes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"暂停种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DeleteTorrents(object? sender, EventArgs e)
        {
            if (_client == null) return;

            var selectedHashes = GetSelectedTorrentHashes();
            if (selectedHashes.Any())
            {
                var result = MessageBox.Show(
                    "是否同时删除文件？",
                    "删除种子",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Cancel)
                {
                    try
                    {
                        await _client.DeleteTorrentsAsync(selectedHashes, result == DialogResult.Yes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"删除种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private IEnumerable<string> GetSelectedTorrentHashes()
        {
            return torrentListView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => item.Name)
                .ToList();
        }

        private async Task SyncData()
        {
            if (_client == null) return;

            try
            {
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
                    if (_torrents.ContainsKey(hash))
                    {
                        var existingTorrent = _torrents[hash];
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
                    // 仅在 General 标签页可见时更新常规信息
                    if (tabControl.SelectedTab == generalTab)
                    {
                        var properties = await _client.GetTorrentPropertiesAsync(_selectedTorrent.Hash);
                        torrentInfoView1.Render(_selectedTorrent, properties);

                        var pieces = await _client.GetTorrentPiecesStatesAsync(_selectedTorrent.Hash);
                        torrentPieceView1.Render([.. pieces]);
                    }

                    // 仅在 Peers 标签页可见时更新对等点信息
                    if (tabControl.SelectedTab == peersTab)
                    {
                        await UpdatePeerList();
                    }
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

        private void UpdateTorrentList()
        {
            var filteredTorrents = FilterTorrents();
            _torrentListViewManager?.UpdateTorrents(filteredTorrents);
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
                "inactive" => _torrents.Where(t => t.Value.DownloadSpeed == 0 && t.Value.UploadSpeed == 0).ToDictionary(t => t.Key, t => t.Value),
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

            tabControl.Enabled = _isConnected && hasSelection;
        }

        private async void TorrentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_client == null) return;

            UpdateControlState();

            if (torrentListView.SelectedItems.Count == 1)
            {
                _selectedTorrent = torrentListView.SelectedItems[0].Tag as TorrentInfo;
                if (_selectedTorrent == null) return;
                var hash = _selectedTorrent.Hash;

                try
                {
                    // Update general properties
                    var properties = await _client.GetTorrentPropertiesAsync(hash);
                    torrentInfoView1.Render(_selectedTorrent, properties);

                    var pieces = await _client.GetTorrentPiecesStatesAsync(hash);
                    torrentPieceView1.Render([.. pieces]);

                    // Update trackers
                    var trackers = await _client.GetTorrentTrackersAsync(hash);
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
                    var files = await _client.GetTorrentContentsAsync(hash);
                    _fileListViewManager?.UpdateFileList(files);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"获取种子详情失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _selectedTorrent = null;
                trackerListView.Items.Clear();
                peerListView.Items.Clear();
                _fileListViewManager?.ClearFileList();
            }
        }

        private void StateTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateTorrentList();
        }

        private TreeNode GetOrCreateNode(TreeNodeCollection nodes, string[] path, int index = 0)
        {
            if (index >= path.Length)
                return null;

            var nodeName = path[index];
            var node = nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == nodeName);

            if (node == null)
            {
                node = new TreeNode(nodeName);
                nodes.Add(node);
            }

            if (index < path.Length - 1)
            {
                return GetOrCreateNode(node.Nodes, path, index + 1);
            }

            return node;
        }

        private static string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
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

        private async Task RefreshData()
        {
            try
            {
                _lastRid = 0;
                _torrents.Clear();
                await SyncData();
                timerSync.Start();
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

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ManageConnections(object sender, EventArgs e)
        {
            using var form = new ConnectionManager(_connections);
            SyncFromModifiedConnections(form._duplicatedConnections);
            if (form.ShowDialog() == DialogResult.OK && !_isConnected && form.SelectedConnection != null)
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

        private void LoadTorrentColumnConfig()
        {
            try
            {
                if (File.Exists(_torrentColumnsConfigPath))
                {
                    var json = File.ReadAllText(_torrentColumnsConfigPath);
                    _torrentColumnConfig = System.Text.Json.JsonSerializer.Deserialize<List<ColumnInfo>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载种子列配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTorrentColumnConfig()
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(_torrentColumnConfig, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_torrentColumnsConfigPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存种子列配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns(object sender, EventArgs e)
        {
            using var form = new ListViewColumnSelector(torrentListView, _torrentListViewManager?.GetColumnConfig());
            if (form.ShowDialog() == DialogResult.OK)
            {
                _torrentListViewManager?.SetColumnConfig(form.SelectedColumns);
                _torrentListViewManager?.SaveColumnConfig();
            }
        }

        private void torrentListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            var column = torrentListView.Columns[e.ColumnIndex];
            var columnInfo = _torrentColumnConfig.FirstOrDefault(c => c.Name == column.Name);
            if (columnInfo != null)
            {
                columnInfo.Width = column.Width;
                SaveTorrentColumnConfig();
            }
        }

        private async void timerSync_Tick(object sender, EventArgs e)
        {
            await SyncData();
        }

        private void tsConfigurePeerColumns_Click(object sender, EventArgs e)
        {
            using var form = new ListViewColumnSelector(peerListView, _peerListViewManager?.GetColumnConfig());
            if (form.ShowDialog() == DialogResult.OK)
            {
                _peerListViewManager?.SetColumnConfig(form.SelectedColumns);
                _peerListViewManager?.SaveColumnConfig();
            }
        }

        private void LoadPeerColumnConfig()
        {
            try
            {
                if (File.Exists(_peerColumnsConfigPath))
                {
                    var json = File.ReadAllText(_peerColumnsConfigPath);
                    _peerColumnConfig = System.Text.Json.JsonSerializer.Deserialize<List<ColumnInfo>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载对等点列配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePeerColumnConfig()
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(_peerColumnConfig, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_peerColumnsConfigPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存对等点列配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdatePeerList()
        {
            if (_selectedTorrent == null || _client == null) return;

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
                _peerListViewManager?.UpdatePeers(_peers.Values);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取对等节点信息失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void peerListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            var column = peerListView.Columns[e.ColumnIndex];
            var columnInfo = _peerListViewManager?.GetColumnConfig().FirstOrDefault(c => c.Name == column.Name);
            if (columnInfo != null)
            {
                columnInfo.Width = column.Width;
                _peerListViewManager?.SaveColumnConfig();
            }
        }
    }
}
