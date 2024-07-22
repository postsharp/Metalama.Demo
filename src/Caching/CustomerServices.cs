using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Aspects;

namespace CachingDemo;

[CachingConfiguration(AbsoluteExpiration = 10)]
internal class CustomerServices
{
    [Cache]
    public static Customer GetCustomer(int id)
    {
        Console.WriteLine($">> Retrieving the customer {id} from database...");
        Thread.Sleep(1000);
        return new Customer { Id = id, Name = "Rubber Debugging Duck" };
    }

    [InvalidateCache(nameof(GetCustomer))]
    public static void UpdateCustomer(int id, string newName)
    {
        Console.WriteLine($">> Updating the customer {id} in database...");
        Thread.Sleep(1000);
    }

    public static void DeleteCustomer(int id, string newName)
    {
        Console.WriteLine($">> Deleting the customer {id} from database...");
        Thread.Sleep(1000);

        CachingService.Default.Invalidate(GetCustomer, id);
    }
}