namespace RetryDemo;

class Program
{
 
    [Retry( Attempts = 5 )]
    static void MyMethod()
    {
     
        if ( Random.Shared.NextDouble() <= 0.8 )
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