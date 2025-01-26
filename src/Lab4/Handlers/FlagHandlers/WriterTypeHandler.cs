using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public class WriterTypeHandler : FlagHandlerBase<FileShowArgumentsContext.Builder>
{
    public override FileShowArgumentsContext.Builder? Handle(
        IEnumerator<string> request,
        FileShowArgumentsContext.Builder builder)
    {
        if (request.Current is not "-m")
        {
            return Next?.Handle(request, builder);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        switch (request.Current)
        {
            case "console":
                builder.WithWriterType(WriterType.Console);
                return builder;
        }

        return null;
    }
}