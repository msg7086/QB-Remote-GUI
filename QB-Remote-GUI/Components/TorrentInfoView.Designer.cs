namespace QB_Remote_GUI.Components
{
    partial class TorrentInfoView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tableLayoutPanelTransfer = new TableLayoutPanel();
            label2 = new Label();
            tableLayoutPanelTorrent = new TableLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 28);
            label1.TabIndex = 0;
            label1.Text = "Transfer";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelTransfer
            // 
            tableLayoutPanelTransfer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelTransfer.ColumnCount = 6;
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanelTransfer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanelTransfer.Location = new Point(0, 28);
            tableLayoutPanelTransfer.Name = "tableLayoutPanelTransfer";
            tableLayoutPanelTransfer.RowCount = 6;
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTransfer.Size = new Size(800, 172);
            tableLayoutPanelTransfer.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = SystemColors.ControlLight;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(0, 200);
            label2.Name = "label2";
            label2.Size = new Size(800, 28);
            label2.TabIndex = 2;
            label2.Text = "Torrent";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelTorrent
            // 
            tableLayoutPanelTorrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelTorrent.ColumnCount = 4;
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000038F));
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelTorrent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelTorrent.Location = new Point(0, 228);
            tableLayoutPanelTorrent.Name = "tableLayoutPanelTorrent";
            tableLayoutPanelTorrent.RowCount = 6;
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelTorrent.Size = new Size(800, 172);
            tableLayoutPanelTorrent.TabIndex = 3;
            // 
            // TorrentInfoView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(tableLayoutPanelTorrent);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanelTransfer);
            Controls.Add(label1);
            Name = "TorrentInfoView";
            Size = new Size(800, 400);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanelTransfer;
        private Label label2;
        private TableLayoutPanel tableLayoutPanelTorrent;
    }
}
