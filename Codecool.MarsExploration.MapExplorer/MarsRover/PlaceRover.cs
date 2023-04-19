using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using System.Xml.Linq;
using Codecool.MarsExploration.MapExplorer.Configuration;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class PlaceRover
{
    public SimulationParameters _configuration;
    public MapLoader.MapLoader _map;
    public Rover _rover;

    public PlaceRover(SimulationParameters configuration, MapLoader.MapLoader map, Rover rover)
    {
        _configuration= configuration;
        _map= map;
        _rover= rover;
    }

    public void PlaceRoveronMap()
    {
        var map = _map.Load(_configuration.MapFile);

        var coordX = _configuration.LandingSpot.X;
        var coordY = _configuration.LandingSpot.Y;
        
        

        for (int i = coordX - 1; i <= coordX + 1; i++)
        {
            for (int j = coordY - 1; j <= coordY + 1; j++)
            {
                if (i >= 0 && i < map.Dimension && j >= 0 && j < map.Dimension && map.IsEmpty(new Coordinate(i, j)))
                    _rover.CurrentPosition = new Coordinate(i, j);
            }
        }


    }
}