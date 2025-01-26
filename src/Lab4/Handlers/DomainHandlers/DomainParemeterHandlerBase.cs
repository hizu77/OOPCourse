using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;

public abstract class DomainParemeterHandlerBase : IDomainParameterHandler
{
    protected IDomainParameterHandler? Next { get; private set; }

    public IDomainParameterHandler AddNext(IDomainParameterHandler domainParameterHandler)
    {
        if (Next is null)
        {
            Next = domainParameterHandler;
        }
        else
        {
            Next.AddNext(domainParameterHandler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}