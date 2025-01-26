using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Contracts.Users.UserMode;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.BankAccountLogin.UserLoginScenarios;

public class LoginUserScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserService _userService;

    public LoginUserScenarioProvider(
        ICurrentUserService currentUserService,
        IUserService userService)
    {
        _currentUserService = currentUserService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;

            return false;
        }

        scenario = new LoginUserScenario(_userService);

        return true;
    }
}