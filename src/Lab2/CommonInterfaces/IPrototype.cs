namespace Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;

public interface IPrototype<out T> where T : IPrototype<T>
{
    T Clone();
}