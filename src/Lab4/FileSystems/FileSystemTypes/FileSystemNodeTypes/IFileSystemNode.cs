using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;

public interface IFileSystemNode
{
    string Name { get; }

    void Accept(IVisitor visitor);
}