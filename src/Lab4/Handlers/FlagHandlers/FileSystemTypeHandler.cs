using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public class FileSystemTypeHandler : FlagHandlerBase<ConnectArgumentsContext.Builder>
{
    public override ConnectArgumentsContext.Builder? Handle(IEnumerator<string> request, ConnectArgumentsContext.Builder builder)
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
            case "local":
                builder.WithFileSystemMode(FileSystemMode.Local);
                return builder;
        }

        return null;
    }
}