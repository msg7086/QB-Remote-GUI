using QB.Remote.API.Clients;
using QB.Remote.API.Models;

namespace QB_Remote_GUI;

public partial class ConnectionForm : Form
{
    public QBittorrentClientOptions ConnectionOptions { get; private set; }

    public ConnectionForm(QBittorrentClientOptions currentOptions)
    {
        InitializeComponent();
        ConnectionOptions = currentOptions;

        // Initialize form with current settings
        hostTextBox.Text = new Uri(currentOptions.BaseUrl).Host;
        portTextBox.Text = new Uri(currentOptions.BaseUrl).Port.ToString();
        usernameTextBox.Text = currentOptions.Username;
        passwordTextBox.Text = currentOptions.Password;
        timeoutNumericUpDown.Value = currentOptions.TimeoutSeconds;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        try
        {
            var port = int.Parse(portTextBox.Text);
            if (port <= 0 || port > 65535)
            {
                MessageBox.Show("端口号必须在1-65535之间。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConnectionOptions = new QBittorrentClientOptions
            {
                BaseUrl = $"http://{hostTextBox.Text.Trim()}:{port}",
                Username = usernameTextBox.Text.Trim(),
                Password = passwordTextBox.Text,
                TimeoutSeconds = (int)timeoutNumericUpDown.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception)
        {
            MessageBox.Show("请输入有效的端口号。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
} 
