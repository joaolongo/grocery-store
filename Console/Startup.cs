using System.Diagnostics.CodeAnalysis;
using APP;
using APP.Services;
using APP.Services.Contracts;
using APP.Settings;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Console;

[ExcludeFromCodeCoverage(Justification = "No testable units.")]
public class Startup
{
    public static Action<HostBuilderContext, ServiceRegistry> ConfigureDelegate => (ctx, registry) =>
    {
        registry.Scan(scanner =>
        {
            scanner.Assembly("APP");

            scanner.AssemblyContainingType<Startup>();
            scanner.TheCallingAssembly();
            scanner.WithDefaultConventions();
            scanner.LookForRegistries();

            scanner.ConnectImplementationsToTypesClosing(typeof(IService<>));
        });

        registry.For<IItemService>().Use<ItemService>();

        registry.AddDbContext<ApplicationContext>();

        registry
            .Configure<AppSettings>(ctx.Configuration)
            .AddSingleton(context => context.GetRequiredService<IOptions<AppSettings>>().Value);
        registry
            .Configure<ConnectionStrings>(ctx.Configuration.GetSection(nameof(ConnectionStrings)))
            .AddSingleton(context => context.GetRequiredService<IOptions<ConnectionStrings>>().Value);
    };
}