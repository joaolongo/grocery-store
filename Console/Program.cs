using Lamar.Microsoft.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using JasperFx.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console;

[ExcludeFromCodeCoverage(Justification = "No testable units.")]
public static class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            // .AddLogger(LoggingConfigurationSection)
            .UseLamar()
            .ConfigureAppConfiguration((context, builder) =>
            {
                context
                    .HostingEnvironment
                    .BuildAppSettings(builder)
                    .Build();
            });

        builder.ConfigureContainer(Startup.ConfigureDelegate);
        
        builder.ConfigureServices(services => services.AddHostedService<ServiceWorker>());
        await builder.RunConsoleAsync();
    }
    
    private static IConfigurationBuilder BuildAppSettings(this IHostEnvironment env, IConfigurationBuilder builder)
    {
        builder.Sources.RemoveAll(x => 
            x.GetType() == typeof(JsonConfigurationSource) || 
            x.GetType() == typeof(EnvironmentVariablesConfigurationSource));
        
        return builder
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile("appsettings." + env.EnvironmentName + ".json", true)
            .AddEnvironmentVariables();
    }
}