using Labwork5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.Deposit;

public class DepositScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public DepositScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Deposit";

    public void Run()
    {
        decimal count = AnsiConsole.Ask<decimal>("How many deposits do you want to deposit? ");

        DepositResult depositResult = _bankAccountService.Deposit(count);

        string message = depositResult switch
        {
            DepositResult.Success => "Deposit successful. ",
            DepositResult.NegativeDepositAmount => "Deposit failed. Deposit amount is negative. ",
            DepositResult.UnauthorizedAccess => "Deposit failed. Unauthorized access to deposit. ",
            _ => throw new ArgumentOutOfRangeException(nameof(depositResult)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}