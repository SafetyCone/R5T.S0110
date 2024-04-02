using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning restore IDE0079 // Remove unnecessary suppression

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB, TContextC, TContextD>(this Func<TContextA, TContextB, TContextC, TContextD, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>, IHasContext<TContextB>, IHasContext<TContextC>, IHasContext<TContextD>
        {
            return (contextSet, contextA) => operation(
                contextA,
                contextSet.Get_Context<TContextSet, TContextB>(),
                contextSet.Get_Context<TContextSet, TContextC>(),
                contextSet.Get_Context<TContextSet, TContextD>());
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA, TContextB, TContextC, TContextD>(this Func<TContextA, TContextB, TContextC, TContextD, Task> operation,
            TypeAdapter<TContextSet, TContextA, TContextB, TContextC, TContextD> contextSetAdapter)
        {
            return (contextSet, contextA) =>
            {
                var contextB = contextSetAdapter.Get_T2(contextSet);
                var contextC = contextSetAdapter.Get_T3(contextSet);
                var contextD = contextSetAdapter.Get_T4(contextSet);

                return operation(
                    contextA,
                    contextB,
                    contextC,
                    contextD);
            };
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
