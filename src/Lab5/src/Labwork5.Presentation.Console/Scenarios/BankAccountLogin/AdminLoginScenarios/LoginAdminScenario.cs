using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.AdminMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogin.AdminLoginScenarios;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin mode";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter the password: ");

        LoginResult loginResult = _adminService.Login(password);

        string message = loginResult switch
        {
            LoginResult.Success => "Success login!",
            LoginResult.InvalidData => "Failed login! Incorrect password!",
            _ => throw new InvalidOperationException(nameof(loginResult)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}