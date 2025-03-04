namespace QB_Remote_GUI
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hostLabel = new Label();
            hostTextBox = new TextBox();
            portLabel = new Label();
            portTextBox = new TextBox();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            timeoutLabel = new Label();
            timeoutNumericUpDown = new NumericUpDown();
            okButton = new Button();
            cancelButton = new Button();

            // Initialize all controls
            SuspendLayout();

            // Host
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(12, 15);
            hostLabel.Text = "主机:";

            hostTextBox.Location = new Point(100, 12);
            hostTextBox.Size = new Size(200, 23);

            // Port
            portLabel.AutoSize = true;
            portLabel.Location = new Point(12, 44);
            portLabel.Text = "端口:";

            portTextBox.Location = new Point(100, 41);
            portTextBox.Size = new Size(100, 23);

            // Username
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 73);
            usernameLabel.Text = "用户名:";

            usernameTextBox.Location = new Point(100, 70);
            usernameTextBox.Size = new Size(200, 23);

            // Password
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 102);
            passwordLabel.Text = "密码:";

            passwordTextBox.Location = new Point(100, 99);
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.UseSystemPasswordChar = true;

            // Timeout
            timeoutLabel.AutoSize = true;
            timeoutLabel.Location = new Point(12, 131);
            timeoutLabel.Text = "超时(秒):";

            timeoutNumericUpDown.Location = new Point(100, 128);
            timeoutNumericUpDown.Size = new Size(100, 23);
            timeoutNumericUpDown.Minimum = 1;
            timeoutNumericUpDown.Maximum = 300;
            timeoutNumericUpDown.Value = 30;

            // Buttons
            okButton.Location = new Point(100, 170);
            okButton.Size = new Size(75, 23);
            okButton.Text = "确定";
            okButton.Click += okButton_Click;

            cancelButton.Location = new Point(190, 170);
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "取消";
            cancelButton.Click += cancelButton_Click;

            // Form
            AcceptButton = okButton;
            CancelButton = cancelButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 211);
            Controls.AddRange(new Control[] {
                hostLabel, hostTextBox,
                portLabel, portTextBox,
                usernameLabel, usernameTextBox,
                passwordLabel, passwordTextBox,
                timeoutLabel, timeoutNumericUpDown,
                okButton, cancelButton
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "连接设置";

            ResumeLayout(false);
            PerformLayout();
        }

        private Label hostLabel;
        private TextBox hostTextBox;
        private Label portLabel;
        private TextBox portTextBox;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label timeoutLabel;
        private NumericUpDown timeoutNumericUpDown;
        private Button okButton;
        private Button cancelButton;

        #endregion
    }
} 
