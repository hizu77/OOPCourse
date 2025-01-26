using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record TreeListCommand : ICommand
{
    private readonly IVisitor _visitor;

    public TreeListCommand(int depth, IWriter writer, ComponentIcons icons)
    {
        _visitor = new Visitor(writer, icons, depth);
    }

    public CommandExecutionResult Execute(IFileSystemContext context)
    {
        IFileSystem fileSystem = context.FileSystem;

        fileSystem.TreeList(_visitor);

        return new CommandExecutionResult.Success();
    }
}