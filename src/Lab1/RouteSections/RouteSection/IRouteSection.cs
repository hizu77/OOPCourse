using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;

public interface IRouteSection
{
    RouteSectionResult TryControlTrain(Train train);
}