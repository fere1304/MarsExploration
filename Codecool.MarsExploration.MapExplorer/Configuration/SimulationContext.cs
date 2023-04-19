using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MarsRover;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record SimulationContext
{
    public int NumberOfSteps;
    public int RequiredNumberOfSteps;
    public Rover Rover;
    public Coordinate SpaceShip;
    public Map map;
    public List<string> Symbols;
    public ExplorationOutcome OutCome;
    public int NecesaryRes;

};