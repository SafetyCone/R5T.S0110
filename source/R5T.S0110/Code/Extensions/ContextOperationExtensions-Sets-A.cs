using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning restore IDE0079 // Remove unnecessary suppression

        public static Func<TContextSet, Task> In_ContextSet<TContextSet, TContextA>(this Func<TContextA, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>
        {
            return contextSet => operation(contextSet.Context);
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA>(this Func<TContextSet, Task> operation,
            TypeSpecifier<TContextA> contextSpecifier)
        {
            return (contextSet, _) => operation(contextSet);
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext_A<TContextSet, TContextA>(this Func<TContextSet, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
        {
            return (contextSet, _) => operation(contextSet);
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetAndContext<TContextSet, TContextA>(this Func<TContextSet, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextSpecifier)
            => operation.In_ContextSetAndContext_A<TContextSet, TContextA>(
                contextSetSpecifier,
                contextSpecifier);

        public static Func<TContextSet, TContextA, Task> In_ContextSetWithContext<TContextSet, TContextA>(this Func<TContextSet, Task> operation,
            TypeSpecifier<TContextA> contextSpecifier)
            where TContextSet : IHasContext<TContextA>
        {
            return (contextSet, _) => operation(contextSet);
        }

        public static Func<TContextSet, TContextA, Task> In_ContextSetWithContext<TContextSet, TContextA>(this Func<TContextA, Task> operation,
            ContextSetSpecifier<TContextSet> contextSetSpecifier)
            where TContextSet : IHasContext<TContextA>
        {
            return (contextSet, context) => operation(context);
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
