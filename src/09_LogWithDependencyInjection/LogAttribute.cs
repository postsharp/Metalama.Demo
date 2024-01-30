using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Microsoft.Extensions.Logging;

class LogAttribute : OverrideMethodAspect
{
    [IntroduceDependency]
    private readonly ILogger _logger;
    
    public override dynamic? OverrideMethod()
    {
        this._logger.Log( LogLevel.Debug, $"Entering {meta.Target.Method}." );

        try
        {
            return meta.Proceed();
        }
        finally
        {
            this._logger.Log( LogLevel.Debug, $"Leaving {meta.Target.Method}." );
        }
    }
}
