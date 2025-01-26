using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

public interface IFileSystem
{
    void Connect(string path);

    void Disconnect();

    void TreeGoTo(string path);

    void TreeList(IVisitor visitor);

    void FileShow(string path, IWriter writer);

    void FileMove(string fromPath, string toPath);

    void FileCopy(string fromPath, string toPath);

    void FileDelete(string path);

    void FileRename(string path, string newName);

    bool CheckFileExists(string path);

    bool CheckDirectoryExists(string path);

    bool IsAbsolutePath(string path);
}