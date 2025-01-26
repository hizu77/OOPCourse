using Labwork5.Application.Contracts.Accounts;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IBankAccountService _bankAccountService;

    public GetBalanceScenarioProvider(
        ICurrentUserService currentUserService,
        IBankAccountService bankAccountService)
    {
        _currentUserService = currentUserService;
        _bankAccountService = bankAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null ||
            _currentUserService.User.Mode == Mode.Admin)
        {
            scenario = null;

            return false;
        }

        scenario = new GetBalanceScenario(_bankAccountService);

        return true;
    }
}