using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Utils;
using QB_Remote_GUI.GUI.Views;

namespace QB_Remote_GUI.GUI.Forms;

public partial class AddTorrent: Form
{
    private readonly LanguageLoader _lang = LanguageLoader.GetInstance();
    private readonly MainForm.NewTorrentInfo _torrentInfo;
    private readonly FileListViewManager _fileListViewManager;

    public AddTorrent(MainForm.NewTorrentInfo torrentInfo, ImageList imgFiles)
    {
        InitializeComponent();
        _torrentInfo = torrentInfo;
        _fileListViewManager = new FileListViewManager(listView1, imgFiles, true);
        TranslateLabels();
        PopulateForm();
    }

    private void TranslateLabels()
    {
        Text = _lang.GetTranslation("Add Torrent");
        groupBox1.Text = _lang.GetTranslation("Transmission options");
        label1.Text = _lang.GetTranslation("Destination folder:");
        label2.Text = _lang.GetTranslation("Save as:");
        checkBoxTMM.Text = _lang.GetTranslation("Auto Management");
        checkBoxStartNow.Text = _lang.GetTranslation("Start Torrent");
        checkBoxSkipChecking.Text = _lang.GetTranslation("Skip Checking");
        checkBoxDlLimit.Text = _lang.GetTranslation("DL Limit (KB/s)");
        checkBoxUlLimit.Text = _lang.GetTranslation("UL Limit (KB/s)");
        checkBoxRatioLimit.Text = _lang.GetTranslation("Ratio Limit");
        checkBoxSeedingLimit.Text = _lang.GetTranslation("Seeding Time Limit (min)");
        checkBoxInactiveSeedingLimit.Text = _lang.GetTranslation("Inactive Seeding Time Limit");
        checkBoxQueueTop.Text = _lang.GetTranslation("Add To Top of Queue");
        checkBoxFLPrio.Text = _lang.GetTranslation("Prioritize Edge Pieces");
        checkBoxSequential.Text = _lang.GetTranslation("Download Sequentially");
        checkBoxRootFolder.Text = _lang.GetTranslation("Create Root Folder");
        groupBox2.Text = _lang.GetTranslation("Torrent contents");
        labelSelectedSize.Text = _lang.GetTranslation("Size:");
        btnSelectAll.Text = _lang.GetTranslation("Select All");
        btnSelectNone.Text = _lang.GetTranslation("Select None");
    }

    private void PopulateForm()
    {
        if (_torrentInfo.TorrentInfo == null || _torrentInfo.ContentInfo == null) return;
        textBox1.Text = _torrentInfo.TorrentInfo.SavePath;
        textBox2.Text = _torrentInfo.TorrentInfo.Name;

        _fileListViewManager.UpdateFileList(_torrentInfo.ContentInfo, _torrentInfo.Hash!);
        labelSelectedSize.Text = _lang.GetTranslation("Size:") + " " + FormattingUtils.FormatSize(_torrentInfo.TorrentInfo?.TotalSize ?? 0);
    }

    public AddTorrentOptions Options
    {
        get
        {
            var options = new AddTorrentOptions
            {
                SavePath = textBox1.Text,
                Rename = textBox2.Text,
                AutomaticTorrentManagement = checkBoxTMM.CheckState switch
                {
                    CheckState.Checked => true,
                    CheckState.Unchecked => false,
                    _ => null
                },
                Stopped = !checkBoxStartNow.Checked,
                SkipChecking = checkBoxSkipChecking.Checked,
                DownloadLimit = checkBoxDlLimit.CheckState switch
                {
                    CheckState.Checked => (int?)numericUpDownDlLimit.Value,
                    CheckState.Unchecked => -1,
                    _ => null
                },
                UploadLimit = checkBoxUlLimit.CheckState switch
                {
                    CheckState.Checked => (int?)numericUpDownUlLimit.Value,
                    CheckState.Unchecked => -1,
                    _ => null
                },
                RatioLimit = checkBoxRatioLimit.CheckState switch
                {
                    CheckState.Checked => (double?)numericUpDownRatioLimit.Value,
                    CheckState.Unchecked => -1,
                    _ => null
                },
                SeedingTimeLimit = checkBoxSeedingLimit.CheckState switch
                {
                    CheckState.Checked => (int?)numericUpDownSeedingLimit.Value,
                    CheckState.Unchecked => -1,
                    _ => null
                },
                InactiveSeedingTimeLimit = checkBoxInactiveSeedingLimit.CheckState switch
                {
                    CheckState.Checked => (int?)numericUpDown1.Value,
                    CheckState.Unchecked => -1,
                    _ => null
                },
                AddToTopOfQueue = checkBoxQueueTop.CheckState switch
                {
                    CheckState.Checked => true,
                    CheckState.Unchecked => false,
                    _ => null
                },
                FirstLastPiecePriority = checkBoxFLPrio.Checked,
                Sequential = checkBoxSequential.Checked,
                CreateRootFolder = checkBoxRootFolder.CheckState switch
                {
                    CheckState.Checked => true,
                    CheckState.Unchecked => false,
                    _ => null
                }
            };

            return options;
        }
    }
}