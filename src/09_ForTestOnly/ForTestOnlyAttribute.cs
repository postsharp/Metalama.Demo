using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;
using Metalama.Framework.Validation;
using System.Diagnostics;

class ForTestOnlyAttribute : Aspect, IAspect<IDeclaration>
{
    private static readonly DiagnosticDefinition<IDeclaration> _warning = new(
        "DEMO02",
        Severity.Warning,
        "'{0}' can be used only in a namespace whose name ends with '.Tests'" );

    public void BuildAspect( IAspectBuilder<IDeclaration> builder )
    {
        builder.With( d => d ).ValidateReferences( this.ValidateReference, ReferenceKinds.All );
    }

    private void ValidateReference( in ReferenceValidationContext context )
    {
        if ( !context.ReferencingType.Namespace.FullName.EndsWith(".Tests"))
        {
            context.Diagnostics.Report( _warning.WithArguments( context.ReferencedDeclaration ) );
        }
    }
}
