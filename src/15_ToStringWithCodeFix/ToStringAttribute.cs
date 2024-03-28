// This is an open-source Metalama example. See https://github.com/postsharp/Metalama.Samples for more.

using System.Linq;
using System.Threading.Tasks;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using Metalama.Framework.CodeFixes;

public class ToStringAttribute : TypeAspect
{
    public override void BuildAspect( IAspectBuilder<INamedType> builder )
    {
        base.BuildAspect( builder );

        // For each field, suggest a code fix to remove from ToString.
        foreach ( var field in builder.Target.FieldsAndProperties.Where( f => !f.IsStatic ) )
        {
            if ( !field.Attributes.Any( a => a.Type.Is( typeof( NotToStringAttribute ) ) ) )
            {
                builder.Diagnostics.Suggest( CodeFixFactory.AddAttribute( field, typeof( NotToStringAttribute ), "Exclude from [ToString]" ), field );
            }
        }

        // Suggest to switch to manual implementation.
        if ( builder.AspectInstance.Predecessors[0].Instance is IAttribute attribute )
        {
            builder.Diagnostics.Suggest(
                new CodeFix( "Switch [ToString] to manual implementation", codeFixBuilder => this.ImplementManually( codeFixBuilder, builder.Target ) ),
                builder.Target );
        }
    }

    /// <summary>
    /// Implementation of the "Switch [ToString] to manual implementation" code action.
    /// </summary>
    [CompileTime]
    private async Task ImplementManually( ICodeActionBuilder builder, INamedType targetType )
    {
        await builder.ApplyAspectAsync( targetType, this );
        await builder.RemoveAttributesAsync( targetType, typeof( ToStringAttribute ) );
        await builder.RemoveAttributesAsync( targetType, typeof( NotToStringAttribute ) );
    }

    /// <summary>
    /// Template for the ToString method.
    /// </summary>
    [Introduce( WhenExists = OverrideStrategy.Override, Name = "ToString" )]
    public string IntroducedToString()
    {
        // Get the fields and properties that must be included in ToString.
        var fields = meta.Target.Type.FieldsAndProperties.Where( f => !f.IsStatic && !f.IsImplicitlyDeclared && !f.Attributes.Any( a => a.Type.Is( typeof( NotToStringAttribute ) ) ) ).ToList();

        // Build an interpolated string.
        var stringBuilder = new InterpolatedStringBuilder();
        stringBuilder.AddText( "{ " );
        stringBuilder.AddText( meta.Target.Type.Name );
        stringBuilder.AddText( " " );

        var i = meta.CompileTime( 0 );

        foreach ( var field in fields )
        {
            if ( i > 0 )
            {
                stringBuilder.AddText( ", " );
            }

            stringBuilder.AddText( field.Name );
            stringBuilder.AddText( "=" );
            stringBuilder.AddExpression( field);

            i++;
        }

        stringBuilder.AddText( " }" );

        return stringBuilder.ToValue();
    }
}
