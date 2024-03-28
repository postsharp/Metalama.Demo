using Metalama.Framework.Aspects;

class IdAttribute : TypeAspect
{
    [Introduce]
    private static int _nextId;
    
    [Introduce]
    public int Id { get; } = Interlocked.Increment( ref _nextId );
}
