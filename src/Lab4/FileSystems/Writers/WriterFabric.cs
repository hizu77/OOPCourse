namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;

public class WriterFabric
{
    public IWriter Create(WriterType type)
    {
        return type switch
        {
            WriterType.Console => new ConsoleWriter(),
            _ => new ConsoleWriter(),
        };
    }
}