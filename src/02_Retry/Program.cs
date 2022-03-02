class Program
{
    static int _invocations;

    [Retry]
    static void MyMethod()
    {
        _invocations++;

        Console.WriteLine( $"{_invocations}-th attempt." );

        if ( _invocations <= 2 )
        {
            Console.WriteLine( "Throw :-(" );
            throw new TimeoutException();
        }
        else
        {
            Console.WriteLine( "Success :-)" );
        }
    }


    static void Main()
    {
        MyMethod();
    }
}


