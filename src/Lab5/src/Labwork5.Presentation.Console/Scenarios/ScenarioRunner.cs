using Spectre.Console;

namespace Labwork5.Presentation.Console.Scenarios;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _scenarioProviders;

    public ScenarioRunner(IEnumerable<IScenarioProvider> scenarioProviders)
    {
        _scenarioProviders = scenarioProviders;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selection = new SelectionPrompt<IScenario>()
            .Title("Select the scenario you want to run")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selection);

        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _scenarioProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
            {
                yield return scenario;
            }
        }
    }
}