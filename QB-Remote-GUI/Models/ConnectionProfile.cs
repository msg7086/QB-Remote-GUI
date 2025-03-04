using System.Text.Json.Serialization;

namespace QB_Remote_GUI.Models;

public class ConnectionProfile
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    [JsonPropertyName("port")]
    public int Port { get; set; } = 8080;

    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("timeout_seconds")]
    public int TimeoutSeconds { get; set; } = 30;

    [JsonPropertyName("use_ssl")]
    public bool UseSsl { get; set; }

    [JsonPropertyName("last_used")]
    public DateTime LastUsed { get; set; }

    public string GetBaseUrl() => $"http{(UseSsl ? "s" : "")}://{Host}:{Port}";

    public override string ToString() => Name;
} 
