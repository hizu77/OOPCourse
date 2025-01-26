namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record struct Message
{
    public Message(string title, string text, int priority)
    {
        Title = title;
        Text = text;
        Priority = priority;
    }

    public string Title { get; }

    public string Text { get; }

    public int Priority { get; }

    public string Format()
    {
        return $"Title: {Title} \n Message: {Text} \n";
    }
}