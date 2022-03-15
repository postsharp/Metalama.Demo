namespace Foo
{
    class Program
    {
        [ForTestOnly]
        public static void SomeTestMethod()
        {
            // Some very typical business code.
            Console.WriteLine( "Hello, World!" );
        }

        static void Main()
        {
            // This call to SomeTestMethod is FORBIDDEN because we are not in a test namespace.
            SomeTestMethod();
        }
    }

    namespace Tests
    {
        class Bar
        {
            void M()
            {
                // This call to SomeTestMethod is ALLOWED because we are not in a test namespace.
                Program.SomeTestMethod();
            }
        }
    }

}