using Metalama.Framework.Aspects;

class LogAttribute : OverrideMethodAspect
{
    public override dynamic? OverrideMethod()
    {
        Console.WriteLine( $"Entering {meta.Target.Method.ToDisplayString()}." );
        try
        {
            return meta.Proceed();
        }
        finally
        {
            Console.WriteLine( $"Leaving {meta.Target.Method.ToDisplayString()}." );
        }
    }
}
