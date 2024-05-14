using MarsRover.Exceptions;
using MarsRover.Models;

namespace MarsRover.Tests;

public sealed class RoverTests
{
    private readonly Plateau _plateau;

    public RoverTests()
    {
        _plateau = new Plateau("5 5");
    }

    [Theory]
    [InlineData("0 1 A", typeof(InvalidDirectionException))]
    [InlineData("1 2 B", typeof(InvalidDirectionException))]
    [InlineData("a 3 S", typeof(InvalidCoordinateException))]
    [InlineData("3 b W", typeof(InvalidCoordinateException))]
    [InlineData("qwe", typeof(InvalidPositionException))]
    [InlineData("asd", typeof(InvalidPositionException))]
    [InlineData("", typeof(InvalidPositionException))]
    [InlineData(null, typeof(InvalidPositionException))]
    public void Given_InvalidPositions_When_GenerateRover_Then_ThrowException(string? position, Type expected)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws(expected, () => new Rover(_plateau, position));
    }
}