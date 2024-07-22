using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;

namespace LogDemo2;

class LogAttribute : OverrideMethodAspect
{
    public override dynamic? OverrideMethod()
    {
        // Build an interpolated string that contains all parameters.
        var stringBuilder = new InterpolatedStringBuilder();
        stringBuilder.AddText( meta.Target.Method.DeclaringType.Name );
        stringBuilder.AddText( "." );
        stringBuilder.AddText( meta.Target.Method.Name );
        stringBuilder.AddText( "( " );

        foreach ( var parameter in meta.Target.Parameters )
        {
            if ( parameter.Index > 0 )
            {
                stringBuilder.AddText( ", " );
            }

            stringBuilder.AddText( parameter.Name );
            stringBuilder.AddText( " = " );

            if ( parameter.RefKind != RefKind.Out )
            {
                stringBuilder.AddExpression( parameter.Value );
            }
            else
            {
                stringBuilder.AddText( "<out>" );
            }
            
        }

        stringBuilder.AddText( " )" );

        // Run-time code template.
        Console.WriteLine( "Entering " + stringBuilder.ToValue() );
        try
        {
            return meta.Proceed();
        }
        finally
        {
            Console.WriteLine( "Leaving " + stringBuilder.ToValue() );
        }
    }
}