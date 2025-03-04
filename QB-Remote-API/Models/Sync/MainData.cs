using System.Text.Json.Serialization;
using QB.Remote.API.Models.Torrents;

namespace QB.Remote.API.Models.Sync;

/// <summary>
/// Represents main data from qBittorrent
/// </summary>
public class MainData
{
    /// <summary>
    /// Response ID
    /// </summary>
    [JsonPropertyName("rid")]
    public int Rid { get; set; }

    /// <summary>
    /// Whether the response contains all the data or partial data
    /// </summary>
    [JsonPropertyName("full_update")]
    public bool IsFullUpdate { get; set; }

    /// <summary>
    /// List of torrents (hash, TorrentInfo)
    /// </summary>
    [JsonPropertyName("torrents")]
    public Dictionary<string, TorrentInfo> Torrents { get; set; } = new();

    /// <summary>
    /// List of removed torrents
    /// </summary>
    [JsonPropertyName("torrents_removed")]
    public List<string> RemovedTorrents { get; set; } = new();

    /// <summary>
    /// List of categories
    /// </summary>
    [JsonPropertyName("categories")]
    public Dictionary<string, TorrentCategory> Categories { get; set; } = new();

    /// <summary>
    /// List of tags
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// Global transfer information
    /// </summary>
    [JsonPropertyName("server_state")]
    public ServerState ServerState { get; set; } = new();
}

/// <summary>
/// Represents torrent category information
/// </summary>
public class TorrentCategory
{
    /// <summary>
    /// Category name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Category save path
    /// </summary>
    [JsonPropertyName("savePath")]
    public string SavePath { get; set; } = string.Empty;
}

/// <summary>
/// Represents server state information
/// </summary>
public class ServerState
{
    /// <summary>
    /// Global download speed (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_info_speed")]
    public long DownloadSpeed { get; set; }

    /// <summary>
    /// Global upload speed (bytes/s)
    /// </summary>
    [JsonPropertyName("up_info_speed")]
    public long UploadSpeed { get; set; }

    /// <summary>
    /// DHT nodes connected to
    /// </summary>
    [JsonPropertyName("dht_nodes")]
    public int DhtNodes { get; set; }

    /// <summary>
    /// Free space on disk (bytes)
    /// </summary>
    [JsonPropertyName("free_space_on_disk")]
    public long FreeSpaceOnDisk { get; set; }

    /// <summary>
    /// True if alternative speed limits are enabled
    /// </summary>
    [JsonPropertyName("use_alt_speed_limits")]
    public bool UseAlternativeSpeedLimits { get; set; }

    /// <summary>
    /// Connection status
    /// </summary>
    [JsonPropertyName("connection_status")]
    public string ConnectionStatus { get; set; } = string.Empty;
} 
