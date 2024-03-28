using Metalama.Patterns.Caching;
using Metalama.Patterns.Caching.Dependencies;

  [Serializable]
  internal class Account : ICacheDependency
  {
    public int AccountId;

    public string GetCacheKey(ICachingService cachingService ) 
        => $"Account:{AccountId}";
  }
