using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IContextSetOperator : IFunctionalityMarker
    {
        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContext>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContext>
            where TDestinationContextSet :
            IWithContext<TContext>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContext>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextA>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextB>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextA>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextB>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextC>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC,
            TContextD>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextA>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextB>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextC>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextD>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC,
            TContextD,
            TContextE>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>,
            IHasContext<TContextE>
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>,
            IWithContext<TContextE>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextA>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextB>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextC>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextD>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextE>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public Task Copy_Contexts<TSourceContextSet, TDestinationContextSet,
            TContextA,
            TContextB,
            TContextC,
            TContextD,
            TContextE,
            TContextF>
            (TSourceContextSet sourceContextSet, TDestinationContextSet destinationContextSet)
            where TSourceContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>,
            IHasContext<TContextD>,
            IHasContext<TContextE>,
            IHasContext<TContextF>
            where TDestinationContextSet :
            IWithContext<TContextA>,
            IWithContext<TContextB>,
            IWithContext<TContextC>,
            IWithContext<TContextD>,
            IWithContext<TContextE>,
            IWithContext<TContextF>
        {
            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextA>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextB>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextC>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextD>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextE>(
                sourceContextSet,
                destinationContextSet);

            this.Copy_Context<TSourceContextSet, TDestinationContextSet, TContextF>(
                sourceContextSet,
                destinationContextSet);

            return Task.CompletedTask;
        }

        public void Copy_Context<TSourceContextSet, TContextSet, TContext>(
            TSourceContextSet sourceContextSet,
            TContextSet contextSet)
            where TSourceContextSet : IHasContext<TContext>
            where TContextSet : IWithContext<TContext>
        {
            contextSet.Context = sourceContextSet.Context;
        }

        public void Copy_Context<TSourceContextSet, TContextSet, TContext>(
            TSourceContextSet sourceContextSet,
            TContextSet contextSet,
            TypeSpecifier<TContext> contextTypeSpecifier)
            where TSourceContextSet : IHasContext<TContext>
            where TContextSet : IWithContext<TContext>
        {
            contextSet.Context = sourceContextSet.Context;
        }
    }
}
