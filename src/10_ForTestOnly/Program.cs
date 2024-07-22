namespace ForTestOnlyDemo
{
    class Program
    {
      
   
        static void Main()
        {
            // These calls to SomeTestMethod is FORBIDDEN because we are not in a test namespace.
            _ = new Foo( true );
            _ = new Foo( "Jane", true );
        }
    }

    class Foo
    {
        public string Name { get; }
        public bool IsTest { get; }

        [ForTestOnly]
        public Foo( string name, bool isTest )
        {
            this.IsTest = isTest;
            this.Name = name;
        }

        [ForTestOnly]
        public Foo( bool isTest ) : this( "default", isTest ) { }

        public Foo( string name = "default" ) : this( false ) { }

    }

    namespace Tests
    {
        class Bar
        {
            void M()
            {
                // This call to SomeTestMethod is ALLOWED because we are not in a test namespace.
                _ = new Foo( true );
            }
        }
    }

}