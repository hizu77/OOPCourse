using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes.FileSystemNodeTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemTypes;

public class LocalFileSystem : IFileSystem
{
    private string _currentPath = string.Empty;

    public void Connect(string path)
    {
        _currentPath = path;
    }

    public void Disconnect()
    {
        _currentPath = string.Empty;
    }

    public bool DisconnectValidation()
    {
        return true;
    }

    public void TreeGoTo(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        _currentPath = fullPath;
    }

    public bool TreeGoToValidation(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        return Directory.Exists(fullPath);
    }

    public void TreeList(IVisitor visitor)
    {
        var factory = new FileSystemNodeFactory();

        IFileSystemNode root = factory.Create(_currentPath);

        root.Accept(visitor);
    }

    public bool TreeListValidation()
    {
        return File.Exists(_currentPath) || Directory.Exists(_currentPath);
    }

    public void FileShow(string path, IWriter writer)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        using var streamReader = new StreamReader(fullPath);

        while (streamReader.ReadLine() is { } line)
        {
            writer.Write(string.Concat(line, '\n'));
        }
    }

    public bool FileShowValidation(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        return File.Exists(fullPath);
    }

    public void FileMove(string fromPath, string toPath)
    {
        string fullFromPath = Path.GetFullPath(fromPath, _currentPath);
        string fullToPath = Path.GetFullPath(toPath, _currentPath);

        string fileName = Path.GetFileName(fullFromPath);
        string destination = Path.Combine(fullToPath, fileName);

        File.Move(fullFromPath, destination);
    }

    public bool FileMoveValidation(string fromPath, string toPath)
    {
        string fullFromPath = Path.GetFullPath(fromPath, _currentPath);
        string fullToPath = Path.GetFullPath(toPath, _currentPath);

        string fileName = Path.GetFileName(fullFromPath);
        string destination = Path.Combine(fullToPath, fileName);

        return File.Exists(fullFromPath) && !File.Exists(destination);
    }

    public void FileCopy(string fromPath, string toPath)
    {
        string fullFromPath = Path.GetFullPath(fromPath, _currentPath);
        string fullToPath = Path.GetFullPath(toPath, _currentPath);

        string fileName = Path.GetFileName(fullFromPath);
        string destination = Path.Combine(fullToPath, fileName);

        File.Copy(fullFromPath, destination);
    }

    public bool FileCopyValidation(string fromPath, string toPath)
    {
        string fullFromPath = Path.GetFullPath(fromPath, _currentPath);
        string fullToPath = Path.GetFullPath(toPath, _currentPath);

        string fileName = Path.GetFileName(fullFromPath);
        string destination = Path.Combine(fullToPath, fileName);

        return File.Exists(fullFromPath) && !File.Exists(destination);
    }

    public void FileDelete(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        File.Delete(fullPath);
    }

    public bool FileDeleteValidation(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        return File.Exists(fullPath);
    }

    public void FileRename(string path, string newName)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        string? directory = Path.GetDirectoryName(fullPath);

        File.Move(fullPath, Path.Combine(directory ?? fullPath, newName));
    }

    public bool FileRenameValidation(string path, string newName)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        string? directory = Path.GetDirectoryName(fullPath);

        string newFullPath = Path.Combine(directory ?? fullPath, newName);

        return File.Exists(fullPath) && !File.Exists(newFullPath);
    }

    public bool CheckFileExists(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        return File.Exists(fullPath);
    }

    public bool CheckDirectoryExists(string path)
    {
        string fullPath = Path.GetFullPath(path, _currentPath);

        return Directory.Exists(fullPath);
    }

    public bool IsAbsolutePath(string path)
    {
        return Path.IsPathFullyQualified(path);
    }
}