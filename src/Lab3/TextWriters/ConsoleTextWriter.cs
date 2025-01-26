namespace Itmo.ObjectOrientedProgramming.Lab3.TextWriters;

public class ConsoleTextWriter : ITextWriter
{
    public void WriteText(string message)
    {
        Console.WriteLine(message);
    }

    public void Clear()
    {
        Console.Clear();
    }
}