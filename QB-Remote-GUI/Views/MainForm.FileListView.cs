using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using QB.Remote.API.Models.Torrents;
using QB.Remote.GUI.Models;
using QB_Remote_GUI.Utils;

namespace QB_Remote_GUI.Views;

public class FileListViewManager
{
    private readonly ListView _fileListView;
    private List<TorrentFileTree> _fileTree;
    private const int INDENT_WIDTH = 20;
    private const int ARROW_WIDTH = 20;

    public FileListViewManager(ListView fileListView)
    {
        _fileListView = fileListView;
        InitializeListView();
    }

    private void InitializeListView()
    {
        _fileListView.View = View.Details;
        _fileListView.FullRowSelect = true;
        _fileListView.GridLines = true;
        _fileListView.CheckBoxes = false;
        _fileListView.OwnerDraw = true;

        _fileListView.Columns.Add("Name", 300);
        _fileListView.Columns.Add("Size", 100);
        _fileListView.Columns.Add("Progress", 100);
        _fileListView.Columns.Add("Priority", 80);
        _fileListView.Columns.Add("Availability", 100);

        _fileListView.DrawColumnHeader += FileListView_DrawColumnHeader;
        _fileListView.DrawSubItem += FileListView_DrawSubItem;
        _fileListView.MouseClick += FileListView_MouseClick;
    }

    private void FileListView_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }

    private void FileListView_DrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
    {
        if (e.ColumnIndex != 0)
        {
            e.DrawDefault = true;
            return;
        }

        var item = e.Item;
        var fileTree = (TorrentFileTree)item.Tag;

        // Draw background with selection state
        if (item.Selected)
        {
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        }
        else
        {
            e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
        }

        // Draw grid lines
        using (var pen = new Pen(Color.FromArgb(240, 240, 240)))
        {
            e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        var x = e.Bounds.X;
        var y = e.Bounds.Y + (e.Bounds.Height - 16) / 2;

        // Draw indent
        x += fileTree.IndentCount * INDENT_WIDTH;

        // Draw arrow if has children
        if (fileTree.Children.Count > 0)
        {
            var arrow = fileTree.IsExpanded ? "▼" : "▶";
            var arrowSize = e.Graphics.MeasureString(arrow, _fileListView.Font);
            e.Graphics.DrawString(arrow, _fileListView.Font, item.Selected ? SystemBrushes.HighlightText : Brushes.Black, x, y);
        }
        x += ARROW_WIDTH;

        // Draw checkbox
        var checkboxPoint = new Point(x, y + 2);
        CheckBoxRenderer.DrawCheckBox(e.Graphics, checkboxPoint, fileTree.CachedCheckBoxState);
        x += 20;

        // Draw text with clipping
        var textRect = new Rectangle(x, e.Bounds.Y, e.Bounds.Width - x, e.Bounds.Height);
        var format = new StringFormat
        {
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
        };
        e.Graphics.DrawString(fileTree.BaseName, _fileListView.Font, 
            item.Selected ? SystemBrushes.HighlightText : Brushes.Black, 
            textRect, format);
    }

    private void FileListView_MouseClick(object? sender, MouseEventArgs e)
    {
        var hit = _fileListView.HitTest(e.Location);
        if (hit.Item == null) return;

        var fileTree = hit.Item.Tag as TorrentFileTree;
        if (fileTree == null) return;

        var x = hit.Item.Bounds.X + fileTree.IndentCount * INDENT_WIDTH;

        // Check if clicked on arrow
        if (e.X >= x && e.X < x + ARROW_WIDTH && fileTree.Children.Count > 0)
        {
            fileTree.IsExpanded = !fileTree.IsExpanded;
            UpdateExpandedState(fileTree);
        }
        // Check if clicked on checkbox
        else if (e.X >= x + ARROW_WIDTH && e.X < x + ARROW_WIDTH + 20)
        {
            fileTree.IsSeed = !fileTree.IsSeed;
            _fileListView.Invalidate();
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
            foreach (var item in itemsToRemove)
            {
                _fileListView.Items.Remove(item);
            }
        }
        _fileListView.Invalidate();
    }

    private void AddTreeItems(List<TorrentFileTree> items, List<ListViewItem> targetList)
    {
        foreach (var item in items)
        {
            var listItem = new ListViewItem(new[]
            {
                item.BaseName,
                FormattingUtils.FormatSize(item.Size),
                $"{item.Progress:F1}%",
                item.Priority.ToString(),
                $"{item.Availability:F2}"
            });
            listItem.Tag = item;
            listItem.IndentCount = item.IndentCount;
            targetList.Add(listItem);

            if (item.IsExpanded)
            {
                AddTreeItems(item.Children, targetList);
            }
        }
    }

    private void AddTreeItems(List<TorrentFileTree> items)
    {
        foreach (var item in items)
        {
            var listItem = new ListViewItem(new[]
            {
                item.BaseName,
                FormattingUtils.FormatSize(item.Size),
                $"{item.Progress:F1}%",
                item.Priority.ToString(),
                $"{item.Availability:F2}"
            });
            listItem.Tag = item;
            listItem.IndentCount = item.IndentCount;
            _fileListView.Items.Add(listItem);

            if (item.IsExpanded)
            {
                AddTreeItems(item.Children);
            }
        }
    }

    public void UpdateFileList(IEnumerable<TorrentContentInfo> files)
    {
        _fileTree = TorrentFileTree.BuildTree(files);
        _fileTree.ForEach(item => item.UpdateStateRecursively());
        RefreshFileList();
    }

    public void ClearFileList()
    {
        _fileTree = null;
        _fileListView.Items.Clear();
    }

    private void RefreshFileList()
    {
        _fileListView.BeginUpdate();
        _fileListView.Items.Clear();
        if (_fileTree != null)
        {
            AddTreeItems(_fileTree);
        }
        _fileListView.EndUpdate();
    }
} 
