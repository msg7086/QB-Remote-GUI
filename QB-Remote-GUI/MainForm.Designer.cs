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
            menuStrip = new MenuStrip();
            menuTorrent = new ToolStripMenuItem();
            menuitemConnect = new ToolStripMenuItem();
            sepTsddMenuConnect = new ToolStripSeparator();
            tsddManageConnection = new ToolStripMenuItem();
            menuitemDisconnect = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuitemAddTorrent = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuitemStartTorrent = new ToolStripMenuItem();
            menuitemPauseTorrent = new ToolStripMenuItem();
            menuitemDeleteTorrent = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            menuitemExit = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            tsbspConnect = new ToolStripSplitButton();
            sepTsbConnect = new ToolStripSeparator();
            tsbManageConnection = new ToolStripMenuItem();
            tsbDisconnect = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbAddTorrent = new ToolStripButton();
            tsbStartTorrent = new ToolStripButton();
            tsbPauseTorrent = new ToolStripButton();
            tsbDeleteTorrent = new ToolStripButton();
            statusStrip = new StatusStrip();
            downloadSpeedLabel = new ToolStripStatusLabel();
            uploadSpeedLabel = new ToolStripStatusLabel();
            connectionStatusLabel = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            stateTreeView = new TreeView();
            imgCategory = new ImageList(components);
            splitContainer2 = new SplitContainer();
            torrentListView = new ListView();
            nameColumn = new ColumnHeader();
            sizeColumn = new ColumnHeader();
            progressColumn = new ColumnHeader();
            statusColumn = new ColumnHeader();
            downloadSpeedColumn = new ColumnHeader();
            uploadSpeedColumn = new ColumnHeader();
            contextMenuTorrentListView = new ContextMenuStrip(components);
            tsConfigureTorrentColumns = new ToolStripMenuItem();
            imgTorrent = new ImageList(components);
            tabControl = new TabControl();
            generalTab = new TabPage();
            torrentInfoView1 = new TorrentInfoView();
            torrentPieceView1 = new TorrentPieceView();
            trackersTab = new TabPage();
            trackerListView = new ListView();
            urlColumn = new ColumnHeader();
            statusColumn2 = new ColumnHeader();
            peersTab = new TabPage();
            peerListView = new ListView();
            ipColumn = new ColumnHeader();
            clientColumn = new ColumnHeader();
            flagsColumn = new ColumnHeader();
            progressColumn2 = new ColumnHeader();
            downloadSpeedColumn2 = new ColumnHeader();
            uploadSpeedColumn2 = new ColumnHeader();
            contextMenuPeerListView = new ContextMenuStrip(components);
            tsConfigurePeerColumns = new ToolStripMenuItem();
            filesTab = new TabPage();
            fileListView = new ListView();
            contextMenuFileListView = new ContextMenuStrip(components);
            tsConfigureFileColumns = new ToolStripMenuItem();
            timerSync = new System.Windows.Forms.Timer(components);
            imgFiles = new ImageList(components);
            imgToolStrip = new ImageList(components);
            tsTorrentOpen = new ToolStripMenuItem();
            tsTorrentOpenFolder = new ToolStripMenuItem();
            tsTorrentSep1 = new ToolStripSeparator();
            tsTorrentStart = new ToolStripMenuItem();
            tsTorrentForceStart = new ToolStripMenuItem();
            tsTorrentStop = new ToolStripMenuItem();
            tsTorrentRemove = new ToolStripMenuItem();
            tsTorrentRemoveData = new ToolStripMenuItem();
            tsTorrentSep2 = new ToolStripSeparator();
            tsTorrentQueue = new ToolStripMenuItem();
            tsTorrentReannounce = new ToolStripMenuItem();
            tsTorrentVerify = new ToolStripMenuItem();
            tsTorrentCopyMagnet = new ToolStripMenuItem();
            tsTorrentRelocate = new ToolStripMenuItem();
            tsTorrentLabels = new ToolStripMenuItem();
            tsTorrentRename = new ToolStripMenuItem();
            tsTorrentSep3 = new ToolStripSeparator();
            tsTorrentSep4 = new ToolStripSeparator();
            tsTorrentProperties = new ToolStripMenuItem();
            imgMenu = new ImageList(components);
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
            menuStrip.Items.AddRange(new ToolStripItem[] { menuTorrent });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1264, 25);
            menuStrip.TabIndex = 0;
            // 
            // menuTorrent
            // 
            menuTorrent.DropDownItems.AddRange(new ToolStripItem[] { menuitemConnect, menuitemDisconnect, toolStripSeparator1, menuitemAddTorrent, toolStripSeparator2, menuitemStartTorrent, menuitemPauseTorrent, menuitemDeleteTorrent, toolStripSeparator4, menuitemExit });
            menuTorrent.Name = "menuTorrent";
            menuTorrent.Size = new Size(63, 21);
            menuTorrent.Text = "Torrent";
            // 
            // menuitemConnect
            // 
            menuitemConnect.DropDownItems.AddRange(new ToolStripItem[] { sepTsddMenuConnect, tsddManageConnection });
            menuitemConnect.Name = "menuitemConnect";
            menuitemConnect.Size = new Size(251, 22);
            menuitemConnect.Text = "Connect to Transmission...";
            // 
            // sepTsddMenuConnect
            // 
            sepTsddMenuConnect.Name = "sepTsddMenuConnect";
            sepTsddMenuConnect.Size = new Size(194, 6);
            // 
            // tsddManageConnection
            // 
            tsddManageConnection.Name = "tsddManageConnection";
            tsddManageConnection.Size = new Size(197, 22);
            tsddManageConnection.Text = "Manage connections";
            tsddManageConnection.Click += ManageConnections;
            // 
            // menuitemDisconnect
            // 
            menuitemDisconnect.Name = "menuitemDisconnect";
            menuitemDisconnect.Size = new Size(251, 22);
            menuitemDisconnect.Text = "Disconnect from Transmission";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(248, 6);
            // 
            // menuitemAddTorrent
            // 
            menuitemAddTorrent.Name = "menuitemAddTorrent";
            menuitemAddTorrent.Size = new Size(251, 22);
            menuitemAddTorrent.Text = "Add Torrent...";
            menuitemAddTorrent.Click += AddTorrent;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(248, 6);
            // 
            // menuitemStartTorrent
            // 
            menuitemStartTorrent.Name = "menuitemStartTorrent";
            menuitemStartTorrent.Size = new Size(251, 22);
            menuitemStartTorrent.Text = "Start";
            menuitemStartTorrent.Click += StartTorrents;
            // 
            // menuitemPauseTorrent
            // 
            menuitemPauseTorrent.Name = "menuitemPauseTorrent";
            menuitemPauseTorrent.Size = new Size(251, 22);
            menuitemPauseTorrent.Text = "Stop";
            menuitemPauseTorrent.Click += PauseTorrents;
            // 
            // menuitemDeleteTorrent
            // 
            menuitemDeleteTorrent.Name = "menuitemDeleteTorrent";
            menuitemDeleteTorrent.Size = new Size(251, 22);
            menuitemDeleteTorrent.Text = "Remove";
            menuitemDeleteTorrent.Click += DeleteTorrents;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(248, 6);
            // 
            // menuitemExit
            // 
            menuitemExit.Name = "menuitemExit";
            menuitemExit.Size = new Size(251, 22);
            menuitemExit.Text = "Exit";
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(32, 32);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbspConnect, tsbDisconnect, toolStripSeparator3, tsbAddTorrent, tsbStartTorrent, tsbPauseTorrent, tsbDeleteTorrent });
            toolStrip.Location = new Point(0, 25);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1264, 25);
            toolStrip.TabIndex = 1;
            // 
            // tsbspConnect
            // 
            tsbspConnect.DropDownItems.AddRange(new ToolStripItem[] { sepTsbConnect, tsbManageConnection });
            tsbspConnect.ImageTransparentColor = Color.Magenta;
            tsbspConnect.Name = "tsbspConnect";
            tsbspConnect.Size = new Size(167, 22);
            tsbspConnect.Text = "Connect to Transmission";
            tsbspConnect.ButtonClick += ConnectLastConn;
            // 
            // sepTsbConnect
            // 
            sepTsbConnect.Name = "sepTsbConnect";
            sepTsbConnect.Size = new Size(194, 6);
            // 
            // tsbManageConnection
            // 
            tsbManageConnection.Name = "tsbManageConnection";
            tsbManageConnection.Size = new Size(197, 22);
            tsbManageConnection.Text = "Manage connections";
            tsbManageConnection.Click += ManageConnections;
            // 
            // tsbDisconnect
            // 
            tsbDisconnect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDisconnect.Name = "tsbDisconnect";
            tsbDisconnect.Size = new Size(23, 22);
            tsbDisconnect.Click += Disconnect;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // tsbAddTorrent
            // 
            tsbAddTorrent.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddTorrent.Name = "tsbAddTorrent";
            tsbAddTorrent.Size = new Size(23, 22);
            tsbAddTorrent.Click += AddTorrent;
            // 
            // tsbStartTorrent
            // 
            tsbStartTorrent.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbStartTorrent.Name = "tsbStartTorrent";
            tsbStartTorrent.Size = new Size(23, 22);
            tsbStartTorrent.Click += StartTorrents;
            // 
            // tsbPauseTorrent
            // 
            tsbPauseTorrent.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbPauseTorrent.Name = "tsbPauseTorrent";
            tsbPauseTorrent.Size = new Size(23, 22);
            tsbPauseTorrent.Click += PauseTorrents;
            // 
            // tsbDeleteTorrent
            // 
            tsbDeleteTorrent.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteTorrent.Name = "tsbDeleteTorrent";
            tsbDeleteTorrent.Size = new Size(23, 22);
            tsbDeleteTorrent.Click += DeleteTorrents;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { downloadSpeedLabel, uploadSpeedLabel, connectionStatusLabel });
            statusStrip.Location = new Point(0, 939);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1264, 22);
            statusStrip.TabIndex = 3;
            // 
            // downloadSpeedLabel
            // 
            downloadSpeedLabel.Name = "downloadSpeedLabel";
            downloadSpeedLabel.Size = new Size(0, 17);
            // 
            // uploadSpeedLabel
            // 
            uploadSpeedLabel.Name = "uploadSpeedLabel";
            uploadSpeedLabel.Size = new Size(0, 17);
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new Size(0, 17);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 50);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(stateTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1264, 889);
            splitContainer1.SplitterDistance = 213;
            splitContainer1.TabIndex = 2;
            // 
            // stateTreeView
            // 
            stateTreeView.Dock = DockStyle.Fill;
            stateTreeView.ImageIndex = 0;
            stateTreeView.ImageList = imgCategory;
            stateTreeView.Location = new Point(0, 0);
            stateTreeView.Name = "stateTreeView";
            stateTreeView.SelectedImageIndex = 0;
            stateTreeView.Size = new Size(213, 889);
            stateTreeView.TabIndex = 0;
            stateTreeView.AfterSelect += StateTreeView_AfterSelect;
            // 
            // imgCategory
            // 
            imgCategory.ColorDepth = ColorDepth.Depth32Bit;
            imgCategory.ImageStream = (ImageListStreamer)resources.GetObject("imgCategory.ImageStream");
            imgCategory.TransparentColor = Color.Transparent;
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
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(torrentListView);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tabControl);
            splitContainer2.Size = new Size(1047, 889);
            splitContainer2.SplitterDistance = 508;
            splitContainer2.TabIndex = 0;
            // 
            // torrentListView
            // 
            torrentListView.Columns.AddRange(new ColumnHeader[] { nameColumn, sizeColumn, progressColumn, statusColumn, downloadSpeedColumn, uploadSpeedColumn });
            torrentListView.ContextMenuStrip = contextMenuTorrentListView;
            torrentListView.Dock = DockStyle.Fill;
            torrentListView.Location = new Point(0, 0);
            torrentListView.Name = "torrentListView";
            torrentListView.Size = new Size(1047, 508);
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
            contextMenuTorrentListView.Items.AddRange(new ToolStripItem[] { tsTorrentOpen, tsTorrentOpenFolder, tsTorrentSep1, tsTorrentStart, tsTorrentForceStart, tsTorrentStop, tsTorrentRemove, tsTorrentRemoveData, tsTorrentSep2, tsTorrentQueue, tsTorrentReannounce, tsTorrentVerify, tsTorrentCopyMagnet, tsTorrentRelocate, tsTorrentLabels, tsTorrentRename, tsTorrentSep3, tsTorrentProperties, tsTorrentSep4, tsConfigureTorrentColumns });
            contextMenuTorrentListView.Name = "contextMenuTorrentListView";
            contextMenuTorrentListView.Size = new Size(225, 402);
            // 
            // tsConfigureTorrentColumns
            // 
            tsConfigureTorrentColumns.Name = "tsConfigureTorrentColumns";
            tsConfigureTorrentColumns.Size = new Size(224, 22);
            tsConfigureTorrentColumns.Text = "Setup columns...";
            tsConfigureTorrentColumns.Click += ConfigureTorrentListViewColumns;
            // 
            // imgTorrent
            // 
            imgTorrent.ColorDepth = ColorDepth.Depth32Bit;
            imgTorrent.ImageStream = (ImageListStreamer)resources.GetObject("imgTorrent.ImageStream");
            imgTorrent.TransparentColor = Color.Transparent;
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
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1047, 377);
            tabControl.TabIndex = 0;
            // 
            // generalTab
            // 
            generalTab.Controls.Add(torrentInfoView1);
            generalTab.Controls.Add(torrentPieceView1);
            generalTab.Location = new Point(4, 26);
            generalTab.Name = "generalTab";
            generalTab.Size = new Size(1039, 347);
            generalTab.TabIndex = 0;
            generalTab.Text = "General";
            // 
            // torrentInfoView1
            // 
            torrentInfoView1.AutoScroll = true;
            torrentInfoView1.Dock = DockStyle.Fill;
            torrentInfoView1.Location = new Point(0, 48);
            torrentInfoView1.Name = "torrentInfoView1";
            torrentInfoView1.Size = new Size(1039, 299);
            torrentInfoView1.TabIndex = 1;
            // 
            // torrentPieceView1
            // 
            torrentPieceView1.Dock = DockStyle.Top;
            torrentPieceView1.Location = new Point(0, 0);
            torrentPieceView1.Name = "torrentPieceView1";
            torrentPieceView1.Size = new Size(1039, 48);
            torrentPieceView1.TabIndex = 2;
            // 
            // trackersTab
            // 
            trackersTab.Controls.Add(trackerListView);
            trackersTab.Location = new Point(4, 26);
            trackersTab.Name = "trackersTab";
            trackersTab.Size = new Size(1039, 347);
            trackersTab.TabIndex = 1;
            trackersTab.Text = "Trackers";
            // 
            // trackerListView
            // 
            trackerListView.Columns.AddRange(new ColumnHeader[] { urlColumn, statusColumn2 });
            trackerListView.Dock = DockStyle.Fill;
            trackerListView.Location = new Point(0, 0);
            trackerListView.Name = "trackerListView";
            trackerListView.Size = new Size(1039, 347);
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
            peersTab.Location = new Point(4, 26);
            peersTab.Name = "peersTab";
            peersTab.Size = new Size(1039, 347);
            peersTab.TabIndex = 2;
            peersTab.Text = "Peers";
            // 
            // peerListView
            // 
            peerListView.Columns.AddRange(new ColumnHeader[] { ipColumn, clientColumn, flagsColumn, progressColumn2, downloadSpeedColumn2, uploadSpeedColumn2 });
            peerListView.ContextMenuStrip = contextMenuPeerListView;
            peerListView.Dock = DockStyle.Fill;
            peerListView.Location = new Point(0, 0);
            peerListView.Name = "peerListView";
            peerListView.Size = new Size(1039, 347);
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
            contextMenuPeerListView.Items.AddRange(new ToolStripItem[] { tsConfigurePeerColumns });
            contextMenuPeerListView.Name = "contextMenuPeerListView";
            contextMenuPeerListView.Size = new Size(162, 26);
            // 
            // tsConfigurePeerColumns
            // 
            tsConfigurePeerColumns.Name = "tsConfigurePeerColumns";
            tsConfigurePeerColumns.Size = new Size(161, 22);
            tsConfigurePeerColumns.Text = "Setup columns";
            tsConfigurePeerColumns.Click += ConfigurePeerListViewColumns;
            // 
            // filesTab
            // 
            filesTab.Controls.Add(fileListView);
            filesTab.Location = new Point(4, 26);
            filesTab.Name = "filesTab";
            filesTab.Size = new Size(1039, 347);
            filesTab.TabIndex = 3;
            filesTab.Text = "Files";
            // 
            // fileListView
            // 
            fileListView.ContextMenuStrip = contextMenuFileListView;
            fileListView.Dock = DockStyle.Fill;
            fileListView.Location = new Point(0, 0);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(1039, 347);
            fileListView.TabIndex = 0;
            fileListView.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuFileListView
            // 
            contextMenuFileListView.Items.AddRange(new ToolStripItem[] { tsConfigureFileColumns });
            contextMenuFileListView.Name = "tsConfigureFileColumns";
            contextMenuFileListView.Size = new Size(162, 26);
            contextMenuFileListView.Click += ConfigureFileListViewColumns;
            // 
            // tsConfigureFileColumns
            // 
            tsConfigureFileColumns.Name = "tsConfigureFileColumns";
            tsConfigureFileColumns.Size = new Size(161, 22);
            tsConfigureFileColumns.Text = "Setup columns";
            // 
            // timerSync
            // 
            timerSync.Enabled = true;
            timerSync.Interval = 5000;
            timerSync.Tick += TimerSync_Tick;
            // 
            // imgFiles
            // 
            imgFiles.ColorDepth = ColorDepth.Depth32Bit;
            imgFiles.ImageStream = (ImageListStreamer)resources.GetObject("imgFiles.ImageStream");
            imgFiles.TransparentColor = Color.Transparent;
            imgFiles.Images.SetKeyName(0, "tr_dir.png");
            imgFiles.Images.SetKeyName(1, "sui-right.png");
            imgFiles.Images.SetKeyName(2, "sui-down.png");
            imgFiles.Images.SetKeyName(3, "tr_f_skip.png");
            imgFiles.Images.SetKeyName(4, "tr_f_mid.png");
            imgFiles.Images.SetKeyName(5, "tr_f_higher.png");
            imgFiles.Images.SetKeyName(6, "tr_f_highest.png");
            // 
            // imgToolStrip
            // 
            imgToolStrip.ColorDepth = ColorDepth.Depth32Bit;
            imgToolStrip.ImageStream = (ImageListStreamer)resources.GetObject("imgToolStrip.ImageStream");
            imgToolStrip.TransparentColor = Color.Transparent;
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
            // tsTorrentOpen
            // 
            tsTorrentOpen.Name = "tsTorrentOpen";
            tsTorrentOpen.Size = new Size(224, 22);
            tsTorrentOpen.Text = "Open";
            // 
            // tsTorrentOpenFolder
            // 
            tsTorrentOpenFolder.Name = "tsTorrentOpenFolder";
            tsTorrentOpenFolder.Size = new Size(224, 22);
            tsTorrentOpenFolder.Text = "Open containing folder";
            // 
            // tsTorrentSep1
            // 
            tsTorrentSep1.Name = "tsTorrentSep1";
            tsTorrentSep1.Size = new Size(221, 6);
            // 
            // tsTorrentStart
            // 
            tsTorrentStart.Name = "tsTorrentStart";
            tsTorrentStart.Size = new Size(224, 22);
            tsTorrentStart.Text = "Start";
            // 
            // tsTorrentForceStart
            // 
            tsTorrentForceStart.Name = "tsTorrentForceStart";
            tsTorrentForceStart.Size = new Size(224, 22);
            tsTorrentForceStart.Text = "Force start";
            // 
            // tsTorrentStop
            // 
            tsTorrentStop.Name = "tsTorrentStop";
            tsTorrentStop.Size = new Size(224, 22);
            tsTorrentStop.Text = "Stop";
            // 
            // tsTorrentRemove
            // 
            tsTorrentRemove.Name = "tsTorrentRemove";
            tsTorrentRemove.Size = new Size(224, 22);
            tsTorrentRemove.Text = "Remove";
            // 
            // tsTorrentRemoveData
            // 
            tsTorrentRemoveData.Name = "tsTorrentRemoveData";
            tsTorrentRemoveData.Size = new Size(224, 22);
            tsTorrentRemoveData.Text = "Remove torrent and Data";
            // 
            // tsTorrentSep2
            // 
            tsTorrentSep2.Name = "tsTorrentSep2";
            tsTorrentSep2.Size = new Size(221, 6);
            // 
            // tsTorrentQueue
            // 
            tsTorrentQueue.Name = "tsTorrentQueue";
            tsTorrentQueue.Size = new Size(224, 22);
            tsTorrentQueue.Text = "Queue";
            // 
            // tsTorrentReannounce
            // 
            tsTorrentReannounce.Name = "tsTorrentReannounce";
            tsTorrentReannounce.Size = new Size(224, 22);
            tsTorrentReannounce.Text = "Reannounce";
            // 
            // tsTorrentVerify
            // 
            tsTorrentVerify.Name = "tsTorrentVerify";
            tsTorrentVerify.Size = new Size(224, 22);
            tsTorrentVerify.Text = "Verify";
            // 
            // tsTorrentCopyMagnet
            // 
            tsTorrentCopyMagnet.Name = "tsTorrentCopyMagnet";
            tsTorrentCopyMagnet.Size = new Size(224, 22);
            tsTorrentCopyMagnet.Text = "Copy Magnet Link(s)";
            // 
            // tsTorrentRelocate
            // 
            tsTorrentRelocate.Name = "tsTorrentRelocate";
            tsTorrentRelocate.Size = new Size(224, 22);
            tsTorrentRelocate.Text = "Set data location...";
            // 
            // tsTorrentLabels
            // 
            tsTorrentLabels.Name = "tsTorrentLabels";
            tsTorrentLabels.Size = new Size(224, 22);
            tsTorrentLabels.Text = "Set labels...";
            // 
            // tsTorrentRename
            // 
            tsTorrentRename.Name = "tsTorrentRename";
            tsTorrentRename.Size = new Size(224, 22);
            tsTorrentRename.Text = "Rename";
            // 
            // tsTorrentSep3
            // 
            tsTorrentSep3.Name = "tsTorrentSep3";
            tsTorrentSep3.Size = new Size(221, 6);
            // 
            // tsTorrentSep4
            // 
            tsTorrentSep4.Name = "tsTorrentSep4";
            tsTorrentSep4.Size = new Size(221, 6);
            // 
            // tsTorrentProperties
            // 
            tsTorrentProperties.Name = "tsTorrentProperties";
            tsTorrentProperties.Size = new Size(224, 22);
            tsTorrentProperties.Text = "Properties...";
            // 
            // imgMenu
            // 
            imgMenu.ColorDepth = ColorDepth.Depth32Bit;
            imgMenu.ImageStream = (ImageListStreamer)resources.GetObject("imgMenu.ImageStream");
            imgMenu.TransparentColor = Color.Transparent;
            imgMenu.Images.SetKeyName(0, "tr_open.png");
            imgMenu.Images.SetKeyName(1, "tr_dir.png");
            imgMenu.Images.SetKeyName(2, "tr_start.png");
            imgMenu.Images.SetKeyName(3, "tr_forcestart.png");
            imgMenu.Images.SetKeyName(4, "tr_pause.png");
            imgMenu.Images.SetKeyName(5, "tr_del.png");
            imgMenu.Images.SetKeyName(6, "tr_moveup.png");
            imgMenu.Images.SetKeyName(7, "tr_movedown.png");
            // 
            // MainForm
            // 
            ClientSize = new Size(1264, 961);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ToolStripMenuItem tsTorrentOpen;
        private ToolStripMenuItem tsTorrentOpenFolder;
        private ToolStripSeparator tsTorrentSep1;
        private ToolStripMenuItem tsTorrentStart;
        private ToolStripMenuItem tsTorrentForceStart;
        private ToolStripMenuItem tsTorrentStop;
        private ToolStripMenuItem tsTorrentRemove;
        private ToolStripMenuItem tsTorrentRemoveData;
        private ToolStripSeparator tsTorrentSep2;
        private ToolStripMenuItem tsTorrentQueue;
        private ToolStripMenuItem tsTorrentReannounce;
        private ToolStripMenuItem tsTorrentVerify;
        private ToolStripMenuItem tsTorrentCopyMagnet;
        private ToolStripMenuItem tsTorrentRelocate;
        private ToolStripMenuItem tsTorrentLabels;
        private ToolStripMenuItem tsTorrentRename;
        private ToolStripSeparator tsTorrentSep3;
        private ToolStripMenuItem tsTorrentProperties;
        private ToolStripSeparator tsTorrentSep4;
        private ImageList imgMenu;
    }
}
