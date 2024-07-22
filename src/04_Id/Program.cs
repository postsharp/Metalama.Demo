namespace IntroductionDemo;

class Program
{
    static void Main()
    {
        var foo = new Foo();
        Console.WriteLine((int)foo.Id);
    }
    
}

[Id]
partial class Foo
{
    int _foo;

}