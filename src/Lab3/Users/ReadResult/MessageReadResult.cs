namespace Itmo.ObjectOrientedProgramming.Lab3.Users.ReadResult;

public abstract record MessageReadResult
{
    private MessageReadResult() { }

    public sealed record Success : MessageReadResult;

    public sealed record MessageAlreadyRead : MessageReadResult;
}