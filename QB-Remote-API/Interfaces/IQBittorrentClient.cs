using QB_Remote_GUI.API.Models.Sync;
using QB_Remote_GUI.API.Models.Torrents;
using QB_Remote_GUI.API.Models.Transfer;

namespace QB_Remote_GUI.API.Interfaces;

/// <summary>
/// Interface for interacting with qBittorrent WebUI API
/// </summary>
public interface IQBittorrentClient
{
    #region Authentication
    /// <summary>
    /// Login to qBittorrent WebUI
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if login successful</returns>
    Task<bool> LoginAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Logout from qBittorrent WebUI
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task LogoutAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Application
    /// <summary>
    /// Get application version
    /// </summary>
    Task<string> GetVersionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get API version
    /// </summary>
    Task<string> GetApiVersionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get application preferences
    /// </summary>
    Task<Dictionary<string, object>> GetPreferencesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Set application preferences
    /// </summary>
    Task SetPreferencesAsync(Dictionary<string, object> preferences, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get default save path
    /// </summary>
    Task<string> GetDefaultSavePathAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Shutdown application
    /// </summary>
    Task ShutdownApplicationAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Sync
    /// <summary>
    /// Get main data from qBittorrent
    /// </summary>
    /// <param name="rid">Response ID. If not 0, a partial response will be returned</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Main data</returns>
    Task<MainData> GetMainDataAsync(int rid = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get peers data for a torrent
    /// </summary>
    /// <param name="hash">Torrent hash</param>
    /// <param name="rid">Response ID. If not 0, a partial response will be returned</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Peers data</returns>
    Task<PeerData> GetPeersDataAsync(string hash, int rid = 0, CancellationToken cancellationToken = default);
    #endregion

    #region Transfer
    /// <summary>
    /// Get global transfer info
    /// </summary>
    Task<TransferInfo> GetTransferInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get alternative speed limits state
    /// </summary>
    Task<bool> GetAlternativeSpeedLimitsEnabledAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Toggle alternative speed limits
    /// </summary>
    Task ToggleAlternativeSpeedLimitsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get global download limit
    /// </summary>
    Task<long> GetGlobalDownloadLimitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Set global download limit
    /// </summary>
    Task SetGlobalDownloadLimitAsync(long limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get global upload limit
    /// </summary>
    Task<long> GetGlobalUploadLimitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Set global upload limit
    /// </summary>
    Task SetGlobalUploadLimitAsync(long limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Ban peers
    /// </summary>
    Task BanPeersAsync(IEnumerable<string> peers, CancellationToken cancellationToken = default);
    #endregion

    #region Torrents
    /// <summary>
    /// Get list of torrents
    /// </summary>
    Task<IEnumerable<TorrentInfo>> GetTorrentsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent generic properties
    /// </summary>
    Task<TorrentProperties> GetTorrentPropertiesAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent trackers
    /// </summary>
    Task<IEnumerable<TorrentTrackerInfo>> GetTorrentTrackersAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent web seeds
    /// </summary>
    Task<IEnumerable<string>> GetTorrentWebSeedsAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent contents
    /// </summary>
    Task<IEnumerable<TorrentContentInfo>> GetTorrentContentsAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent pieces' states
    /// </summary>
    Task<IEnumerable<int>> GetTorrentPiecesStatesAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent pieces' hashes
    /// </summary>
    Task<IEnumerable<string>> GetTorrentPiecesHashesAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new torrent
    /// </summary>
    Task AddTorrentAsync(AddTorrentOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Pause torrents
    /// </summary>
    Task PauseTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resume torrents
    /// </summary>
    Task ResumeTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete torrents
    /// </summary>
    Task DeleteTorrentsAsync(IEnumerable<string> hashes, bool deleteFiles = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Recheck torrents
    /// </summary>
    Task RecheckTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reannounce torrents
    /// </summary>
    Task ReannounceTorrentsAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add trackers to torrent
    /// </summary>
    Task AddTrackersAsync(string hash, IEnumerable<string> urls, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit trackers
    /// </summary>
    Task EditTrackerAsync(string hash, string origUrl, string newUrl, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove trackers
    /// </summary>
    Task RemoveTrackersAsync(string hash, IEnumerable<string> urls, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add peers
    /// </summary>
    Task AddPeersAsync(string hash, IEnumerable<string> peers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent download limit
    /// </summary>
    Task<long> GetTorrentDownloadLimitAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set torrent download limit
    /// </summary>
    Task SetTorrentDownloadLimitAsync(string hash, long limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get torrent upload limit
    /// </summary>
    Task<long> GetTorrentUploadLimitAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set torrent upload limit
    /// </summary>
    Task SetTorrentUploadLimitAsync(string hash, long limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set torrent location
    /// </summary>
    Task SetTorrentLocationAsync(string hash, string location, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set torrent name
    /// </summary>
    Task SetTorrentNameAsync(string hash, string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set torrent category
    /// </summary>
    Task SetTorrentCategoryAsync(string hash, string category, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all categories
    /// </summary>
    Task<Dictionary<string, TorrentCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new category
    /// </summary>
    Task AddCategoryAsync(string category, string savePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit category
    /// </summary>
    Task EditCategoryAsync(string category, string savePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove categories
    /// </summary>
    Task RemoveCategoriesAsync(IEnumerable<string> categories, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add torrent tags
    /// </summary>
    Task AddTorrentTagsAsync(IEnumerable<string> hashes, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove torrent tags
    /// </summary>
    Task RemoveTorrentTagsAsync(IEnumerable<string> hashes, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all tags
    /// </summary>
    Task<IEnumerable<string>> GetAllTagsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Create tags
    /// </summary>
    Task CreateTagsAsync(IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete tags
    /// </summary>
    Task DeleteTagsAsync(IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set automatic torrent management
    /// </summary>
    Task SetAutomaticTorrentManagementAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default);

    /// <summary>
    /// Toggle sequential download
    /// </summary>
    Task ToggleSequentialDownloadAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set first/last piece priority
    /// </summary>
    Task SetFirstLastPiecePriorityAsync(IEnumerable<string> hashes, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set force start
    /// </summary>
    Task SetForceStartAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set super seeding
    /// </summary>
    Task SetSuperSeedingAsync(IEnumerable<string> hashes, bool enable, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rename file
    /// </summary>
    Task RenameFileAsync(string hash, int fileId, string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rename folder
    /// </summary>
    Task RenameFolderAsync(string hash, string oldPath, string newPath, CancellationToken cancellationToken = default);
    #endregion
} 
