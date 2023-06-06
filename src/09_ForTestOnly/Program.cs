using Metalama.Extensions.Architecture.Aspects;

namespace Foo
{
    class Program
    {
      
   
        static void Main()
        {
            // This call to SomeTestMethod is FORBIDDEN because we are not in a test namespace.
            new Foo( true );
        }
    }

    class Foo
    {
        public bool IsTest { get; }

        [CanOnlyBeUsedFrom( Namespaces = new[] { "**.Tests.**" } )]
        public Foo( bool isTest )
        {
            this.IsTest = isTest;
        }

        public Foo() { }

    }

    namespace Tests
    {
        class Bar
        {
            void M()
            {
                // This call to SomeTestMethod is ALLOWED because we are not in a test namespace.
                new Foo( true );
            }
        }
    }

}