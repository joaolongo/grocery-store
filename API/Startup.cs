using APP;
using APP.Services.Contracts;
using APP.Settings;
using Lamar;
using Microsoft.Extensions.Options;

namespace API;

public class Startup
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        _env = env;
        _configuration = configuration;
    }

    public void ConfigureContainer(ServiceRegistry services)
    {
        services.Scan(scanner =>
        {
            scanner.Assembly("APP");
            
            scanner.AssemblyContainingType<Startup>();
            scanner.TheCallingAssembly();
            scanner.WithDefaultConventions();
            scanner.LookForRegistries();
            
            scanner.ConnectImplementationsToTypesClosing(typeof(IService<>));
        });

        services
            .Configure<AppSettings>(_configuration)
            .AddSingleton(context => context.GetRequiredService<IOptions<AppSettings>>().Value);
        services
            .Configure<ConnectionStrings>(_configuration.GetSection(nameof(ConnectionStrings)))
            .AddSingleton(context => context.GetRequiredService<IOptions<ConnectionStrings>>().Value);

        services.AddDbContext<ApplicationContext>();
        
        services.AddCors(options =>
        {
            options.AddPolicy("GROCERY_STORE_POLICY_NAME",
                policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
        
        services.AddSwaggerGen();
        
        services.AddControllers(options => { options.EnableEndpointRouting = false; })
            .AddControllersAsServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
    }
}

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();