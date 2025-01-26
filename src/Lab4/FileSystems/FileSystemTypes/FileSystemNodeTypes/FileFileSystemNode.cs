using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;

public class FileFileSystemNode : IFileSystemNode
{
    public FileFileSystemNode(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}