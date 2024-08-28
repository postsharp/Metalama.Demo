using Metalama.Extensions.Architecture;
using Metalama.Extensions.Architecture.Predicates;
using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;
using NamespaceInternalDemo.InternalNamespace;

namespace NamespaceInternalDemo
{
    namespace InternalNamespace
    {
        class Fabric : NamespaceFabric
        {
            public override void AmendNamespace( INamespaceAmender amender )
            {
                amender
                    .InternalsCanOnlyBeUsedFrom( 
                        from => from.CurrentNamespace().Or().AnyTest() );
            }

        }

        internal static class InternalClass
        {
            public static void A() { }
        }

        public static class PublicClass
        {
            public static void B() => InternalClass.A();

        }
    }

    class Program
    {
        public static void Main()
        {
            // Use of InternalClass forbidden here.
            InternalClass.A();

            PublicClass.B();
        }
    }

    namespace Tests
    {
        public static class SomeTest
        {
            // Use of InternalClass allowed in a test.
            public static void B() => InternalClass.A();

        }
    }

  

}