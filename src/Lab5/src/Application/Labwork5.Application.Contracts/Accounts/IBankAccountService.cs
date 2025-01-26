namespace Labwork5.Application.Contracts.Accounts;

public interface IBankAccountService
{
    DepositResult Deposit(decimal amount);

    WithdrawResult Withdraw(decimal amount);

    decimal GetBalance();
}