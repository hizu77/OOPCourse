using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;

public class ConnectHandler : DomainParemeterHandlerBase
{
    private readonly IFlagHandler<ConnectArgumentsContext.Builder> _flagHandler;

    public ConnectHandler(IFlagHandler<ConnectArgumentsContext.Builder> flagHandler)
    {
        _flagHandler = flagHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
        {
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        var builder = new ConnectArgumentsContext.Builder();

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

        ConnectArgumentsContext command = builder.Build();

        var factory = new FileSystemFabric();

        IFileSystem fileSystem = factory.Create(command.FileSystemMode ?? FileSystemMode.Local);

        return parsedNecessary ?
            new ConnectCommand(command.Address ?? string.Empty, fileSystem)
            : null;
    }
}