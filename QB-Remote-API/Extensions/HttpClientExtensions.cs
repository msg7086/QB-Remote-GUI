using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using QB_Remote_GUI.API.Exceptions;

namespace QB_Remote_GUI.API.Extensions;

/// <summary>
/// Extension methods for HttpClient
/// </summary>
internal static class HttpClientExtensions
{
    private static readonly bool DebugEnabled = true;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Sends a GET request and deserializes the JSON response
    /// </summary>
    public static async Task<T> GetJsonAsync<T>(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        if (DebugEnabled)
            Debug.WriteLine($"[GetJsonAsync] GET {requestUri}");
        var response = await client.GetAsync(requestUri, cancellationToken);
        await EnsureSuccessStatusCodeAsync(response);
        
        if (typeof(T) == typeof(string))
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return (T)(object)content;
        }

        var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions, cancellationToken);
        if (result == null)
            throw new QBittorrentClientException("Failed to deserialize response");
        return result;
    }

    /// <summary>
    /// Sends a POST request with form data
    /// </summary>
    public static async Task PostFormAsync(this HttpClient client, string requestUri, Dictionary<string, string> data, CancellationToken cancellationToken = default)
    {
        if (DebugEnabled)
            Debug.WriteLine($"[PostFormAsync] POST {requestUri} - {string.Join("&", data.Select(x => $"{x.Key}={x.Value}"))}");
        using var content = new FormUrlEncodedContent(data);
        var response = await client.PostAsync(requestUri, content, cancellationToken);
        await EnsureSuccessStatusCodeAsync(response);
    }

    /// <summary>
    /// Sends a POST request with JSON content
    /// </summary>
    public static async Task PostJsonAsync(this HttpClient client, string requestUri, object data, CancellationToken cancellationToken = default)
    {
        if (DebugEnabled)
            Debug.WriteLine($"[PostJsonAsync] POST {requestUri} - {JsonSerializer.Serialize(data)}");
        var response = await client.PostAsJsonAsync(requestUri, data, JsonOptions, cancellationToken);
        await EnsureSuccessStatusCodeAsync(response);
    }

    /// <summary>
    /// Sends a POST request with multipart content
    /// </summary>
    public static async Task PostMultipartAsync(this HttpClient client, string requestUri, MultipartFormDataContent content, CancellationToken cancellationToken = default)
    {
        if (DebugEnabled)
            Debug.WriteLine($"[PostMultipartAsync] POST {requestUri} - {content}");
        var response = await client.PostAsync(requestUri, content, cancellationToken);
        await EnsureSuccessStatusCodeAsync(response);
    }

    /// <summary>
    /// Ensures the HTTP response was successful, otherwise throws an exception with details
    /// </summary>
    private static async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode) {
            if (DebugEnabled)
                Debug.WriteLine($"[EnsureSuccessStatusCodeAsync] {response.StatusCode} - {content}\n");
            return;
        }

        throw new QBittorrentClientException($"HTTP request failed: {response.StatusCode} - {content}")
        {
            StatusCode = (int)response.StatusCode
        };
    }
} 
