using Metalama.Framework.Fabrics;

namespace Demo1
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject( IProjectAmender amender )
        {
            // Configure logging.
            amender.Project.LogOptions().Color = ConsoleColor.Green;

            // Add logging to all types and all methods.
            amender.With( c => c.Types.SelectMany( t => t.Methods ) ).AddAspectIfEligible( t => new LogAttribute() );
        }
    }
}
