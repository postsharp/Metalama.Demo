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

    public static ReferencePredicate TypeKind( this ReferencePredicateBuilder builder, params TypeKind[] typeKinds )
        => new TypeKindPredicate( builder, typeKinds );


    class TypeKindPredicate : ReferencePredicate
    {
        private readonly TypeKind[] _typeKinds;

        public TypeKindPredicate( ReferencePredicateBuilder builder, TypeKind[] typeKinds ) : base( builder )
        {
            this._typeKinds = typeKinds;
        }

        public override ReferenceGranularity Granularity => ReferenceGranularity.Type;

         

        protected override bool IsMatchCore( ReferenceValidationContext context )
         => Array.IndexOf( this._typeKinds, context.Origin.Type.TypeKind ) >= 0;
    }
}