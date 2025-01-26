using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.Modules;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.RouteSection;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSections.TravelResult;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Lab1.Tests;

public class UnitTests
{
    [Fact]
    public void TryEnroute_ShouldReturnSuccessTraverseResult_WhenTrainTravelsWithAcceptedRouteSpeed()
    {
        // Arrange
        var train = new Train(new Weight(100500), 10050000, new Time(30));
        var route = new Route(
            [
                new MagneticForcePath(1200, new Length(1000)),
                new NormalMagneticPath(new Length(2000))
            ],
            new PowerModules(1000));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<RouteSectionResult.Success>(result);
        Assert.Equal(((RouteSectionResult.Success)result).ResultTime, new Time(840));
    }

    [Fact]
    public void TryEnroute_ShouldReturnStoppingResultFailed_WhenTrainTravelsWithHigherRouteSpeed()
    {
        // Arrange
        var train = new Train(new Weight(1000), 5010, new Time(50));
        var route = new Route(
            [
                new MagneticForcePath(4900, new Length(1500)),
                new NormalMagneticPath(new Length(2000))
            ],
            new PowerModules(1));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<StoppingError>(((RouteSectionResult.Failed)result).Err);
    }

    [Fact]
    public void TryEnroute_ShouldReturnSuccessTraverseResult_WhenTrainTravelsWithAcceptedRouteSpeedWithAddedStations()
    {
        // Arrange
        var train = new Train(new Weight(1000), 5000, new Time(70));
        var route = new Route(
            [
                new MagneticForcePath(1000, new Length(1000)),
                new NormalMagneticPath(new Length(2000)),
                new Station(new Time(30), new PowerModules(1000000000)),
                new NormalMagneticPath(new Length(2000)),
            ],
            new PowerModules(100000));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<RouteSectionResult.Success>(result);
        Assert.Equal(((RouteSectionResult.Success)result).ResultTime, new Time(240));
    }

    [Fact]
    public void TryEnroute_ShouldReturnStationSpeedLimitReached_WhenTrainTravelsWithHigherStationSpeed()
    {
        // Arrange
        var train = new Train(new Weight(1000), 5000, new Time(1));
        var route = new Route(
            [
                new MagneticForcePath(1000, new Length(1000)),
                new Station(new Time(30), new PowerModules(10)),
                new NormalMagneticPath(new Length(200)),
            ],
            new PowerModules(10000));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<StationError>(((RouteSectionResult.Failed)result).Err);
    }

    [Fact]
    public void TryEnroute_ShouldReturnStoppingFailed_WhenTrainTravelsWithHigherRoutSpeed()
    {
        // Arrange
        var train = new Train(new Weight(1000), 5000, new Time(1));
        var route = new Route(
            [
                new MagneticForcePath(1000, new Length(100)),
                new NormalMagneticPath(new Length(200)),
                new Station(new Time(30), new PowerModules(100000)),
                new NormalMagneticPath(new Length(200)),
            ],
            new PowerModules(10));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<StoppingError>(((RouteSectionResult.Failed)result).Err);
    }

    [Fact]
    public void TryEnroute_ShouldReturnTravelSuccess_WhenTrainTravelsStationsAndNegativeForcePaths()
    {
        // Arrange
        var train = new Train(new Weight(1000), 500000000, new Time(1));
        var route = new Route(
            [
                new MagneticForcePath(10000, new Length(100)),
                new NormalMagneticPath(new Length(200)),
                new MagneticForcePath(-100, new Length(100)),
                new Station(new Time(30), new PowerModules(1000)),
                new NormalMagneticPath(new Length(200)),
                new MagneticForcePath(10000, new Length(100)),
                new NormalMagneticPath(new Length(200)),
                new MagneticForcePath(-100, new Length(100)),
            ],
            new PowerModules(1000));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<RouteSectionResult.Success>(result);
        Assert.Equal(((RouteSectionResult.Success)result).ResultTime, new Time(56));
    }

    [Fact]
    public void TryEnroute_ShouldReturnZeroSpeedAcceleration_WhenTrainTravelWithoutForcePaths()
    {
        // Arrange
        var train = new Train(new Weight(1000), 5000, new Time(1));
        var route = new Route(
            [
                new NormalMagneticPath(new Length(200)),
            ],
            new PowerModules(10));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<AcceleratingError>(((RouteSectionResult.Failed)result).Err);
    }

    [Fact]
    public void TryEnroute_ShouldReturnNegativeSpeed_WhenTrainTravelOnHigherNegativeForcePathsThanOthers()
    {
        // Arrange
        var train = new Train(new Weight(1000), 500, new Time(1));
        var route = new Route(
            [
                new MagneticForcePath(100, new Length(100)),
                new MagneticForcePath(-200, new Length(100)),
            ],
            new PowerModules(100));

        // Act
        RouteSectionResult result = route.TryEnroute(train);

        // Assert
        Assert.IsType<AcceleratingError>(((RouteSectionResult.Failed)result).Err);
    }
 }