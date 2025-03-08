using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Forms;
using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI.Views;

public class TorrentListViewManager
{
    private readonly LanguageLoader _lang;
    private readonly ListView _torrentListView;
    private List<ColumnInfo> _columnConfig = null!;
    private const string ConfigPath = "torrent_columns.json";

    public TorrentListViewManager(ListView torrentListView)
    {
        _torrentListView = torrentListView;
        _lang = LanguageLoader.Instance;
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

        _torrentListView.ColumnWidthChanged += TorrentListView_ColumnWidthChanged;
    }

    private void LoadOrInitializeColumnConfig()
    {
        InitializeDefaultColumnConfig();
        try
        {
            if (!File.Exists(ConfigPath)) return;

            var json = File.ReadAllText(ConfigPath);
            var storedConfig = System.Text.Json.JsonSerializer.Deserialize<List<ColumnInfo>>(json);
            if (storedConfig == null) return;

            // Merge stored config with default config
            _columnConfig = ColumnConfigMerger.MergeColumnConfigs(_columnConfig, storedConfig);
        }
        catch
        {
            InitializeDefaultColumnConfig();
        }
    }

    private void InitializeDefaultColumnConfig()
    {
        _columnConfig =
        [
            new ColumnInfo { Name = "nameColumn", Text = _lang.GetTranslation("Name"), Width = 500, IsVisible = true },
            new ColumnInfo { Name = "sizeDownloadColumn", Text = _lang.GetTranslation("Size to download"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "sizeColumn", Text = _lang.GetTranslation("Size"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "progressColumn", Text = _lang.GetTranslation("Done"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "downloadedColumn", Text = _lang.GetTranslation("Downloaded"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "uploadedColumn", Text = _lang.GetTranslation("Uploaded"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "statusColumn", Text = _lang.GetTranslation("Status"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "seedsColumn", Text = _lang.GetTranslation("Seeds"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "peersColumn", Text = _lang.GetTranslation("Peers"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "downloadSpeedColumn", Text = _lang.GetTranslation("Download speed"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "uploadSpeedColumn", Text = _lang.GetTranslation("Upload speed"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "etaColumn", Text = _lang.GetTranslation("ETA"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "ratioColumn", Text = _lang.GetTranslation("Ratio"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "addedOnColumn", Text = _lang.GetTranslation("Added on"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "completedOnColumn", Text = _lang.GetTranslation("Completed on"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "lastActiveColumn", Text = _lang.GetTranslation("Last active"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "pathColumn", Text = _lang.GetTranslation("Last active"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "priorityColumn", Text = _lang.GetTranslation("Priority"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "seedingTimeColumn", Text = _lang.GetTranslation("Seeding time"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "sizeLeftColumn", Text = _lang.GetTranslation("Size left"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "isPrivateColumn", Text = _lang.GetTranslation("Private"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "labelColumn", Text = _lang.GetTranslation("Label"), Width = 100, IsVisible = true }
        ];
    }

    private void ApplyColumnConfig()
    {
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

        for (var i = 0; i < _torrentListView.Columns.Count; i++)
        {
            var text = GetColumnText(_torrentListView.Columns[i].Name, torrent);
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

        foreach (var column in _torrentListView.Columns.Cast<ColumnHeader>().Skip(1))
        {
            var text = GetColumnText(column.Name, torrent);
            item.SubItems.Add(text);
        }

        return item;
    }

    private string GetColumnText(string? columnName, TorrentInfo torrent)
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
            "etaColumn" => torrent.Eta == 8640000 ? "∞" : FormattingUtils.FormatReadableTime(torrent.Eta),
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

    private HashSet<string> GetSelectedTorrentHashes()
    {
        return _torrentListView.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => item.Name)
            .ToHashSet();
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
            File.WriteAllText(ConfigPath, json);
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
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value!);

        _columnConfig = config;
        ApplyColumnConfig();

        // Re-render data if we have any
        if (torrents.Count > 0)
        {
            UpdateTorrents(torrents);
                
            // Restore selection
            foreach (var item in selectedHashes.Select(hash => _torrentListView.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Name == hash)).OfType<ListViewItem>())
            {
                item.Selected = true;
            }
        }
    }

    private void TorrentListView_ColumnWidthChanged(object? sender, ColumnWidthChangedEventArgs e)
    {
        var column = _torrentListView.Columns[e.ColumnIndex];
        var columnInfo = _columnConfig.FirstOrDefault(c => c.Name == column.Name);
        if (columnInfo == null) return;
        columnInfo.Width = column.Width;
        SaveColumnConfig();
    }
}
