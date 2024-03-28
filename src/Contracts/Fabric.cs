using Metalama.Framework.Fabrics;
using Metalama.Patterns.Contracts;

namespace Contracts;

public class Fabric : ProjectFabric
{
    public override void AmendProject( IProjectAmender amender )
    {
        amender.Outbound.VerifyNotNullableDeclarations();
    }
}