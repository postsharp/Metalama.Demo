using Metalama.Framework.Aspects;

class LogAttribute : OverrideMethodAspect
{
    // Template that overrides the methods to which the aspect is applied.
    public override dynamic? OverrideMethod()
    {
        var color = meta.Target.Project.LogOptions().Color;
        
        LoggingHelper.Log( $"Entering {meta.Target.Method.ToDisplayString()}.", color );
        try
        {
            return meta.Proceed();
        }
        finally
        {
            LoggingHelper.Log( $"Leaving {meta.Target.Method.ToDisplayString()}.", color );
        }
    }
}
