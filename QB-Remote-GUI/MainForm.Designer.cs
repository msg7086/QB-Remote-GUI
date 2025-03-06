using QB_Remote_GUI.GUI.Components;

namespace QB_Remote_GUI.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new System.Windows.Forms.MenuStrip();
            menuTorrent = new System.Windows.Forms.ToolStripMenuItem();
            menuitemConnect = new System.Windows.Forms.ToolStripMenuItem();
            sepTsddMenuConnect = new System.Windows.Forms.ToolStripSeparator();
            tsddManageConnection = new System.Windows.Forms.ToolStripMenuItem();
            menuitemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuitemAddTorrent = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuitemStartTorrent = new System.Windows.Forms.ToolStripMenuItem();
            menuitemPauseTorrent = new System.Windows.Forms.ToolStripMenuItem();
            menuitemDeleteTorrent = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            menuitemExit = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip = new System.Windows.Forms.ToolStrip();
            tsbspConnect = new System.Windows.Forms.ToolStripSplitButton();
            sepTsbConnect = new System.Windows.Forms.ToolStripSeparator();
            tsbManageConnection = new System.Windows.Forms.ToolStripMenuItem();
            tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            tsbAddTorrent = new System.Windows.Forms.ToolStripButton();
            tsbStartTorrent = new System.Windows.Forms.ToolStripButton();
            tsbPauseTorrent = new System.Windows.Forms.ToolStripButton();
            tsbDeleteTorrent = new System.Windows.Forms.ToolStripButton();
            statusStrip = new System.Windows.Forms.StatusStrip();
            downloadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            uploadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            stateTreeView = new System.Windows.Forms.TreeView();
            imgCategory = new System.Windows.Forms.ImageList(components);
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            torrentListView = new System.Windows.Forms.ListView();
            nameColumn = new System.Windows.Forms.ColumnHeader();
            sizeColumn = new System.Windows.Forms.ColumnHeader();
            progressColumn = new System.Windows.Forms.ColumnHeader();
            statusColumn = new System.Windows.Forms.ColumnHeader();
            downloadSpeedColumn = new System.Windows.Forms.ColumnHeader();
            uploadSpeedColumn = new System.Windows.Forms.ColumnHeader();
            contextMenuTorrentListView = new System.Windows.Forms.ContextMenuStrip(components);
            tsConfigureTorrentColumns = new System.Windows.Forms.ToolStripMenuItem();
            imgTorrent = new System.Windows.Forms.ImageList(components);
            tabControl = new System.Windows.Forms.TabControl();
            generalTab = new System.Windows.Forms.TabPage();
            torrentInfoView1 = new QB_Remote_GUI.GUI.Components.TorrentInfoView();
            torrentPieceView1 = new QB_Remote_GUI.GUI.Components.TorrentPieceView();
            trackersTab = new System.Windows.Forms.TabPage();
            trackerListView = new System.Windows.Forms.ListView();
            urlColumn = new System.Windows.Forms.ColumnHeader();
            statusColumn2 = new System.Windows.Forms.ColumnHeader();
            peersTab = new System.Windows.Forms.TabPage();
            peerListView = new System.Windows.Forms.ListView();
            ipColumn = new System.Windows.Forms.ColumnHeader();
            clientColumn = new System.Windows.Forms.ColumnHeader();
            flagsColumn = new System.Windows.Forms.ColumnHeader();
            progressColumn2 = new System.Windows.Forms.ColumnHeader();
            downloadSpeedColumn2 = new System.Windows.Forms.ColumnHeader();
            uploadSpeedColumn2 = new System.Windows.Forms.ColumnHeader();
            contextMenuPeerListView = new System.Windows.Forms.ContextMenuStrip(components);
            tsConfigurePeerColumns = new System.Windows.Forms.ToolStripMenuItem();
            filesTab = new System.Windows.Forms.TabPage();
            fileListView = new System.Windows.Forms.ListView();
            contextMenuFileListView = new System.Windows.Forms.ContextMenuStrip(components);
            tsConfigureFileColumns = new System.Windows.Forms.ToolStripMenuItem();
            timerSync = new System.Windows.Forms.Timer(components);
            imgFiles = new System.Windows.Forms.ImageList(components);
            imgToolStrip = new System.Windows.Forms.ImageList(components);
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            contextMenuTorrentListView.SuspendLayout();
            tabControl.SuspendLayout();
            generalTab.SuspendLayout();
            trackersTab.SuspendLayout();
            peersTab.SuspendLayout();
            contextMenuPeerListView.SuspendLayout();
            filesTab.SuspendLayout();
            contextMenuFileListView.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuTorrent });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(1264, 25);
            menuStrip.TabIndex = 0;
            // 
            // menuTorrent
            // 
            menuTorrent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuitemConnect, menuitemDisconnect, toolStripSeparator1, menuitemAddTorrent, toolStripSeparator2, menuitemStartTorrent, menuitemPauseTorrent, menuitemDeleteTorrent, toolStripSeparator4, menuitemExit });
            menuTorrent.Name = "menuTorrent";
            menuTorrent.Size = new System.Drawing.Size(63, 21);
            menuTorrent.Text = "Torrent";
            // 
            // menuitemConnect
            // 
            menuitemConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { sepTsddMenuConnect, tsddManageConnection });
            menuitemConnect.Name = "menuitemConnect";
            menuitemConnect.Size = new System.Drawing.Size(251, 22);
            menuitemConnect.Text = "Connect to Transmission...";
            // 
            // sepTsddMenuConnect
            // 
            sepTsddMenuConnect.Name = "sepTsddMenuConnect";
            sepTsddMenuConnect.Size = new System.Drawing.Size(194, 6);
            // 
            // tsddManageConnection
            // 
            tsddManageConnection.Name = "tsddManageConnection";
            tsddManageConnection.Size = new System.Drawing.Size(197, 22);
            tsddManageConnection.Text = "Manage connections";
            tsddManageConnection.Click += ManageConnections;
            // 
            // menuitemDisconnect
            // 
            menuitemDisconnect.Name = "menuitemDisconnect";
            menuitemDisconnect.Size = new System.Drawing.Size(251, 22);
            menuitemDisconnect.Text = "Disconnect from Transmission";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // menuitemAddTorrent
            // 
            menuitemAddTorrent.Name = "menuitemAddTorrent";
            menuitemAddTorrent.Size = new System.Drawing.Size(251, 22);
            menuitemAddTorrent.Text = "Add Torrent...";
            menuitemAddTorrent.Click += AddTorrent;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(248, 6);
            // 
            // menuitemStartTorrent
            // 
            menuitemStartTorrent.Name = "menuitemStartTorrent";
            menuitemStartTorrent.Size = new System.Drawing.Size(251, 22);
            menuitemStartTorrent.Text = "Start";
            menuitemStartTorrent.Click += StartTorrents;
            // 
            // menuitemPauseTorrent
            // 
            menuitemPauseTorrent.Name = "menuitemPauseTorrent";
            menuitemPauseTorrent.Size = new System.Drawing.Size(251, 22);
            menuitemPauseTorrent.Text = "Stop";
            menuitemPauseTorrent.Click += PauseTorrents;
            // 
            // menuitemDeleteTorrent
            // 
            menuitemDeleteTorrent.Name = "menuitemDeleteTorrent";
            menuitemDeleteTorrent.Size = new System.Drawing.Size(251, 22);
            menuitemDeleteTorrent.Text = "Remove";
            menuitemDeleteTorrent.Click += DeleteTorrents;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(248, 6);
            // 
            // menuitemExit
            // 
            menuitemExit.Name = "menuitemExit";
            menuitemExit.Size = new System.Drawing.Size(251, 22);
            menuitemExit.Text = "Exit";
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbspConnect, tsbDisconnect, toolStripSeparator3, tsbAddTorrent, tsbStartTorrent, tsbPauseTorrent, tsbDeleteTorrent });
            toolStrip.Location = new System.Drawing.Point(0, 25);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(1264, 25);
            toolStrip.TabIndex = 1;
            // 
            // tsbspConnect
            // 
            tsbspConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { sepTsbConnect, tsbManageConnection });
            tsbspConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbspConnect.Name = "tsbspConnect";
            tsbspConnect.Size = new System.Drawing.Size(167, 22);
            tsbspConnect.Text = "Connect to Transmission";
            tsbspConnect.ButtonClick += ConnectLastConn;
            // 
            // sepTsbConnect
            // 
            sepTsbConnect.Name = "sepTsbConnect";
            sepTsbConnect.Size = new System.Drawing.Size(194, 6);
            // 
            // tsbManageConnection
            // 
            tsbManageConnection.Name = "tsbManageConnection";
            tsbManageConnection.Size = new System.Drawing.Size(197, 22);
            tsbManageConnection.Text = "Manage connections";
            // 
            // tsbDisconnect
            // 
            tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbDisconnect.Name = "tsbDisconnect";
            tsbDisconnect.Size = new System.Drawing.Size(23, 22);
            tsbDisconnect.Click += Disconnect;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddTorrent
            // 
            tsbAddTorrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbAddTorrent.Name = "tsbAddTorrent";
            tsbAddTorrent.Size = new System.Drawing.Size(23, 22);
            tsbAddTorrent.Click += AddTorrent;
            // 
            // tsbStartTorrent
            // 
            tsbStartTorrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbStartTorrent.Name = "tsbStartTorrent";
            tsbStartTorrent.Size = new System.Drawing.Size(23, 22);
            tsbStartTorrent.Click += StartTorrents;
            // 
            // tsbPauseTorrent
            // 
            tsbPauseTorrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPauseTorrent.Name = "tsbPauseTorrent";
            tsbPauseTorrent.Size = new System.Drawing.Size(23, 22);
            tsbPauseTorrent.Click += PauseTorrents;
            // 
            // tsbDeleteTorrent
            // 
            tsbDeleteTorrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbDeleteTorrent.Name = "tsbDeleteTorrent";
            tsbDeleteTorrent.Size = new System.Drawing.Size(23, 22);
            tsbDeleteTorrent.Click += DeleteTorrents;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { downloadSpeedLabel, uploadSpeedLabel, connectionStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 939);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(1264, 22);
            statusStrip.TabIndex = 3;
            // 
            // downloadSpeedLabel
            // 
            downloadSpeedLabel.Name = "downloadSpeedLabel";
            downloadSpeedLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // uploadSpeedLabel
            // 
            uploadSpeedLabel.Name = "uploadSpeedLabel";
            uploadSpeedLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 50);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(stateTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new System.Drawing.Size(1264, 889);
            splitContainer1.SplitterDistance = 213;
            splitContainer1.TabIndex = 2;
            // 
            // stateTreeView
            // 
            stateTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            stateTreeView.ImageIndex = 0;
            stateTreeView.ImageList = imgCategory;
            stateTreeView.Location = new System.Drawing.Point(0, 0);
            stateTreeView.Name = "stateTreeView";
            stateTreeView.SelectedImageIndex = 0;
            stateTreeView.Size = new System.Drawing.Size(213, 889);
            stateTreeView.TabIndex = 0;
            stateTreeView.AfterSelect += StateTreeView_AfterSelect;
            // 
            // imgCategory
            // 
            imgCategory.ImageStream = ((System.Windows.Forms.ImageListStreamer)resources.GetObject("imgCategory.ImageStream"));
            imgCategory.TransparentColor = System.Drawing.Color.Transparent;
            imgCategory.Images.SetKeyName(0, "tr_t_all");
            imgCategory.Images.SetKeyName(1, "tr_t_down");
            imgCategory.Images.SetKeyName(2, "tr_t_up");
            imgCategory.Images.SetKeyName(3, "tr_active");
            imgCategory.Images.SetKeyName(4, "tr_t_busy");
            imgCategory.Images.SetKeyName(5, "tr_t_pause");
            imgCategory.Images.SetKeyName(6, "tr_t_error");
            imgCategory.Images.SetKeyName(7, "tr_queue");
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(torrentListView);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tabControl);
            splitContainer2.Size = new System.Drawing.Size(1047, 889);
            splitContainer2.SplitterDistance = 508;
            splitContainer2.TabIndex = 0;
            // 
            // torrentListView
            // 
            torrentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { nameColumn, sizeColumn, progressColumn, statusColumn, downloadSpeedColumn, uploadSpeedColumn });
            torrentListView.ContextMenuStrip = contextMenuTorrentListView;
            torrentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            torrentListView.Location = new System.Drawing.Point(0, 0);
            torrentListView.Name = "torrentListView";
            torrentListView.Size = new System.Drawing.Size(1047, 508);
            torrentListView.SmallImageList = imgTorrent;
            torrentListView.TabIndex = 0;
            torrentListView.UseCompatibleStateImageBehavior = false;
            torrentListView.ColumnClick += TorrentListView_ColumnClick;
            torrentListView.SelectedIndexChanged += TorrentListView_SelectedIndexChanged;
            // 
            // nameColumn
            // 
            nameColumn.Name = "nameColumn";
            // 
            // sizeColumn
            // 
            sizeColumn.Name = "sizeColumn";
            // 
            // progressColumn
            // 
            progressColumn.Name = "progressColumn";
            // 
            // statusColumn
            // 
            statusColumn.Name = "statusColumn";
            // 
            // downloadSpeedColumn
            // 
            downloadSpeedColumn.Name = "downloadSpeedColumn";
            // 
            // uploadSpeedColumn
            // 
            uploadSpeedColumn.Name = "uploadSpeedColumn";
            // 
            // contextMenuTorrentListView
            // 
            contextMenuTorrentListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsConfigureTorrentColumns });
            contextMenuTorrentListView.Name = "contextMenuTorrentListView";
            contextMenuTorrentListView.Size = new System.Drawing.Size(162, 26);
            // 
            // tsConfigureTorrentColumns
            // 
            tsConfigureTorrentColumns.Name = "tsConfigureTorrentColumns";
            tsConfigureTorrentColumns.Size = new System.Drawing.Size(161, 22);
            tsConfigureTorrentColumns.Text = "Setup columns";
            tsConfigureTorrentColumns.Click += ConfigureTorrentListViewColumns;
            // 
            // imgTorrent
            // 
            imgTorrent.ImageStream = ((System.Windows.Forms.ImageListStreamer)resources.GetObject("imgTorrent.ImageStream"));
            imgTorrent.TransparentColor = System.Drawing.Color.Transparent;
            imgTorrent.Images.SetKeyName(0, "tr_t_busy");
            imgTorrent.Images.SetKeyName(1, "tr_t_done");
            imgTorrent.Images.SetKeyName(2, "tr_t_down");
            imgTorrent.Images.SetKeyName(3, "tr_t_downerror");
            imgTorrent.Images.SetKeyName(4, "tr_t_downqueue");
            imgTorrent.Images.SetKeyName(5, "tr_t_error");
            imgTorrent.Images.SetKeyName(6, "tr_t_pause");
            imgTorrent.Images.SetKeyName(7, "tr_t_up");
            imgTorrent.Images.SetKeyName(8, "tr_t_uperror");
            imgTorrent.Images.SetKeyName(9, "tr_t_upqueue");
            // 
            // tabControl
            // 
            tabControl.Controls.Add(generalTab);
            tabControl.Controls.Add(trackersTab);
            tabControl.Controls.Add(peersTab);
            tabControl.Controls.Add(filesTab);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1047, 377);
            tabControl.TabIndex = 0;
            // 
            // generalTab
            // 
            generalTab.Controls.Add(torrentInfoView1);
            generalTab.Controls.Add(torrentPieceView1);
            generalTab.Location = new System.Drawing.Point(4, 26);
            generalTab.Name = "generalTab";
            generalTab.Size = new System.Drawing.Size(1039, 347);
            generalTab.TabIndex = 0;
            generalTab.Text = "General";
            // 
            // torrentInfoView1
            // 
            torrentInfoView1.AutoScroll = true;
            torrentInfoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            torrentInfoView1.Location = new System.Drawing.Point(0, 48);
            torrentInfoView1.Name = "torrentInfoView1";
            torrentInfoView1.Size = new System.Drawing.Size(1039, 299);
            torrentInfoView1.TabIndex = 1;
            // 
            // torrentPieceView1
            // 
            torrentPieceView1.Dock = System.Windows.Forms.DockStyle.Top;
            torrentPieceView1.Location = new System.Drawing.Point(0, 0);
            torrentPieceView1.Name = "torrentPieceView1";
            torrentPieceView1.Size = new System.Drawing.Size(1039, 48);
            torrentPieceView1.TabIndex = 2;
            // 
            // trackersTab
            // 
            trackersTab.Controls.Add(trackerListView);
            trackersTab.Location = new System.Drawing.Point(4, 26);
            trackersTab.Name = "trackersTab";
            trackersTab.Size = new System.Drawing.Size(1039, 341);
            trackersTab.TabIndex = 1;
            trackersTab.Text = "Trackers";
            // 
            // trackerListView
            // 
            trackerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { urlColumn, statusColumn2 });
            trackerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            trackerListView.Location = new System.Drawing.Point(0, 0);
            trackerListView.Name = "trackerListView";
            trackerListView.Size = new System.Drawing.Size(1039, 341);
            trackerListView.TabIndex = 0;
            trackerListView.UseCompatibleStateImageBehavior = false;
            // 
            // urlColumn
            // 
            urlColumn.Name = "urlColumn";
            // 
            // statusColumn2
            // 
            statusColumn2.Name = "statusColumn2";
            // 
            // peersTab
            // 
            peersTab.Controls.Add(peerListView);
            peersTab.Location = new System.Drawing.Point(4, 26);
            peersTab.Name = "peersTab";
            peersTab.Size = new System.Drawing.Size(1039, 341);
            peersTab.TabIndex = 2;
            peersTab.Text = "Peers";
            // 
            // peerListView
            // 
            peerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ipColumn, clientColumn, flagsColumn, progressColumn2, downloadSpeedColumn2, uploadSpeedColumn2 });
            peerListView.ContextMenuStrip = contextMenuPeerListView;
            peerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            peerListView.Location = new System.Drawing.Point(0, 0);
            peerListView.Name = "peerListView";
            peerListView.Size = new System.Drawing.Size(1039, 341);
            peerListView.TabIndex = 0;
            peerListView.UseCompatibleStateImageBehavior = false;
            // 
            // ipColumn
            // 
            ipColumn.Name = "ipColumn";
            // 
            // clientColumn
            // 
            clientColumn.Name = "clientColumn";
            // 
            // flagsColumn
            // 
            flagsColumn.Name = "flagsColumn";
            // 
            // progressColumn2
            // 
            progressColumn2.Name = "progressColumn2";
            // 
            // downloadSpeedColumn2
            // 
            downloadSpeedColumn2.Name = "downloadSpeedColumn2";
            // 
            // uploadSpeedColumn2
            // 
            uploadSpeedColumn2.Name = "uploadSpeedColumn2";
            // 
            // contextMenuPeerListView
            // 
            contextMenuPeerListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsConfigurePeerColumns });
            contextMenuPeerListView.Name = "contextMenuPeerListView";
            contextMenuPeerListView.Size = new System.Drawing.Size(162, 26);
            // 
            // tsConfigurePeerColumns
            // 
            tsConfigurePeerColumns.Name = "tsConfigurePeerColumns";
            tsConfigurePeerColumns.Size = new System.Drawing.Size(161, 22);
            tsConfigurePeerColumns.Text = "Setup columns";
            tsConfigurePeerColumns.Click += ConfigurePeerListViewColumns;
            // 
            // filesTab
            // 
            filesTab.Controls.Add(fileListView);
            filesTab.Location = new System.Drawing.Point(4, 26);
            filesTab.Name = "filesTab";
            filesTab.Size = new System.Drawing.Size(1039, 341);
            filesTab.TabIndex = 3;
            filesTab.Text = "Files";
            // 
            // fileListView
            // 
            fileListView.ContextMenuStrip = contextMenuFileListView;
            fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            fileListView.Location = new System.Drawing.Point(0, 0);
            fileListView.Name = "fileListView";
            fileListView.Size = new System.Drawing.Size(1039, 341);
            fileListView.TabIndex = 0;
            fileListView.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuFileListView
            // 
            contextMenuFileListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsConfigureFileColumns });
            contextMenuFileListView.Name = "tsConfigureFileColumns";
            contextMenuFileListView.Size = new System.Drawing.Size(162, 26);
            contextMenuFileListView.Click += ConfigureFileListViewColumns;
            // 
            // tsConfigureFileColumns
            // 
            tsConfigureFileColumns.Name = "tsConfigureFileColumns";
            tsConfigureFileColumns.Size = new System.Drawing.Size(161, 22);
            tsConfigureFileColumns.Text = "Setup columns";
            // 
            // timerSync
            // 
            timerSync.Enabled = true;
            timerSync.Interval = 5000;
            timerSync.Tick += timerSync_Tick;
            // 
            // imgFiles
            // 
            imgFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)resources.GetObject("imgFiles.ImageStream"));
            imgFiles.TransparentColor = System.Drawing.Color.Transparent;
            imgFiles.Images.SetKeyName(0, "tr_dir.png");
            imgFiles.Images.SetKeyName(1, "sui-right.png");
            imgFiles.Images.SetKeyName(2, "sui-down.png");
            // 
            // imgToolStrip
            // 
            imgToolStrip.ImageStream = ((System.Windows.Forms.ImageListStreamer)resources.GetObject("imgToolStrip.ImageStream"));
            imgToolStrip.TransparentColor = System.Drawing.Color.Transparent;
            imgToolStrip.Images.SetKeyName(0, "tr32_connect.png");
            imgToolStrip.Images.SetKeyName(1, "tr32_disconnect.png");
            imgToolStrip.Images.SetKeyName(2, "tr32_add.png");
            imgToolStrip.Images.SetKeyName(3, "tr32_magnet.png");
            imgToolStrip.Images.SetKeyName(4, "tr32_start.png");
            imgToolStrip.Images.SetKeyName(5, "tr32_pause.png");
            imgToolStrip.Images.SetKeyName(6, "tr32_del.png");
            imgToolStrip.Images.SetKeyName(7, "tr32_movedown.png");
            imgToolStrip.Images.SetKeyName(8, "tr32_moveup.png");
            imgToolStrip.Images.SetKeyName(9, "tr32_qbconfig.png");
            imgToolStrip.Images.SetKeyName(10, "tr32_config.png");
            imgToolStrip.Images.SetKeyName(11, "tr32_speedlimit.png");
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(1264, 961);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            MainMenuStrip = menuStrip;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "QB Remote GUI";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            contextMenuTorrentListView.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            generalTab.ResumeLayout(false);
            trackersTab.ResumeLayout(false);
            peersTab.ResumeLayout(false);
            contextMenuPeerListView.ResumeLayout(false);
            filesTab.ResumeLayout(false);
            contextMenuFileListView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ImageList imgToolStrip;

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuTorrent;
        private ToolStripMenuItem menuitemAddTorrent;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuitemStartTorrent;
        private ToolStripMenuItem menuitemPauseTorrent;
        private ToolStripMenuItem menuitemDeleteTorrent;
        private ToolStrip toolStrip;
        private ToolStripButton tsbDisconnect;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsbAddTorrent;
        private ToolStripButton tsbStartTorrent;
        private ToolStripButton tsbPauseTorrent;
        private ToolStripButton tsbDeleteTorrent;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel downloadSpeedLabel;
        private ToolStripStatusLabel uploadSpeedLabel;
        private ToolStripStatusLabel connectionStatusLabel;
        private SplitContainer splitContainer1;
        private TreeView stateTreeView;
        private SplitContainer splitContainer2;
        internal ListView torrentListView;
        internal ColumnHeader nameColumn;
        internal ColumnHeader sizeColumn;
        internal ColumnHeader progressColumn;
        internal ColumnHeader statusColumn;
        internal ColumnHeader downloadSpeedColumn;
        internal ColumnHeader uploadSpeedColumn;
        private TabControl tabControl;
        private TabPage generalTab;
        private TabPage trackersTab;
        private ListView trackerListView;
        private ColumnHeader urlColumn;
        private ColumnHeader statusColumn2;
        private TabPage peersTab;
        internal ListView peerListView;
        private ColumnHeader ipColumn;
        private ColumnHeader clientColumn;
        private ColumnHeader flagsColumn;
        private ColumnHeader progressColumn2;
        private ColumnHeader downloadSpeedColumn2;
        private ColumnHeader uploadSpeedColumn2;
        private TabPage filesTab;

        #endregion
        private ToolStripMenuItem menuitemConnect;
        private ToolStripMenuItem menuitemDisconnect;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem menuitemExit;
        private System.Windows.Forms.ToolStripSplitButton tsbspConnect;
        private ToolStripSeparator sepTsbConnect;
        private ToolStripMenuItem tsbManageConnection;
        private ToolStripSeparator sepTsddMenuConnect;
        private ToolStripMenuItem tsddManageConnection;
        private ImageList imgTorrent;
        private ContextMenuStrip contextMenuTorrentListView;
        private ToolStripMenuItem tsConfigureTorrentColumns;
        private System.Windows.Forms.Timer timerSync;
        private ImageList imgCategory;
        private Components.TorrentInfoView torrentInfoView1;
        private Components.TorrentPieceView torrentPieceView1;
        private ContextMenuStrip contextMenuPeerListView;
        private ToolStripMenuItem tsConfigurePeerColumns;
        private ListView fileListView;
        private ImageList imgFiles;
        private ContextMenuStrip contextMenuFileListView;
        private ToolStripMenuItem tsConfigureFileColumns;
    }
}
