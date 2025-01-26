using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.UserMode;
using Labwork5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogout.UserLogoutScenarios;

public class LogoutUserScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserService _userService;

    public LogoutUserScenarioProvider(
        ICurrentUserService currentUserService,
        IUserService userService)
    {
        _currentUserService = currentUserService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null ||
            _currentUserService.User.Mode == Mode.Admin)
        {
            scenario = null;

            return false;
        }

        scenario = new LogoutUserScenario(_userService);

        return true;
    }
}