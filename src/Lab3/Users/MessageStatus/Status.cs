namespace Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStatus;

public abstract record Status
{
    private Status() { }

    public sealed record Read : Status;

    public sealed record UnRead : Status;
}