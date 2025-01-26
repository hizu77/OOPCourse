using Itmo.ObjectOrientedProgramming.Lab3.TextWriters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private readonly ITextWriter _textWriter;

    public Messenger(ITextWriter textWriter)
    {
        _textWriter = textWriter;
    }

    public void ReceiveMessage(string message)
    {
        DisplayText(message);
    }

    public void DisplayText(string message)
    {
        _textWriter.WriteText($"Messenger: {message}");
    }
}