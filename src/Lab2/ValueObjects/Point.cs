namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record struct Point
{
    public static readonly Point KMaxPoint = new Point(100);

    public double Value { get; }

    public Point(double value)
    {
        if (value is < 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Points must be between 0 and 100.");
        }

        Value = value;
    }
}