using Metalama.Framework.Aspects;

static class ConsoleLogger
{
    [ExcludeAspect(typeof(LogAttribute), Justification = "Avoid infinite recursion.") ]
    public static void Log( string message, ConsoleColor color )
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message );
        Console.ForegroundColor = oldColor;
    }
}