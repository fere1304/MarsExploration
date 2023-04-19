using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapExplorer.Simulator;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        string mapFile = $@"C:\Users\Adriana\Desktop\proiecte\OOP\mars-exploration-2-csharp-calinadriana\Codecool.MarsExploration.MapExplorer\Resources\exploration-0.map";
        Coordinate landingSpot = new Coordinate(6, 6);
        List<string> resources = new List<string>() { "#", "&", "%", "*" };
        int NumberofSteps = 1000; 
        MapLoader.MapLoader mapLoader = new MapLoader.MapLoader();
        Rover rover = new Rover();
        Logger.Logger logger = new Logger.Logger();
        SimulationParameters config = new SimulationParameters(mapFile, landingSpot, resources, NumberofSteps);
        PlaceRover placeRover = new PlaceRover(config,mapLoader,rover);
        ValidatorConfiguration validate = new ValidatorConfiguration();

        ExplorationSimulator simulator =
            new ExplorationSimulator(validate, rover, logger, mapLoader, placeRover, config);
        
        simulator.Run(10);
        Console.WriteLine("ceva");
        //SimulationContext context =
        //new SimulationContext(0, NumberofSteps, rover, landingSpot, mapLoader.Load(mapFile), resources, outcome, 10);

    }
}
