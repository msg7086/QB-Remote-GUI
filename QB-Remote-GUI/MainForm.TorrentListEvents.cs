namespace QB_Remote_GUI;

public partial class MainForm
{
    private void AddTorrent(object? sender, EventArgs e)
    {
        _ = AddTorrent();
    }

    private void StartTorrents(object? sender, EventArgs e)
    {
        _ = StartTorrents();
    }

    private void PauseTorrents(object? sender, EventArgs e)
    {
        _ = PauseTorrents();
    }

    private void DeleteTorrents(object? sender, EventArgs e)
    {
        _ = DeleteTorrentsWithoutFiles();
    }
}