using Metalama.Framework.Aspects;

internal class RetryAttribute : OverrideMethodAspect
{
    /// <summary>
    /// Gets or sets the number of times that the method should be executed in case of failure.
    /// </summary>
    public int Attempts { get; set; } = 3;

    // Template that overrides the methods to which the aspect is applied.
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

