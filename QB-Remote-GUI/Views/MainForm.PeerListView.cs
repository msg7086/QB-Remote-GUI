using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Forms;
using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI.Views;

public class PeerListViewManager
{
    private readonly ListView _peerListView;
    private List<ColumnInfo> _columnConfig = null!;
    private const string ConfigPath = "peer_columns.json";

    public PeerListViewManager(ListView peerListView)
    {
        _peerListView = peerListView;
        InitializeListView();
    }

    private void InitializeListView()
    {
        _peerListView.View = View.Details;
        _peerListView.FullRowSelect = true;
        _peerListView.MultiSelect = true;
        _peerListView.GridLines = true;

        LoadOrInitializeColumnConfig();
        ApplyColumnConfig();

        _peerListView.ColumnWidthChanged += PeerListView_ColumnWidthChanged;
    }

    private void LoadOrInitializeColumnConfig()
    {
        try
        {
            if (!File.Exists(ConfigPath))
            {
                InitializeDefaultColumnConfig();
                return;
            }

            var json = File.ReadAllText(ConfigPath);
            var storedConfig = System.Text.Json.JsonSerializer.Deserialize<List<ColumnInfo>>(json);
            if (storedConfig == null)
            {
                InitializeDefaultColumnConfig();
                return;
            }

            _columnConfig = storedConfig;
        }
        catch
        {
            InitializeDefaultColumnConfig();
        }
    }

    private void InitializeDefaultColumnConfig()
    {
        var lang = LanguageLoader.Instance;
        _columnConfig =
        [
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
            new ColumnInfo { Name = "filesColumn", Text = lang.GetTranslation("Files"), Width = 100, IsVisible = true }
        ];
    }

    private void ApplyColumnConfig()
    {
        _peerListView.BeginUpdate();
        try
        {
            _peerListView.Columns.Clear();
            _peerListView.Items.Clear();
            foreach (var column in _columnConfig.Where(c => c.IsVisible))
            {
                var header = new ColumnHeader
                {
                    Name = column.Name,
                    Text = column.Text,
                    Width = column.Width
                };
                _peerListView.Columns.Add(header);
            }
        }
        finally
        {
            _peerListView.EndUpdate();
        }
    }

    public void UpdatePeers(IEnumerable<PeerInfo> peers)
    {
        _peerListView.BeginUpdate();
        try
        {
            var existingItems = _peerListView.Items.Cast<ListViewItem>()
                .ToDictionary(item => $"{item.SubItems[0].Text}:{item.SubItems[7].Text}", item => item);

            foreach (var peer in peers)
            {
                var key = $"{peer.Ip}:{peer.Port}";
                if (existingItems.TryGetValue(key, out var item))
                {
                    UpdateListViewItem(item, peer);
                    existingItems.Remove(key);
                }
                else
                {
                    item = CreateListViewItem(peer);
                    _peerListView.Items.Add(item);
                }
            }

            foreach (var item in existingItems.Values)
            {
                _peerListView.Items.Remove(item);
            }
        }
        finally
        {
            _peerListView.EndUpdate();
        }
    }

    private ListViewItem CreateListViewItem(PeerInfo peer)
    {
        var item = new ListViewItem
        {
            Text = GetColumnText(_peerListView.Columns[0].Name, peer),
            Tag = peer
        };

        foreach (ColumnHeader column in _peerListView.Columns.Cast<ColumnHeader>().Skip(1))
        {
            string text = GetColumnText(column.Name, peer);
            item.SubItems.Add(text);
        }

        return item;
    }

    private void UpdateListViewItem(ListViewItem item, PeerInfo peer)
    {
        item.Tag = peer;
        for (int i = 0; i < _peerListView.Columns.Count; i++)
        {
            string text = GetColumnText(_peerListView.Columns[i].Name, peer);
            if (i == 0)
                item.Text = text;
            else
                item.SubItems[i].Text = text;
        }
    }

    private string GetColumnText(string? columnName, PeerInfo peer)
    {
        return columnName switch
        {
            "ipColumn" => peer.Ip ?? "?",
            "clientColumn" => peer.Client ?? "?",
            "flagsColumn" => $"{peer.Flags} ({peer.FlagsDescription})",
            "progressColumn" => $"{peer.Progress:P1}",
            "downloadSpeedColumn" => FormattingUtils.FormatSpeed(peer.DownloadSpeed),
            "uploadSpeedColumn" => FormattingUtils.FormatSpeed(peer.UploadSpeed),
            "connectionColumn" => peer.Connection ?? "?",
            "portColumn" => peer.Port?.ToString() ?? "?",
            "relevanceColumn" => peer.Relevance?.ToString("F2") ?? "?",
            "filesColumn" => peer.Files ?? "?",
            "countryColumn" => peer.Country ?? "?",
            "downloadedColumn" => FormattingUtils.FormatSize(peer.Downloaded),
            "uploadedColumn" => FormattingUtils.FormatSize(peer.Uploaded),
            _ => "?"
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
        var peers = _peerListView.Items.Cast<ListViewItem>()
            .Select(item => item.Tag as PeerInfo)
            .Where(p => p != null)
            .Select(p => p!)
            .ToList();

        _columnConfig = config;
        ApplyColumnConfig();

        // Re-render data if we have any
        if (peers.Count > 0)
        {
            UpdatePeers(peers);
        }
    }

    private void PeerListView_ColumnWidthChanged(object? sender, ColumnWidthChangedEventArgs e)
    {
        var column = _peerListView.Columns[e.ColumnIndex];
        var columnInfo = _columnConfig.FirstOrDefault(c => c.Name == column.Name);
        if (columnInfo != null)
        {
            columnInfo.Width = column.Width;
            SaveColumnConfig();
        }
    }
}