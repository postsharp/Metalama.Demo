using Metalama.Patterns.Caching.Aspects;
using Metalama.Patterns.Caching.Building;
using Microsoft.Extensions.DependencyInjection;

namespace CachingDemo;

[CachingConfiguration( AbsoluteExpiration = 5 )]
internal class Program
{
    private static void Main( string[] args )
    {
        // Uncomment the next line for detailed logging.
        // LoggingServices.DefaultBackend.DefaultVerbosity.SetMinimalLevel(LogLevel.Debug, LoggingRoles.Caching);

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMetalamaCaching();
        serviceCollection.AddSingleton<CustomerServices>();
        serviceCollection.AddSingleton<AccountServices>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var customerServices = serviceProvider.GetRequiredService<CustomerServices>();
        var accountServices = serviceProvider.GetRequiredService<AccountServices>();
        

        // Testing direct invalidation.
        Console.WriteLine( "Retrieving the customer for the 1st time should hit the database." );
        customerServices.GetCustomer( 1 );
        Console.WriteLine( "Retrieving the customer for the 2nd time should NOT hit the database." );
        customerServices.GetCustomer( 1 );
        Console.WriteLine( "This should invalidate the GetCustomer method." );
        customerServices.UpdateCustomer( 1, "New name" );
        Console.WriteLine( "This should hit the database again because GetCustomer has been invalidated." );
        customerServices.GetCustomer( 1 );

        // Testing indirect invalidation (dependencies).
        Console.WriteLine( "Retrieving the account list for the 1st time should hit the database." );
        _ = accountServices.GetAccountsOfCustomer( 1 );
        Console.WriteLine( "Retrieving the account list for the 2nt time should NOT hit the database." );
        var accounts = accountServices.GetAccountsOfCustomer( 1 );
        Console.WriteLine( "This should invalidate the accounts" );
        accountServices.UpdateAccount( accounts.First() );
        Console.WriteLine(
            "This should hit the database again because GetAccountsOfCustomer has been invalidated." );
        _ = accountServices.GetAccountsOfCustomer( 1 );

        Console.WriteLine( "Done!" );
    }
}