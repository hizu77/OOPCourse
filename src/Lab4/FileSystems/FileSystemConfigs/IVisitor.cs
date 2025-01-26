using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

public interface IVisitor
{
    void Visit(DirectoryFileSystemNode directoryFileSystemNode);

    void Visit(FileFileSystemNode fileFileSystemNode);
}