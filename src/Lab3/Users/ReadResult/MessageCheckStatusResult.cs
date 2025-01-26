using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStatus;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.ReadResult;

public abstract record MessageCheckStatusResult
{
    private MessageCheckStatusResult() { }

    public sealed record Success(Status Status) : MessageCheckStatusResult;

    public sealed record MessageNotFound : MessageCheckStatusResult;
}