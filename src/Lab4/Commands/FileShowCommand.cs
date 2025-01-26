using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly IWriter _writer;

    public FileShowCommand(string path, IWriter writer)
    {
        _path = path;
        _writer = writer;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.CheckFileExists(_path))
        {
            return new CommandExecutionResult.Failure(new FileShowError());
        }

        fileSystem.FileShow(_path, _writer);

        return new CommandExecutionResult.Success();
    }
}