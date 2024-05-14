using MarsRover.Exceptions;
using MarsRover.Models;

namespace MarsRover.Tests;

public sealed class InstructionTests
{
    private readonly Plateau _plateau;

    public InstructionTests()
    {
        _plateau = new Plateau("5 5");
    }

    [Theory]
    [InlineData("1 2 N", "LMLMLMLMM", "1 3 N")]
    [InlineData("1 2 N", "LMLMLMLMMM", "1 4 N")]
    [InlineData("3 3 E", "MMRMMRMRRM", "5 1 E")]
    [InlineData("3 3 E", "MMRMMRMRRMRRRM", "5 2 N")]
    public void Given_ValidPositionsAndInstructions_When_ExecuteInstructions_Then_ReturnExpectedPositions(
        string? position,
        string? instructions,
        string expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.ExecuteInstructions(instructions);

        // Assert
        Assert.Equal(expected, rover.ToString());
    }

    [Theory]
    [InlineData("1 2 N", "LMLMLMLMM", "1 1 N")]
    [InlineData("1 2 N", "LMLMLMLMMM", "1 1 N")]
    [InlineData("3 3 E", "MMRMMRMRRM", "1 1 N")]
    [InlineData("3 3 E", "MMRMMRMRRMRRRM", "1 1 N")]
    public void Given_InvalidPositions_When_ExecuteInstructions_Then_ReturnNotExpectedPositions(
        string? position,
        string? instructions,
        string expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act
        rover.ExecuteInstructions(instructions);

        // Assert
        Assert.NotEqual(expected, rover.ToString());
    }

    [Theory]
    [InlineData("1 1 N", "A", typeof(InvalidInstructionException))]
    [InlineData("1 1 N", "B", typeof(InvalidInstructionException))]
    [InlineData("1 1 N", "C", typeof(InvalidInstructionException))]
    [InlineData("1 1 N", "D", typeof(InvalidInstructionException))]
    public void Given_InvalidInstructions_When_ExecuteInstructions_Then_ThrowException(
        string? position,
        string? instructions,
        Type expected)
    {
        // Arrange
        var rover = new Rover(_plateau, position);

        // Act

        // Assert
        Assert.Throws(expected, () => rover.ExecuteInstructions(instructions));
    }
}