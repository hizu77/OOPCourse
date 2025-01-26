using Labwork5.Application.Contracts.Operations;
using Labwork5.Application.Contracts.Users;
using Labwork5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios.GetOperationHistory;

public class GetOperationHistoryScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IOperationsService _operationsService;

    public GetOperationHistoryScenarioProvider(
        ICurrentUserService currentUserService,
        IOperationsService operationsService)
    {
        _currentUserService = currentUserService;
        _operationsService = operationsService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null ||
            _currentUserService.User.Mode == Mode.Admin)
        {
            scenario = null;

            return false;
        }

        scenario = new GetOperationHistoryScenario(_operationsService);

        return true;
    }
}