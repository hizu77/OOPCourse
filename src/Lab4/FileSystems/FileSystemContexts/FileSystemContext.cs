using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;

public class FileSystemContext : IFileSystemContext
{
    public FileSystemContext()
    {
        FileSystem = new NullFileSystem();
    }

    public IFileSystem FileSystem { get; private set; }

    public void Connect(IFileSystem fileSystem, string path)
    {
        FileSystem = fileSystem;

        FileSystem.Connect(path);
    }

    public void Disconnect()
    {
        FileSystem.Disconnect();

        FileSystem = new NullFileSystem();
    }
}