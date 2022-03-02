using Metalama.Framework.Aspects;

class IdAttribute : TypeAspect
{
    [Introduce]
    public Guid Id { get; } = Guid.NewGuid();
}
