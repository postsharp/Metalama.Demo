using Metalama.Extensions.Architecture.Aspects;
using Metalama.Framework.Aspects;

namespace ForTestOnlyDemo
{
    [CompileTime]
    internal class ForTestOnlyAttribute : CanOnlyBeUsedFromAttribute
    {
        public ForTestOnlyAttribute() 
        {
            this.Namespaces = ["**.Tests.**"];
        }
    }
}
