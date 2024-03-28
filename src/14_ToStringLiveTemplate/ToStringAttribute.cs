﻿// This is an open-source Metalama example. See https://github.com/postsharp/Metalama.Samples for more.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using System.Linq;

[EditorExperience( SuggestAsLiveTemplate = true )]
internal class ToStringAttribute : TypeAspect
{
    [Introduce( WhenExists = OverrideStrategy.Override, Name = "ToString" )]
    public string IntroducedToString()
    {
        var stringBuilder = new InterpolatedStringBuilder();
        stringBuilder.AddText( "{ " );
        stringBuilder.AddText( meta.Target.Type.Name );
        stringBuilder.AddText( " " );

        var fields = meta.Target.Type.FieldsAndProperties.Where( f => !f.IsStatic && !f.IsImplicitlyDeclared ).ToList();

        var i = meta.CompileTime( 0 );

        foreach ( var field in fields )
        {
            if ( i > 0 )
            {
                stringBuilder.AddText( ", " );
            }

            stringBuilder.AddText( field.Name );
            stringBuilder.AddText( "=" );
            stringBuilder.AddExpression( field );

            i++;
        }

        stringBuilder.AddText( " }" );

        return stringBuilder.ToValue();
    }
}
