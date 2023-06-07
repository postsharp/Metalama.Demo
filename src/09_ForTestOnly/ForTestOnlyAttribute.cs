using Metalama.Extensions.Architecture.Aspects;
using Metalama.Framework.Aspects;

namespace Demo1
{
    [CompileTime]
    internal class ForTestOnlyAttribute : CanOnlyBeUsedFromAttribute
    {
        public ForTestOnlyAttribute() 
        {
            this.Namespaces = new[] { "**.Tests.**" };
        }
    }
}
