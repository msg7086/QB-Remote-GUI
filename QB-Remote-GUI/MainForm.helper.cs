using QB.Remote.API.Models.Torrents;
using QB_Remote_GUI.Forms;
using QB_Remote_GUI.Models;

namespace QB_Remote_GUI
{
    static class MainFormHelper
    {
        internal static void InitTorrentListView(this MainForm form)
        {
            var torrentListView = form.torrentListView;
            var lang = LanguageLoader.Instance;
            torrentListView.View = View.Details;
            torrentListView.FullRowSelect = true;
            torrentListView.MultiSelect = true;
            torrentListView.GridLines = true;

            // Define default columns if no configuration exists
            if (form._torrentColumnConfig == null)
            {
                form._torrentColumnConfig = new List<ColumnInfo>
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

            form.ApplyTorrentColumnConfig();
        }

        internal static void ApplyTorrentColumnConfig(this MainForm form)
        {
            if (form._torrentColumnConfig == null) return;

            form.torrentListView.BeginUpdate();
            try
            {
                form.torrentListView.Columns.Clear();
                form.torrentListView.Items.Clear();
                foreach (var column in form._torrentColumnConfig.Where(c => c.IsVisible))
                {
                    var header = new ColumnHeader
                    {
                        Name = column.Name,
                        Text = column.Text,
                        Width = column.Width
                    };
                    form.torrentListView.Columns.Add(header);
                }
            }
            finally
            {
                form.torrentListView.EndUpdate();
            }
        }

        public static void UpdateTorrentsToListView(Dictionary<string, TorrentInfo> filteredTorrents, ListView torrentListView, ImageList imgTorrent)
        {
            var selectedHashes = GetSelectedTorrentHashes(torrentListView);
            torrentListView.BeginUpdate();

            try
            {
                var existingItems = torrentListView.Items.Cast<ListViewItem>().ToDictionary(item => (item.Tag as TorrentInfo)?.Hash ?? "", item => item);

                // Update or add items
                foreach (var (hash, torrent) in filteredTorrents)
                {
                    if (existingItems.TryGetValue(hash, out var item))
                    {
                        // Update existing item
                        UpdateListViewItem(item, torrent, torrentListView.Columns);
                        existingItems.Remove(hash);
                    }
                    else
                    {
                        // Create new item
                        item = CreateListViewItem(hash, torrent, torrentListView.Columns);
                        torrentListView.Items.Add(item);
                    }
                    item.Selected = selectedHashes.Contains(item.Name);
                }

                // Remove old items
                foreach (var item in existingItems.Values)
                {
                    torrentListView.Items.Remove(item);
                }
            }
            finally
            {
                torrentListView.EndUpdate();
            }
        }

        private static void UpdateListViewItem(ListViewItem item, TorrentInfo torrent, ListView.ColumnHeaderCollection columns)
        {
            item.ImageKey = GetImageNameFromState(torrent.State);

            for (int i = 0; i < columns.Count; i++)
            {
                string text = GetColumnText(columns[i].Name, torrent);
                item.SubItems[i].Text = text;
            }
        }

        private static ListViewItem CreateListViewItem(string hash, TorrentInfo torrent, ListView.ColumnHeaderCollection columns)
        {
            var item = new ListViewItem(hash)
            {
                Name = hash,
                Text = GetColumnText(columns[0].Name, torrent),
                ImageKey = GetImageNameFromState(torrent.State),
                Tag = torrent
            };

            // Add subitems based on visible columns
            foreach (ColumnHeader column in columns.Cast<ColumnHeader>().Skip(1))
            {
                string text = GetColumnText(column.Name, torrent);
                item.SubItems.Add(text);
            }

            return item;
        }

        private static string GetColumnText(string columnName, TorrentInfo torrent)
        {
            return columnName switch
            {
                "nameColumn" => torrent.Name ?? "?",
                "sizeColumn" => FormatSize(torrent.TotalSize),
                "sizeDownloadColumn" => FormatSize(torrent.Size),
                "progressColumn" => $"{torrent.Progress:P1}",
                "downloadedColumn" => FormatSize(torrent.Downloaded),
                "uploadedColumn" => FormatSize(torrent.Uploaded),
                "statusColumn" => torrent.State ?? "Unknown",
                "seedsColumn" => $"{torrent.ConnectedSeeds}/{torrent.TotalSeeds}",
                "peersColumn" => $"{torrent.ConnectedPeers}/{torrent.TotalPeers}",
                "downloadSpeedColumn" => FormatSpeed(torrent.DownloadSpeed),
                "uploadSpeedColumn" => FormatSpeed(torrent.UploadSpeed),
                "etaColumn" => torrent.ETA == 8640000 ? "∞" : FormatReadableTime(torrent.ETA),
                "ratioColumn" => $"{torrent.Ratio:F2}",
                "addedOnColumn" => FormatDateTime(torrent.AddedOn),
                "completedOnColumn" => FormatDateTime(torrent.CompletionOn),
                "lastActiveColumn" => FormatDateTime(torrent.LastActive),
                "pathColumn" => torrent.DownloadPath ?? "?",
                "priorityColumn" => $"{torrent.Priority}",
                "seedingTimeColumn" => FormatReadableTime(torrent.SeedingTime),
                "sizeLeftColumn" => FormatSize(torrent.AmountLeft),
                "isPrivateColumn" => torrent.Private.GetValueOrDefault(false) ? "Yes" : "No",
                "labelColumn" => torrent.Tags ?? "?",
                _ => "?"
            };
        }

        private static IEnumerable<string> GetSelectedTorrentHashes(ListView torrentListView)
        {
            return torrentListView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => item.Name)
                .ToList();
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

        private static string FormatSize(long? bytes)
        {
            if (bytes.HasValue)
                return FormatSize(bytes.Value);
            return "N/A";
        }

        private static string FormatSpeed(long bytesPerSecond)
        {
            if (bytesPerSecond == 0)
                return "";
            return $"{FormatSize(bytesPerSecond)}/s";
        }

        private static string FormatSpeed(long? bytesPerSecond)
        {
            if (bytesPerSecond.HasValue)
                return FormatSpeed(bytesPerSecond.Value);
            return "N/A";
        }

        private static string FormatTime(long? seconds)
        {
            if (seconds.HasValue)
                return TimeSpan.FromSeconds(seconds.Value).ToString(@"hh\:mm\:ss");
            return "N/A";
        }

        private static string FormatReadableTime(long? seconds)
        {
            if (!seconds.HasValue)
                return "N/A";
            if (seconds.Value < 60)
                return $"{seconds.Value}s";
            if (seconds.Value < 3600)
                return $"{seconds.Value / 60}m";
            if (seconds.Value < 86400)
                return $"{seconds.Value / 3600}h, {seconds.Value % 3600 / 60}m";
            return $"{seconds.Value / 86400}d, {seconds.Value % 86400 / 3600}h";
        }

        private static string FormatDateTime(long? unixTimestamp)
        {
            if (unixTimestamp.HasValue)
                return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp.Value).LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return "N/A";
        }

