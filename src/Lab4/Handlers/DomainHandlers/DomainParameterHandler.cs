using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;

public class DomainParameterHandler : DomainParemeterHandlerBase
{
    private readonly IParameterHandler _additionalParameterChain;
    private readonly string _targetDomain;

    public DomainParameterHandler(string targetDomain, IParameterHandler additionalParameterChain)
    {
        _additionalParameterChain = additionalParameterChain;
        _targetDomain = targetDomain;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != _targetDomain)
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        return _additionalParameterChain.Handle(request);
    }
}