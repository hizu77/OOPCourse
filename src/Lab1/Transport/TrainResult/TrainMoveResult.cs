using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;

public abstract record TrainMoveResult
{
    private TrainMoveResult() { }

    public sealed record Success(Time Time) : TrainMoveResult;

    public sealed record Failed(ITrainMoveError Err) : TrainMoveResult;
}