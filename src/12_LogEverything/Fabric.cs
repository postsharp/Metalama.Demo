using Metalama.Framework.Fabrics;

namespace Demo1
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject( IProjectAmender amender )
        {
            // Add logging to all types and all methods.
            amender.Outbound.SelectMany( c => c.Types.SelectMany( t => t.Methods ) ).AddAspectIfEligible( t => new LogAttribute() );
        }
    }
}
