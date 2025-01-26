using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.Modules;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;

public class Station : IRouteSection
{
    private readonly Time _loadingTime;
    private readonly PowerModules _powerModules;

    public Station(Time loadingTime, PowerModules powerModules)
    {
        _loadingTime = loadingTime;
        _powerModules = powerModules;
    }

    public RouteSectionResult TryControlTrain(Train train)
    {
        TrainMoveResult stoppingResult = _powerModules.TryStopTrain(train);

        return stoppingResult is not TrainMoveResult.Success
            ? new RouteSectionResult.Failed(new StationError())
            : new RouteSectionResult.Success(_loadingTime);
    }
}
