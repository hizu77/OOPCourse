using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemModes;

public class FileSystemFabric
{
    public IFileSystem Create(FileSystemMode type)
    {
        return type switch
        {
            FileSystemMode.Local => new LocalFileSystem(),
            _ => new NullFileSystem(),
        };
    }
}