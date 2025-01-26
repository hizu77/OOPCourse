using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.Modules;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;

public class Route
{
    private readonly IReadOnlyCollection<IRouteSection> _rootSections;
    private readonly PowerModules _powerModules;

    public Route(IReadOnlyCollection<IRouteSection> rootSections, PowerModules powerModules)
    {
        _rootSections = rootSections;
        _powerModules = powerModules;
    }

    public RouteSectionResult TryEnroute(Train train)
    {
        var totalTime = new Time(0);

        foreach (IRouteSection section in _rootSections)
        {
            RouteSectionResult sectionTravelResult = section.TryControlTrain(train);

            if (sectionTravelResult is not RouteSectionResult.Success success)
                return sectionTravelResult;

            totalTime += success.ResultTime;
        }

        TrainMoveResult stoppingResult = _powerModules.TryStopTrain(train);

        return stoppingResult is not TrainMoveResult.Success
            ? new RouteSectionResult.Failed(new StoppingError())
            : new RouteSectionResult.Success(totalTime);
    }
}