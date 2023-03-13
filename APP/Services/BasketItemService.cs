using APP.Domain;
using APP.Services.Contracts;

namespace APP.Services;

public class BasketItemService : Service<BasketItem>, IBasketItemService
{
    public BasketItemService(ApplicationContext context) : base(context)
    {
    }

    public decimal GetDiscount(BasketItem basketItem)
    {
        var basketDiscounts = basketItem.Basket.Items
            .Where(x => x.Item.SpecialOffer is not null)
            .Select(x => x.Item.SpecialOffer!).ToList();

        if (basketDiscounts.Count < 1)
            return basketItem.Item.Price;

        var discounts = basketDiscounts
            .Where(x => x.DiscountItem is not null && basketItem.Basket.Items.Any(y => y.Item.Id == x.DiscountItem.Id))
            .OrderByDescending(x => x.Percentage)
            .ToList();
        
        if (discounts.Count > 0)
        {
            foreach (var discount in discounts
                         .Where(discount => basketItem.Quantity >= discount.RequiredAmount))
            {
                return basketItem.Item.Price * (1 - discount.Percentage);
            }
        }
        
        var specialOffer = basketItem.Item.SpecialOffer;

        if (basketItem.Quantity >= specialOffer?.RequiredAmount)
        {
            return basketItem.Item.Price * (1 - specialOffer.Percentage);
        }

        return basketItem.Item.Price;
    }
}