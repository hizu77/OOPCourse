using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class ParameterHandlerBase : IParameterHandler
{
    protected IParameterHandler? Next { get; private set; }

    public IParameterHandler AddNext(IParameterHandler parameterHandler)
    {
        if (Next is null)
        {
            Next = parameterHandler;
        }
        else
        {
            Next.AddNext(parameterHandler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}