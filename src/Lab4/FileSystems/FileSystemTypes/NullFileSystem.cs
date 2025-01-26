using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

public class NullFileSystem : IFileSystem
{
    public void Connect(string path)
    {
    }

    public void Disconnect()
    {
    }

    public void TreeGoTo(string path)
    {
    }

    public void TreeList(IVisitor visitor)
    {
    }

    public void FileShow(string path, IWriter writer)
    {
    }

    public void FileMove(string fromPath, string toPath)
    {
    }

    public void FileCopy(string fromPath, string toPath)
    {
    }

    public void FileDelete(string path)
    {
    }

    public void FileRename(string path, string newName)
    {
    }

    public bool CheckFileExists(string path)
    {
        return false;
    }

    public bool CheckDirectoryExists(string path)
    {
        return false;
    }

    public bool IsAbsolutePath(string path)
    {
        return false;
    }
}