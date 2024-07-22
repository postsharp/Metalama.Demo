﻿using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Aspects;

namespace CachingDemo;

[CachingConfiguration(ProfileName = "Account")] // See Program.cs for the configuration of the "Account" caching profile.
internal class AccountServices
{
    [Cache]
    public static Account GetAccount(int id)
    {
        Console.WriteLine($">> Retrieving the account {id} from database...");
        Thread.Sleep(1000);

        var account = new Account { AccountId = id };

        CachingService.Default.AddDependency(account);

        return account;
    }

    [Cache]
    public static IEnumerable<Account> GetAccountsOfCustomer(int customerId)
    {
        // Dependencies of GetAccount are automatically added to GetAccountsOfCustomer.
        yield return GetAccount(1);
        yield return GetAccount(2);
    }

    public static void UpdateAccount(Account account)
    {
        Console.WriteLine($">> Updating the account {account.AccountId} in database...");
        Thread.Sleep(1000);

        // This will invalidate both GetAccount and GetAccountsOfCustomer.
        CachingService.Default.Invalidate(account);
    }
}