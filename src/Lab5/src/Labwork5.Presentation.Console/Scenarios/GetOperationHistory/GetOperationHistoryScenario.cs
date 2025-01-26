using Labwork5.Application.Contracts.Operations;
using Labwork5.Application.Models.Operations;
using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios.GetOperationHistory;

public class GetOperationHistoryScenario : IScenario
{
    private readonly IOperationsService _operationsService;

    public GetOperationHistoryScenario(IOperationsService operationsService)
    {
        _operationsService = operationsService;
    }

    public string Name => "Get operation history";

    public void Run()
    {
        IEnumerable<Operation> operations = _operationsService.GetOperationsHistory();

        foreach (Operation operation in operations)
        {
            AnsiConsole.WriteLine(
                $"Invoice {operation.Invoice} : operation {operation.OperationType}");
        }

        AnsiConsole.Ask<string>("Press any key to continue ...");
    }
}