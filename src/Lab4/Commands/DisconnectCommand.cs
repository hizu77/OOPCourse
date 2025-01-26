using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record DisconnectCommand : ICommand
{
    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        context.Disconnect();

        return new CommandExecutionResult.Success();
    }
}