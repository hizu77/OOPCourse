using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

public class CommandParser : ICommandParser
{
    private readonly IDomainParameterHandler _handler;

    public CommandParser(IDomainParameterHandler handler)
    {
        _handler = handler;
    }

    public ICommand? ParseCommand(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        ICommand? command = null;

        if (request.MoveNext())
        {
            command = _handler.Handle(request);
        }

        return request.MoveNext() ? null : command;
    }
}