using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.AdminMode;
using Labwork5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.ChangePassword;

public class ChangePasswordScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IAdminService _adminService;

    public ChangePasswordScenarioProvider(
        ICurrentUserService currentUserService,
        IAdminService adminService)
    {
        _currentUserService = currentUserService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null ||
            _currentUserService.User.Mode == Mode.User)
        {
            scenario = null;

            return false;
        }

        scenario = new ChangePasswordScenario(_adminService);

        return true;
    }
}