using MarsRover.Resources;

namespace MarsRover.Exceptions;

public sealed class InvalidSizeException : Exception
{
    public InvalidSizeException()
        : base(SharedResource.InvalidSize)
    {

    }

    public InvalidSizeException(Exception innerException)
        : base(SharedResource.InvalidSize, innerException)
    {

    }
}