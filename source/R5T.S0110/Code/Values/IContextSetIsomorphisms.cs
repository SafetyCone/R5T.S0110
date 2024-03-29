using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IContextSetIsomorphisms : IValuesMarker
    {
        public IDirectionalIsomorphism<TParentContextSet, TContextSet> For<TParentContextSet, TContextSet>(
            ContextSetContextTypesSpecifier<Context000, Context001> contextSetContextTypesSpecifier)
            where TParentContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>
            where TContextSet :
            IWithContext<Context000>,
            IWithContext<Context001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TParentContextSet, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TParentContextSet, TContextSet, Context000, Context001>);

            return output;
        }

        public ContextSetTypesPairSpecification<TSourceContextSet, TDestinationContextSetB> For_ContextSets<TSourceContextSet, TDestinationContextSetB>()
            => ContextSetTypesPairSpecification<TSourceContextSet, TDestinationContextSetB>.Instance;

        public IDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet> From_ContextSet<TSourceContextSet, TDestinationContextSet,
            TContextA
            >()
            where TDestinationContextSet :
            IWithContext<TContextA>
            where TSourceContextSet :
            IHasContext<TContextA>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TSourceContextSet, TDestinationContextSet,
                TContextA
                >);

            return output;
        }

        public IDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet> From_ContextSet<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB
            >()
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TSourceContextSet, TDestinationContextSet,
                TContextA,
                TContextB
                >);

            return output;
        }

        public IDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet> From_ContextSet<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC
            >()
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TSourceContextSet, TDestinationContextSet,
                TContextA,
                TContextB,
                TContextC
                >);

            return output;
        }

        public IDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet> From_ContextSet<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC,
            TContextD
            >()
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TSourceContextSet, TDestinationContextSet,
                TContextA,
                TContextB,
                TContextC,
                TContextD
                >);

            return output;
        }

        public IDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet> From_ContextSet<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC,
            TContextD,
            TContextE
            >()
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>,
            IWithContext<TContextE>
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>,
            IHasContext<TContextE>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TSourceContextSet, TDestinationContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<TSourceContextSet, TDestinationContextSet,
                TContextA,
                TContextB,
                TContextC,
                TContextD,
                TContextE
                >);

            return output;
        }

        public IDirectionalIsomorphism<ContextSet001, TContextSet> From_ContextSet001<TContextSet>()
            where TContextSet :
            IWithContext<Context000>
        {
            var output = new FunctionBasedDirectionalIsomorphism<ContextSet001, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<ContextSet001, TContextSet, Context000>);

            return output;
        }

        public IDirectionalIsomorphism<ContextSet002, TContextSet> From_ContextSet002<TContextSet>()
            where TContextSet :
            IWithContext<Context000>,
            IWithContext<Context001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<ContextSet002, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<ContextSet002, TContextSet, Context000, Context001>);

            return output;
        }

        public IDirectionalIsomorphism<ContextSet003, TContextSet> From_ContextSet003<TContextSet>()
            where TContextSet :
            IWithContext<Context000>,
            IWithContext<Context001>,
            IWithContext<SingleProjectSolutionSetContext>
        {
            var output = new FunctionBasedDirectionalIsomorphism<ContextSet003, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<ContextSet003, TContextSet, Context000, Context001, SingleProjectSolutionSetContext>);

            return output;
        }

        public IDirectionalIsomorphism<ContextSet004, TContextSet> From_ContextSet004<TContextSet>()
            where TContextSet :
            IWithContext<Context000>,
            IWithContext<Context001>,
            IWithContext<SingleProjectSolutionSetContext>,
            IWithContext<ProjectContext001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<ContextSet004, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<ContextSet004, TContextSet, Context000, Context001, SingleProjectSolutionSetContext, ProjectContext001>);

            return output;
        }

        public IDirectionalIsomorphism<TContextSet, ContextSet004> To_ContextSet004<TContextSet>()
            where TContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>,
            IHasContext<SingleProjectSolutionSetContext>,
            IHasContext<ProjectContext001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TContextSet, ContextSet004>(
                Instances.ContextSetOperator.Copy_Contexts<TContextSet, ContextSet004, Context000, Context001, SingleProjectSolutionSetContext, ProjectContext001>);

            return output;
        }

        public IDirectionalIsomorphism<TContextSet, ContextSet004> To_ContextSet004<TContextSet>(
            ContextSetContextTypesSpecifier<Context000, Context001, ProjectContext001> contextSetContextTypesSpecifier)
            where TContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>,
            IHasContext<ProjectContext001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TContextSet, ContextSet004>(
                Instances.ContextSetOperator.Copy_Contexts<TContextSet, ContextSet004, Context000, Context001, ProjectContext001>);

            return output;
        }

        public IDirectionalIsomorphism<ContextSet005, TContextSet> From_ContextSet005<TContextSet>()
            where TContextSet :
            IWithContext<Context000>,
            IWithContext<Context001>,
            IWithContext<SingleProjectSolutionSetContext>,
            IWithContext<ProjectContext001>,
            IWithContext<Context005>
        {
            var output = new FunctionBasedDirectionalIsomorphism<ContextSet005, TContextSet>(
                Instances.ContextSetOperator.Copy_Contexts<ContextSet005, TContextSet, Context000, Context001, SingleProjectSolutionSetContext, ProjectContext001, Context005>);

            return output;
        }

        public IDirectionalIsomorphism<TContextSet, ContextSet005> To_ContextSet005<TContextSet>()
            where TContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>,
            IHasContext<SingleProjectSolutionSetContext>,
            IHasContext<ProjectContext001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TContextSet, ContextSet005>(
                Instances.ContextSetOperator.Copy_Contexts<TContextSet, ContextSet005, Context000, Context001, SingleProjectSolutionSetContext, ProjectContext001>);

            return output;
        }

        public IDirectionalIsomorphism<TContextSet, ContextSet005> To_ContextSet005<TContextSet>(
            ContextSetContextTypesSpecifier<Context000, Context001, ProjectContext001> contextSetContextTypesSpecifier)
            where TContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>,
            IHasContext<ProjectContext001>
        {
            var output = new FunctionBasedDirectionalIsomorphism<TContextSet, ContextSet005>(
                Instances.ContextSetOperator.Copy_Contexts<TContextSet, ContextSet005, Context000, Context001, ProjectContext001>);

            return output;
        }
    }
}
