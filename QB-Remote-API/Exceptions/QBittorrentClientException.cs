namespace QB.Remote.API.Exceptions;

/// <summary>
/// Exception thrown when an error occurs while interacting with qBittorrent WebUI
/// </summary>
public class QBittorrentClientException : Exception
{
    /// <summary>
    /// Creates a new instance of QBittorrentClientException
    /// </summary>
    public QBittorrentClientException() { }

    /// <summary>
    /// Creates a new instance of QBittorrentClientException with a specified error message
    /// </summary>
    public QBittorrentClientException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of QBittorrentClientException with a specified error message and inner exception
    /// </summary>
    public QBittorrentClientException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// HTTP status code if applicable
    /// </summary>
    public int? StatusCode { get; set; }
} 
