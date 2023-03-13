using System.Globalization;
using System.Text.Json;
using APP.Domain;
using APP.Services.Contracts;
using JasperFx.Core;
using Microsoft.Extensions.Hosting;
using static System.Console;
namespace Console;

public class ServiceWorker : BackgroundService
{
    private readonly IHostApplicationLifetime _host;
    private readonly IItemService _itemService;
    private readonly IBasketService _basketService;

    public ServiceWorker(IHostApplicationLifetime host, IItemService itemService, IBasketService basketService)
    {
        _host = host;
        _itemService = itemService;
        _basketService = basketService;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var dbItems = await _itemService.GetAll();
            
            WriteLine($"Available products: {dbItems.Select(x => x.Name).Join(" ")}");
            WriteLine("Please insert the items you want to buy, separated by space:");
            Write("PriceBasket: ");
            var inputBasket = ReadLine();
            var requestedItems = inputBasket?.Split(" ").Select(x => new Item
            {
                Name = x
            });

            if (requestedItems is null)
            {
                WriteLine("No items selected");
                return;
            }

            var itemsToList = dbItems.Intersect(requestedItems).GroupBy(x => x);

            var basket = new Basket();

            var basketItems = itemsToList.Select(item => 
                new BasketItem { Basket = basket, Item = item.Key, Quantity = item.Count() }).ToList();

            basket.Items = basketItems;

            var result = 
                _basketService.GetPrice(basket).ToString("C", CultureInfo.GetCultureInfo("en-GB"));
            var resultWithNoDiscount =
                basket.Items.Sum(x => x.Item.Price).ToString("C", CultureInfo.GetCultureInfo("en-GB"));
            
            WriteLine($"Subtotal: {resultWithNoDiscount}");

            var offers = basket.Items.Select(x => x.Item.SpecialOffer).ToList();
            
            if(offers.Count < 1 || offers.All(x => x is null))
                WriteLine("(no offers available)");
            else
                foreach (var discount in offers.Where(discount => discount is not null))
                {
                    WriteLine(discount!.Item.SpecialOffer!.Description);
                }
            
            WriteLine($"Total: {result}");
        }
        finally
        {
            _host.StopApplication();
        }
    }
}