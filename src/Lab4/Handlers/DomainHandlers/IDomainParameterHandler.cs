using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;

public interface IDomainParameterHandler
{
    IDomainParameterHandler AddNext(IDomainParameterHandler domainParameterHandler);

    ICommand? Handle(IEnumerator<string> request);
}