using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.TreeHandlers;

public class ListHandler : ParameterHandlerBase
{
    private readonly IFlagHandler<TreeListArgumentsContext.Builder> _flagHandler;
    private readonly WriterType _writer;
    private readonly ComponentIcons _componentIcons;

    public ListHandler(
        IFlagHandler<TreeListArgumentsContext.Builder> flagHandler,
        WriterType writer,
        ComponentIcons componentIcons)
    {
        _flagHandler = flagHandler;
        _writer = writer;
        _componentIcons = componentIcons;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "list")
        {
            return Next?.Handle(request);
        }

        var builder = new TreeListArgumentsContext.Builder();

        while (request.MoveNext())
        {
            builder = _flagHandler.Handle(request, builder);

            if (builder is null)
            {
                return null;
            }
        }

        builder.WithIcons(_componentIcons);

        builder.WithWriterType(_writer);

        TreeListArgumentsContext context = builder.Build();

        var writerFabric = new WriterFabric();
        IWriter writer = writerFabric.Create(context.WriterType ?? WriterType.Console);

        return new TreeListCommand(
            context.Depth ?? 1,
            writer,
            _componentIcons);
    }
}