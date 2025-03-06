using System.Text.Json.Serialization;

namespace QB_Remote_GUI.API.Models.Torrents;

/// <summary>
/// Represents torrent content information
/// </summary>
public class TorrentContentInfo
{
    /// <summary>
    /// File index
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    /// File name (including relative path)
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// File size (bytes)
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// File progress (percentage)
    /// </summary>
    [JsonPropertyName("progress")]
    public double Progress { get; set; }

    /// <summary>
    /// File priority
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    /// <summary>
    /// True if file is seed, false otherwise
    /// </summary>
    [JsonPropertyName("is_seed")]
    public bool IsSeed { get; set; }

    /// <summary>
    /// File piece range
    /// </summary>
    [JsonPropertyName("piece_range")]
    public int[] PieceRange { get; set; } = [];

    /// <summary>
    /// File availability
    /// </summary>
    [JsonPropertyName("availability")]
    public double Availability { get; set; }
} 
