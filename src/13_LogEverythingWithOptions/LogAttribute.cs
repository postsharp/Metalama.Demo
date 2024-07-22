using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace LogFabricWithOptionsDemo;

class LogAttribute : OverrideMethodAspect
{
    // Template that overrides the methods to which the aspect is applied.
    public override dynamic? OverrideMethod()
    {
        var color = meta.Target.Method.Enhancements().GetOptions<LogOptions>().Color ?? ConsoleColor.Black;
        
        ConsoleLogger.Log( $"Entering {meta.Target.Method.ToDisplayString()}.", color );
        try
        {
            return meta.Proceed();
        }
        finally
        {
            ConsoleLogger.Log( $"Leaving {meta.Target.Method.ToDisplayString()}.", color );
        }
    }
}