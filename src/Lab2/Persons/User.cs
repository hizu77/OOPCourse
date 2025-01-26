using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Persons;

public class User : IUser, IPrototype<User>
{
    private readonly string _name;

    public User(long id, string name)
    {
        Id = id;
        _name = name;
    }

    public long Id { get; }

    public User Clone()
    {
        return new User(Id, _name);
    }

    IUser IUser.Clone()
    {
        return Clone();
    }
}