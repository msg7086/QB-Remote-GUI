using QB_Remote_GUI.GUI.Models;
using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI.Components
{
    public sealed partial class TorrentInfoView : UserControl
    {
        private readonly Dictionary<string, Label> _valueLabels = new();
        private readonly LanguageLoader _languageLoader = LanguageLoader.Instance;

        public TorrentInfoView()
        {
            InitializeComponent();

            InitializeTransferLabels();
            InitializeTorrentLabels();

            Controls.Add(tableLayoutPanelTransfer);
            Controls.Add(tableLayoutPanelTorrent);
        }

        private void InitializeTransferLabels()
        {
            // Column 1,2
            AddTransferLabelPair(0, 0, "State");
            AddTransferLabelPair(1, 0, "Downloaded");
            AddTransferLabelPair(2, 0, "Download speed");
            AddTransferLabelPair(3, 0, "Down limit");
            AddTransferLabelPair(4, 0, "Seeds");
            AddTransferLabelPair(5, 0, "Tracker");

            // Column 3,4
            AddTransferLabelPair(0, 2, "Error");
            AddTransferLabelPair(1, 2, "Uploaded");
            AddTransferLabelPair(2, 2, "Upload speed");
            AddTransferLabelPair(3, 2, "Up limit");
            AddTransferLabelPair(4, 2, "Peers");
            AddTransferLabelPair(5, 2, "Tracker updated on");

            // Column 5,6
            AddTransferLabelPair(1, 4, "Remaining");
            AddTransferLabelPair(2, 4, "Wasted");
            AddTransferLabelPair(3, 4, "Share ratio");
            AddTransferLabelPair(4, 4, "Max peers");
            AddTransferLabelPair(5, 4, "Last active");

            var errorValueLabel = tableLayoutPanelTransfer.GetControlFromPosition(3, 0);
            if (errorValueLabel != null)
                tableLayoutPanelTransfer.SetColumnSpan(errorValueLabel, 3);
        }

        private void AddTransferLabelPair(int row, int col, string key)
        {
            // Create and add title label
            var titleLabel = new Label
            {
                Text = _languageLoader.GetTranslation(key),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTransfer.Controls.Add(titleLabel, col, row);

            // Create and add value label
            var valueLabel = new Label
            {
                Text = "",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTransfer.Controls.Add(valueLabel, col + 1, row);
            _valueLabels[$"Transfer_{key}"] = valueLabel;
        }

        private void InitializeTorrentLabels()
        {
            // Column 1,2
            AddTorrentLabelPair(0, 0, "Save path");
            AddTorrentLabelPair(1, 0, "Total size");
            AddTorrentLabelPair(2, 0, "Info hash v1");
            AddTorrentLabelPair(3, 0, "Info hash v2");
            AddTorrentLabelPair(4, 0, "Added on");
            AddTorrentLabelPair(5, 0, "Magnet link");

            // Column 3,4
            AddTorrentLabelPair(0, 2, "Created on");
            AddTorrentLabelPair(1, 2, "Pieces");
            AddTorrentLabelPair(2, 2, "Comments");
            AddTorrentLabelPair(3, 2, "Completed on");
            AddTorrentLabelPair(4, 2, "Tags");
        }

        private void AddTorrentLabelPair(int row, int col, string key)
        {
            // Create and add title label
            var titleLabel = new Label
            {
                Text = _languageLoader.GetTranslation(key),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTorrent.Controls.Add(titleLabel, col, row);

            // Create and add value label
            var valueLabel = new Label
            {
                Text = "",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTorrent.Controls.Add(valueLabel, col + 1, row);
            _valueLabels[$"Torrent_{key}"] = valueLabel;
        }

        public void Render(TorrentInfo info, TorrentProperties properties)
        {
            // Update transfer panel labels
            _valueLabels["Transfer_State"].Text = info.State; // State needs to be provided separately
            _valueLabels["Transfer_Downloaded"].Text = FormattingUtils.FormatSize(properties.TotalDownloaded);
            _valueLabels["Transfer_Download speed"].Text = $"{FormattingUtils.FormatSize(properties.DownloadSpeed)}/s";
            _valueLabels["Transfer_Down limit"].Text = properties.DownloadLimit > 0 ? $"{FormattingUtils.FormatSize(properties.DownloadLimit)}/s" : "∞";
            _valueLabels["Transfer_Seeds"].Text = $"{info.ConnectedSeeds}/{info.TotalSeeds}"; // Seeds count needs to be provided separately
            _valueLabels["Transfer_Tracker"].Text = "-"; // Tracker info needs to be provided separately

            _valueLabels["Transfer_Error"].Text = "-"; // Error needs to be provided separately
            _valueLabels["Transfer_Uploaded"].Text = FormattingUtils.FormatSize(properties.TotalUploaded);
            _valueLabels["Transfer_Upload speed"].Text = $"{FormattingUtils.FormatSize(properties.UploadSpeed)}/s";
            _valueLabels["Transfer_Up limit"].Text = properties.UploadLimit > 0 ? $"{FormattingUtils.FormatSize(properties.UploadLimit)}/s" : "∞";
            _valueLabels["Transfer_Peers"].Text = $"{info.ConnectedPeers}/{info.TotalPeers}";
            _valueLabels["Transfer_Tracker updated on"].Text = "-"; // Tracker update time needs to be provided separately

            _valueLabels["Transfer_Remaining"].Text = FormattingUtils.FormatSize(properties.TotalSize - properties.TotalDownloaded);
            _valueLabels["Transfer_Wasted"].Text = FormattingUtils.FormatSize(properties.TotalWasted);
            _valueLabels["Transfer_Share ratio"].Text = properties.ShareRatio.ToString("F2");
            _valueLabels["Transfer_Max peers"].Text = properties.ConnectionCountLimit.ToString();
            _valueLabels["Transfer_Last active"].Text = UnixTimeToDateTime(properties.LastSeen).ToString("g");

            // Update torrent panel labels
            _valueLabels["Torrent_Save path"].Text = properties.SavePath;
            _valueLabels["Torrent_Total size"].Text = $"{FormattingUtils.FormatSize(properties.TotalSize)} ({FormattingUtils.FormatSize(properties.TotalDownloaded)})";
            _valueLabels["Torrent_Info hash v1"].Text = properties.InfohashV1;
            _valueLabels["Torrent_Info hash v2"].Text = properties.InfohashV2;
            _valueLabels["Torrent_Added on"].Text = UnixTimeToDateTime(properties.AdditionDate).ToString("g");
            _valueLabels["Torrent_Magnet link"].Text = info.MagnetUri;

            _valueLabels["Torrent_Created on"].Text = UnixTimeToDateTime(properties.CreationDate).ToString("g");
            _valueLabels["Torrent_Pieces"].Text = $"{properties.PiecesHave} x {FormattingUtils.FormatSize(properties.PieceSize)} ({properties.PiecesNum})"; // Piece count needs to be provided separately
            _valueLabels["Torrent_Comments"].Text = properties.Comment;
            _valueLabels["Torrent_Completed on"].Text = properties.CompletionDate > 0 
                ? UnixTimeToDateTime(properties.CompletionDate).ToString("g") 
                : "-";
            _valueLabels["Torrent_Tags"].Text = info.Tags;
        }

        private DateTime UnixTimeToDateTime(long unixTime)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime);
            return dateTime.LocalDateTime;
        }
    }
}
