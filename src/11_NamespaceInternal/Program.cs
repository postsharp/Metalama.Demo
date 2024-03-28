using Foo.InternalNamespace;
using Metalama.Framework.Fabrics;
using Metalama.Extensions.Architecture.Fabrics;
using Metalama.Extensions.Architecture.Predicates;
using Metalama.Framework.Code;

namespace Foo
{
    namespace InternalNamespace
    {
        class Fabric : NamespaceFabric
        {
            public override void AmendNamespace( INamespaceAmender amender )
            {
                amender.Verify()
                    .InternalsCanOnlyBeUsedFrom( from => from
                        .CurrentNamespace()
                        .Or( or => or.AnyTest() ) 
                        .Or( or => or.TypeKind( TypeKind.Struct, TypeKind.RecordStruct ) ));
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