using MarsRover.Constants;
using MarsRover.Models;

namespace MarsRover.Tests;

public sealed class MovementTests
{
    private readonly Plateau _plateau;

    public MovementTests()
    {
        _plateau = new Plateau("5 5");
    }

    [Theory]
    [InlineData("0 1 N", Directions.West)]
    [InlineData("1 2 E", Directions.North)]
    [InlineData("2 3 S", Directions.East)]
    [InlineData("3 4 W", Directions.South)]
    public void Given_ValidDirections_When_TurnLeft_Then_ReturnExpectedDirection(string? position, char expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.TurnLeft();

        // Assert
        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData("0 1 N", Directions.North)]
    [InlineData("1 2 E", Directions.East)]
    [InlineData("2 3 S", Directions.South)]
    [InlineData("3 4 W", Directions.West)]
    public void Given_InvalidDirections_When_TurnLeft_Then_ReturnNotExpectedDirection(string? position, char expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.TurnLeft();

        // Assert
        Assert.NotEqual(expected, rover.Direction);
    }

    [Theory]
    [InlineData("0 1 N", Directions.East)]
    [InlineData("1 2 E", Directions.South)]
    [InlineData("2 3 S", Directions.West)]
    [InlineData("3 4 W", Directions.North)]
    public void Given_ValidDirections_When_TurnRight_Then_ReturnExpectedDirection(string? position, char expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.TurnRight();

        // Assert
        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData("0 1 N", Directions.North)]
    [InlineData("1 2 E", Directions.East)]
    [InlineData("2 3 S", Directions.South)]
    [InlineData("3 4 W", Directions.West)]
    public void Given_InvalidDirections_When_TurnRight_Then_ReturnNotExpectedDirection(string? position, char expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.TurnRight();

        // Assert
        Assert.NotEqual(expected, rover.Direction);
    }

    [Theory]
    [InlineData("2 1 W", 1)]
    [InlineData("2 3 E", 3)]
    [InlineData("3 2 W", 2)]
    [InlineData("3 4 E", 4)]
    public void Given_ValidLocationX_When_MoveForward_Then_ReturnExpectedLocationX(string? position, int expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.MoveForward();

        // Assert
        Assert.Equal(expected, rover.LocationX);
    }

    [Theory]
    [InlineData("0 1 W", 1)]
    [InlineData("2 3 E", 2)]
    [InlineData("1 2 W", 2)]
    [InlineData("3 4 E", 3)]
    public void Given_InvalidLocationX_When_MoveForward_Then_ReturnNotExpectedLocationX(string? position, int expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.MoveForward();

        // Assert
        Assert.NotEqual(expected, rover.LocationX);
    }

    [Theory]
    [InlineData("0 1 N", 2)]
    [InlineData("2 3 S", 2)]
    [InlineData("1 2 N", 3)]
    [InlineData("3 4 S", 3)]
    public void Given_ValidLocationY_When_MoveForward_Then_ReturnExpectedLocationY(string? position, int expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.MoveForward();

        // Assert
        Assert.Equal(expected, rover.LocationY);
    }

    [Theory]
    [InlineData("0 1 N", 1)]
    [InlineData("2 3 S", 3)]
    [InlineData("1 2 N", 2)]
    [InlineData("3 4 S", 4)]
    public void Given_InvalidLocationY_When_MoveForward_Then_ReturnNotExpectedLocationY(string? position, int expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.MoveForward();

        // Assert
        Assert.NotEqual(expected, rover.LocationY);
    }
}