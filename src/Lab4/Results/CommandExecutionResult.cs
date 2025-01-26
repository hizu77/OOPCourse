using Itmo.ObjectOrientedProgramming.Lab4.Results.CommandExecutionErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Results;

public abstract record CommandExecutionResult
{
    private CommandExecutionResult() { }

    public sealed record Success : CommandExecutionResult;

    public sealed record Failure(ICommandExecutionError Error) : CommandExecutionResult;
}