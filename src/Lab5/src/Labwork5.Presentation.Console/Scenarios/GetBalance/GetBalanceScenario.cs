using Labwork5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public GetBalanceScenario(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public string Name => "Get Balance ";

    public void Run()
    {
        decimal balance = _bankAccountService.GetBalance();

        AnsiConsole.WriteLine($"Balance: {balance}");

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}