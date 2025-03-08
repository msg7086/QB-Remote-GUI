using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI;

partial class MainForm
{
    private void InitializeTorrentListMenu()
    {
        contextMenuTorrentListView.ImageList = imgMenu;
        tsTorrentOpen.Text = _lang.GetTranslation("Open");
        tsTorrentOpen.ImageIndex = 0;
        tsTorrentOpenFolder.Text = _lang.GetTranslation("Open containing folder");
        tsTorrentOpenFolder.ImageIndex = 1;
        tsTorrentStart.Text = _lang.GetTranslation("Start");
        tsTorrentStart.ImageIndex = 2;
        tsTorrentForceStart.Text = _lang.GetTranslation("Force start");
        tsTorrentForceStart.ImageIndex = 3;
        tsTorrentStop.Text = _lang.GetTranslation("Stop");
        tsTorrentStop.ImageIndex = 4;
        tsTorrentRemove.Text = _lang.GetTranslation("Remove");
        tsTorrentRemove.ImageIndex = 5;
        tsTorrentRemoveData.Text = _lang.GetTranslation("Remove torrent and Data");
        tsTorrentQueue.Text = _lang.GetTranslation("Queue");
        tsTorrentReannounce.Text = _lang.GetTranslation("Reannounce (get more peers)");
        tsTorrentVerify.Text = _lang.GetTranslation("&Verify");
        tsTorrentCopyMagnet.Text = _lang.GetTranslation("Copy Magnet Link(s)");
        tsTorrentRelocate.Text = _lang.GetTranslation("Set data location") + LanguageLoader.Dots;
        tsTorrentLabels.Text = _lang.GetTranslation("Set labels") + LanguageLoader.Dots;
        tsTorrentRename.Text = _lang.GetTranslation("Rename");
        tsTorrentProperties.Text = _lang.GetTranslation("Properties") + LanguageLoader.Dots;
        tsConfigureTorrentColumns.Text = _lang.GetTranslation("Setup columns") + LanguageLoader.Dots;
    }
}
