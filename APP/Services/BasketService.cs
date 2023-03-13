using APP.Domain;
using APP.Services.Contracts;

namespace APP.Services;

public class BasketService : Service<Basket>, IBasketService
{
    private readonly IBasketItemService _basketItemService;

    public BasketService(ApplicationContext context, IBasketItemService basketItemService) : base(context)
    {
        _basketItemService = basketItemService;
    }

    public async Task<decimal?> GetPrice(Guid id)
    {
        var basket = await Get(id);

        if (basket is null)
            return null!; //TODO: Handle not found
        if (basket.Items.Count < 1)
            return null!; //TODO: Handle value 0

        return basket.Items.Sum(x => _basketItemService.GetDiscount(x));
    }

    public decimal GetPrice(Basket basket)
    {
        if (basket.Items.Count < 1)
            return 0; //TODO: Handle value 0

        return basket.Items.Sum(item => _basketItemService.GetDiscount(item));
    }
}