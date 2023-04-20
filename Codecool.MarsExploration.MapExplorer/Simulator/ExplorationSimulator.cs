using System.Data;
using System.Globalization;
using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.Configuration.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulator;

public class ExplorationSimulator
{
    //private SimulationContext simulationContext;
    private List<Coordinate> ExploredArea = new List<Coordinate>();
    private ValidatorConfiguration validator { get; set; }
    private Rover rover { get; set; }
    private Logger.Logger logger { get; set; }
    private MapLoader.MapLoader mapLoader { get; set; }

    private PlaceRover placeRover { get; set; }

    private SimulationParameters simulationParameters { get; set; }

    

    public ExplorationSimulator(ValidatorConfiguration validateConfiguration, Rover rover, Logger.Logger logger, MapLoader.MapLoader mapLoader, PlaceRover placeRover, SimulationParameters simulation)
    {
        this.validator = validateConfiguration;
        this.rover = rover;
        this.logger = logger;
        this.mapLoader = mapLoader;
        this.placeRover = placeRover;
        this.simulationParameters = simulation;

    }

    public SimulationContext Generate( int Res)
    {
       

        placeRover.PlaceRoveronMap();

        return new SimulationContext
        {
            map = mapLoader.Load(simulationParameters.MapFile),
            NecesaryRes = Res,
            OutCome = default,
            NumberOfSteps = 0,
            RequiredNumberOfSteps = simulationParameters.SimulationSteps,
            Rover = rover,
            SpaceShip = simulationParameters.LandingSpot,
            Symbols = new List<string>{"*","%"}
        };


    }

    public void Run(int res)
    {
        var simulationContext = Generate(res);
        while (simulationContext.NumberOfSteps <= simulationContext.RequiredNumberOfSteps)
        {
            Scan(simulationContext);
            Move(simulationContext);
            Analizyz(simulationContext);
            Log(simulationContext);
            simulationContext.NumberOfSteps++;


        }
    }

    private void Move(SimulationContext simulationContext)
    {
        List<Coordinate> PossibletoMove = new List<Coordinate>();
        var coordX = simulationContext.Rover.CurrentPosition.X;
        var coordY = simulationContext.Rover.CurrentPosition.Y;
        Random random = new Random();
        for (int i = coordX - 1; i < coordX + 1; i++)
        {
            for (int j = coordY - 1; j < coordY + 1; j++)
            {
                var coord = new Coordinate(i, j);
                if (i >= 0 && i < simulationContext.map.Dimension && j >= 0 && j < simulationContext.map.Dimension  && simulationContext.map.Representation[i, j] == " " && !ExploredArea.Contains(coord))
                {
                    PossibletoMove.Add(coord);
                    ExploredArea.Add(coord);

                }
            }
        }

        if (PossibletoMove.Count > 0)
        {
            rover.CurrentPosition = PossibletoMove[random.Next(0, PossibletoMove.Count)];
        }
        if (PossibletoMove.Count == 0)
        {
            rover.CurrentPosition = ExploredArea[random.Next(ExploredArea.Count)];
        }

        




    }

    private void Scan(SimulationContext simulationContext)
    {
        
        var coordX = simulationContext.Rover.CurrentPosition.X;
        var coordY = simulationContext.Rover.CurrentPosition.Y;
        var sight = simulationContext.Rover.Sight;
        for (int i = coordX-sight; i < coordX + sight; i++)
        {
            for (int j = coordY - sight; j < coordY + sight; j++)
            {
                if (i>=0 && i<simulationContext.map.Dimension && j>= 0 && j< simulationContext.map.Dimension  &&
                    !simulationContext.Rover.Resources.Contains(new Coordinate(i, j)))
                {
                    if (simulationContext.map.Representation[i, j] == "*" ||
                        simulationContext.map.Representation[i, j] == "%")
                    {
                        simulationContext.Rover.Resources.Add(new Coordinate(i, j));
                    }
                    
                }
            }
        }
    }

    private void Analizyz(SimulationContext simulationContext)
    {
        if (simulationContext.NumberOfSteps >= simulationContext.RequiredNumberOfSteps)
        {
            simulationContext.OutCome = ExplorationOutcome.Timeout;
        }
        else if (simulationContext.NumberOfSteps < simulationContext.RequiredNumberOfSteps &&
                  simulationContext.Rover.Resources.Count == simulationContext.NecesaryRes)
        {
            simulationContext.OutCome = ExplorationOutcome.Colonizable;
            
        }
        else if (simulationContext.NumberOfSteps < simulationContext.RequiredNumberOfSteps  &&
                 rover.Resources.Count == 0)
        {
            simulationContext.OutCome = ExplorationOutcome.Error;
        }

        
        
    }

    private void Log(SimulationContext simulationContext)
    {
        Console.WriteLine($"STEP {simulationContext.NumberOfSteps}; EVENT {simulationContext.OutCome}; UNIT {rover.Id}; POSITION {rover.CurrentPosition}. Found {rover.Resources.Count} resources out of{simulationContext.NecesaryRes}");
        logger.Log($"STEP {simulationContext.NumberOfSteps}; EVENT {simulationContext.OutCome}; UNIT {rover.Id}; POSITION {rover.CurrentPosition}. Found {rover.Resources.Count} resources out of{simulationContext.NecesaryRes}");
        
    }

  
    
}