using System;


namespace R5T.S0110.Contexts
{
    public static class ContextSetTypesPairSpecificationExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContext>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            TypeSpecifier<TContext> contextTypeSpecifier)
            where TContextSet :
            IWithContext<TContext>
            where TParentContextSet :
            IHasContext<TContext>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContext>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            TypeSpecifier<TContextA> contextTypeASpecifier,
            TypeSpecifier<TContextB> contextTypeBSpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB, TContextC>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            TypeSpecifier<TContextA> contextTypeASpecifier,
            TypeSpecifier<TContextB> contextTypeBSpecifier,
            TypeSpecifier<TContextC> contextTypeCSpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB, TContextC>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB, TContextC, TContextD>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            TypeSpecifier<TContextA> contextTypeASpecifier,
            TypeSpecifier<TContextB> contextTypeBSpecifier,
            TypeSpecifier<TContextC> contextTypeCSpecifier,
            TypeSpecifier<TContextD> contextTypeDSpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB, TContextC, TContextD>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB, TContextC, TContextD, TContextE>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            TypeSpecifier<TContextA> contextTypeASpecifier,
            TypeSpecifier<TContextB> contextTypeBSpecifier,
            TypeSpecifier<TContextC> contextTypeCSpecifier,
            TypeSpecifier<TContextD> contextTypeDSpecifier,
            TypeSpecifier<TContextE> contextTypeESpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>,
            IWithContext<TContextE>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>,
            IHasContext<TContextE>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB, TContextC, TContextD, TContextE>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContext>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            ContextSetContextTypesSpecifier<TContext> contextSetContextTypesSpecifier)
            where TContextSet :
            IWithContext<TContext>
            where TParentContextSet :
            IHasContext<TContext>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContext>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            ContextSetContextTypesSpecifier<TContextA, TContextB> contextSetContextTypesSpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB>();

        public static IDirectionalIsomorphism<TParentContextSet, TContextSet> For_Contexts<TParentContextSet, TContextSet, TContextA, TContextB, TContextC>(
            this ContextSetTypesPairSpecification<TParentContextSet, TContextSet> contextSetTypesPairSpecification,
            ContextSetContextTypesSpecifier<TContextA, TContextB, TContextC> contextSetContextTypesSpecifier)
            where TContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>
            where TParentContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
            => Instances.ContextSetIsomorphisms.From_ContextSet<TParentContextSet, TContextSet, TContextA, TContextB, TContextC>();

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
