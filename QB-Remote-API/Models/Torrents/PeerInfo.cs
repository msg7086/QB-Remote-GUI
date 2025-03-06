using System.Text.Json.Serialization;

namespace QB.Remote.API.Models.Torrents;

/// <summary>
/// Represents peer information from qBittorrent
/// </summary>
public class PeerInfo
{
    /// <summary>
    /// Peer IP address
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Peer port
    /// </summary>
    [JsonPropertyName("port")]
    public int? Port { get; set; }

    /// <summary>
    /// Client name
    /// </summary>
    [JsonPropertyName("client")]
    public string? Client { get; set; }

    /// <summary>
    /// Connection type
    /// </summary>
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    /// <summary>
    /// Country name
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Country code
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Download speed (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_speed")]
    public long? DownloadSpeed { get; set; }

    /// <summary>
    /// Total downloaded (bytes)
    /// </summary>
    [JsonPropertyName("downloaded")]
    public long? Downloaded { get; set; }

    /// <summary>
    /// Files being downloaded
    /// </summary>
    [JsonPropertyName("files")]
    public string? Files { get; set; }

    /// <summary>
    /// Peer flags
    /// </summary>
    [JsonPropertyName("flags")]
    public string? Flags { get; set; }

    /// <summary>
    /// Flags description
    /// </summary>
    [JsonPropertyName("flags_desc")]
    public string? FlagsDescription { get; set; }

    /// <summary>
    /// Peer client ID
    /// </summary>
    [JsonPropertyName("peer_id_client")]
    public string? PeerIdClient { get; set; }

    /// <summary>
    /// Progress (0-1)
    /// </summary>
    [JsonPropertyName("progress")]
    public double? Progress { get; set; }

    /// <summary>
    /// Relevance
    /// </summary>
    [JsonPropertyName("relevance")]
    public double? Relevance { get; set; }

    /// <summary>
    /// Whether the peer is shadowbanned
    /// </summary>
    [JsonPropertyName("shadowbanned")]
    public bool? Shadowbanned { get; set; }

    /// <summary>
    /// Upload speed (bytes/s)
    /// </summary>
    [JsonPropertyName("up_speed")]
    public long? UploadSpeed { get; set; }

    /// <summary>
    /// Total uploaded (bytes)
    /// </summary>
    [JsonPropertyName("uploaded")]
    public long? Uploaded { get; set; }

    /// <summary>
    /// Update the current peer info with another peer info (could contain partial data)
    /// </summary>
    /// <param name="other">The other peer info to update with</param>
    public void Update(PeerInfo other)
    {
        foreach (var property in other.GetType().GetProperties())
        {
            var value = property.GetValue(other);
            if (value != null)
            {
                property.SetValue(this, value);
            }
        }
    }
} 
