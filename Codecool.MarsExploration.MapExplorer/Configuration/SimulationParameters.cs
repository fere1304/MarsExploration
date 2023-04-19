using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public record SimulationParameters(string MapFile, Coordinate LandingSpot, List<string> Resources, int SimulationSteps);
