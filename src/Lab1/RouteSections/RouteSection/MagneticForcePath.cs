using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;

public class MagneticForcePath : IRouteSection
{
    private readonly double _power;
    private readonly Length _length;

    public MagneticForcePath(double power, Length length)
    {
        _power = power;
        _length = length;
    }

    public RouteSectionResult TryControlTrain(Train train)
    {
        TrainMoveResult acceleratingResult = train.TryAccelerate(_power);

        if (acceleratingResult is TrainMoveResult.Failed)
        {
            return new RouteSectionResult.Failed(new AcceleratingError());
        }

        TrainMoveResult traverseResult = train.TryTraverse(_length);
        train.TryAccelerate(0);

        return traverseResult is TrainMoveResult.Success success
               ? new RouteSectionResult.Success(success.Time)
               : new RouteSectionResult.Failed(new AcceleratingError());
    }
}