using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record FileCopyCommand : ICommand
{
    private readonly string _sourceFilePath;
    private readonly string _destinationFilePath;

    public FileCopyCommand(string sourceFilePath, string destinationFilePath)
    {
        _sourceFilePath = sourceFilePath;
        _destinationFilePath = destinationFilePath;
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        if (!fileSystem.CheckFileExists(_sourceFilePath) ||
            fileSystem.CheckFileExists(_destinationFilePath))
        {
            return new CommandExecutionResult.Failure(new FileCopyError());
        }

        fileSystem.FileCopy(_sourceFilePath, _destinationFilePath);

        return new CommandExecutionResult.Success();
    }
}