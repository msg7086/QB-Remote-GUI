using System.Text.Json.Serialization;
using QB_Remote_GUI.API.Models.Torrents;

namespace QB_Remote_GUI.API.Models.Sync;

/// <summary>
/// Represents peer data response from qBittorrent
/// </summary>
public class PeerData
{
    /// <summary>
    /// Dictionary of peers, key is "ip:port"
    /// </summary>
    [JsonPropertyName("peers")]
    public Dictionary<string, PeerInfo>? Peers { get; set; }

    /// <summary>
    /// List of removed peers
    /// </summary>
    [JsonPropertyName("peers_removed")]
    public List<string>? RemovedPeers { get; set; }

    /// <summary>
    /// Response ID for partial updates
    /// </summary>
    [JsonPropertyName("rid")]
    public int? Rid { get; set; }

    /// <summary>
    /// Whether the response contains all the data or partial data
    /// </summary>
    [JsonPropertyName("full_update")]
    public bool IsFullUpdate { get; set; }
} 
