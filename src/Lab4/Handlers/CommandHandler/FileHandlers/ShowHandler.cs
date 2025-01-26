using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;

public class ShowHandler : ParameterHandlerBase
{
    private readonly IFlagHandler<FileShowArgumentsContext.Builder> _flagHandler;

    public ShowHandler(IFlagHandler<FileShowArgumentsContext.Builder> flagHandler)
    {
        _flagHandler = flagHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "show")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new FileShowArgumentsContext.Builder();

        builder.WithAddress(request.Current);

        bool parsedNecessary = false;

        while (request.MoveNext())
        {
            parsedNecessary = true;

            builder = _flagHandler.Handle(request, builder);

            if (builder is null)
            {
                return null;
            }
        }

        FileShowArgumentsContext context = builder.Build();

        var writerFabric = new WriterFabric();
        IWriter writer = writerFabric.Create(context.WriterType ?? WriterType.Console);

        return parsedNecessary
            ? new FileShowCommand(
                context.Address ?? string.Empty,
                writer)
            : null;
    }
}