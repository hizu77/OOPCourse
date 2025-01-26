using Labwork5.Application.Contracts.Users.AdminMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.ChangePassword;

public class ChangePasswordScenario : IScenario
{
    private readonly IAdminService _adminService;

    public ChangePasswordScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Change Password";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter the password: ");

        _adminService.ChangePassword(password);

        AnsiConsole.WriteLine("Password changed");
        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}