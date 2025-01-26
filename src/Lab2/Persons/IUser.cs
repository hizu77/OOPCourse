namespace Itmo.ObjectOrientedProgramming.Lab2.Persons;

public interface IUser
{
    long Id { get; }

    IUser Clone();
}