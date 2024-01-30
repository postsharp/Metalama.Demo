using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Aspects;

[assembly: CachingConfiguration( UseDependencyInjection = false )]

[CachingConfiguration( AbsoluteExpiration = 5 )]
internal class Program
{
    private static void Main( string[] args )
    {
        // Uncomment the next line for detailed logging.
        // LoggingServices.DefaultBackend.DefaultVerbosity.SetMinimalLevel(LogLevel.Debug, LoggingRoles.Caching);

        var accountProfile = new CachingProfile( "Account" ) { AbsoluteExpiration = TimeSpan.FromSeconds( 10 ) };
        CachingService.Default = CachingService.Create( builder => builder.AddProfile( accountProfile ) );


        // Testing direct invalidation.
        Console.WriteLine( "Retrieving the customer for the 1st time should hit the database." );
        CustomerServices.GetCustomer( 1 );
        Console.WriteLine( "Retrieving the customer for the 2nd time should NOT hit the database." );
        CustomerServices.GetCustomer( 1 );
        Console.WriteLine( "This should invalidate the GetCustomer method." );
        CustomerServices.UpdateCustomer( 1, "New name" );
        Console.WriteLine( "This should hit the database again because GetCustomer has been invalidated." );
        CustomerServices.GetCustomer( 1 );

        // Testing indirect invalidation (dependencies).
        Console.WriteLine( "Retrieving the account list for the 1st time should hit the database." );
        _ = AccountServices.GetAccountsOfCustomer( 1 );
        Console.WriteLine( "Retrieving the account list for the 2nt time should NOT hit the database." );
        var accounts = AccountServices.GetAccountsOfCustomer( 1 );
        Console.WriteLine( "This should invalidate the accounts" );
        AccountServices.UpdateAccount( accounts.First() );
        Console.WriteLine(
            "This should hit the database again because GetAccountsOfCustomer has been invalidated." );
        _ = AccountServices.GetAccountsOfCustomer( 1 );

        Console.WriteLine( "Done!" );
    }
}