using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI;

internal class ListViewItemComparer(int column, bool ascending) : System.Collections.IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x == null && y == null) return 0;
        if (x is not ListViewItem itemX || y is not ListViewItem itemY) return 0;
        if (itemX.SubItems.Count <= column || itemY.SubItems.Count <= column) return 0;
        if (itemX.Tag is not TorrentInfo torrentX || itemY.Tag is not TorrentInfo torrentY) return 0;
        var listViewX = itemX.ListView;
        var listViewY = itemY.ListView;
        if (listViewX == null || listViewY == null || listViewX != listViewY) return 0;
        var columnName = listViewX.Columns[column].Name;
        if (columnName == null) return 0;
        return TorrentInfoComparer.Compare(torrentX, torrentY, columnName) * (ascending ? 1 : -1);
    }
}
