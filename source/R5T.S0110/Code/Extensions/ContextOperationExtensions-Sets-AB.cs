using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

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

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            TypeAdapter<TContextSet, TContextA, TContextB> contextSetAdapter)
        {
            return (contextSet, contextA) =>
            {
                var contextB = contextSetAdapter.Get_T2(contextSet);

                return operation(
                    contextA,
                    contextB);
            };
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetWithContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetWithContext_AB<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, _) => operation(
                contextSet.Get_Context<TContextSet, TContextB>());
        }


        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext_AB<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
            => operation.In_ContextSetAndContext_AB<TContextSet, TContextA, TContextB>(
                contextSetSpecifier,
                contextSpecifier);



        public static Func<TContextSet, TContextB, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB>(this Func<TContextA, TContextB, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextB> contextSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>
        {
            return (contextSet, contextB) => operation(
                contextSet.Get_Context<TContextSet, TContextA>(),
                contextB);
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
