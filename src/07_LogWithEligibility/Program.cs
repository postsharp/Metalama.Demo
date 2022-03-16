class Program
{
    TextWriter _logger = Console.Out;

    [Log]
    void MyMethod()
    {
        // Some very typical business code.
        Console.WriteLine("Hello, World!");
    }

    static void Main()
    {
    
    }
}


