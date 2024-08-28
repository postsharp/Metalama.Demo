using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Aspects;

namespace CachingDemo;

internal class AccountServices
{
    [Cache]
    public Account GetAccount(int id)
    {
        Console.WriteLine($">> Retrieving the account {id} from database...");
        Thread.Sleep(1000);

        var account = new Account { AccountId = id };

        CachingService.Default.AddDependency(account);

        return account;
    }

    [Cache]
    public IEnumerable<Account> GetAccountsOfCustomer(int customerId)
    {
        // Dependencies of GetAccount are automatically added to GetAccountsOfCustomer.
        yield return GetAccount(1);
        yield return GetAccount(2);
    }

    public void UpdateAccount(Account account)
    {
        Console.WriteLine($">> Updating the account {account.AccountId} in database...");
        Thread.Sleep(1000);

        // This will invalidate both GetAccount and GetAccountsOfCustomer.
        CachingService.Default.Invalidate(account);
    }
}