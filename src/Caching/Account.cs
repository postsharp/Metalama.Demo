using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Dependencies;

namespace CachingDemo;

[Serializable]
internal class Account : ICacheDependency
{
    public int AccountId;

    public string GetCacheKey(ICachingService cachingService ) 
        => $"Account:{this.AccountId}";
}