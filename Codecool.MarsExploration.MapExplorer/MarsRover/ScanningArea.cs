using Codecool.MarsExploration.MapExplorer.Configuration;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class ScanningArea
{
    public void ScanArea(Rover Rover, string[,] map)
    {
        bool[,] scannedCells = new bool[map.GetLength(0), map.GetLength(1)];
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                int dx = i - Rover.CurrentPosition.X;
                int dy = j - Rover.CurrentPosition.Y;
                int distance = (int)Math.Sqrt(dx * dx + dy * dy);
                if (!scannedCells[i, j] && distance < Rover.Sight)
                {
                    scannedCells[i, j] = true;
                }
            }
        }
    }
}