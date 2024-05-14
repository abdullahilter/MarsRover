using MarsRover.Resources;

namespace MarsRover.Exceptions;

public sealed class InvalidInstructionException : Exception
{
    public InvalidInstructionException()
        : base(SharedResource.InvalidInstruction)
    {

    }
}