using Metalama.Framework.Fabrics;

namespace Demo1
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject( IProjectAmender amender )
        {
            // Configure logging.
            amender.Outbound
                .SetOptions( new LogOptions { Color = ConsoleColor.Green } );
            amender.Outbound
                .SelectMany( c=>c.Types.OfName( nameof(Greeter) ) )
                .SetOptions( new LogOptions { Color = ConsoleColor.Red } );
            

            // Add logging to all types and all methods.
            amender.Outbound
                .SelectMany( c => c.Types )
                .SelectMany( t => t.Methods )
                .AddAspectIfEligible<LogAttribute>();
        }
    }
}
