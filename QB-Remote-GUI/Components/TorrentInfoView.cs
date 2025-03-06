using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QB_Remote_GUI.GUI.Models;
using QB_Remote_GUI.API.Models.Torrents;

namespace QB_Remote_GUI.GUI.Components
{
    public partial class TorrentInfoView : UserControl
    {
        private readonly Dictionary<string, Label> valueLabels = new Dictionary<string, Label>();
        private readonly LanguageLoader languageLoader = LanguageLoader.Instance;

        public TorrentInfoView()
        {
            InitializeComponent();

            InitializeLabels();
            InitializeTorrentLabels();

            Controls.Add(tableLayoutPanelTransfer);
            Controls.Add(tableLayoutPanelTorrent);
        }

        private void InitializeLabels()
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
                Text = languageLoader.GetTranslation(key),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTransfer.Controls.Add(titleLabel, col, row);

            // Create and add value label
            var valueLabel = new Label
            {
                Text = "-",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTransfer.Controls.Add(valueLabel, col + 1, row);
            valueLabels[$"Transfer_{key}"] = valueLabel;
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
                Text = languageLoader.GetTranslation(key),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTorrent.Controls.Add(titleLabel, col, row);

            // Create and add value label
            var valueLabel = new Label
            {
                Text = "-",
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tableLayoutPanelTorrent.Controls.Add(valueLabel, col + 1, row);
            valueLabels[$"Torrent_{key}"] = valueLabel;
        }

        public void Render(TorrentInfo info, TorrentProperties properties)
        {
            if (properties == null) return;

            // Update transfer panel labels
            valueLabels["Transfer_State"].Text = info.State; // State needs to be provided separately
            valueLabels["Transfer_Downloaded"].Text = FormatBytes(properties.TotalDownloaded);
            valueLabels["Transfer_Download speed"].Text = $"{FormatBytes(properties.DownloadSpeed)}/s";
            valueLabels["Transfer_Down limit"].Text = properties.DownloadLimit > 0 ? $"{FormatBytes(properties.DownloadLimit)}/s" : "∞";
            valueLabels["Transfer_Seeds"].Text = $"{info.ConnectedSeeds}/{info.TotalSeeds}"; // Seeds count needs to be provided separately
            valueLabels["Transfer_Tracker"].Text = "-"; // Tracker info needs to be provided separately

            valueLabels["Transfer_Error"].Text = "-"; // Error needs to be provided separately
            valueLabels["Transfer_Uploaded"].Text = FormatBytes(properties.TotalUploaded);
            valueLabels["Transfer_Upload speed"].Text = $"{FormatBytes(properties.UploadSpeed)}/s";
            valueLabels["Transfer_Up limit"].Text = properties.UploadLimit > 0 ? $"{FormatBytes(properties.UploadLimit)}/s" : "∞";
            valueLabels["Transfer_Peers"].Text = $"{info.ConnectedPeers}/{info.TotalPeers}";
            valueLabels["Transfer_Tracker updated on"].Text = "-"; // Tracker update time needs to be provided separately

            valueLabels["Transfer_Remaining"].Text = FormatBytes(properties.TotalSize - properties.TotalDownloaded);
            valueLabels["Transfer_Wasted"].Text = FormatBytes(properties.TotalWasted);
            valueLabels["Transfer_Share ratio"].Text = properties.ShareRatio.ToString("F2");
            valueLabels["Transfer_Max peers"].Text = properties.ConnectionCountLimit.ToString();
            valueLabels["Transfer_Last active"].Text = UnixTimeToDateTime(properties.LastSeen).ToString("g");

            // Update torrent panel labels
            valueLabels["Torrent_Save path"].Text = properties.SavePath;
            valueLabels["Torrent_Total size"].Text = $"{FormatBytes(properties.TotalSize)} ({FormatBytes(properties.TotalDownloaded)})";
            valueLabels["Torrent_Info hash v1"].Text = properties.InfohashV1;
            valueLabels["Torrent_Info hash v2"].Text = properties.InfohashV2;
            valueLabels["Torrent_Added on"].Text = UnixTimeToDateTime(properties.AdditionDate).ToString("g");
            valueLabels["Torrent_Magnet link"].Text = info.MagnetUri;

            valueLabels["Torrent_Created on"].Text = UnixTimeToDateTime(properties.CreationDate).ToString("g");
            valueLabels["Torrent_Pieces"].Text = $"{properties.PiecesHave} x {FormatBytes(properties.PieceSize)} ({properties.PiecesNum})"; // Piece count needs to be provided separately
            valueLabels["Torrent_Comments"].Text = properties.Comment;
            valueLabels["Torrent_Completed on"].Text = properties.CompletionDate > 0 
                ? UnixTimeToDateTime(properties.CompletionDate).ToString("g") 
                : "-";
            valueLabels["Torrent_Tags"].Text = info.Tags;
        }

        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        private DateTime UnixTimeToDateTime(long unixTime)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime);
            return dateTime.LocalDateTime;
        }
    }
}
