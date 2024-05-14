using MarsRover.Resources;

namespace MarsRover.Exceptions;

public sealed class InvalidCoordinateException : Exception
{
    public InvalidCoordinateException()
        : base(SharedResource.InvalidCoordinate)
    {

    }
}