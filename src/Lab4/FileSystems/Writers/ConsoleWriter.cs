namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.Write(text);
    }
}