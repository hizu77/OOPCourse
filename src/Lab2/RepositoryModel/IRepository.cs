using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel;

public interface IRepository<TValue> where TValue : IIdentifiable
{
    TValue? FindById(long id);

    void Add(TValue obj);
}