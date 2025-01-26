using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.AdminMode;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogin.AdminLoginScenarios;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IAdminService _adminService;

    public LoginAdminScenarioProvider(
        ICurrentUserService currentUserService,
        IAdminService adminService)
    {
        _currentUserService = currentUserService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new LoginAdminScenario(_adminService);

        return true;
    }
}