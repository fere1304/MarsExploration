using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using System.IO.Compression;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public class ValidatorConfiguration : IValidatorConfiguration
{
    
    public bool Validate(string mapFile, Coordinate landingSpot, List<string> resources, int timeout)
    {
        if (string.IsNullOrWhiteSpace(mapFile))
        {
            throw new ArgumentNullException("Invalid file path");
        }

        if (resources == null || resources.Count == 0)
        {
            throw new ArgumentException("Invalid resources");
        }

        if (timeout <= 0)
        {
            throw new ArgumentException("Invalid timeout value");
        }


        var map = new MapLoader.MapLoader().Load(mapFile);

        Console.WriteLine(map.Dimension);
        if (map.Representation[landingSpot.X, landingSpot.Y] != " " || landingSpot.X<0 || landingSpot.X >= map.Dimension)
        {
            
            throw new ArgumentException("Invalid landing spot");
        }

        if (landingSpot.Y<0 || landingSpot.Y >= map.Dimension)
        {
            throw new ArgumentException("Invalid landing spot");
        }

        if (!HasAdjacentEmptySpot( landingSpot, mapFile))
        {
            return false;
        }

        return true;
    }

    private bool HasAdjacentEmptySpot(Coordinate coordinate, string mapFile)
    {
        var map = new MapLoader.MapLoader().Load(mapFile);
        for (int i = coordinate.X - 1; i <= coordinate.X + 1; i++)
            {
                for (int j = coordinate.Y - 1; j <= coordinate.Y + 1; j++)
                {
                    if (i >= 0 && i <map.Dimension && j >= 0 && j < map.Dimension && map.Representation[i,j] == " ")
                        return true;
                }
            }

            return false;
    }
    

}