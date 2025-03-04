namespace QB.Remote.API.Models.Torrents;

/// <summary>
/// Options for adding a new torrent
/// </summary>
public class AddTorrentOptions
{
    /// <summary>
    /// URLs for torrents to add (either magnet links or URLs to .torrent files)
    /// </summary>
    public IEnumerable<string> Urls { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Torrent files to add
    /// </summary>
    public IEnumerable<byte[]> TorrentFiles { get; set; } = Array.Empty<byte[]>();

    /// <summary>
    /// Download folder
    /// </summary>
    public string? SavePath { get; set; }

    /// <summary>
    /// Cookie sent to download the .torrent file
    /// </summary>
    public string? Cookie { get; set; }

    /// <summary>
    /// Category for the torrent
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Tags for the torrent (comma separated)
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// Skip hash checking
    /// </summary>
    public bool? SkipChecking { get; set; }

    /// <summary>
    /// Add torrents in the stopped state
    /// </summary>
    public bool? Stopped { get; set; }

    /// <summary>
    /// Enable sequential download
    /// </summary>
    public bool? Sequential { get; set; }

    /// <summary>
    /// Enable first/last piece priority
    /// </summary>
    public bool? FirstLastPiecePriority { get; set; }

    /// <summary>
    /// Add to top of queue
    /// </summary>
    public bool? AddToTopOfQueue { get; set; }

    /// <summary>
    /// Create the root folder
    /// </summary>
    public bool? CreateRootFolder { get; set; }

    /// <summary>
    /// Enable automatic torrent management
    /// </summary>
    public bool? AutomaticTorrentManagement { get; set; }

    /// <summary>
    /// Rename the torrent
    /// </summary>
    public string? Rename { get; set; }

    /// <summary>
    /// Set torrent download speed limit in bytes/second
    /// </summary>
    public long? DownloadLimit { get; set; }

    /// <summary>
    /// Set torrent upload speed limit in bytes/second
    /// </summary>
    public long? UploadLimit { get; set; }

    /// <summary>
    /// Set torrent share ratio limit
    /// </summary>
    public float? RatioLimit { get; set; }

    /// <summary>
    /// Set torrent seeding time limit in minutes
    /// </summary>
    public long? SeedingTimeLimit { get; set; }
} 
