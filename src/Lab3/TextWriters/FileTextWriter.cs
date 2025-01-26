namespace Itmo.ObjectOrientedProgramming.Lab3.TextWriters;

public class FileTextWriter : ITextWriter
{
    private readonly string _path;

    public FileTextWriter(string path)
    {
        _path = path;
    }

    public void WriteText(string message)
    {
        File.WriteAllText(_path, message);
    }

    public void Clear()
    {
        File.WriteAllText(_path, string.Empty);
    }
}