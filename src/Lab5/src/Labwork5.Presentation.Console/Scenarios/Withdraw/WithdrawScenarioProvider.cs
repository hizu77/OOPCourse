using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IBankAccountService _accountService;

    public WithdrawScenarioProvider(
        ICurrentUserService currentUserService,
        IBankAccountService accountService)
    {
        _currentUserService = currentUserService;
        _accountService = accountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null ||
            _currentUserService.User.Mode == Mode.Admin)
        {
            scenario = null;

            return false;
        }

        scenario = new WithdrawScenario(_accountService);

        return true;
    }
}