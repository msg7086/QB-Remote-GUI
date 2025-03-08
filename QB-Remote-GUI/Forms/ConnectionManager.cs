using QB_Remote_GUI.GUI.Models;

namespace QB_Remote_GUI.GUI.Forms;

public partial class ConnectionManager : Form
{
    public readonly List<ConnectionProfile> DuplicatedConnections;

    public ConnectionProfile? SelectedConnection { get; private set; }

    public ConnectionManager(List<ConnectionProfile> connections)
    {
        InitializeComponent();
        DuplicatedConnections = connections.Select(c => new ConnectionProfile
        {
            Name = c.Name,
            Host = c.Host,
            Port = c.Port,
            Username = c.Username,
            Password = c.Password,
            TimeoutSeconds = c.TimeoutSeconds,
            UseSsl = c.UseSsl,
            LastUsed = c.LastUsed
        }).ToList();

        // Initialize UI
        InitializeUI();

        // Load connections to UI
        RefreshConnectionsList();
    }

    private void InitializeUI()
    {
        // Set button texts
        btnNewConnection.Text = "新建";
        btnRenameConnection.Text = "重命名";
        btnDeleteConnection.Text = "删除";
        tabPageConnectionInfo.Text = "连接信息";
        Text = "连接管理器";

        // Set default values
        timeoutNumericUpDown.Value = 30;
        portTextBox.Text = "8080";

        // Bind text changed events
        hostTextBox.TextChanged += UpdateConnectionOnTextChanged;
        portTextBox.TextChanged += UpdateConnectionOnTextChanged;
        usernameTextBox.TextChanged += UpdateConnectionOnTextChanged;
        passwordTextBox.TextChanged += UpdateConnectionOnTextChanged;
        timeoutNumericUpDown.ValueChanged += UpdateConnectionOnTextChanged;
    }

    private void RefreshConnectionsList()
    {
        // Update ComboBox
        comboBox1.DataSource = null;
        comboBox1.DataSource = DuplicatedConnections.OrderByDescending(c => c.LastUsed).ToList();
        comboBox1.DisplayMember = "Name";
        if (DuplicatedConnections.Count > 0)
        {
            comboBox1.SelectedIndex = 0;
        }
    }

    private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SelectedConnection = comboBox1.SelectedItem as ConnectionProfile;
        UpdateConnectionInfo();
        UpdateButtonStates();
    }

    private void UpdateConnectionInfo()
    {
        if (SelectedConnection != null)
        {
            hostTextBox.Text = SelectedConnection.Host;
            portTextBox.Text = SelectedConnection.Port.ToString();
            usernameTextBox.Text = SelectedConnection.Username;
            passwordTextBox.Text = SelectedConnection.Password;
            timeoutNumericUpDown.Value = SelectedConnection.TimeoutSeconds;
        }
        else
        {
            hostTextBox.Text = "";
            portTextBox.Text = "8080";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            timeoutNumericUpDown.Value = 30;
        }
    }

    private void UpdateButtonStates()
    {
        bool hasSelection = SelectedConnection != null;
        btnRenameConnection.Enabled = hasSelection;
        btnDeleteConnection.Enabled = hasSelection;
    }

    private void BtnNewConnection_Click(object? sender, EventArgs e)
    {
        var newConnection = SelectedConnection switch
        {
            null => GetEmptyConnection(),
            _ => new ConnectionProfile
            {
                Name = SelectedConnection.Name + " - duplicate",
                Host = SelectedConnection.Host,
                Port = SelectedConnection.Port,
                Username = SelectedConnection.Username,
                Password = SelectedConnection.Password,
                TimeoutSeconds = SelectedConnection.TimeoutSeconds,
                UseSsl = SelectedConnection.UseSsl,
                LastUsed = DateTime.Now
            }
        };
        DuplicatedConnections.Add(newConnection);
        comboBox1.SelectedItem = newConnection;
        SelectedConnection = newConnection;
        UpdateConnectionInfo();
        UpdateButtonStates();
        RefreshConnectionsList();
    }

    private void BtnRenameConnection_Click(object? sender, EventArgs e)
    {
        if (SelectedConnection == null) return;

        var input = new Form()
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "重命名连接",
            StartPosition = FormStartPosition.CenterParent
        };
        var textBox = new TextBox() { Left = 50, Top = 20, Width = 200, Text = SelectedConnection.Name };
        var buttonOk = new Button() { Text = "确定", Left = 50, Width = 100, Top = 50, DialogResult = DialogResult.OK };
        var buttonCancel = new Button() { Text = "取消", Left = 150, Width = 100, Top = 50, DialogResult = DialogResult.Cancel };

        input.Controls.AddRange(new Control[] { textBox, buttonOk, buttonCancel });
        input.AcceptButton = buttonOk;
        input.CancelButton = buttonCancel;

        if (input.ShowDialog() != DialogResult.OK) return;
        var newName = textBox.Text.Trim();

        if (string.IsNullOrEmpty(newName))
        {
            MessageBox.Show("名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (DuplicatedConnections.Any(c => c != SelectedConnection && c.Name == newName))
        {
            MessageBox.Show("该名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SelectedConnection.Name = newName;
        RefreshConnectionsList();
    }

    private void BtnDeleteConnection_Click(object? sender, EventArgs e)
    {
        if (SelectedConnection == null) return;

        if (MessageBox.Show(
                $"确定要删除连接 \"{SelectedConnection.Name}\" 吗？",
                "删除连接",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
        {
            DuplicatedConnections.Remove(SelectedConnection);
            RefreshConnectionsList();
        }
    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void ConnectionManager_Load(object sender, EventArgs e)
    {
        if (DuplicatedConnections.Count > 0) return;
        DuplicatedConnections.Add(GetEmptyConnection());
        RefreshConnectionsList();
    }

    private ConnectionProfile GetEmptyConnection()
    {
        return new ConnectionProfile
        {
            Name = "Default Connection",
            Host = "localhost",
            Port = 8080,
            Username = "",
            Password = "",
            TimeoutSeconds = 30,
            UseSsl = false,
            LastUsed = DateTime.Now
        };
    }

    private void UpdateConnectionOnTextChanged(object? sender, EventArgs e)
    {
        if (SelectedConnection == null) return;

        if (sender == hostTextBox)
        {
            SelectedConnection.Host = hostTextBox.Text;
        }
        else if (sender == portTextBox && int.TryParse(portTextBox.Text, out int port))
        {
            SelectedConnection.Port = port;
        }
        else if (sender == usernameTextBox)
        {
            SelectedConnection.Username = usernameTextBox.Text;
        }
        else if (sender == passwordTextBox)
        {
            SelectedConnection.Password = passwordTextBox.Text;
        }
        else if (sender == timeoutNumericUpDown)
        {
            SelectedConnection.TimeoutSeconds = (int)timeoutNumericUpDown.Value;
        }
    }
}
