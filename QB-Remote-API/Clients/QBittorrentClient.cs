using System.Globalization;
using Microsoft.Extensions.Options;
using QB.Remote.API.Extensions;
using QB.Remote.API.Interfaces;
using QB.Remote.API.Models.Sync;
using QB.Remote.API.Models.Torrents;
using QB.Remote.API.Models.Transfer;

namespace QB.Remote.API.Clients;

/// <summary>
/// Client for interacting with qBittorrent WebUI API
/// </summary>
public class QBittorrentClient : IQBittorrentClient, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly QBittorrentClientOptions _options;
    private bool _isDisposed;

    /// <summary>
    /// Creates a new instance of QBittorrentClient
    /// </summary>
    public QBittorrentClient(IOptions<QBittorrentClientOptions> options)
    {
        _options = options.Value;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_options.BaseUrl.TrimEnd('/') + "/api/v2/"),
            Timeout = TimeSpan.FromSeconds(_options.TimeoutSeconds)
        };
    }

    #region Authentication
    /// <inheritdoc />
    public async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _httpClient.PostFormAsync("auth/login", new Dictionary<string, string>
            {
                ["username"] = _options.Username,
                ["password"] = _options.Password
            }, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    public async Task LogoutAsync(CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsync("auth/logout", null, cancellationToken);
    }
    #endregion

    #region Application
    /// <inheritdoc />
    public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<string>("app/version", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string> GetApiVersionAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<string>("app/webapiVersion", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Dictionary<string, object>> GetPreferencesAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<Dictionary<string, object>>("app/preferences", cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetPreferencesAsync(Dictionary<string, object> preferences, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostJsonAsync("app/setPreferences", preferences, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string> GetDefaultSavePathAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<string>("app/defaultSavePath", cancellationToken);
    }

    /// <inheritdoc />
    public async Task ShutdownApplicationAsync(CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsync("app/shutdown", null, cancellationToken);
    }
    #endregion

    #region Sync
    /// <inheritdoc />
    public async Task<MainData> GetMainDataAsync(int rid = 0, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<MainData>($"sync/maindata?rid={rid}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<PeerData> GetPeersDataAsync(string hash, int rid = 0, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<PeerData>($"sync/torrentPeers?hash={hash}&rid={rid}", cancellationToken);
    }
    #endregion

    #region Transfer
    /// <inheritdoc />
    public async Task<TransferInfo> GetTransferInfoAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<TransferInfo>("transfer/info", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> GetAlternativeSpeedLimitsEnabledAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetJsonAsync<string>("transfer/speedLimitsMode", cancellationToken);
        return result == "1";
    }

    /// <inheritdoc />
    public async Task ToggleAlternativeSpeedLimitsAsync(CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsync("transfer/toggleSpeedLimitsMode", null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<long> GetGlobalDownloadLimitAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetJsonAsync<string>("transfer/downloadLimit", cancellationToken);
        return long.Parse(result);
    }

    /// <inheritdoc />
    public async Task SetGlobalDownloadLimitAsync(long limit, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("transfer/setDownloadLimit", new Dictionary<string, string>
        {
            ["limit"] = limit.ToString()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<long> GetGlobalUploadLimitAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetJsonAsync<string>("transfer/uploadLimit", cancellationToken);
        return long.Parse(result);
    }

    /// <inheritdoc />
    public async Task SetGlobalUploadLimitAsync(long limit, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("transfer/setUploadLimit", new Dictionary<string, string>
        {
            ["limit"] = limit.ToString()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task BanPeersAsync(IEnumerable<string> peers, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("transfer/banPeers", new Dictionary<string, string>
        {
            ["peers"] = string.Join("|", peers)
        }, cancellationToken);
    }
    #endregion

    #region Torrents
    /// <inheritdoc />
    public async Task<IEnumerable<TorrentInfo>> GetTorrentsAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<TorrentInfo>>("torrents/info", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TorrentProperties> GetTorrentPropertiesAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<TorrentProperties>($"torrents/properties?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TorrentTrackerInfo>> GetTorrentTrackersAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<TorrentTrackerInfo>>($"torrents/trackers?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> GetTorrentWebSeedsAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<string>>($"torrents/webseeds?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TorrentContentInfo>> GetTorrentContentsAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<TorrentContentInfo>>($"torrents/files?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<int>> GetTorrentPiecesStatesAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<int>>($"torrents/pieceStates?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> GetTorrentPiecesHashesAsync(string hash, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<string>>($"torrents/pieceHashes?hash={hash}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddTorrentAsync(AddTorrentOptions options, CancellationToken cancellationToken = default)
    {
        var content = new MultipartFormDataContent();

        // Add torrent files if any
        int fileIndex = 0;
        foreach (var fileContent in options.TorrentFiles)
        {
            var fileContentPart = new ByteArrayContent(fileContent);
            content.Add(fileContentPart, "torrents", $"file{fileIndex++}.torrent");
        }

        // Add URLs if any
        if (options.Urls.Any())
        {
            content.Add(new StringContent(string.Join("\n", options.Urls)), "urls");
        }

        // Add other options
        if (options.SavePath != null)
            content.Add(new StringContent(options.SavePath), "savepath");
        if (options.Cookie != null)
            content.Add(new StringContent(options.Cookie), "cookie");
        if (options.Category != null)
            content.Add(new StringContent(options.Category), "category");
        if (options.Tags != null)
            content.Add(new StringContent(options.Tags), "tags");
        if (options.Stopped.HasValue)
        {
            content.Add(new StringContent(options.Stopped.Value.ToString().ToLower()), "paused"); // backward compatibility
            content.Add(new StringContent(options.Stopped.Value.ToString().ToLower()), "stopped");
        }
        if (options.SkipChecking.HasValue)
            content.Add(new StringContent(options.SkipChecking.Value.ToString().ToLower()), "skip_checking");
        if (options.Sequential.HasValue)
            content.Add(new StringContent(options.Sequential.Value.ToString().ToLower()), "sequentialDownload");
        if (options.FirstLastPiecePriority.HasValue)
            content.Add(new StringContent(options.FirstLastPiecePriority.Value.ToString().ToLower()), "firstLastPiecePrio");
        if (options.AddToTopOfQueue.HasValue)
            content.Add(new StringContent(options.AddToTopOfQueue.Value.ToString().ToLower()), "addToTopOfQueue");
        if (options.CreateRootFolder.HasValue)
            content.Add(new StringContent(options.CreateRootFolder.Value.ToString().ToLower()), "root_folder");
        if (options.AutomaticTorrentManagement.HasValue)
            content.Add(new StringContent(options.AutomaticTorrentManagement.Value.ToString().ToLower()), "autoTMM");
        if (options.Rename != null)
            content.Add(new StringContent(options.Rename), "rename");
        if (options.DownloadLimit.HasValue)
            content.Add(new StringContent(options.DownloadLimit.Value.ToString()), "dlLimit");
        if (options.UploadLimit.HasValue)
            content.Add(new StringContent(options.UploadLimit.Value.ToString()), "upLimit");
        if (options.RatioLimit.HasValue)
            content.Add(new StringContent(options.RatioLimit.Value.ToString(CultureInfo.InvariantCulture)), "ratioLimit");
        if (options.SeedingTimeLimit.HasValue)
            content.Add(new StringContent(options.SeedingTimeLimit.Value.ToString()), "seedingTimeLimit");

        await _httpClient.PostAsync("torrents/add", content, cancellationToken);
    }

    /// <inheritdoc />
    public async Task PauseTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/stop", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task ResumeTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/start", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteTorrentsAsync(IEnumerable<string> hashes, bool deleteFiles = false, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/delete", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["deleteFiles"] = deleteFiles.ToString().ToLower()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RecheckTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/recheck", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task ReannounceTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/reannounce", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddTrackersAsync(string hash, IEnumerable<string> urls, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/addTrackers", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["urls"] = string.Join("\n", urls)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task EditTrackerAsync(string hash, string origUrl, string newUrl, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/editTracker", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["origUrl"] = origUrl,
            ["newUrl"] = newUrl
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveTrackersAsync(string hash, IEnumerable<string> urls, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/removeTrackers", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["urls"] = string.Join("|", urls)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddPeersAsync(string hash, IEnumerable<string> peers, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/addPeers", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["peers"] = string.Join("|", peers)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<long> GetTorrentDownloadLimitAsync(string hash, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetJsonAsync<string>($"torrents/downloadLimit?hash={hash}", cancellationToken);
        return long.Parse(result);
    }

    /// <inheritdoc />
    public async Task SetTorrentDownloadLimitAsync(string hash, long limit, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setDownloadLimit", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["limit"] = limit.ToString()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<long> GetTorrentUploadLimitAsync(string hash, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetJsonAsync<string>($"torrents/uploadLimit?hash={hash}", cancellationToken);
        return long.Parse(result);
    }

    /// <inheritdoc />
    public async Task SetTorrentUploadLimitAsync(string hash, long limit, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setUploadLimit", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["limit"] = limit.ToString()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetTorrentLocationAsync(string hash, string location, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setLocation", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["location"] = location
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetTorrentNameAsync(string hash, string name, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/rename", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["name"] = name
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetTorrentCategoryAsync(string hash, string category, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setCategory", new Dictionary<string, string>
        {
            ["hashes"] = hash,
            ["category"] = category
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Dictionary<string, TorrentCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<Dictionary<string, TorrentCategory>>("torrents/categories", cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddCategoryAsync(string category, string savePath, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/createCategory", new Dictionary<string, string>
        {
            ["category"] = category,
            ["savePath"] = savePath
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task EditCategoryAsync(string category, string savePath, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/editCategory", new Dictionary<string, string>
        {
            ["category"] = category,
            ["savePath"] = savePath
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveCategoriesAsync(IEnumerable<string> categories, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/removeCategories", new Dictionary<string, string>
        {
            ["categories"] = string.Join("\n", categories)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddTorrentTagsAsync(IEnumerable<string> hashes, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/addTags", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["tags"] = string.Join(",", tags)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveTorrentTagsAsync(IEnumerable<string> hashes, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/removeTags", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["tags"] = string.Join(",", tags)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> GetAllTagsAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetJsonAsync<IEnumerable<string>>("torrents/tags", cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateTagsAsync(IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/createTags", new Dictionary<string, string>
        {
            ["tags"] = string.Join(",", tags)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteTagsAsync(IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/deleteTags", new Dictionary<string, string>
        {
            ["tags"] = string.Join(",", tags)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetAutomaticTorrentManagementAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setAutoManagement", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["enable"] = enable.ToString().ToLower()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task ToggleSequentialDownloadAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/toggleSequentialDownload", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetFirstLastPiecePriorityAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/toggleFirstLastPiecePrio", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes)
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetForceStartAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setForceStart", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["value"] = enable.ToString().ToLower()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetSuperSeedingAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/setSuperSeeding", new Dictionary<string, string>
        {
            ["hashes"] = string.Join("|", hashes),
            ["value"] = enable.ToString().ToLower()
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RenameFileAsync(string hash, int fileId, string name, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/renameFile", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["id"] = fileId.ToString(),
            ["name"] = name
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RenameFolderAsync(string hash, string oldPath, string newPath, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostFormAsync("torrents/renameFolder", new Dictionary<string, string>
        {
            ["hash"] = hash,
            ["oldPath"] = oldPath,
            ["newPath"] = newPath
        }, cancellationToken);
    }
    #endregion

    /// <inheritdoc />
    public void Dispose()
    {
        if (_isDisposed)
            return;

        _httpClient.Dispose();
        _isDisposed = true;
        GC.SuppressFinalize(this);
    }
} 
