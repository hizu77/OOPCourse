using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;

public class MoveHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "move")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileMoveArgumentsContext.Builder();

        builder.WithSource(request.Current);

        if (request.MoveNext() is false)
        {
            return null;
        }

        builder.WithDestination(request.Current);

        FileMoveArgumentsContext context = builder.Build();

        return new FileMoveCommand(
            context.Source ?? string.Empty,
            context.Destination ?? string.Empty);
    }
}