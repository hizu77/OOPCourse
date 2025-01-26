using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel;

public class Repository<T> : IRepository<T> where T : IIdentifiable
{
    private readonly Dictionary<long, T> _entities = [];

    public T? FindById(long id)
    {
        _entities.TryGetValue(id, out T? entity);
        return entity;
    }

    public void Add(T obj)
    {
        _entities[obj.Id] = obj;
    }
}