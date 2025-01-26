using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.CheckFileExists(_path))
        {
            return new CommandExecutionResult.Failure(new FileDeleteError());
        }

        fileSystem.FileDelete(_path);

        return new CommandExecutionResult.Success();
    }
}