using System.Windows.Forms;
using QB.Remote.API.Models.Torrents;
using QB_Remote_GUI.Forms;
using QB_Remote_GUI.Models;
using QB_Remote_GUI.Utils;

namespace QB_Remote_GUI.Views
{
    public class TorrentListViewManager
    {
        private readonly ListView _torrentListView;
        private readonly ImageList _imgTorrent;
        private List<ColumnInfo> _columnConfig;
        private readonly string _configPath = "torrent_columns.json";

        public TorrentListViewManager(ListView torrentListView, ImageList imgTorrent)
        {
            _torrentListView = torrentListView;
            _imgTorrent = imgTorrent;
            InitializeListView();
        }

        private void InitializeListView()
        {
            _torrentListView.View = View.Details;
            _torrentListView.FullRowSelect = true;
            _torrentListView.MultiSelect = true;
            _torrentListView.GridLines = true;

            LoadOrInitializeColumnConfig();
            ApplyColumnConfig();
        }

        private void LoadOrInitializeColumnConfig()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    var json = File.ReadAllText(_configPath);
                    _columnConfig = System.Text.Json.JsonSerializer.Deserialize<List<ColumnInfo>>(json);
                }
                else
                {
                    InitializeDefaultColumnConfig();
                }
            }
            catch
            {
                InitializeDefaultColumnConfig();
            }
        }

        private void InitializeDefaultColumnConfig()
        {
            var lang = LanguageLoader.Instance;
            _columnConfig = new List<ColumnInfo>
            {
                new ColumnInfo { Name = "nameColumn", Text = lang.GetTranslation("Name"), Width = 500, IsVisible = true },
                new ColumnInfo { Name = "sizeDownloadColumn", Text = lang.GetTranslation("Size to download"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "sizeColumn", Text = lang.GetTranslation("Size"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "progressColumn", Text = lang.GetTranslation("Done"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "downloadedColumn", Text = lang.GetTranslation("Downloaded"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "uploadedColumn", Text = lang.GetTranslation("Uploaded"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "statusColumn", Text = lang.GetTranslation("Status"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "seedsColumn", Text = lang.GetTranslation("Seeds"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "peersColumn", Text = lang.GetTranslation("Peers"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "downloadSpeedColumn", Text = lang.GetTranslation("Download speed"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "uploadSpeedColumn", Text = lang.GetTranslation("Upload speed"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "etaColumn", Text = lang.GetTranslation("ETA"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "ratioColumn", Text = lang.GetTranslation("Ratio"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "addedOnColumn", Text = lang.GetTranslation("Added on"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "completedOnColumn", Text = lang.GetTranslation("Completed on"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "lastActiveColumn", Text = lang.GetTranslation("Last active"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "pathColumn", Text = lang.GetTranslation("Last active"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "priorityColumn", Text = lang.GetTranslation("Priority"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "seedingTimeColumn", Text = lang.GetTranslation("Seeding time"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "sizeLeftColumn", Text = lang.GetTranslation("Size left"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "isPrivateColumn", Text = lang.GetTranslation("Private"), Width = 100, IsVisible = true },
                new ColumnInfo { Name = "labelColumn", Text = lang.GetTranslation("Label"), Width = 100, IsVisible = true },
            };
        }

        public void ApplyColumnConfig()
        {
            if (_columnConfig == null) return;

            _torrentListView.BeginUpdate();
            try
            {
                _torrentListView.Columns.Clear();
                _torrentListView.Items.Clear();
                foreach (var column in _columnConfig.Where(c => c.IsVisible))
                {
                    var header = new ColumnHeader
                    {
                        Name = column.Name,
                        Text = column.Text,
                        Width = column.Width
                    };
                    _torrentListView.Columns.Add(header);
                }
            }
            finally
            {
                _torrentListView.EndUpdate();
            }
        }

        public void UpdateTorrents(Dictionary<string, TorrentInfo> filteredTorrents)
        {
            var selectedHashes = GetSelectedTorrentHashes();
            _torrentListView.BeginUpdate();

            try
            {
                var existingItems = _torrentListView.Items.Cast<ListViewItem>()
                    .ToDictionary(item => (item.Tag as TorrentInfo)?.Hash ?? "", item => item);

                foreach (var (hash, torrent) in filteredTorrents)
                {
                    if (existingItems.TryGetValue(hash, out var item))
                    {
                        UpdateListViewItem(item, torrent);
                        existingItems.Remove(hash);
                    }
                    else
                    {
                        item = CreateListViewItem(hash, torrent);
                        _torrentListView.Items.Add(item);
                    }
                    item.Selected = selectedHashes.Contains(item.Name);
                }

                foreach (var item in existingItems.Values)
                {
                    _torrentListView.Items.Remove(item);
                }
            }
            finally
            {
                _torrentListView.EndUpdate();
            }
        }

        private void UpdateListViewItem(ListViewItem item, TorrentInfo torrent)
        {
            item.ImageKey = GetImageNameFromState(torrent.State);

            for (int i = 0; i < _torrentListView.Columns.Count; i++)
            {
                string text = GetColumnText(_torrentListView.Columns[i].Name, torrent);
                item.SubItems[i].Text = text;
            }
        }

        private ListViewItem CreateListViewItem(string hash, TorrentInfo torrent)
        {
            var item = new ListViewItem(hash)
            {
                Name = hash,
                Text = GetColumnText(_torrentListView.Columns[0].Name, torrent),
                ImageKey = GetImageNameFromState(torrent.State),
                Tag = torrent
            };

            foreach (ColumnHeader column in _torrentListView.Columns.Cast<ColumnHeader>().Skip(1))
            {
                string text = GetColumnText(column.Name, torrent);
                item.SubItems.Add(text);
            }

            return item;
        }

        private string GetColumnText(string columnName, TorrentInfo torrent)
        {
            return columnName switch
            {
                "nameColumn" => torrent.Name ?? "?",
                "sizeColumn" => FormattingUtils.FormatSize(torrent.TotalSize),
                "sizeDownloadColumn" => FormattingUtils.FormatSize(torrent.Size),
                "progressColumn" => $"{torrent.Progress:P1}",
                "downloadedColumn" => FormattingUtils.FormatSize(torrent.Downloaded),
                "uploadedColumn" => FormattingUtils.FormatSize(torrent.Uploaded),
                "statusColumn" => torrent.State ?? "Unknown",
                "seedsColumn" => $"{torrent.ConnectedSeeds}/{torrent.TotalSeeds}",
                "peersColumn" => $"{torrent.ConnectedPeers}/{torrent.TotalPeers}",
                "downloadSpeedColumn" => FormattingUtils.FormatSpeed(torrent.DownloadSpeed),
                "uploadSpeedColumn" => FormattingUtils.FormatSpeed(torrent.UploadSpeed),
                "etaColumn" => torrent.ETA == 8640000 ? "∞" : FormattingUtils.FormatReadableTime(torrent.ETA),
                "ratioColumn" => $"{torrent.Ratio:F2}",
                "addedOnColumn" => FormattingUtils.FormatDateTime(torrent.AddedOn),
                "completedOnColumn" => FormattingUtils.FormatDateTime(torrent.CompletionOn),
                "lastActiveColumn" => FormattingUtils.FormatDateTime(torrent.LastActive),
                "pathColumn" => torrent.DownloadPath ?? "?",
                "priorityColumn" => $"{torrent.Priority}",
                "seedingTimeColumn" => FormattingUtils.FormatReadableTime(torrent.SeedingTime),
                "sizeLeftColumn" => FormattingUtils.FormatSize(torrent.AmountLeft),
                "isPrivateColumn" => torrent.Private.GetValueOrDefault(false) ? "Yes" : "No",
                "labelColumn" => torrent.Tags ?? "?",
                _ => "?"
            };
        }

        private IEnumerable<string> GetSelectedTorrentHashes()
        {
            return _torrentListView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => item.Name)
                .ToList();
        }

        private string GetImageNameFromState(string? state)
        {
            return state switch
            {
                "stoppedDL" or "pausedDL" => "tr_t_pause",
                "queuedUP" => "tr_t_upqueue",
                "queuedDL" => "tr_t_downqueue",
                "stalledUP" or "uploading" or "forcedUP" => "tr_t_up",
                "stoppedUP" or "pausedUP" => "tr_t_done",
                "downloading" or "forcedDL" or "stalledDL" or "metaDL" => "tr_t_down",
                "allocating" or "checkingUP" or "checkingDL" or "checkingResumeData" or "moving" => "tr_t_busy",
                _ => "tr_t_error"
            };
        }

        public void SaveColumnConfig()
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(_columnConfig);
                File.WriteAllText(_configPath, json);
            }
            catch
            {
                // Log error if needed
            }
        }

        public List<ColumnInfo> GetColumnConfig()
        {
            return _columnConfig;
        }

        public void SetColumnConfig(List<ColumnInfo> config)
        {
            // Save current data before applying new config
            var selectedHashes = GetSelectedTorrentHashes();
            var torrents = _torrentListView.Items.Cast<ListViewItem>()
                .ToDictionary(item => item.Name, item => item.Tag as TorrentInfo)
                .Where(kvp => kvp.Value != null)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            _columnConfig = config;
            ApplyColumnConfig();

            // Re-render data if we have any
            if (torrents.Count > 0)
            {
                UpdateTorrents(torrents);
                
                // Restore selection
                foreach (var hash in selectedHashes)
                {
                    var item = _torrentListView.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Name == hash);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
} 
