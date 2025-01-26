using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.Modules;

public class PowerModules
{
    private readonly double _acceptedSpeed;

    public PowerModules(double acceptedSpeed)
    {
        _acceptedSpeed = acceptedSpeed;
    }

    public TrainMoveResult TryStopTrain(Train train)
    {
        return train.Speed > _acceptedSpeed
            ? new TrainMoveResult.Failed(new SpeedLimitError())
            : new TrainMoveResult.Success(Time.ZeroTime);
    }
}