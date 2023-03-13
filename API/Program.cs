using System.Diagnostics.CodeAnalysis;
using JasperFx.Core;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

namespace API;

[ExcludeFromCodeCoverage(Justification = "No testable units.")]
public static class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateWebHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseLamar()
            .ConfigureAppConfiguration((context, builder) =>
            {
                context
                    .HostingEnvironment
                    .BuildAppSettings(builder)
                    .Build();
            })
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
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
