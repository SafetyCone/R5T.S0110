using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContextA, TContextB, TContextC>(this Func<TContextA, TContextB, Task> operation,
            AccessorTypeAdapter<TContextSet, TContextA, TContextB, TContextC> typeAdapter)
        {
            return contextSet =>
            {
                var contextA = typeAdapter.Get_T1(contextSet);
                var contextB = typeAdapter.Get_T2(contextSet);

                return operation(contextA, contextB);
            };
        }

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContextA, TContextB, TContextC>(this Func<TContextA, TContextB, TContextC, Task> operation,
            AccessorTypeAdapter<TContextSet, TContextA, TContextB, TContextC> typeAdapter)
        {
            return contextSet =>
            {
                var contextA = typeAdapter.Get_T1(contextSet);
                var contextB = typeAdapter.Get_T2(contextSet);
                var contextC = typeAdapter.Get_T3(contextSet);

                return operation(contextA, contextB, contextC);
            };
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB, TContextC>(this Func<TContextA, TContextB, TContextC, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextB>, IHasContext<TContextC>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>(),
                contextSet.Get_Context<TContextSet, TContextC>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB, TContextC>(this Func<TContextB, TContextC, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextB>, IHasContext<TContextC>
        {
            return (contextSet, _) => operation(
                contextSet.Get_Context<TContextSet, TContextB>(),
                contextSet.Get_Context<TContextSet, TContextC>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext_ABC<TContextSet, TContextA, TContextB, TContextC>(this Func<TContextB, TContextC, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextB>, IHasContext<TContextC>
        {
            return (contextSet, _) => operation(
                contextSet.Get_Context<TContextSet, TContextB>(),
                contextSet.Get_Context<TContextSet, TContextC>());
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
