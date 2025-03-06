using System.ComponentModel.DataAnnotations;

namespace QB.Remote.API.Clients;

/// <summary>
/// Configuration options for the qBittorrent client
/// </summary>
public class QBittorrentClientOptions
{
    /// <summary>
    /// The base URL of the qBittorrent WebUI (e.g. http://localhost:8080)
    /// </summary>
    [Required]
    public string BaseUrl { get; init; } = string.Empty;

    /// <summary>
    /// The username for authentication
    /// </summary>
    [Required]
    public string Username { get; init; } = string.Empty;

    /// <summary>
    /// The password for authentication
    /// </summary>
    [Required]
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// Timeout for HTTP requests in seconds. Default is 30 seconds.
    /// </summary>
    public int TimeoutSeconds { get; init; } = 30;
} 
