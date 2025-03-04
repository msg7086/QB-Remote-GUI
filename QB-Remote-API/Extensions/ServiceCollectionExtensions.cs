using Microsoft.Extensions.DependencyInjection;
using QB.Remote.API.Clients;
using QB.Remote.API.Interfaces;

namespace QB.Remote.API.Extensions;

/// <summary>
/// Extension methods for IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds qBittorrent client services to the service collection
    /// </summary>
    public static IServiceCollection AddQBittorrentClient(this IServiceCollection services, Action<QBittorrentClientOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddHttpClient();
        services.AddScoped<IQBittorrentClient, QBittorrentClient>();
        return services;
    }
} 
