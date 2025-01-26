namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public interface IFlagHandler<TBuilder> where TBuilder : class
{
    IFlagHandler<TBuilder> AddNext(IFlagHandler<TBuilder> flagHandler);

    TBuilder? Handle(IEnumerator<string> request, TBuilder builder);
}