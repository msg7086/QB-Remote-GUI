namespace QB_Remote_GUI.GUI.Forms
{
    partial class AddTorrent
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
            groupBox1 = new GroupBox();
            tableLayoutPanelOptions = new TableLayoutPanel();
            checkBoxStartNow = new CheckBox();
            checkBoxTMM = new CheckBox();
            checkBoxSkipChecking = new CheckBox();
            checkBoxDlLimit = new CheckBox();
            checkBoxUlLimit = new CheckBox();
            numericUpDownDlLimit = new NumericUpDown();
            numericUpDownUlLimit = new NumericUpDown();
            checkBoxRatioLimit = new CheckBox();
            checkBoxSeedingLimit = new CheckBox();
            numericUpDownRatioLimit = new NumericUpDown();
            numericUpDownSeedingLimit = new NumericUpDown();
            checkBoxInactiveSeedingLimit = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            checkBoxQueueTop = new CheckBox();
            checkBoxFLPrio = new CheckBox();
            checkBoxSequential = new CheckBox();
            checkBoxRootFolder = new CheckBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            labelSelectedSize = new Label();
            btnSelectNone = new Button();
            btnSelectAll = new Button();
            listView1 = new ListView();
            btnOK = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDlLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUlLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRatioLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeedingLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanelOptions);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 260);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // tableLayoutPanelOptions
            // 
            tableLayoutPanelOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelOptions.ColumnCount = 5;
            tableLayoutPanelOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanelOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanelOptions.Controls.Add(checkBoxStartNow, 1, 0);
            tableLayoutPanelOptions.Controls.Add(checkBoxTMM, 0, 0);
            tableLayoutPanelOptions.Controls.Add(checkBoxSkipChecking, 0, 1);
            tableLayoutPanelOptions.Controls.Add(checkBoxDlLimit, 3, 0);
            tableLayoutPanelOptions.Controls.Add(checkBoxUlLimit, 3, 1);
            tableLayoutPanelOptions.Controls.Add(numericUpDownDlLimit, 4, 0);
            tableLayoutPanelOptions.Controls.Add(numericUpDownUlLimit, 4, 1);
            tableLayoutPanelOptions.Controls.Add(checkBoxRatioLimit, 3, 2);
            tableLayoutPanelOptions.Controls.Add(checkBoxSeedingLimit, 3, 3);
            tableLayoutPanelOptions.Controls.Add(numericUpDownRatioLimit, 4, 2);
            tableLayoutPanelOptions.Controls.Add(numericUpDownSeedingLimit, 4, 3);
            tableLayoutPanelOptions.Controls.Add(checkBoxInactiveSeedingLimit, 3, 4);
            tableLayoutPanelOptions.Controls.Add(numericUpDown1, 4, 4);
            tableLayoutPanelOptions.Controls.Add(checkBoxQueueTop, 1, 1);
            tableLayoutPanelOptions.Controls.Add(checkBoxFLPrio, 0, 2);
            tableLayoutPanelOptions.Controls.Add(checkBoxSequential, 1, 2);
            tableLayoutPanelOptions.Controls.Add(checkBoxRootFolder, 0, 3);
            tableLayoutPanelOptions.Location = new Point(6, 114);
            tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            tableLayoutPanelOptions.Padding = new Padding(2);
            tableLayoutPanelOptions.RowCount = 5;
            tableLayoutPanelOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelOptions.Size = new Size(668, 140);
            tableLayoutPanelOptions.TabIndex = 4;
            // 
            // checkBoxStartNow
            // 
            checkBoxStartNow.Dock = DockStyle.Fill;
            checkBoxStartNow.Location = new Point(171, 5);
            checkBoxStartNow.Name = "checkBoxStartNow";
            checkBoxStartNow.Size = new Size(160, 21);
            checkBoxStartNow.TabIndex = 2;
            checkBoxStartNow.Text = "Start Torrent";
            checkBoxStartNow.UseVisualStyleBackColor = true;
            // 
            // checkBoxTMM
            // 
            checkBoxTMM.Dock = DockStyle.Fill;
            checkBoxTMM.Location = new Point(5, 5);
            checkBoxTMM.Name = "checkBoxTMM";
            checkBoxTMM.Size = new Size(160, 21);
            checkBoxTMM.TabIndex = 0;
            checkBoxTMM.Text = "Auto Management";
            checkBoxTMM.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipChecking
            // 
            checkBoxSkipChecking.Dock = DockStyle.Fill;
            checkBoxSkipChecking.Location = new Point(5, 32);
            checkBoxSkipChecking.Name = "checkBoxSkipChecking";
            checkBoxSkipChecking.Size = new Size(160, 21);
            checkBoxSkipChecking.TabIndex = 3;
            checkBoxSkipChecking.Text = "Skip Checking";
            checkBoxSkipChecking.UseVisualStyleBackColor = true;
            // 
            // checkBoxDlLimit
            // 
            checkBoxDlLimit.Checked = true;
            checkBoxDlLimit.CheckState = CheckState.Indeterminate;
            checkBoxDlLimit.Dock = DockStyle.Fill;
            checkBoxDlLimit.Location = new Point(370, 5);
            checkBoxDlLimit.Name = "checkBoxDlLimit";
            checkBoxDlLimit.Size = new Size(193, 21);
            checkBoxDlLimit.TabIndex = 4;
            checkBoxDlLimit.Text = "DL Limit (KB/s)";
            checkBoxDlLimit.ThreeState = true;
            checkBoxDlLimit.UseVisualStyleBackColor = true;
            // 
            // checkBoxUlLimit
            // 
            checkBoxUlLimit.Checked = true;
            checkBoxUlLimit.CheckState = CheckState.Indeterminate;
            checkBoxUlLimit.Dock = DockStyle.Fill;
            checkBoxUlLimit.Location = new Point(370, 32);
            checkBoxUlLimit.Name = "checkBoxUlLimit";
            checkBoxUlLimit.Size = new Size(193, 21);
            checkBoxUlLimit.TabIndex = 5;
            checkBoxUlLimit.Text = "UL Limit (KB/s)";
            checkBoxUlLimit.ThreeState = true;
            checkBoxUlLimit.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDlLimit
            // 
            numericUpDownDlLimit.Dock = DockStyle.Fill;
            numericUpDownDlLimit.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownDlLimit.Location = new Point(569, 5);
            numericUpDownDlLimit.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numericUpDownDlLimit.Name = "numericUpDownDlLimit";
            numericUpDownDlLimit.Size = new Size(94, 23);
            numericUpDownDlLimit.TabIndex = 6;
            // 
            // numericUpDownUlLimit
            // 
            numericUpDownUlLimit.Dock = DockStyle.Fill;
            numericUpDownUlLimit.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownUlLimit.Location = new Point(569, 32);
            numericUpDownUlLimit.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numericUpDownUlLimit.Name = "numericUpDownUlLimit";
            numericUpDownUlLimit.Size = new Size(94, 23);
            numericUpDownUlLimit.TabIndex = 7;
            // 
            // checkBoxRatioLimit
            // 
            checkBoxRatioLimit.Checked = true;
            checkBoxRatioLimit.CheckState = CheckState.Indeterminate;
            checkBoxRatioLimit.Dock = DockStyle.Fill;
            checkBoxRatioLimit.Location = new Point(370, 59);
            checkBoxRatioLimit.Name = "checkBoxRatioLimit";
            checkBoxRatioLimit.Size = new Size(193, 21);
            checkBoxRatioLimit.TabIndex = 8;
            checkBoxRatioLimit.Text = "Ratio Limit";
            checkBoxRatioLimit.ThreeState = true;
            checkBoxRatioLimit.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeedingLimit
            // 
            checkBoxSeedingLimit.Checked = true;
            checkBoxSeedingLimit.CheckState = CheckState.Indeterminate;
            checkBoxSeedingLimit.Dock = DockStyle.Fill;
            checkBoxSeedingLimit.Location = new Point(370, 86);
            checkBoxSeedingLimit.Name = "checkBoxSeedingLimit";
            checkBoxSeedingLimit.Size = new Size(193, 21);
            checkBoxSeedingLimit.TabIndex = 9;
            checkBoxSeedingLimit.Text = "Seeding Time Limit (min)";
            checkBoxSeedingLimit.ThreeState = true;
            checkBoxSeedingLimit.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRatioLimit
            // 
            numericUpDownRatioLimit.DecimalPlaces = 2;
            numericUpDownRatioLimit.Dock = DockStyle.Fill;
            numericUpDownRatioLimit.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownRatioLimit.Location = new Point(569, 59);
            numericUpDownRatioLimit.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numericUpDownRatioLimit.Name = "numericUpDownRatioLimit";
            numericUpDownRatioLimit.Size = new Size(94, 23);
            numericUpDownRatioLimit.TabIndex = 10;
            // 
            // numericUpDownSeedingLimit
            // 
            numericUpDownSeedingLimit.Dock = DockStyle.Fill;
            numericUpDownSeedingLimit.Increment = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownSeedingLimit.Location = new Point(569, 86);
            numericUpDownSeedingLimit.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numericUpDownSeedingLimit.Name = "numericUpDownSeedingLimit";
            numericUpDownSeedingLimit.Size = new Size(94, 23);
            numericUpDownSeedingLimit.TabIndex = 11;
            // 
            // checkBoxInactiveSeedingLimit
            // 
            checkBoxInactiveSeedingLimit.Checked = true;
            checkBoxInactiveSeedingLimit.CheckState = CheckState.Indeterminate;
            checkBoxInactiveSeedingLimit.Dock = DockStyle.Fill;
            checkBoxInactiveSeedingLimit.Location = new Point(370, 113);
            checkBoxInactiveSeedingLimit.Name = "checkBoxInactiveSeedingLimit";
            checkBoxInactiveSeedingLimit.Size = new Size(193, 22);
            checkBoxInactiveSeedingLimit.TabIndex = 12;
            checkBoxInactiveSeedingLimit.Text = "Inactive Seeding Time Limit";
            checkBoxInactiveSeedingLimit.ThreeState = true;
            checkBoxInactiveSeedingLimit.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Increment = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDown1.Location = new Point(569, 113);
            numericUpDown1.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(94, 23);
            numericUpDown1.TabIndex = 13;
            // 
            // checkBoxQueueTop
            // 
            checkBoxQueueTop.AutoSize = true;
            checkBoxQueueTop.Checked = true;
            checkBoxQueueTop.CheckState = CheckState.Indeterminate;
            checkBoxQueueTop.Dock = DockStyle.Fill;
            checkBoxQueueTop.Location = new Point(171, 32);
            checkBoxQueueTop.Name = "checkBoxQueueTop";
            checkBoxQueueTop.Size = new Size(160, 21);
            checkBoxQueueTop.TabIndex = 14;
            checkBoxQueueTop.Text = "Add To Top of Queue";
            checkBoxQueueTop.ThreeState = true;
            checkBoxQueueTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxFLPrio
            // 
            checkBoxFLPrio.AutoSize = true;
            checkBoxFLPrio.Checked = true;
            checkBoxFLPrio.CheckState = CheckState.Checked;
            checkBoxFLPrio.Dock = DockStyle.Fill;
            checkBoxFLPrio.Location = new Point(5, 59);
            checkBoxFLPrio.Name = "checkBoxFLPrio";
            checkBoxFLPrio.Size = new Size(160, 21);
            checkBoxFLPrio.TabIndex = 15;
            checkBoxFLPrio.Text = "Prioritize Edge Pieces";
            checkBoxFLPrio.UseVisualStyleBackColor = true;
            // 
            // checkBoxSequential
            // 
            checkBoxSequential.AutoSize = true;
            checkBoxSequential.Dock = DockStyle.Fill;
            checkBoxSequential.Location = new Point(171, 59);
            checkBoxSequential.Name = "checkBoxSequential";
            checkBoxSequential.Size = new Size(160, 21);
            checkBoxSequential.TabIndex = 16;
            checkBoxSequential.Text = "Download Sequentially";
            checkBoxSequential.UseVisualStyleBackColor = true;
            // 
            // checkBoxRootFolder
            // 
            checkBoxRootFolder.AutoSize = true;
            checkBoxRootFolder.Checked = true;
            checkBoxRootFolder.CheckState = CheckState.Indeterminate;
            checkBoxRootFolder.Dock = DockStyle.Fill;
            checkBoxRootFolder.Location = new Point(5, 86);
            checkBoxRootFolder.Name = "checkBoxRootFolder";
            checkBoxRootFolder.Size = new Size(160, 21);
            checkBoxRootFolder.TabIndex = 17;
            checkBoxRootFolder.Text = "Create Root Folder";
            checkBoxRootFolder.ThreeState = true;
            checkBoxRootFolder.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(6, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(668, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 65);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 2;
            label2.Text = "Save as:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(6, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(668, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(115, 17);
            label1.TabIndex = 0;
            label1.Text = "Destination folder:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(labelSelectedSize);
            groupBox2.Controls.Add(btnSelectNone);
            groupBox2.Controls.Add(btnSelectAll);
            groupBox2.Controls.Add(listView1);
            groupBox2.Location = new Point(12, 284);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(680, 350);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Torrent contents";
            // 
            // labelSelectedSize
            // 
            labelSelectedSize.AutoSize = true;
            labelSelectedSize.Location = new Point(6, 25);
            labelSelectedSize.Name = "labelSelectedSize";
            labelSelectedSize.Size = new Size(34, 17);
            labelSelectedSize.TabIndex = 3;
            labelSelectedSize.Text = "Size:";
            // 
            // btnSelectNone
            // 
            btnSelectNone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectNone.Location = new Point(574, 21);
            btnSelectNone.Name = "btnSelectNone";
            btnSelectNone.Size = new Size(100, 25);
            btnSelectNone.TabIndex = 2;
            btnSelectNone.Text = "Select None";
            btnSelectNone.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectAll.Location = new Point(459, 21);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(100, 25);
            btnSelectAll.TabIndex = 1;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Location = new Point(6, 51);
            listView1.Name = "listView1";
            listView1.Size = new Size(668, 292);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(527, 644);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 25);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(617, 644);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddTorrent
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(704, 681);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTorrent";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Torrent";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanelOptions.ResumeLayout(false);
            tableLayoutPanelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDlLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUlLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRatioLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeedingLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown numericUpDownRatioLimit;
        private System.Windows.Forms.NumericUpDown numericUpDownSeedingLimit;

        private System.Windows.Forms.CheckBox checkBoxRatioLimit;
        private System.Windows.Forms.CheckBox checkBoxSeedingLimit;

        private System.Windows.Forms.NumericUpDown numericUpDownDlLimit;
        private System.Windows.Forms.NumericUpDown numericUpDownUlLimit;

        private System.Windows.Forms.CheckBox checkBoxDlLimit;

        private System.Windows.Forms.CheckBox checkBoxUlLimit;

        private System.Windows.Forms.CheckBox checkBoxSkipChecking;

        private System.Windows.Forms.CheckBox checkBoxStartNow;

        private System.Windows.Forms.CheckBox checkBoxTMM;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;

        #endregion

        private CheckBox checkBoxInactiveSeedingLimit;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBoxQueueTop;
        private CheckBox checkBoxFLPrio;
        private CheckBox checkBoxSequential;
        private CheckBox checkBoxRootFolder;
        private Label labelSelectedSize;
        private Button btnSelectNone;
        private Button btnSelectAll;
        private ListView listView1;
        private Button btnOK;
        private Button btnCancel;
    }
}