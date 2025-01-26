using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public interface IParameterHandler
{
    IParameterHandler AddNext(IParameterHandler parameterHandler);

    ICommand? Handle(IEnumerator<string> request);
}