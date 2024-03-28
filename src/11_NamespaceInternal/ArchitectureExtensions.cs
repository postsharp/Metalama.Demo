using Metalama.Extensions.Architecture.Predicates;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Validation;

namespace Foo;

[CompileTime]
public static class ArchitectureExtensions
{
    public static ReferencePredicate AnyTest( this ReferencePredicateBuilder builder )
        => builder.Type( "**.Tests.**" );

    public static ReferencePredicate TypeKind( this ReferencePredicateBuilder builder, params TypeKind[] typeKinds )
        => new TypeKindPredicate( typeKinds );


    class TypeKindPredicate : ReferencePredicate
    {
        private readonly TypeKind[] _typeKinds;

        public TypeKindPredicate( TypeKind[] typeKinds )
        {
            this._typeKinds = typeKinds;
        }


        public override bool IsMatch( in ReferenceValidationContext context ) =>
            Array.IndexOf( this._typeKinds, context.ReferencingType.TypeKind ) >= 0;
    }
}