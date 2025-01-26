namespace Labwork5.Application.Contracts.Accounts;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success : WithdrawResult;

    public sealed record NotEnoughMoney : WithdrawResult;

    public sealed record NegativeWithdrawAmount : WithdrawResult;

    public sealed record UnauthorizedAccess : WithdrawResult;
}