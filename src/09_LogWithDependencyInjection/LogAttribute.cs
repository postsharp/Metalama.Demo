using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;
using Metalama.Framework.Eligibility;
using Microsoft.Extensions.Logging;

class LogAttribute : OverrideMethodAspect
{
    [IntroduceDependency]
    private readonly ILogger _logger;
    
    // Template that overrides the methods to which the aspect is applied.
    public override dynamic? OverrideMethod()
    {
        // `meta.This` is a dynamic object and compiles into `this`. Anything on the right side is resolved at compile time
        // in the context of the target type.

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
