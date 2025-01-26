using Labwork5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public WithdrawScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Withdraw";

    public void Run()
    {
        decimal count = AnsiConsole.Ask<decimal>("Enter the amount of money you want to withdraw: ");

        WithdrawResult withdrawResult = _bankAccountService.Withdraw(count);

        string message = withdrawResult switch
        {
            WithdrawResult.Success => "Withdraw success!",
            WithdrawResult.NotEnoughMoney => "Withdraw failed! Not enough money!",
            WithdrawResult.NegativeWithdrawAmount => "Withdraw failed! Withdraw negative!",
            WithdrawResult.UnauthorizedAccess => "Withdraw failed! Access denied!",
            _ => throw new ArgumentOutOfRangeException(nameof(withdrawResult)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}