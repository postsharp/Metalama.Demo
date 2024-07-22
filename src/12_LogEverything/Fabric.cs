using Metalama.Framework.Fabrics;

namespace LogFabricDemo
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject( IProjectAmender amender )
        {
            // Add logging to all types and all methods.
            amender
                .SelectMany( c => c.Types )
                .SelectMany( t => t.Methods )
                .AddAspectIfEligible<LogAttribute>();
        }
    }
}
