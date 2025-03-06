using System.Text.Json.Serialization;

namespace QB_Remote_GUI.API.Models.Transfer;

/// <summary>
/// Represents global transfer information
/// </summary>
public class TransferInfo
{
    /// <summary>
    /// Global download rate (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_info_speed")]
    public long DownloadSpeed { get; set; }

    /// <summary>
    /// Global upload rate (bytes/s)
    /// </summary>
    [JsonPropertyName("up_info_speed")]
    public long UploadSpeed { get; set; }

    /// <summary>
    /// Data downloaded this session (bytes)
    /// </summary>
    [JsonPropertyName("dl_info_data")]
    public long DownloadedThisSession { get; set; }

    /// <summary>
    /// Data uploaded this session (bytes)
    /// </summary>
    [JsonPropertyName("up_info_data")]
    public long UploadedThisSession { get; set; }

    /// <summary>
    /// Download rate limit (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_rate_limit")]
    public long DownloadRateLimit { get; set; }

    /// <summary>
    /// Upload rate limit (bytes/s)
    /// </summary>
    [JsonPropertyName("up_rate_limit")]
    public long UploadRateLimit { get; set; }

    /// <summary>
    /// DHT nodes connected to
    /// </summary>
    [JsonPropertyName("dht_nodes")]
    public int DhtNodes { get; set; }

    /// <summary>
    /// Connection status
    /// </summary>
    [JsonPropertyName("connection_status")]
    public string ConnectionStatus { get; set; } = string.Empty;

    /// <summary>
    /// True if alternative speed limits are enabled
    /// </summary>
    [JsonPropertyName("use_alt_speed_limits")]
    public bool UseAlternativeSpeedLimits { get; set; }
} 
