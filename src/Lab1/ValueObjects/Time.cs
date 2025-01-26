namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record struct Time
{
    public static readonly Time ZeroTime = new Time(0);

    public double Value { get; }

    public Time(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }

    public static Time operator +(Time lhs, Time rhs)
    {
        double resultTIme = lhs.Value + rhs.Value;
        return new Time(resultTIme);
    }
}