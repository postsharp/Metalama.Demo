using Foo.InternalNamespace;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;
using Metalama.Framework.Fabrics;
using Metalama.Framework.Validation;

namespace Foo
{
    class Program
    {
        public static void Main()
        {
            InternalClass.A();

            PublicClass.B();
        }
    }

    namespace InternalNamespace
    {

        class Fabric : NamespaceFabric
        {
            private static readonly DiagnosticDefinition<(IDeclaration, INamespace)> _warning = new(
         "DEMO03",
         Severity.Warning,
         "'{0}' can be used only in the namespace '{1}'." );

            public override void AmendNamespace( INamespaceAmender amender )
            {
                amender.With( c => c.DescendantsAndSelf().SelectMany( ns => ns.Types ) .Where( t => t.Accessibility == Accessibility.Internal ) ).ValidateReferences( this.ValidateReference, ReferenceKinds.All );
            }

            private void ValidateReference( in ReferenceValidationContext context )
            {
                var referencedNamespace = ((INamedType) context.ReferencedDeclaration).Namespace;
                var referencingNamespace = context.ReferencingType.Namespace;

                if ( referencedNamespace != referencingNamespace && !referencingNamespace.IsDescendantOf( referencedNamespace ) )
                {
                    context.Diagnostics.Report( _warning.WithArguments( (context.ReferencedDeclaration, referencedNamespace) ) );
                }
            }
        }

        internal class InternalClass
        {
            public static void A() { }
        }

        public class PublicClass
        {
            public static void B() => InternalClass.A();

        }
    }

  

}