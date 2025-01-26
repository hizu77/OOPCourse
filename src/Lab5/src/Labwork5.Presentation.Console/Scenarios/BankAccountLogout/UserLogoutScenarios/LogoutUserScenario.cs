using Labwork5.Application.Contracts.Users.UserMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogout.UserLogoutScenarios;

public class LogoutUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _userService.Logout();

        AnsiConsole.WriteLine("User logged out");

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}