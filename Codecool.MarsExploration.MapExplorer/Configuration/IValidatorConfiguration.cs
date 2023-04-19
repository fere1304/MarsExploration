using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public interface IValidatorConfiguration
{
    bool Validate(string mapFile, Coordinate landingSpot, List<string> resources, int timeout);
}