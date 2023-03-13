using System.Reflection;
using APP.Domain;
using APP.Settings;
using Microsoft.EntityFrameworkCore;

namespace APP;

public class ApplicationContext : DbContext
{
    private readonly AppSettings _settings;

    public ApplicationContext(DbContextOptions options
        , AppSettings settings) : base(options)
    {
        _settings = settings;
    }

    private static IEnumerable<Assembly> LoadAssemblies()
    {
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        if (assemblyName != null) yield return Assembly.Load(assemblyName);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        
        if (_settings.Development)
            optionsBuilder.EnableSensitiveDataLogging();


        optionsBuilder.UseNpgsql(_settings.ConnectionStrings.DefaultConnection,
            builder => { builder.MigrationsAssembly(GetType().Assembly.FullName); });

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var loadAssembly in LoadAssemblies())
            modelBuilder.ApplyConfigurationsFromAssembly(loadAssembly);
        base.OnModelCreating(modelBuilder);

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var items = new List<Item>
        {
            new()
            {
                Id = new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"),
                Name = "Soup",
                Price = 0.65m
            },
            new()
            {
                Id = new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"),
                Name = "Bread",
                Price = 0.8m
            },
            new()
            {
                Id = new Guid("d7aeb3c3-8467-4e60-bec1-12ba88e59380"),
                Name = "Milk",
                Price = 1.3m
            },
            new()
            {
                Id = new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"),
                Name = "Apples",
                Price = 1m
            }
        };
        
        modelBuilder.Entity<Item>().HasData(items);
        
        var specialOfferBuilder = modelBuilder.Entity<SpecialOffer>();
        
        var offer1 = new SpecialOffer
        {
            Id = new Guid("317f6f8f-b0df-44a7-b07d-05c8f2fcf02b"),
            Percentage = 0.1m,
            ItemId = new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"),
            RequiredAmount = 1,
            Description = "Apples have 10% off their normal price this week",
            DiscountItem = null
        };
        
        specialOfferBuilder.HasData(offer1);

        var offer2 = new SpecialOffer
        {
            Id = new Guid("9faae3b7-2e49-4b7e-9fa3-74e8a259afe0"),
            Percentage = 0.5m,
            ItemId = new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"),
            DiscountItemId = new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"),
            RequiredAmount = 2,
            Description = "Buy 2 tins of soup and get a loaf of bread for half price"
        };
        
        specialOfferBuilder.HasData(offer2);
    }
}