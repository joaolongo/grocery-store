using APP.Domain;

namespace APP.Services.Contracts;

public interface IBasketService : IService<Basket>
{
    Task<decimal?> GetPrice(Guid id);

    decimal GetPrice(Basket basket);
}