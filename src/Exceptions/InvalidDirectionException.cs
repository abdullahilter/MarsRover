using MarsRover.Resources;

namespace MarsRover.Exceptions;

public sealed class InvalidDirectionException : Exception
{
    public InvalidDirectionException()
        : base(SharedResource.InvalidDirection)
    {

    }
}