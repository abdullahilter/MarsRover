using MarsRover.Constants;
using MarsRover.Exceptions;

namespace MarsRover.Models;

public sealed class Rover
{
    #region Declerations

    private readonly Plateau _plateau;

    #endregion

    #region Properties

    public int LocationX { get; private set; }

    public int LocationY { get; private set; }

    public char Direction { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position">eg. "1 2 N"</param>
    public Rover(Plateau plateau, string? position)
    {
        _plateau = plateau;

        if (string.IsNullOrWhiteSpace(position))
        {
            throw new InvalidPositionException();
        }

        var splittedPosition = position?.Split(' ')!;

        if (splittedPosition is null ||
            splittedPosition.Length != 3)
        {
            throw new InvalidPositionException();
        }

        #region Location X

        var isParsedX = int.TryParse(splittedPosition[0], out var parsedX);

        if (!isParsedX ||
            parsedX < 0 ||
            parsedX > _plateau.Width)
        {
            throw new InvalidCoordinateException();
        }

        LocationX = parsedX;

        #endregion

        #region Location Y

        var isParsedY = int.TryParse(splittedPosition[1], out var parsedY);

        if (!isParsedY ||
            parsedY < 0 ||
            parsedY > _plateau.Height)
        {
            throw new InvalidCoordinateException();
        }

        LocationY = parsedY;

        #endregion

        #region Direction

        Direction = char.Parse(splittedPosition[2]);

        if (!Equals(Directions.North, Direction) &&
            !Equals(Directions.East, Direction) &&
            !Equals(Directions.South, Direction) &&
            !Equals(Directions.West, Direction))
        {
            throw new InvalidDirectionException();
        }

        #endregion
    }

    #endregion

    #region Methods

    public void TurnLeft()
    {
        Direction = Direction switch
        {
            Directions.North => Directions.West,
            Directions.East => Directions.North,
            Directions.South => Directions.East,
            Directions.West => Directions.South,
            _ => Direction
        };
    }

    public void TurnRight()
    {
        Direction = Direction switch
        {
            Directions.North => Directions.East,
            Directions.East => Directions.South,
            Directions.South => Directions.West,
            Directions.West => Directions.North,
            _ => Direction
        };
    }

    public void MoveForward()
    {
        switch (Direction)
        {
            case Directions.North: if (LocationY < _plateau.Height) LocationY++; break;
            case Directions.East: if (LocationX < _plateau.Width) LocationX++; break;
            case Directions.South: if (LocationY > 0) LocationY--; break;
            case Directions.West: if (LocationX > 0) LocationX--; break;
            default: break;
        }
    }

    public void ExecuteInstructions(string? instructions)
    {
        foreach (var instruction in instructions ?? string.Empty)
        {
            switch (instruction)
            {
                case Commands.Left: TurnLeft(); break;
                case Commands.Right: TurnRight(); break;
                case Commands.Move: MoveForward(); break;
                default: throw new InvalidInstructionException();
            };
        }
    }

    #endregion

    #region Functions

    public override string ToString() => $"{LocationX} {LocationY} {Direction}";

    #endregion
}