using Metalama.Extensions.Architecture.Predicates;
using Metalama.Framework.Aspects;

namespace NamespaceInternalDemo;

[CompileTime]
public static class ArchitectureExtensions
{
    public static ReferencePredicate AnyTest( this ReferencePredicateBuilder builder )
        => builder.Type( "**.Tests.**" );
}