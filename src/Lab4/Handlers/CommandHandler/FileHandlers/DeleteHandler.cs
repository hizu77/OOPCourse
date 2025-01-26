using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;

public class DeleteHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "delete")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileDeleteArgumentsContext.Builder();

        builder.WithSource(request.Current);

        FileDeleteArgumentsContext context = builder.Build();

        return new FileDeleteCommand(context.Source ?? string.Empty);
    }
}