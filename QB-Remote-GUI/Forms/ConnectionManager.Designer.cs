namespace QB_Remote_GUI.GUI.Forms
{
    partial class ConnectionManager
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
            btnNewConnection = new Button();
            btnRenameConnection = new Button();
            btnDeleteConnection = new Button();
            tabConnection = new TabControl();
            tabPageConnectionInfo = new TabPage();
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
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            tabConnection.SuspendLayout();
            tabPageConnectionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewConnection
            // 
            btnNewConnection.Dock = DockStyle.Right;
            btnNewConnection.Location = new Point(11, 0);
            btnNewConnection.Name = "btnNewConnection";
            btnNewConnection.Size = new Size(75, 25);
            btnNewConnection.TabIndex = 1;
            btnNewConnection.Text = "button1";
            btnNewConnection.UseVisualStyleBackColor = true;
            btnNewConnection.Click += BtnNewConnection_Click;
            // 
            // btnRenameConnection
            // 
            btnRenameConnection.Dock = DockStyle.Right;
            btnRenameConnection.Location = new Point(86, 0);
            btnRenameConnection.Name = "btnRenameConnection";
            btnRenameConnection.Size = new Size(75, 25);
            btnRenameConnection.TabIndex = 2;
            btnRenameConnection.Text = "button2";
            btnRenameConnection.UseVisualStyleBackColor = true;
            btnRenameConnection.Click += BtnRenameConnection_Click;
            // 
            // btnDeleteConnection
            // 
            btnDeleteConnection.Dock = DockStyle.Right;
            btnDeleteConnection.Location = new Point(161, 0);
            btnDeleteConnection.Name = "btnDeleteConnection";
            btnDeleteConnection.Size = new Size(75, 25);
            btnDeleteConnection.TabIndex = 3;
            btnDeleteConnection.Text = "button3";
            btnDeleteConnection.UseVisualStyleBackColor = true;
            btnDeleteConnection.Click += BtnDeleteConnection_Click;
            // 
            // tabConnection
            // 
            tabConnection.Controls.Add(tabPageConnectionInfo);
            tabConnection.Dock = DockStyle.Fill;
            tabConnection.Location = new Point(0, 49);
            tabConnection.Name = "tabConnection";
            tabConnection.SelectedIndex = 0;
            tabConnection.Size = new Size(584, 312);
            tabConnection.TabIndex = 4;
            // 
            // tabPageConnectionInfo
            // 
            tabPageConnectionInfo.Controls.Add(hostLabel);
            tabPageConnectionInfo.Controls.Add(hostTextBox);
            tabPageConnectionInfo.Controls.Add(portLabel);
            tabPageConnectionInfo.Controls.Add(portTextBox);
            tabPageConnectionInfo.Controls.Add(usernameLabel);
            tabPageConnectionInfo.Controls.Add(usernameTextBox);
            tabPageConnectionInfo.Controls.Add(passwordLabel);
            tabPageConnectionInfo.Controls.Add(passwordTextBox);
            tabPageConnectionInfo.Controls.Add(timeoutLabel);
            tabPageConnectionInfo.Controls.Add(timeoutNumericUpDown);
            tabPageConnectionInfo.Controls.Add(okButton);
            tabPageConnectionInfo.Controls.Add(cancelButton);
            tabPageConnectionInfo.Location = new Point(4, 26);
            tabPageConnectionInfo.Name = "tabPageConnectionInfo";
            tabPageConnectionInfo.Padding = new Padding(3);
            tabPageConnectionInfo.Size = new Size(576, 282);
            tabPageConnectionInfo.TabIndex = 0;
            tabPageConnectionInfo.Text = "tabPage1";
            tabPageConnectionInfo.UseVisualStyleBackColor = true;
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(30, 9);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(35, 17);
            hostLabel.TabIndex = 12;
            hostLabel.Text = "主机:";
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(118, 6);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(200, 23);
            hostTextBox.TabIndex = 13;
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(30, 42);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(35, 17);
            portLabel.TabIndex = 14;
            portLabel.Text = "端口:";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(118, 38);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 15;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(30, 75);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(47, 17);
            usernameLabel.TabIndex = 16;
            usernameLabel.Text = "用户名:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(118, 71);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 23);
            usernameTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(30, 108);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(35, 17);
            passwordLabel.TabIndex = 18;
            passwordLabel.Text = "密码:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(118, 104);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.TabIndex = 19;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // timeoutLabel
            // 
            timeoutLabel.AutoSize = true;
            timeoutLabel.Location = new Point(30, 140);
            timeoutLabel.Name = "timeoutLabel";
            timeoutLabel.Size = new Size(55, 17);
            timeoutLabel.TabIndex = 20;
            timeoutLabel.Text = "超时(秒):";
            // 
            // timeoutNumericUpDown
            // 
            timeoutNumericUpDown.Location = new Point(118, 137);
            timeoutNumericUpDown.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            timeoutNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timeoutNumericUpDown.Name = "timeoutNumericUpDown";
            timeoutNumericUpDown.Size = new Size(100, 23);
            timeoutNumericUpDown.TabIndex = 21;
            timeoutNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // okButton
            // 
            okButton.Location = new Point(118, 185);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 26);
            okButton.TabIndex = 22;
            okButton.Text = "确定";
            okButton.Click += OkButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(208, 185);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 26);
            cancelButton.TabIndex = 23;
            cancelButton.Text = "取消";
            cancelButton.Click += CancelButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(12);
            panel1.Size = new Size(584, 49);
            panel1.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(324, 25);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnNewConnection);
            panel2.Controls.Add(btnRenameConnection);
            panel2.Controls.Add(btnDeleteConnection);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(336, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 25);
            panel2.TabIndex = 0;
            // 
            // ConnectionManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(tabConnection);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectionManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ConnectionManager";
            Load += ConnectionManager_Load;
            tabConnection.ResumeLayout(false);
            tabPageConnectionInfo.ResumeLayout(false);
            tabPageConnectionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnNewConnection;
        private Button btnRenameConnection;
        private Button btnDeleteConnection;
        private TabControl tabConnection;
        private TabPage tabPageConnectionInfo;
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
        private Panel panel1;
        private ComboBox comboBox1;
        private Panel panel2;
    }
}