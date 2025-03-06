using System.Text.Json.Serialization;

namespace QB_Remote_GUI.API.Models.Torrents;

/// <summary>
/// Represents torrent information from qBittorrent
/// </summary>
public class TorrentInfo
{
    /// <summary>
    /// Torrent hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    /// Torrent name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Torrent size (bytes)
    /// </summary>
    [JsonPropertyName("size")]
    public long? Size { get; set; }

    /// <summary>
    /// Torrent progress (0-1)
    /// </summary>
    [JsonPropertyName("progress")]
    public double? Progress { get; set; }

    /// <summary>
    /// Download speed (bytes/s)
    /// </summary>
    [JsonPropertyName("dlspeed")]
    public long? DownloadSpeed { get; set; }

    /// <summary>
    /// Upload speed (bytes/s)
    /// </summary>
    [JsonPropertyName("upspeed")]
    public long? UploadSpeed { get; set; }

    /// <summary>
    /// Priority (-1 if queuing is disabled)
    /// </summary>
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    /// <summary>
    /// Number of seeds connected to
    /// </summary>
    [JsonPropertyName("num_seeds")]
    public int? ConnectedSeeds { get; set; }

    /// <summary>
    /// Number of peers connected to
    /// </summary>
    [JsonPropertyName("num_leechs")]
    public int? ConnectedPeers { get; set; }

    /// <summary>
    /// Number of seeds in swarm
    /// </summary>
    [JsonPropertyName("num_complete")]
    public int? TotalSeeds { get; set; }

    /// <summary>
    /// Number of peers in swarm
    /// </summary>
    [JsonPropertyName("num_incomplete")]
    public int? TotalPeers { get; set; }

    /// <summary>
    /// Torrent state
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Torrent category
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Torrent tags (comma separated)
    /// </summary>
    [JsonPropertyName("tags")]
    public string? Tags { get; set; }

    /// <summary>
    /// Torrent save path
    /// </summary>
    [JsonPropertyName("save_path")]
    public string? SavePath { get; set; }

    /// <summary>
    /// Time when the torrent was added (Unix timestamp)
    /// </summary>
    [JsonPropertyName("added_on")]
    public long? AddedOn { get; set; }

    /// <summary>
    /// Time when the torrent was completed (Unix timestamp)
    /// </summary>
    [JsonPropertyName("completion_on")]
    public long? CompletionOn { get; set; }

    /// <summary>
    /// Time when the torrent was last active (Unix timestamp)
    /// </summary>
    [JsonPropertyName("last_activity")]
    public long? LastActive { get; set; }

    /// <summary>
    /// Amount left to download (bytes)
    /// </summary>
    [JsonPropertyName("amount_left")]
    public long? AmountLeft { get; set; }

    /// <summary>
    /// Auto TMM (true if auto TMM is enabled)
    /// </summary>
    [JsonPropertyName("auto_tmm")]
    public bool? AutoTmm { get; set; }

    /// <summary>
    /// Availability (0-1)
    /// </summary>
    [JsonPropertyName("availability")]
    public double? Availability { get; set; }

    /// <summary>
    /// Torrent comment
    /// </summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    /// <summary>
    /// Torrent completed (bytes)
    /// </summary>
    [JsonPropertyName("completed")]
    public long? Completed { get; set; }

    /// <summary>
    /// Torrent content path
    /// </summary>
    [JsonPropertyName("content_path")]
    public string? ContentPath { get; set; }

    /// <summary>
    /// Torrent download limit (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_limit")]
    public long? DownloadLimit { get; set; }

    /// <summary>
    /// Torrent download path
    /// </summary>
    [JsonPropertyName("download_path")]
    public string? DownloadPath { get; set; }

    /// <summary>
    /// Torrent downloaded (bytes)
    /// </summary>
    [JsonPropertyName("downloaded")]
    public long? Downloaded { get; set; }

    /// <summary>
    /// Torrent downloaded in current session (bytes)
    /// </summary>
    [JsonPropertyName("downloaded_session")]
    public long? DownloadedSession { get; set; }

    /// <summary>
    /// Torrent ETA (seconds)
    /// </summary>
    [JsonPropertyName("eta")]
    public long? Eta { get; set; }

    /// <summary>
    /// Torrent force start (true if force start is enabled)
    /// </summary>
    [JsonPropertyName("force_start")]
    public bool? ForceStart { get; set; }

    /// <summary>
    /// Torrent has metadata (true if metadata is available)
    /// </summary>
    [JsonPropertyName("has_metadata")]
    public bool? HasMetadata { get; set; }

