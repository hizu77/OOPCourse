using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;

public class CopyHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "copy")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileCopyArgumentsContext.Builder();

        builder.WithSource(request.Current);

        if (request.MoveNext() is false)
        {
            return null;
        }

        builder.WithDestination(request.Current);

        FileCopyArgumentsContext context = builder.Build();

        return new FileCopyCommand(
            context.Source ?? string.Empty,
            context.Destination ?? string.Empty);
    }
}