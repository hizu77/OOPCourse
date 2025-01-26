namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record struct Weight
{
    public double Value { get; }

    public Weight(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }
}