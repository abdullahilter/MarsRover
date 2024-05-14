using MarsRover.Models;
using MarsRover.Resources;

while (true)
{
    Console.WriteLine(SharedResource.PlateauSize);
    var plateau = new Plateau(Console.ReadLine());

    Console.WriteLine(SharedResource.RoverPosition);
    var position = Console.ReadLine();

    Console.WriteLine(SharedResource.RoverInstructions);
    var instructions = Console.ReadLine();

    var rover = new Rover(plateau, position);
    rover.ExecuteInstructions(instructions);
    Console.WriteLine(rover);

    Console.WriteLine(SharedResource.WouldYouLikeToContinue);
    var anotherRover = Console.ReadLine() ?? string.Empty;

    if (!anotherRover.Equals(SharedResource.Yes, StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
}

public partial class Program { }