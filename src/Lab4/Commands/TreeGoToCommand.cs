using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.CheckDirectoryExists(_path))
        {
            return new CommandExecutionResult.Failure(new TreeGoToError());
        }

        fileSystem.TreeGoTo(_path);

        return new CommandExecutionResult.Success();
    }
}