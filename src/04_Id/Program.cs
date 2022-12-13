class Program
{
    static void Main()
    {
        var foo = new Foo();
        Console.WriteLine(foo.Id4);
    }
    
}

[Id]
partial class Foo
{
    int _foo;

}


