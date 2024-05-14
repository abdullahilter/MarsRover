using MarsRover.Exceptions;
using MarsRover.Models;

namespace MarsRover.Tests;

public sealed class PlateauTests
{
    [Theory]
    [InlineData("-1 2", typeof(InvalidSizeException))]
    [InlineData("ab", typeof(InvalidSizeException))]
    [InlineData("", typeof(InvalidSizeException))]
    [InlineData(null, typeof(InvalidSizeException))]
    public void Given_InvalidSize_When_GeneratePlateau_Then_ThrowException(string? size, Type expected)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws(expected, () => new Plateau(size));
    }
}