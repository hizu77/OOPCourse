using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;

public class NormalMagneticPath : IRouteSection
{
    private readonly Length _length;

    public NormalMagneticPath(Length length)
    {
        _length = length;
    }

    public RouteSectionResult TryControlTrain(Train train)
    {
        TrainMoveResult traverseResult = train.TryTraverse(_length);

        return traverseResult is TrainMoveResult.Success success
            ? new RouteSectionResult.Success(success.Time)
            : new RouteSectionResult.Failed(new AcceleratingError());
    }
}
