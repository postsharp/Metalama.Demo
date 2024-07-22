using Metalama.Framework.Fabrics;

namespace LogFabricWithOptionsDemo
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject( IProjectAmender amender )
        {
            // Configure logging.
            amender
                .SetOptions( new LogOptions { Color = ConsoleColor.Green } );
            amender
                .SelectMany( c=>c.Types.OfName( nameof(Greeter) ) )
                .SetOptions( new LogOptions { Color = ConsoleColor.Red } );
            

            // Add logging to all types and all methods.
            amender
                .SelectMany( c => c.Types )
                .SelectMany( t => t.Methods )
                .AddAspectIfEligible<LogAttribute>();
        }
    }
}
