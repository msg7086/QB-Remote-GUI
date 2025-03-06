using System.Text.Json.Serialization;

namespace QB_Remote_GUI.API.Models.Torrents;

/// <summary>
/// Represents torrent tracker information
/// </summary>
public class TorrentTrackerInfo
{
    /// <summary>
    /// Tracker URL
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Tracker status
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Tracker tier
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier { get; set; }

    /// <summary>
    /// Number of peers for current torrent reported by the tracker
    /// </summary>
    [JsonPropertyName("num_peers")]
    public int NumPeers { get; set; }

    /// <summary>
    /// Number of seeds for current torrent reported by the tracker
    /// </summary>
    [JsonPropertyName("num_seeds")]
    public int NumSeeds { get; set; }

    /// <summary>
    /// Number of leeches for current torrent reported by the tracker
    /// </summary>
    [JsonPropertyName("num_leeches")]
    public int NumLeeches { get; set; }

    /// <summary>
    /// Number of completed downloads for current torrent reported by the tracker
    /// </summary>
    [JsonPropertyName("num_downloaded")]
    public int NumDownloaded { get; set; }

    /// <summary>
    /// Tracker message (there is no way to know what this message is - it's up to tracker admins)
    /// </summary>
    [JsonPropertyName("msg")]
    public string Message { get; set; } = string.Empty;
} 
