namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public abstract class FlagHandlerBase<TBuilder> : IFlagHandler<TBuilder> where TBuilder : class
{
    public IFlagHandler<TBuilder>? Next { get; private set; }

    public IFlagHandler<TBuilder> AddNext(IFlagHandler<TBuilder> flagHandler)
    {
        if (Next is null)
        {
            Next = flagHandler;
        }
        else
        {
            Next.AddNext(flagHandler);
        }

        return this;
    }

    public abstract TBuilder? Handle(IEnumerator<string> request, TBuilder builder);
}