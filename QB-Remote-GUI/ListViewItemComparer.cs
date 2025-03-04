namespace QB_Remote_GUI;

class ListViewItemComparer : System.Collections.IComparer
{
    private int _col;
    private bool _ascending;
    public ListViewItemComparer(int column, bool ascending)
    {
        _col = column;
        _ascending = ascending;
    }
    public int Compare(object x, object y)
    {
        int returnVal = 0;
        if (!(x is ListViewItem itemX) || !(y is ListViewItem itemY))
        {
            return returnVal;
        }

        if (itemX.SubItems.Count <= _col || itemY.SubItems.Count <= _col)
        {
            return returnVal;
        }

        string textX = itemX.SubItems[_col].Text;
        string textY = itemY.SubItems[_col].Text;

        // Attempt to parse as numbers for numeric comparison
        if (double.TryParse(textX, out double numberX) && double.TryParse(textY, out double numberY))
        {
            returnVal = numberX.CompareTo(numberY);
        }
        else
        {
            // Compare as strings
            returnVal = string.Compare(textX, textY);
        }

        // Adjust sort order
        if (!_ascending)
        {
            returnVal *= -1;
        }

        return returnVal;
    }
}
