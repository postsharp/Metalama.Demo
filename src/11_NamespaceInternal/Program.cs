using Foo.InternalNamespace;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;
using Metalama.Framework.Fabrics;
using Metalama.Framework.Validation;
using Metalama.Extensions.Architecture.Fabrics;
using Metalama.Extensions.Architecture.Predicates;

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

            public override void AmendNamespace( INamespaceAmender amender )
            {
                amender.Verify().InternalsCannotBeUsedFrom( x => x.CurrentNamespace() );
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