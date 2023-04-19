using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.MapLoader;

public class MapLoader : IMapLoader
{
    public Map Load(string mapFile)
    {
        var text = File.ReadAllLines(mapFile);
        var mapList2D = new string[text.Length, text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < text[i].Length; j++)
            {
                if (text[i][j] == ' ')
                {
                    mapList2D[i, j] = " ";
                }
                else
                {
                    mapList2D[i,j] = text[i][j].ToString();
                }
            }
        }

        return new Map(mapList2D);
    }
}