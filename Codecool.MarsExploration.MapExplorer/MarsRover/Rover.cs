using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class Rover
{
    public Coordinate CurrentPosition { get; set; }
    public int Sight { get; set; } = 3;
    public List<Coordinate> Resources { get; set; } = new List<Coordinate>();
    public string Symbol { get; set; }
    public string Id { get; init; } = "rover - 1";
}