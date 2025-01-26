using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.CheckFileExists(_path))
        {
            return new CommandExecutionResult.Failure(new FileCopyError());
        }

        fileSystem.FileRename(_path, _name);

        return new CommandExecutionResult.Success();
    }
}