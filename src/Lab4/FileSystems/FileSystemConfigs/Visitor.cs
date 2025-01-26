using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

public class Visitor : IVisitor
{
    private readonly IWriter _writer;
    private readonly ComponentIcons _icons;
    private readonly int _maxDepth;
    private int _currentDepth;

    public Visitor(IWriter writer, ComponentIcons icons, int depth)
    {
        _writer = writer;
        _icons = icons;
        _maxDepth = depth;
    }

    public void Visit(DirectoryFileSystemNode directoryFileSystemNode)
    {
        if (_currentDepth > _maxDepth)
        {
            return;
        }

        WriteIndented(directoryFileSystemNode.Name, _icons.FolderSymbol);

        _currentDepth += 1;

        foreach (IFileSystemNode node in directoryFileSystemNode.Children.Value)
        {
            node.Accept(this);
        }

        _currentDepth -= 1;
    }

    public void Visit(FileFileSystemNode fileFileSystemNode)
    {
        if (_currentDepth > _maxDepth)
        {
            return;
        }

        WriteIndented(fileFileSystemNode.Name, _icons.FileSymbol);
    }

    private void WriteIndented(string text, string componentIcon)
    {
        if (_currentDepth is not 0)
        {
            _writer.Write(string.Concat(Enumerable.Repeat(_icons.PaddingSymbols, _currentDepth)));
            _writer.Write("|–> ");
        }

        string newText = string.Concat(componentIcon, text, '\n');

        _writer.Write(newText);
    }
}