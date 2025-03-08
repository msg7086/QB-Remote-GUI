using QB_Remote_GUI.GUI.Utils;

namespace QB_Remote_GUI.GUI;

public partial class MainForm
{
    private void InitializeToolbar()
    {
        toolStrip.ImageList = imgToolStrip;
        tsbspConnect.Text = _lang.GetTranslation("Connect to Transmission");
        tsbspConnect.ImageIndex = 0;
        tsbDisconnect.Text = _lang.GetTranslation("Disconnect from Transmission");
        tsbDisconnect.ImageIndex = 1;
        tsbAddTorrent.Text = _lang.GetTranslation("&Add torrent");
        tsbAddTorrent.ImageIndex = 2;
        tsbStartTorrent.Text = _lang.GetTranslation("Start");
        tsbStartTorrent.ImageIndex = 4;
        tsbPauseTorrent.Text = _lang.GetTranslation("Stop");
        tsbPauseTorrent.ImageIndex = 5;
        tsbDeleteTorrent.Text = _lang.GetTranslation("Remove");
        tsbDeleteTorrent.ImageIndex = 6;
        tsbManageConnection.Text = _lang.GetTranslation("Manage connections") + LanguageLoader.Dots;
    }

    private void AddTorrent(object? sender, EventArgs e)
    {
        _ = AddTorrent();
    }
}
