using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.TreeHandlers;

public class GoToHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "goto")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new TreeGoToArgumentsContext.Builder();

        builder.WithPath(request.Current);

        TreeGoToArgumentsContext context = builder.Build();

        return new TreeGoToCommand(
            context.Path ?? string.Empty);
    }
}