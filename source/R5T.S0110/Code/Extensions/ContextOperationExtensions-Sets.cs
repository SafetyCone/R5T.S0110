using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static Func<TContextSet, TContext, Task> In_ContextSetAndContext<TContextSet, TChildContextSet, TContext>(this Func<TChildContextSet, Task> operation,
            IDirectionalIsomorphism<TContextSet, TChildContextSet> contextSetIsomorphism,
            TypeSpecifier<TContext> contextSpecifier)
            where TChildContextSet : new()
        {
            return (contextSet, _) =>
            {
                return Instances.ContextOperator.In_ChildContextSet(
                    contextSet,
                    contextSetIsomorphism,
                    operation);
            };
        }     

        public static Func<TContextSet, TContext, Task> In_ContextSetAndContext<TContextSet, TContext>(this Func<TContextSet, Task> operation,
            TypeSpecifier<TContext> contextSpecifier)
            where TContextSet : IHasContext<TContext>
        {
            return (contextSet, _) => operation(contextSet);
        }

        public static Func<TContextSet, TContext, Task> In_ContextSetAndContext<TContextSet, TContext>(this Func<TContext, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContext>
        {
            return (contextSet, context) => operation(context);
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndDifferentContext<TContextSet, TContextA, TContextB>(this Func<TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, _) => operation(
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContext>(this Func<TContext, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContext>
        {
            return contextSet => operation(contextSet.Context);
        }

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return contextSet => operation(
                contextSet.Get_Context<TContextSet, TContextA>(),
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return contextSet => operation(
                contextSet.Get_Context<TContextSet, TContextA>(),
                contextSet.Get_Context<TContextSet, TContextB>());
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
