using static System.Environment;

namespace Northwind.EntityModels;

public class NorthwindContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine("..", "northwindlog.txt");
        string fullpath = Path.GetFullPath(path);
        Console.WriteLine($"Northwindlog Path: {fullpath}");
        using StreamWriter textFile = File.AppendText(fullpath);
        textFile.WriteLine(message);
    }
}
