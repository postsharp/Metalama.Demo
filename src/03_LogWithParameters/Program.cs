namespace LogDemo2;

class Program
{
    [Log]
    static void MyMethod( string who, int a )
    {
        // Some very typical business code.
        Console.WriteLine($"Hello, {who}!");
    }

    static void Main()
    {
        MyMethod("Lama", 0);
    }
}