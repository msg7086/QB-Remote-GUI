using System.Text.Json.Serialization;

namespace QB_Remote_GUI.API.Models.Torrents;

/// <summary>
/// Represents torrent properties
/// </summary>
public class TorrentProperties
{
    /// <summary>
    /// Torrent save path
    /// </summary>
    [JsonPropertyName("save_path")]
    public string SavePath { get; set; } = string.Empty;

    /// <summary>
    /// Torrent creation date (Unix timestamp)
    /// </summary>
    [JsonPropertyName("creation_date")]
    public long CreationDate { get; set; }

    /// <summary>
    /// Torrent piece size (bytes)
    /// </summary>
    [JsonPropertyName("piece_size")]
    public long PieceSize { get; set; }

    /// <summary>
    /// Torrent comment
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Torrent total size (bytes)
    /// </summary>
    [JsonPropertyName("total_size")]
    public long TotalSize { get; set; }

    /// <summary>
    /// Total data uploaded for torrent (bytes)
    /// </summary>
    [JsonPropertyName("total_uploaded")]
    public long TotalUploaded { get; set; }

    /// <summary>
    /// Total data downloaded for torrent (bytes)
    /// </summary>
    [JsonPropertyName("total_downloaded")]
    public long TotalDownloaded { get; set; }

    /// <summary>
    /// Torrent upload limit (bytes/s)
    /// </summary>
    [JsonPropertyName("up_limit")]
    public long UploadLimit { get; set; }

    /// <summary>
    /// Torrent download limit (bytes/s)
    /// </summary>
    [JsonPropertyName("dl_limit")]
    public long DownloadLimit { get; set; }

    /// <summary>
    /// Torrent elapsed time (seconds)
    /// </summary>
    [JsonPropertyName("time_elapsed")]
    public long TimeElapsed { get; set; }

    /// <summary>
    /// Torrent elapsed time while complete (seconds)
    /// </summary>
    [JsonPropertyName("seeding_time")]
    public long SeedingTime { get; set; }

    /// <summary>
    /// Torrent connection count
    /// </summary>
    [JsonPropertyName("nb_connections")]
    public int ConnectionCount { get; set; }

    /// <summary>
    /// Torrent connection count limit
    /// </summary>
    [JsonPropertyName("nb_connections_limit")]
    public int ConnectionCountLimit { get; set; }

    /// <summary>
    /// Torrent share ratio
    /// </summary>
    [JsonPropertyName("share_ratio")]
    public double ShareRatio { get; set; }

    /// <summary>
    /// When this torrent was added (Unix timestamp)
    /// </summary>
    [JsonPropertyName("addition_date")]
    public long AdditionDate { get; set; }

    /// <summary>
    /// Torrent completion date (Unix timestamp)
    /// </summary>
    [JsonPropertyName("completion_date")]
    public long CompletionDate { get; set; }

    /// <summary>
    /// Torrent creator
    /// </summary>
    [JsonPropertyName("created_by")]
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// Torrent average download speed (bytes/second)
    /// </summary>
    [JsonPropertyName("dl_speed_avg")]
    public long AverageDownloadSpeed { get; set; }

    /// <summary>
    /// Torrent download speed (bytes/second)
    /// </summary>
    [JsonPropertyName("dl_speed")]
    public long DownloadSpeed { get; set; }

    /// <summary>
    /// Torrent average upload speed (bytes/second)
    /// </summary>
    [JsonPropertyName("up_speed_avg")]
    public long AverageUploadSpeed { get; set; }

    /// <summary>
    /// Torrent upload speed (bytes/second)
    /// </summary>
    [JsonPropertyName("up_speed")]
    public long UploadSpeed { get; set; }

    /// <summary>
    /// Torrent download path
    /// </summary>
    [JsonPropertyName("download_path")]
    public string DownloadPath { get; set; } = string.Empty;

    /// <summary>
    /// Torrent ETA (seconds)
    /// </summary>
    [JsonPropertyName("eta")]
    public long Eta { get; set; }

    /// <summary>
    /// Torrent has metadata
    /// </summary>
    [JsonPropertyName("has_metadata")]
    public bool HasMetadata { get; set; }

    /// <summary>
    /// Torrent hash
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; set; } = string.Empty;
    
    /// <summary>
    /// Torrent infohash v1
    /// </summary>
    [JsonPropertyName("infohash_v1")]
    public string InfohashV1 { get; set; } = string.Empty;
    
    /// <summary>
    /// Torrent infohash v2
    /// </summary>
    [JsonPropertyName("infohash_v2")]
    public string InfohashV2 { get; set; } = string.Empty;
    
    /// <summary>
    /// Torrent is private
    /// </summary>
    [JsonPropertyName("is_private")]
    public bool IsPrivate { get; set; }
    
    /// <summary>
    /// Torrent last seen (Unix timestamp)
    /// </summary>
    [JsonPropertyName("last_seen")]
    public long LastSeen { get; set; }
    
    /// <summary>
    /// Torrent name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Torrent peers
    /// </summary>
    [JsonPropertyName("peers")]
    public int Peers { get; set; }
    
    /// <summary>
    /// Torrent peers total
    /// </summary>
    [JsonPropertyName("peers_total")]
    public int PeersTotal { get; set; }
    
    /// <summary>
    /// Torrent pieces have
    /// </summary>
    [JsonPropertyName("pieces_have")]
    public int PiecesHave { get; set; }
    
    /// <summary>
    /// Torrent pieces num
    /// </summary>
    [JsonPropertyName("pieces_num")]
    public int PiecesNum { get; set; }
    
    /// <summary>
    /// Torrent popularity
    /// </summary>
    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }
    
    /// <summary>
    /// Torrent private
    /// </summary>
    [JsonPropertyName("private")]
    public bool Private { get; set; }   
    
    /// <summary>
    /// Torrent reannounce
    /// </summary>
    [JsonPropertyName("reannounce")]
    public long Reannounce { get; set; }
    
    /// <summary>
    /// Torrent seeds
    /// </summary>
    [JsonPropertyName("seeds")]
    public int Seeds { get; set; }
    
    /// <summary>
    /// Torrent seeds total
    /// </summary>
    [JsonPropertyName("seeds_total")]
    public int SeedsTotal { get; set; }
    
    /// <summary>
    /// Torrent total downloaded session
    /// </summary>
    [JsonPropertyName("total_downloaded_session")]
    public long TotalDownloadedSession { get; set; }
    
    /// <summary>
    /// Torrent total uploaded session
    /// </summary>
    [JsonPropertyName("total_uploaded_session")]
    public long TotalUploadedSession { get; set; }
    
    /// <summary>
    /// Torrent total wasted
    /// </summary>
    [JsonPropertyName("total_wasted")]
    public long TotalWasted { get; set; }
}

/*
{
    "eta": 8640000,
    "has_metadata": true,
    "hash": "21fa8581c6411fd0bfc099d38138a113d90d9e01",
    "infohash_v1": "21fa8581c6411fd0bfc099d38138a113d90d9e01",
    "infohash_v2": "",
    "is_private": false,
    "last_seen": -1,
    "name": "[Kamigami] Ace of Diamond [BD 720p x264 AAC CHS]",
    "peers": 0,
    "peers_total": 0,
    "pieces_have": 1466,
    "pieces_num": 1466,
    "popularity": 7349.041146577186,
    "private": false,
    "reannounce": 85,
    "seeds": 0,
    "seeds_total": 1,
    "total_downloaded_session": 0,
    "total_uploaded_session": 0,
    "total_wasted": 0,
}
*/