    /// <summary>
    /// Torrent inactive seeding time limit (seconds)
    /// </summary>
    [JsonPropertyName("inactive_seeding_time_limit")]
    public long? InactiveSeedingTimeLimit { get; set; }

    /// <summary>
    /// Torrent info hash (v1)
    /// </summary>
    [JsonPropertyName("infohash_v1")]
    public string? InfoHashV1 { get; set; }

    /// <summary>
    /// Torrent info hash (v2)
    /// </summary>
    [JsonPropertyName("infohash_v2")]
    public string? InfoHashV2 { get; set; }

    /// <summary>
    /// Torrent magnet URI
    /// </summary>
    [JsonPropertyName("magnet_uri")]
    public string? MagnetUri { get; set; }

    /// <summary>
    /// Torrent max inactive seeding time (seconds)
    /// </summary>
    [JsonPropertyName("max_inactive_seeding_time")]
    public long? MaxInactiveSeedingTime { get; set; }

    /// <summary>
    /// Torrent max ratio
    /// </summary>
    [JsonPropertyName("max_ratio")]
    public double? MaxRatio { get; set; }

    /// <summary>
    /// Torrent max seeding time (seconds)
    /// </summary>
    [JsonPropertyName("max_seeding_time")]
    public long? MaxSeedingTime { get; set; }

    /// <summary>
    /// Torrent popularity
    /// </summary>
    [JsonPropertyName("popularity")]
    public double? Popularity { get; set; }

    /// <summary>
    /// Torrent private (true if private torrent)
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; set; }

    /// <summary>
    /// Torrent ratio
    /// </summary>
    [JsonPropertyName("ratio")]
    public double? Ratio { get; set; }

    /// <summary>
    /// Torrent ratio limit
    /// </summary>
    [JsonPropertyName("ratio_limit")]
    public double? RatioLimit { get; set; }

    /// <summary>
    /// Torrent reannounce count
    /// </summary>
    [JsonPropertyName("reannounce")]
    public int? Reannounce { get; set; }

    /// <summary>
    /// Torrent root path
    /// </summary>
    [JsonPropertyName("root_path")]
    public string? RootPath { get; set; }

    /// <summary>
    /// Torrent seeding time
    /// </summary>
    [JsonPropertyName("seeding_time")]
    public long? SeedingTime { get; set; }

    /// <summary>
    /// Torrent seeding time limit
    /// </summary>
    [JsonPropertyName("seeding_time_limit")]
    public long? SeedingTimeLimit { get; set; }

    /// <summary>
    /// Torrent seen complete
    /// </summary>
    [JsonPropertyName("seen_complete")]
    public int? SeenComplete { get; set; }

    /// <summary>
    /// Torrent sequential download (true if sequential download is enabled)
    /// </summary>
    [JsonPropertyName("seq_dl")]
    public bool? SequentialDownload { get; set; }

    /// <summary>
    /// Torrent super seeding (true if super seeding is enabled)
    /// </summary>
    [JsonPropertyName("super_seeding")]
    public bool? SuperSeeding { get; set; }

    /// <summary>
    /// Torrent time active (seconds)
    /// </summary>
    [JsonPropertyName("time_active")]
    public long? TimeActive { get; set; }

    /// <summary>
    /// Torrent total size (bytes)
    /// </summary>
    [JsonPropertyName("total_size")]
    public long? TotalSize { get; set; }

    /// <summary>
    /// Torrent tracker
    /// </summary>
    [JsonPropertyName("tracker")]
    public string? Tracker { get; set; }

    /// <summary>
    /// Torrent trackers count
    /// </summary>
    [JsonPropertyName("trackers_count")]
    public int? TrackersCount { get; set; }

    /// <summary>
    /// Torrent upload limit (bytes/s)
    /// </summary>
    [JsonPropertyName("up_limit")]
    public long? UploadLimit { get; set; }

    /// <summary>
    /// Torrent uploaded (bytes)
    /// </summary>
    [JsonPropertyName("uploaded")]
    public long? Uploaded { get; set; }

    /// <summary>
    /// Torrent uploaded in current session (bytes)
    /// </summary>
    [JsonPropertyName("uploaded_session")]
    public long? UploadedSession { get; set; }

    /// <summary>
    /// Update the current torrent info with another torrent info (could contain partial data, unchanged properties will be null, and will be ignored)
    /// </summary>
    /// <param name="other">The other torrent info to update with</param>
    public void Update(TorrentInfo other)
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
