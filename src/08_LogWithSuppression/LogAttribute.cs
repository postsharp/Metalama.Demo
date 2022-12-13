using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;
using Metalama.Framework.Eligibility;

class LogAttribute : OverrideMethodAspect
{
    // Definition of the warning. It must be a static field in the aspect class.
    static DiagnosticDefinition<(INamedType DeclaringType, IMethod Method)> _loggerFieldNotFoundError = new(
        "DEMO01",
        Severity.Error,
        "The type '{0}' must contain an instance field '_logger' of type 'TextWriter' because of the [Log] aspect on '{1}'." );

    static SuppressionDefinition _loggerFieldNotUsedSuppression = new( "IDE0052" );


    // Entry point of the aspect.
    public override void BuildAspect( IAspectBuilder<IMethod> builder )
    {
        // We must call the base implementation, otherwise the target method will not be overridden.
        base.BuildAspect( builder );

        // Validate that we have a proper _logger field.
        var loggerField = builder.Target.DeclaringType.Fields.OfName( "_logger" ).SingleOrDefault();
        if ( loggerField == null || !loggerField.Type.Is( typeof( TextWriter ) ) || loggerField.IsStatic )
        {
            // Report the error.
            builder.Diagnostics.Report( _loggerFieldNotFoundError.WithArguments( (builder.Target.DeclaringType, builder.Target) ), builder.Target.DeclaringType );

            // Do not apply the aspect.
            builder.SkipAspect();

            return;
        }

        // Suppresses IDE0052 from the _logger field.
        builder.Diagnostics.Suppress( _loggerFieldNotUsedSuppression, loggerField );
    }

    // Defines the eligibility of the aspect. This method is pseudo-static. It is called once per compilation.
    public override void BuildEligibility( IEligibilityBuilder<IMethod> builder )
    {
        base.BuildEligibility( builder );
        builder.MustNotBeStatic();
    }

    // Template that overrides the methods to which the aspect is applied.
    public override dynamic? OverrideMethod()
    {
        // `meta.This` is a dynamic object and compiles into `this`. Anything on the right side is resolved at compile time
        // in the context of the target type.

        meta.This._logger.WriteLine( $"Entering {meta.Target.Method}." );

        try
        {
            return meta.Proceed();
        }
        finally
        {
            meta.This._logger.WriteLine( $"Leaving {meta.Target.Method}." );
        }
    }
}
