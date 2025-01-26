using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;

public interface IFileSystemContext
{
    public IFileSystem FileSystem { get; }

    public void Connect(IFileSystem fileSystem, string path);

    public void Disconnect();
}