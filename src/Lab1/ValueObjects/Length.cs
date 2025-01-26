namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record struct Length
{
    public static readonly Length ZeroLength = new Length(0);

    public double Value { get; }

    public Length(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }

    public static Length operator -(Length lhs, Length rhs)
    {
        double resultLength = lhs.Value - rhs.Value;
        return new Length(resultLength);
    }

    public static bool operator >=(Length lhs, Length rhs)
    {
        return lhs.Value - rhs.Value >= 0;
    }

    public static bool operator <=(Length lhs, Length rhs)
    {
        return lhs.Value - rhs.Value <= 0;
    }

    public static bool operator >(Length lhs, Length rhs)
    {
        return lhs.Value - rhs.Value > 0;
    }

    public static bool operator <(Length lhs, Length rhs)
    {
        return lhs.Value - rhs.Value < 0;
    }
}