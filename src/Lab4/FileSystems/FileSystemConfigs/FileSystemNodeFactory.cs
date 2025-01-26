using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;

public class FileSystemNodeFactory
{
    public IFileSystemNode Create(string path)
    {
        string name = Path.GetFileName(path);

        if (Directory.Exists(path))
        {
            IEnumerable<string> names = Directory
                .EnumerateFileSystemEntries(path)
                .Select(Path.GetFileName)
                .Where(f => f is not null)
                .Cast<string>();

            IFileSystemNode[] nodes = names
                .Select(entry => Path.Combine(path, entry))
                .Select(Create)
                .ToArray();

            return new DirectoryFileSystemNode(name, nodes);
        }

        return new FileFileSystemNode(name);
    }
}