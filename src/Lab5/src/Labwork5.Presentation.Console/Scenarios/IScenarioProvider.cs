using System.Diagnostics.CodeAnalysis;

namespace Labwork5.Presentation.Console.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}