using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.UserMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogin.UserLoginScenarios;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User mode";

    public void Run()
    {
        string invoice = AnsiConsole.Ask<string>("Enter the invoice number: ");
        string pin = AnsiConsole.Ask<string>("Enter the pin: ");

        LoginResult loginResult = _userService.Login(invoice, pin);

        string message = loginResult switch
        {
            LoginResult.Success => "Success login!",
            LoginResult.InvalidData => "Failed login! Incorrect password or invoice.",
            _ => throw new InvalidOperationException(nameof(loginResult)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}