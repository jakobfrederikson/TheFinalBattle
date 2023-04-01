using System.Drawing;

public static class ColouredConsole
{
    public static void WriteLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color; 
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Write(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

