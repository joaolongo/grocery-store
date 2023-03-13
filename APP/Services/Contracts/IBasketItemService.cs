using APP.Domain;

namespace APP.Services.Contracts;

public interface IBasketItemService : IService<BasketItem>
{
    decimal GetDiscount(BasketItem basketItem);
}