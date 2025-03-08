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
            comboBox1 = new ComboBox();
            tabConnection.SuspendLayout();
            tabPageConnectionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // btnNewConnection
            // 
            btnNewConnection.Location = new Point(335, 12);
            btnNewConnection.Name = "btnNewConnection";
            btnNewConnection.Size = new Size(75, 25);
            btnNewConnection.TabIndex = 1;
            btnNewConnection.Text = "button1";
            btnNewConnection.UseVisualStyleBackColor = true;
            btnNewConnection.Click += BtnNewConnection_Click;
            // 
            // btnRenameConnection
            // 
            btnRenameConnection.Location = new Point(416, 11);
            btnRenameConnection.Name = "btnRenameConnection";
            btnRenameConnection.Size = new Size(75, 25);
            btnRenameConnection.TabIndex = 2;
            btnRenameConnection.Text = "button2";
            btnRenameConnection.UseVisualStyleBackColor = true;
            btnRenameConnection.Click += BtnRenameConnection_Click;
            // 
            // btnDeleteConnection
            // 
            btnDeleteConnection.Location = new Point(497, 12);
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
            tabConnection.Location = new Point(12, 43);
            tabConnection.Name = "tabConnection";
            tabConnection.SelectedIndex = 0;
            tabConnection.Size = new Size(560, 258);
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
            tabPageConnectionInfo.Location = new Point(4, 26);
            tabPageConnectionInfo.Name = "tabPageConnectionInfo";
            tabPageConnectionInfo.Padding = new Padding(3);
            tabPageConnectionInfo.Size = new Size(552, 228);
            tabPageConnectionInfo.TabIndex = 0;
            tabPageConnectionInfo.Text = "tabPage1";
            tabPageConnectionInfo.UseVisualStyleBackColor = true;
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(25, 25);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(35, 17);
            hostLabel.TabIndex = 12;
            hostLabel.Text = "主机:";
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(113, 22);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(200, 23);
            hostTextBox.TabIndex = 13;
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(25, 58);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(35, 17);
            portLabel.TabIndex = 14;
            portLabel.Text = "端口:";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(113, 54);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 15;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(25, 91);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(47, 17);
            usernameLabel.TabIndex = 16;
            usernameLabel.Text = "用户名:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(113, 87);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 23);
            usernameTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(25, 124);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(35, 17);
            passwordLabel.TabIndex = 18;
            passwordLabel.Text = "密码:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(113, 120);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.TabIndex = 19;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // timeoutLabel
            // 
            timeoutLabel.AutoSize = true;
            timeoutLabel.Location = new Point(25, 156);
            timeoutLabel.Name = "timeoutLabel";
            timeoutLabel.Size = new Size(55, 17);
            timeoutLabel.TabIndex = 20;
            timeoutLabel.Text = "超时(秒):";
            // 
            // timeoutNumericUpDown
            // 
            timeoutNumericUpDown.Location = new Point(113, 153);
            timeoutNumericUpDown.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            timeoutNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timeoutNumericUpDown.Name = "timeoutNumericUpDown";
            timeoutNumericUpDown.Size = new Size(100, 23);
            timeoutNumericUpDown.TabIndex = 21;
            timeoutNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(205, 324);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 25);
            okButton.TabIndex = 22;
            okButton.Text = "确定";
            okButton.Click += OkButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(305, 324);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 25);
            cancelButton.TabIndex = 23;
            cancelButton.Text = "取消";
            cancelButton.Click += CancelButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(317, 25);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // ConnectionManager
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(584, 361);
            Controls.Add(btnNewConnection);
            Controls.Add(btnRenameConnection);
            Controls.Add(comboBox1);
            Controls.Add(btnDeleteConnection);
            Controls.Add(tabConnection);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
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
        private ComboBox comboBox1;
    }
}