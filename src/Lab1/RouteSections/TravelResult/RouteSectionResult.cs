using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;

public abstract record RouteSectionResult
{
    private RouteSectionResult() { }

    public sealed record Success(Time ResultTime) : RouteSectionResult;

    public sealed record Failed(IRouteSectionError Err) : RouteSectionResult;
}