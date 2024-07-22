using Metalama.Framework.Fabrics;
using Metalama.Patterns.Contracts;

namespace ContractsDemo;

public class Fabric : ProjectFabric
{
    public override void AmendProject( IProjectAmender amender )
    {
        amender.VerifyNotNullableDeclarations();
    }
}