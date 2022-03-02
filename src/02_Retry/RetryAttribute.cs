using Metalama.Framework.Aspects;

internal class RetryAttribute : OverrideMethodAspect
{
    public int Attempts { get; set; } = 3;

    public override dynamic? OverrideMethod()
    {
        for ( var i = 0; ;i++ )
        {
            try
            {
                return meta.Proceed();
            }
            catch ( Exception e ) when ( i < this.Attempts )
            {
                Console.WriteLine( $"Caught exception of type {e.Message.GetType().Name}. Retrying in 1 second." );
                Thread.Sleep( 1000 );
            }
        }
    }
}

