namespace LogFabricDemo;

static class Program
{
    static void Main()
    {
        Greeter.Greet();
    }
}

static class Greeter
{
    public static void Greet()
    {
        Console.WriteLine( "Hello, World!" );
    }
}