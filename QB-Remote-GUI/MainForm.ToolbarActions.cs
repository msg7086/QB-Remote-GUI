using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.GUI.Forms;

namespace QB_Remote_GUI.GUI;

public partial class MainForm
{
    public class NewTorrentInfo
    {
        public required string FileName { get; set; }
        public required byte[] TorrentFileBytes { get; set; }
        public string? Hash { get; set; }
        public TorrentInfo? TorrentInfo { get; set; }
        public IEnumerable<TorrentContentInfo>? ContentInfo { get; set; }
    }

    // tag to torrent_info
    private readonly Dictionary<string, NewTorrentInfo> _newTorrents = [];
    private const string TagPrefix = "QB-Remote-GUI";
    private async Task AddTorrent()
    {
        if (_client == null) return;

        using var dialog = new OpenFileDialog();
        dialog.Filter = lang.GetTranslation("Torrents (*.torrent)|*.torrent|All files (*.*)|*.*");
        dialog.Multiselect = true; // Add files in sequence

        if (dialog.ShowDialog() != DialogResult.OK) return;
        await HandleNewTorrents(dialog.FileNames);
    }

    private async Task HandleNewTorrents(string[] torrentFileNames)
    {
        if (_client == null) return;
        timerSync.Enabled = false;
        try {
            await Task.WhenAll(torrentFileNames.Select(file => {
                var uuid = $"{TagPrefix}-{Guid.NewGuid()}";
                var torrentFile = File.ReadAllBytes(file);
                _newTorrents[uuid] = new NewTorrentInfo {
                    FileName = Path.GetFileName(file),
                    TorrentFileBytes = torrentFile
                };
                return _client.AddTorrentAsync(new AddTorrentOptions{
                    TorrentFiles = [torrentFile],
                    Stopped = true,
                    Tags = uuid
                });
            }));

            await SyncData();

            foreach (var (hash, torrent) in _torrents)
            {
                if (torrent.Tags == null) continue;
                if (!_newTorrents.ContainsKey(torrent.Tags)) continue;
                var contents = await _client.GetTorrentContentsAsync(hash);
                _newTorrents[torrent.Tags].Hash = hash;
                _newTorrents[torrent.Tags].TorrentInfo = torrent;
                _newTorrents[torrent.Tags].ContentInfo = contents;
            }

            await SyncData();

            _newTorrents.Where(t => t.Value.Hash == null).ToList().ForEach(t => _newTorrents.Remove(t.Key));

            // Delete all temporary torrents
            var hashes = _newTorrents.Values
                .Select(t => t.Hash!)
                .ToList();

            if (hashes.Count > 0) {
                await _client.DeleteTorrentsAsync(hashes, false);
                await _client.DeleteTagsAsync(_newTorrents.Keys);
                await SyncData();
            }

            // Process each torrent sequentially
            foreach (var torrentInfo in _newTorrents.Values)
            {
                var form = new AddTorrent(torrentInfo, imgFiles);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _client.AddTorrentAsync(form.Options);
                }
            }

            _newTorrents.Clear();
        }
        finally {
            timerSync.Enabled = true;
        }
    }
}
