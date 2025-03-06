using QB_Remote_GUI.API.Models.Torrents;

namespace QB_Remote_GUI.GUI;

public partial class MainForm
{
    private List<string> GetSelectedTorrentHashes()
    {
        // Allow multiple selections in the Torrent List View
        return torrentListView.SelectedItems
            .Cast<ListViewItem>()
            .Select(item => item.Name)
            .ToList();
    }

    private async Task AddTorrent()
    {
        if (_client == null) return;

        using var dialog = new OpenFileDialog();
        dialog.Filter = lang.GetTranslation("Torrents (*.torrent)|*.torrent|All files (*.*)|*.*");
        dialog.Multiselect = true;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var torrentFiles = new List<byte[]>();
                foreach (var file in dialog.FileNames)
                {
                    torrentFiles.Add(await File.ReadAllBytesAsync(file));
                }

                await _client.AddTorrentAsync(new AddTorrentOptions
                {
                    TorrentFiles = torrentFiles,
                    Stopped = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async Task StartTorrents()
    {
        if (_client == null) return;

        var selectedHashes = GetSelectedTorrentHashes();
        if (selectedHashes.Count > 0)
        {
            try
            {
                await _client.ResumeTorrentsAsync(selectedHashes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"开始种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async Task PauseTorrents()
    {
        if (_client == null) return;

        var selectedHashes = GetSelectedTorrentHashes();
        if (selectedHashes.Count > 0)
        {
            try
            {
                await _client.PauseTorrentsAsync(selectedHashes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"暂停种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async Task DeleteTorrentsWithoutFiles()
    {
        if (_client == null) return;

        var selectedHashes = GetSelectedTorrentHashes();
        if (selectedHashes.Count == 0) return;

        var message = selectedHashes.Count > 1 ?
            String.Format(lang.GetTranslation("Are you sure to remove %d selected torrents?"), selectedHashes.Count) :
            String.Format(lang.GetTranslation("Are you sure to remove torrent '%s'?"), selectedHashes.First());

        var result = MessageBox.Show(
            message,
            lang.GetTranslation("Remove torrent"),
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.No) return;

        try
        {
            await _client.DeleteTorrentsAsync(selectedHashes);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"删除种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task DeleteTorrentsWithFiles()
    {
        if (_client == null) return;

        var selectedHashes = GetSelectedTorrentHashes();
        if (selectedHashes.Count == 0) return;

        var message = selectedHashes.Count > 1 ?
            String.Format(lang.GetTranslation("Are you sure to remove %d selected torrents and all their associated DATA?"), selectedHashes.Count) :
            String.Format(lang.GetTranslation("Are you sure to remove torrent '%s' and all associated DATA?"), selectedHashes.First());

        var result = MessageBox.Show(
            message,
            lang.GetTranslation("Remove torrent and Data"),
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.No) return;

        try
        {
            await _client.DeleteTorrentsAsync(selectedHashes, true);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"删除种子失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
