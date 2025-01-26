using Labwork5.Application.Contracts.Users.AdminMode;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogout.AdminLogoutScenarios;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _adminService.Logout();

        AnsiConsole.WriteLine("Admin logged out");

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}