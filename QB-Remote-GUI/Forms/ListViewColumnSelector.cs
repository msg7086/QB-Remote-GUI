using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI.Forms;

public partial class ListViewColumnSelector : Form
{
    private ListView _sourceListView;
    private readonly List<ColumnInfo> _columns = [];
    public List<ColumnInfo> SelectedColumns => _columns;

    public ListViewColumnSelector(ListView sourceListView, List<ColumnInfo>? existingColumns = null)
    {
        InitializeComponent();
        InitializeControls();
        _sourceListView = sourceListView;

        // Initialize columns list
        if (existingColumns != null)
        {
            _columns = existingColumns;
        }
        else
        {
            foreach (ColumnHeader column in sourceListView.Columns)
            {
                _columns.Add(new ColumnInfo
                {
                    Name = column.Name,
                    Text = column.Text,
                    Width = column.Width,
                    IsVisible = true
                });
            }
        }

        // Populate listbox
        RefreshColumnList();
    }

    private void InitializeControls()
    {
        var lang = LanguageLoader.Instance;

        btnOK.Text = lang.GetTranslation("OK");
        btnCancel.Text = lang.GetTranslation("Cancel");
        btnUp.Text = lang.GetTranslation("Move up");
        btnDown.Text = lang.GetTranslation("Move down");
    }

    private void RefreshColumnList()
    {
        listColumns.Items.Clear();
        foreach (var column in _columns)
        {
            listColumns.Items.Add(new ListViewItem
            {
                Text = column.Text,
                Checked = column.IsVisible,
                Tag = column
            });
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        // Update visibility based on checkbox state
        for (int i = 0; i < listColumns.Items.Count; i++)
        {
            var item = listColumns.Items[i];
            var column = item.Tag as ColumnInfo;
            if (column == null) continue;
            column.IsVisible = item.Checked;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
        if (listColumns.SelectedItems.Count == 0 || listColumns.SelectedIndices[0] == 0)
            return;

        int selectedIndex = listColumns.SelectedIndices[0];
        var selectedColumn = _columns[selectedIndex];
        _columns.RemoveAt(selectedIndex);
        _columns.Insert(selectedIndex - 1, selectedColumn);

        RefreshColumnList();
        listColumns.Items[selectedIndex - 1].Selected = true;
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
        if (listColumns.SelectedItems.Count == 0 || listColumns.SelectedIndices[0] == listColumns.Items.Count - 1)
            return;

        int selectedIndex = listColumns.SelectedIndices[0];
        var selectedColumn = _columns[selectedIndex];
        _columns.RemoveAt(selectedIndex);
        _columns.Insert(selectedIndex + 1, selectedColumn);

        RefreshColumnList();
        listColumns.Items[selectedIndex + 1].Selected = true;
    }
}

public class ColumnInfo
{
    public string? Name { get; set; }
    public string? Text { get; set; }
    public int Width { get; set; }
    public bool IsVisible { get; set; }
}