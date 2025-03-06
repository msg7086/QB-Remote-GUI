using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Forms;
using QB_Remote_GUI.GUI.Models;
using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI.Views;

public class FileListViewManager
{
    private readonly ListView _fileListView;
    private List<TorrentFileTree>? _fileTree;
    private const int IndentWidth = 20;
    private const int ArrowWidth = 20;
    private readonly ImageList _imgFiles;
    private readonly bool _isSimpleMode;
    private List<ColumnInfo> _columnConfig = null!;
    private const string ConfigPath = "file_columns.json";
    private string _currentHash = string.Empty;
    private string _lastHash = string.Empty;

    public FileListViewManager(ListView fileListView, ImageList imgFiles, bool isSimpleMode = false)
    {
        _fileListView = fileListView;
        _imgFiles = imgFiles;
        _isSimpleMode = isSimpleMode;
        InitializeListView();
    }

    private void InitializeListView()
    {
        _fileListView.View = View.Details;
        _fileListView.FullRowSelect = true;
        _fileListView.MultiSelect = true;
        _fileListView.GridLines = true;
        _fileListView.CheckBoxes = false;
        _fileListView.OwnerDraw = true;
        _fileListView.SmallImageList = _imgFiles;

        if (_isSimpleMode)
        {
            InitializeSimpleModeColumns();
        }
        else
        {
            LoadOrInitializeColumnConfig();
            ApplyColumnConfig();
        }

        _fileListView.DrawColumnHeader += FileListView_DrawColumnHeader;
        _fileListView.DrawSubItem += FileListView_DrawSubItem;
        _fileListView.MouseClick += FileListView_MouseClick;
        _fileListView.ColumnWidthChanged += FileListView_ColumnWidthChanged;
    }

    private void InitializeSimpleModeColumns()
    {
        _fileListView.Columns.Clear();
        _fileListView.Columns.Add("Name", 300);
        _fileListView.Columns.Add("Size", 100);
        _fileListView.Columns.Add("Priority", 80);
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
            new ColumnInfo { Name = "nameColumn", Text = lang.GetTranslation("Name"), Width = 300, IsVisible = true },
            new ColumnInfo { Name = "sizeColumn", Text = lang.GetTranslation("Size"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "progressColumn", Text = lang.GetTranslation("Progress"), Width = 100, IsVisible = true },
            new ColumnInfo { Name = "priorityColumn", Text = lang.GetTranslation("Priority"), Width = 80, IsVisible = true },
            new ColumnInfo { Name = "availabilityColumn", Text = lang.GetTranslation("Availability"), Width = 100, IsVisible = true }
        ];
    }

    private void ApplyColumnConfig()
    {
        if (_isSimpleMode) return;

        _fileListView.BeginUpdate();
        try
        {
            _fileListView.Columns.Clear();
            _fileListView.Items.Clear();

            // Find and add name column first
            var nameColumn = _columnConfig.FirstOrDefault(c => c.Name == "nameColumn");
            if (nameColumn != null)
            {
                var header = new ColumnHeader
                {
                    Name = nameColumn.Name,
                    Text = nameColumn.Text,
                    Width = nameColumn.Width
                };
                _fileListView.Columns.Add(header);
            }

            // Add other columns based on config
            foreach (var column in _columnConfig.Where(c => c.IsVisible && c.Name != "nameColumn"))
            {
                var header = new ColumnHeader
                {
                    Name = column.Name,
                    Text = column.Text,
                    Width = column.Width
                };
                _fileListView.Columns.Add(header);
            }
        }
        finally
        {
            _fileListView.EndUpdate();
        }
    }

