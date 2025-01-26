using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly IFileSystem _mode;

    public ConnectCommand(string path, IFileSystem mode)
    {
        _path = path;
        _mode = mode;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        if (!_mode.CheckDirectoryExists(_path) || !_mode.IsAbsolutePath(_path))
        {
            return new CommandExecutionResult.Failure(new ConnectFileSystemError());
        }

        context.Connect(_mode, _path);

        return new CommandExecutionResult.Success();
    }
}