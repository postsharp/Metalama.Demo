class Program
{
    [ForTestOnly]
    static void MyMethod()
    {
        // Some very typical business code.
        Console.WriteLine("Hello, World!");
    }

    static void Main()
    {
        MyMethod();
    }
}


