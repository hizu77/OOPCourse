namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record EditResult
{
    private EditResult() { }

    public sealed record Success : EditResult;

    public sealed record Failed : EditResult;
}