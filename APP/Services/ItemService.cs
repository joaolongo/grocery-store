using APP.Domain;
using APP.Services.Contracts;

namespace APP.Services;

public class ItemService : Service<Item>, IItemService 
{
    public ItemService(ApplicationContext context) : base(context)
    {
    }
}