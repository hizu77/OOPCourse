using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;

public class RenameHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "rename")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileRenameArgumentsContext.Builder();

        builder.WithSource(request.Current);

        if (request.MoveNext() is false)
        {
            return null;
        }

        builder.WithName(request.Current);

        FileRenameArgumentsContext context = builder.Build();

        return new FileRenameCommand(
            context.Source ?? string.Empty,
            context.Name ?? string.Empty);
    }
}