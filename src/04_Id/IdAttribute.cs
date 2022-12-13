using Metalama.Framework.Aspects;

class IdAttribute : TypeAspect
{
    [Introduce]
    public Guid Id4 { get; } = Guid.NewGuid();
}
