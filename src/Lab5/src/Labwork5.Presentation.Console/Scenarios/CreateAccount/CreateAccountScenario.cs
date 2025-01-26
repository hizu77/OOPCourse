using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Users.AdminMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create account";

    public void Run()
    {
        string invoice = AnsiConsole.Ask<string>("What would you like to create an invoice? ");
        string pin = AnsiConsole.Ask<string>("What would you like to pin the bank account? ");

        CreateAccountResult createAccountResult = _adminService.AddAccount(invoice, pin);

        string message = createAccountResult switch
        {
            CreateAccountResult.Success => "Account created successfully!",
            CreateAccountResult.AccountAlreadyExists => "Failed to create account. Account already exists!",
            _ => throw new InvalidOperationException(nameof(CreateAccountResult)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}