using Microsoft.Extensions.DependencyInjection;
using QB_Remote_GUI.API.Clients;
using QB_Remote_GUI.API.Interfaces;

namespace QB_Remote_GUI.API.Extensions;

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
