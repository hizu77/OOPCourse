using Itmo.ObjectOrientedProgramming.Lab2.Persons;

namespace Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;

public interface IIdentifiable
{
    IUser Author { get; }

    string Name { get; }

    long Id { get; }
}