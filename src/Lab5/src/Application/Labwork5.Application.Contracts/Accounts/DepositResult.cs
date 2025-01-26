namespace Labwork5.Application.Contracts.Accounts;

public abstract record DepositResult
{
    private DepositResult() { }

    public sealed record Success : DepositResult;

    public sealed record NegativeDepositAmount : DepositResult;

    public sealed record UnauthorizedAccess : DepositResult;
}