        private static string GetImageNameFromState(string? state)
        {
            switch(state)
            {
                case "stoppedDL":
                case "pausedDL":
                    return "tr_t_pause";
                case "queuedUP":
                    return "tr_t_upqueue";
                case "queuedDL":
                    return "tr_t_downqueue";
                case "stalledUP":
                case "uploading":
                case "forcedUP":
                    return "tr_t_up";
                case "stoppedUP":
                case "pausedUP":
                    return "tr_t_done";
                case "downloading":
                case "forcedDL":
                case "stalledDL":
                case "metaDL":
                    return "tr_t_down";
                case "allocating":
                case "checkingUP":
                case "checkingDL":
                case "checkingResumeData":
                case "moving":
                    return "tr_t_busy";
                default:
                    return "tr_t_error";
            }
        }

        internal static void InitPeerListView(this MainForm form)
        {
            var peerListView = form.peerListView;
            var lang = LanguageLoader.Instance;
            peerListView.View = View.Details;
            peerListView.FullRowSelect = true;
            peerListView.MultiSelect = true;
            peerListView.GridLines = true;

            // Define default columns if no configuration exists
            if (form._peerColumnConfig == null)
            {
                form._peerColumnConfig = new List<ColumnInfo>
                {
                    new ColumnInfo { Name = "ipColumn", Text = "IP", Width = 150, IsVisible = true },
                    new ColumnInfo { Name = "portColumn", Text = lang.GetTranslation("Port"), Width = 80, IsVisible = true },
                    new ColumnInfo { Name = "clientColumn", Text = lang.GetTranslation("Client"), Width = 150, IsVisible = true },
                    new ColumnInfo { Name = "flagsColumn", Text = lang.GetTranslation("Flags"), Width = 200, IsVisible = true },
                    new ColumnInfo { Name = "countryColumn", Text = lang.GetTranslation("Country"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "connectionColumn", Text = lang.GetTranslation("Connection"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "progressColumn", Text = lang.GetTranslation("Progress"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "downloadSpeedColumn", Text = lang.GetTranslation("Download speed"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "uploadSpeedColumn", Text = lang.GetTranslation("Upload speed"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "downloadedColumn", Text = lang.GetTranslation("Downloaded"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "uploadedColumn", Text = lang.GetTranslation("Uploaded"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "relevanceColumn", Text = lang.GetTranslation("Relevance"), Width = 100, IsVisible = true },
                    new ColumnInfo { Name = "filesColumn", Text = lang.GetTranslation("Files"), Width = 100, IsVisible = true },
                };
            }

            form.ApplyPeerColumnConfig();
        }

        internal static void ApplyPeerColumnConfig(this MainForm form)
        {
            if (form._peerColumnConfig == null) return;

            form.peerListView.BeginUpdate();
            try
            {
                form.peerListView.Columns.Clear();
                form.peerListView.Items.Clear();
                foreach (var column in form._peerColumnConfig.Where(c => c.IsVisible))
                {
                    var header = new ColumnHeader
                    {
                        Name = column.Name,
                        Text = column.Text,
                        Width = column.Width
                    };
                    form.peerListView.Columns.Add(header);
                }
            }
            finally
            {
                form.peerListView.EndUpdate();
            }
        }

        public static void UpdatePeersToListView(IEnumerable<PeerInfo> peers, ListView peerListView)
        {
            peerListView.BeginUpdate();
            try
            {
                var existingItems = peerListView.Items.Cast<ListViewItem>()
                    .ToDictionary(item => $"{item.SubItems[0].Text}:{item.SubItems[7].Text}", item => item);

                // Update or add items
                foreach (var peer in peers)
                {
                    var key = $"{peer.Ip}:{peer.Port}";
                    if (existingItems.TryGetValue(key, out var item))
                    {
                        // Update existing item
                        UpdatePeerListViewItem(item, peer, peerListView.Columns);
                        existingItems.Remove(key);
                    }
                    else
                    {
                        // Create new item
                        item = CreatePeerListViewItem(peer, peerListView.Columns);
                        peerListView.Items.Add(item);
                    }
                }

                // Remove old items
                foreach (var item in existingItems.Values)
                {
                    peerListView.Items.Remove(item);
                }
            }
            finally
            {
                peerListView.EndUpdate();
            }
        }

        private static ListViewItem CreatePeerListViewItem(PeerInfo peer, ListView.ColumnHeaderCollection columns)
        {
            var item = new ListViewItem
            {
                Text = GetPeerColumnText(columns[0].Name, peer),
                Tag = peer
            };

            // Add subitems based on visible columns
            foreach (ColumnHeader column in columns.Cast<ColumnHeader>().Skip(1))
            {
                string text = GetPeerColumnText(column.Name, peer);
                item.SubItems.Add(text);
            }

            return item;
        }

        private static void UpdatePeerListViewItem(ListViewItem item, PeerInfo peer, ListView.ColumnHeaderCollection columns)
        {
            item.Tag = peer;
            for (int i = 0; i < columns.Count; i++)
            {
                string text = GetPeerColumnText(columns[i].Name, peer);
                if (i == 0)
                    item.Text = text;
                else
                    item.SubItems[i].Text = text;
            }
        }

        private static string GetPeerColumnText(string columnName, PeerInfo peer)
        {
            return columnName switch
            {
                "ipColumn" => peer.Ip ?? "?",
                "clientColumn" => peer.Client ?? "?",
                "flagsColumn" => $"{peer.Flags} ({peer.FlagsDescription})",
                "progressColumn" => $"{peer.Progress:P1}",
                "downloadSpeedColumn" => FormatSpeed(peer.DownloadSpeed),
                "uploadSpeedColumn" => FormatSpeed(peer.UploadSpeed),
                "connectionColumn" => peer.Connection ?? "?",
                "portColumn" => peer.Port?.ToString() ?? "?",
                "relevanceColumn" => peer.Relevance?.ToString("F2") ?? "?",
                "filesColumn" => peer.Files ?? "?",
                "countryColumn" => peer.Country ?? "?",
                "downloadedColumn" => FormatSize(peer.Downloaded),
                "uploadedColumn" => FormatSize(peer.Uploaded),
                _ => "?"
            };
        }
    }
}
