using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using QB_Remote_GUI.GUI.Models;

namespace QB_Remote_GUI.GUI.Forms
{
    public partial class ConnectionManager : Form
    {
        public readonly List<ConnectionProfile> _duplicatedConnections;
        private ConnectionProfile? _selectedConnection;

        public ConnectionProfile? SelectedConnection => _selectedConnection;

        public ConnectionManager(List<ConnectionProfile> connections)
        {
            InitializeComponent();
            _duplicatedConnections = connections.Select(c => new ConnectionProfile
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
            comboBox1.DataSource = _duplicatedConnections.OrderByDescending(c => c.LastUsed).ToList();
            comboBox1.DisplayMember = "Name";
            if (_duplicatedConnections.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            _selectedConnection = comboBox1.SelectedItem as ConnectionProfile;
            UpdateConnectionInfo();
            UpdateButtonStates();
        }

        private void UpdateConnectionInfo()
        {
            if (_selectedConnection != null)
            {
                hostTextBox.Text = _selectedConnection.Host;
                portTextBox.Text = _selectedConnection.Port.ToString();
                usernameTextBox.Text = _selectedConnection.Username;
                passwordTextBox.Text = _selectedConnection.Password;
                timeoutNumericUpDown.Value = _selectedConnection.TimeoutSeconds;
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
            bool hasSelection = _selectedConnection != null;
            btnRenameConnection.Enabled = hasSelection;
            btnDeleteConnection.Enabled = hasSelection;
        }

        private void BtnNewConnection_Click(object? sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            _selectedConnection = null;
            UpdateConnectionInfo();
            UpdateButtonStates();
            RefreshConnectionsList();
        }

        private void BtnRenameConnection_Click(object? sender, EventArgs e)
        {
            if (_selectedConnection == null) return;

            var input = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "重命名连接",
                StartPosition = FormStartPosition.CenterParent
            };
            var textBox = new TextBox() { Left = 50, Top = 20, Width = 200, Text = _selectedConnection.Name };
            var buttonOk = new Button() { Text = "确定", Left = 50, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            var buttonCancel = new Button() { Text = "取消", Left = 150, Width = 100, Top = 50, DialogResult = DialogResult.Cancel };

            input.Controls.AddRange(new Control[] { textBox, buttonOk, buttonCancel });
            input.AcceptButton = buttonOk;
            input.CancelButton = buttonCancel;

            if (input.ShowDialog() == DialogResult.OK)
            {
                var newName = textBox.Text.Trim();

                if (string.IsNullOrEmpty(newName))
                {
                    MessageBox.Show("名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_duplicatedConnections.Any(c => c != _selectedConnection && c.Name == newName))
                {
                    MessageBox.Show("该名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _selectedConnection.Name = newName;
                RefreshConnectionsList();
            }
        }

        private void BtnDeleteConnection_Click(object? sender, EventArgs e)
        {
            if (_selectedConnection == null) return;

            if (MessageBox.Show(
                $"确定要删除连接 \"{_selectedConnection.Name}\" 吗？",
                "删除连接",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _duplicatedConnections.Remove(_selectedConnection);
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
            if (_duplicatedConnections.Count == 0)
            {
                _duplicatedConnections.Add(new ConnectionProfile
                {
                    Name = "Default Connection",
                    Host = "localhost",
                    Port = 8080,
                    Username = "",
                    Password = "",
                    TimeoutSeconds = 30,
                    UseSsl = false,
                    LastUsed = DateTime.Now
                });
                RefreshConnectionsList();
            }
        }

        private void UpdateConnectionOnTextChanged(object sender, EventArgs e)
        {
            if (_selectedConnection == null) return;

            if (sender == hostTextBox)
            {
                _selectedConnection.Host = hostTextBox.Text;
            }
            else if (sender == portTextBox && int.TryParse(portTextBox.Text, out int port))
            {
                _selectedConnection.Port = port;
            }
            else if (sender == usernameTextBox)
            {
                _selectedConnection.Username = usernameTextBox.Text;
            }
            else if (sender == passwordTextBox)
            {
                _selectedConnection.Password = passwordTextBox.Text;
            }
            else if (sender == timeoutNumericUpDown)
            {
                _selectedConnection.TimeoutSeconds = (int)timeoutNumericUpDown.Value;
            }
        }
    }
}
