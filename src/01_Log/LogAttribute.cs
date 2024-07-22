using Metalama.Framework.Aspects;

namespace LogDemo;

class LogAttribute : OverrideMethodAspect
{
    // Template that overrides the methods to which the aspect is applied.
    public override dynamic? OverrideMethod()
    {
        Console.WriteLine( $"Entering {meta.Target.Method}." );
        try
        {
            return meta.Proceed();
        }
        finally
        {
            Console.WriteLine( $"Leaving {meta.Target.Method}." );
        }
    }
}