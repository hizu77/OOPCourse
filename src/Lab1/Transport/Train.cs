using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train : ITrain
{
    private readonly Weight _weight;
    private readonly double _maximumForce;
    private readonly Time _precision;
    private double _acceleration;

    public Train(Weight weight, double maximumForce, Time precision)
    {
        _weight = weight;
        _maximumForce = maximumForce;
        _precision = precision;
    }

    public double Speed { get; private set; }

    public TrainMoveResult TryAccelerate(double power)
    {
        if (power > _maximumForce)
        {
            return new TrainMoveResult.Failed(new MaxForceError());
        }

        _acceleration = power / _weight.Value;

        return new TrainMoveResult.Success(Time.ZeroTime);
    }

    public TrainMoveResult TryTraverse(Length length)
    {
        var timeSpent = new Time(0);
        double remainingLength = length.Value;

        while (remainingLength > 0)
        {
            bool isZeroSpeedAcceleration = _acceleration <= 0 && Speed <= 0;
            bool isNegativeSpeed = Speed + (_acceleration * _precision.Value) <= 0;

            if (isZeroSpeedAcceleration || isNegativeSpeed)
            {
                return new TrainMoveResult.Failed(new NegativeSpeedError());
            }

            Speed += _acceleration * _precision.Value;
            timeSpent += _precision;
            remainingLength -= Speed * _precision.Value;
        }

        return new TrainMoveResult.Success(timeSpent);
    }
}