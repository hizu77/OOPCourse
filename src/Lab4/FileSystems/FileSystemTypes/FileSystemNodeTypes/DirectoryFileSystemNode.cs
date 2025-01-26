using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;

public class DirectoryFileSystemNode : IFileSystemNode
{
    public DirectoryFileSystemNode(
        string directoryName,
        IReadOnlyCollection<IFileSystemNode> children)
    {
        Name = directoryName;
        Children = new Lazy<IReadOnlyCollection<IFileSystemNode>>(children);
    }

    public string Name { get; }

    public Lazy<IReadOnlyCollection<IFileSystemNode>> Children { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}