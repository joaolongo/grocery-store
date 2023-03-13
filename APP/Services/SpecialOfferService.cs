using APP.Domain;
using APP.Services.Contracts;

namespace APP.Services;

public class SpecialOfferService : Service<SpecialOffer>, ISpecialOfferService
{
    public SpecialOfferService(ApplicationContext context) : base(context)
    {
    }
}