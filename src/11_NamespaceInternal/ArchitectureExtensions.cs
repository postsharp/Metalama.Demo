using Metalama.Extensions.Architecture.Predicates;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Validation;

namespace NamespaceInternalDemo;

[CompileTime]
public static class ArchitectureExtensions
{
    public static ReferencePredicate AnyTest( this ReferencePredicateBuilder builder )
        => builder.Type( "**.Tests.**" );
}