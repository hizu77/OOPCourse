using Itmo.ObjectOrientedProgramming.Lab1.Transport.TrainResult;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public interface ITrain
{
    public double Speed { get;  }

    public TrainMoveResult TryAccelerate(double power);

    public TrainMoveResult TryTraverse(Length length);
}