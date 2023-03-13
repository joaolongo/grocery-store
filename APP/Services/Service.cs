using APP.Domain;

using APP.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APP.Services;

public class Service<T> : IService<T> where T : Entity
{
    private readonly DbSet<T> _set;

    public Service(ApplicationContext context)
    {
        _set = context.Set<T>();
    }
    
    public async Task<List<T>> GetAll()
    {
        return await _set.AsQueryable().ToListAsync();
    }

    public async Task<T?> Get(Guid id)
    {
        return await _set.SingleOrDefaultAsync(x => x.Id == id);
    }
}