namespace Codecool.MarsExploration.MapExplorer.Logger;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);

        string filePath = @"C:\Users\Adriana\Desktop\proiecte\OOP\mars-exploration-2-csharp-calinadriana\Codecool.MarsExploration.MapExplorer\Logger\log.txt";
        using (StreamWriter wr = new StreamWriter(filePath,true))
        {
            wr.WriteLine(message);
        }

    }
}