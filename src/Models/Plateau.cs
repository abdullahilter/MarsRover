using MarsRover.Exceptions;

namespace MarsRover.Models;

public sealed class Plateau
{
    #region Properties

    public int Width { get; private set; }

    public int Height { get; private set; }

    #endregion

    #region Constructors

    public Plateau(string? size)
    {
        if (string.IsNullOrWhiteSpace(size))
        {
            throw new InvalidSizeException();
        }

        var splittedSize = size?.Split(' ')!;

        if (splittedSize is null ||
            splittedSize.Length != 2)
        {
            throw new InvalidSizeException();
        }

        Width = int.Parse(splittedSize[0]);
        if (Width < 0)
        {
            throw new InvalidSizeException();
        }

        Height = int.Parse(splittedSize[1]);
        if (Height < 0)
        {
            throw new InvalidSizeException();
        }
    }

    #endregion
}