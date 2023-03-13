using APP.Domain;

namespace APP.Services.Contracts;

public interface IService<T> where T : Entity
{
    Task<List<T>> GetAll();
    Task<T?> Get(Guid id);
}