    private void FileListView_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }

    private void FileListView_DrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
    {
        // check column index
        if (e.ColumnIndex != 0 && _fileListView.Columns[e.ColumnIndex].Name != "progressColumn")
        {
            e.DrawDefault = true;
            return;
        }

        var item = e.Item;

        if (item?.Tag is not TorrentFileTree fileTree) return;

        // Draw background with selection state
        e.Graphics.FillRectangle(item.Selected ? SystemBrushes.Highlight : SystemBrushes.Window, e.Bounds);

        // Draw grid lines
        using (var pen = new Pen(Color.FromArgb(240, 240, 240)))
        {
            e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        if (e.ColumnIndex == 0)
        {
            var x = e.Bounds.X;
            var y = e.Bounds.Y + (e.Bounds.Height - 16) / 2;

            // Draw indent
            x += fileTree.IndentCount * IndentWidth;

            // Draw arrow if it has children
            if (fileTree.Children.Count > 0)
            {
                var arrowIndex = fileTree.IsExpanded ? 2 : 1; // 2 for down arrow, 1 for right arrow
                e.Graphics.DrawImage(_imgFiles.Images[arrowIndex], x, y);
                x += ArrowWidth;
            }

            // Draw folder icon if it's a directory
            if (fileTree.Children.Count > 0)
            {
                e.Graphics.DrawImage(_imgFiles.Images[0], x, y);
                x += 16;
            }

            // Draw text with clipping
            var textRect = e.Bounds with { X = x, Width = e.Bounds.Width - x };
            var format = new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(fileTree.BaseName, _fileListView.Font, 
                item.Selected ? SystemBrushes.HighlightText : Brushes.Black, 
                textRect, format);
        }
        else if (_fileListView.Columns[e.ColumnIndex].Name == "progressColumn")
        {
            // Draw progress bar
            // fileTree.Progress is a double between 0 and 1
            var progress = fileTree.Progress; // Convert from percentage to decimal
            var progressPercent = progress * 100;
            var progressText = $"{progressPercent:F1}%";
            
            // Calculate progress bar dimensions
            var barWidth = e.Bounds.Width - 8; // Leave 4px padding on each side
            var barHeight = e.Bounds.Height - 4; // Leave 2px padding on top and bottom
            var progressWidth = (int)(barWidth * progress);
            
            // Draw progress bar background
            var bgRect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, barWidth, barHeight);
            using (var brush = new SolidBrush(Color.FromArgb(240, 240, 240)))
            {
                e.Graphics.FillRectangle(brush, bgRect);
            }

            // Draw progress bar fill
            if (progress > 0)
            {
                var progressRect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, progressWidth, barHeight);
                using var brush = new SolidBrush(Color.SkyBlue);
                e.Graphics.FillRectangle(brush, progressRect);
            }

            // Draw progress text
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(progressText, _fileListView.Font, Brushes.Black, e.Bounds, format);
        }
        else
        {
            e.DrawDefault = true;
        }
    }

    private void FileListView_MouseClick(object? sender, MouseEventArgs e)
    {
        var hit = _fileListView.HitTest(e.Location);
        if (hit.Item == null) return;

        var fileTree = hit.Item.Tag as TorrentFileTree;
        if (fileTree == null) return;

        var x = hit.Item.Bounds.X + fileTree.IndentCount * IndentWidth;

        // Check if clicked on arrow
        if (e.X >= x && e.X < x + ArrowWidth && fileTree.Children.Count > 0)
        {
            fileTree.IsExpanded = !fileTree.IsExpanded;
            UpdateExpandedState(fileTree);
        }
    }

    private void UpdateExpandedState(TorrentFileTree fileTree)
    {
        // Find the item by comparing Tag instead of Name
        var itemIndex = -1;
        for (int i = 0; i < _fileListView.Items.Count; i++)
        {
            if (_fileListView.Items[i].Tag == fileTree)
            {
                itemIndex = i;
                break;
            }
        }
        if (itemIndex == -1) return;

        if (fileTree.IsExpanded)
        {
            // Insert child items after the current item
            var childItems = new List<ListViewItem>();
            AddTreeItems(fileTree.Children, childItems);
            // Insert items one by one
            _fileListView.BeginUpdate();
            for (int i = 0; i < childItems.Count; i++)
            {
                _fileListView.Items.Insert(itemIndex + 1 + i, childItems[i]);
            }
            _fileListView.EndUpdate();
        }
        else
        {
            // Remove all child items
            var itemsToRemove = new List<ListViewItem>();
            for (int i = itemIndex + 1; i < _fileListView.Items.Count; i++)
            {
                var childTree = _fileListView.Items[i].Tag as TorrentFileTree;
                if (childTree == null || childTree.IndentCount <= fileTree.IndentCount)
                    break;
                itemsToRemove.Add(_fileListView.Items[i]);
            }
            _fileListView.BeginUpdate();
            foreach (var item in itemsToRemove)
            {
                _fileListView.Items.Remove(item);
            }
            _fileListView.EndUpdate();
        }
        _fileListView.Invalidate();
    }

    private void AddTreeItems(List<TorrentFileTree> items, dynamic targetList)
    {
        foreach (var item in items)
        {
            var subItems = new List<string> { item.BaseName };

            if (_isSimpleMode)
            {
                subItems.Add(FormattingUtils.FormatSize(item.Size));
                subItems.Add(item.Priority.ToString());
            }
            else
            {
                subItems.AddRange(_fileListView.Columns.Cast<ColumnHeader>().Skip(1).Select(column => GetColumnText(column.Name, item)));
            }

            var listItem = new ListViewItem(subItems.ToArray())
            {
                Tag = item
            };
            targetList.Add(listItem);

            if (item.IsExpanded)
            {
                AddTreeItems(item.Children, targetList);
            }
        }
    }

    private string GetColumnText(string? columnName, TorrentFileTree item)
    {
        return columnName switch
        {
            "sizeColumn" => FormattingUtils.FormatSize(item.Size),
            "progressColumn" => $"{item.Progress:F1}%",
            "priorityColumn" => item.Priority.ToString(),
            "availabilityColumn" => $"{item.Availability:F2}",
            _ => "?"
        };
    }

    public void SaveColumnConfig()
    {
        if (_isSimpleMode) return;
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
        if (_isSimpleMode) return;

        // Ensure name column is always visible and at the beginning
        var nameColumn = config.FirstOrDefault(c => c.Name == "nameColumn");
        if (nameColumn != null)
        {
            nameColumn.IsVisible = true;
            config.Remove(nameColumn);
            config.Insert(0, nameColumn);
        }

        _columnConfig = config;
        ApplyColumnConfig();
    }

    public void UpdateFileList(IEnumerable<TorrentContentInfo> files, string hash)
    {
        _lastHash = _currentHash;
        _currentHash = hash;
        
        // If it's the same torrent, preserve expanded state
        if (hash == _lastHash && _fileTree != null)
        {
            var expandedPaths = GetExpandedPaths(_fileTree);
            _fileTree = TorrentFileTree.BuildTree(files);
            RestoreExpandedState(_fileTree, expandedPaths);
        }
        else
        {
            _fileTree = TorrentFileTree.BuildTree(files);
        }
        
        _fileTree.ForEach(item => item.UpdateStateRecursively());
        RefreshFileList();
    }

    private HashSet<string> GetExpandedPaths(List<TorrentFileTree> tree)
    {
        var paths = new HashSet<string>();
        foreach (var item in tree.Where(item => item.IsExpanded))
        {
            paths.Add(item.FullPath);
            paths.UnionWith(GetExpandedPaths(item.Children));
        }
        return paths;
    }

    private void RestoreExpandedState(List<TorrentFileTree> tree, HashSet<string> expandedPaths)
    {
        foreach (var item in tree.Where(item => expandedPaths.Contains(item.FullPath)))
        {
            item.IsExpanded = true;
            RestoreExpandedState(item.Children, expandedPaths);
        }
    }

    public void ClearFileList()
    {
        _currentHash = string.Empty;
        _lastHash = string.Empty;
        _fileListView.Items.Clear();
    }

    private void RefreshFileList()
    {
        if (_fileTree == null) return;
        _fileListView.BeginUpdate();
        try
        {
            if (_currentHash != _lastHash)
            {
                _fileListView.Items.Clear();
                AddTreeItems(_fileTree, _fileListView.Items);
                return;
            }

            // add tree items to List<ListViewItem>
            var items = new List<ListViewItem>();
            AddTreeItems(_fileTree, items);

            // now compare and update the items
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var existingItem = _fileListView.Items[i];
                for (int j = 0; j < existingItem.SubItems.Count; j++)
                {
                    existingItem.SubItems[j].Text = item.SubItems[j].Text;
                }
                existingItem.Tag = item.Tag;
            }
            _fileListView.Invalidate();
        }
        finally
        {
            _fileListView.EndUpdate();
        }
    }

    private void FileListView_ColumnWidthChanged(object? sender, ColumnWidthChangedEventArgs e)
    {
        var column = _fileListView.Columns[e.ColumnIndex];
        var columnInfo = _columnConfig.FirstOrDefault(c => c.Name == column.Name);
        if (columnInfo == null) return;
        columnInfo.Width = column.Width;
        SaveColumnConfig();
    }
} 
