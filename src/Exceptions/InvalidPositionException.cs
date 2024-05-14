using MarsRover.Resources;

namespace MarsRover.Exceptions;

public sealed class InvalidPositionException : Exception
{
    public InvalidPositionException()
        : base(SharedResource.InvalidPosition)
    {

    }

    public InvalidPositionException(Exception innerException)
        : base(SharedResource.InvalidPosition, innerException)
    {

    }
}