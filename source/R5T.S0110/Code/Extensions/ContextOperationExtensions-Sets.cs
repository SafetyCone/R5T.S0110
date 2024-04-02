using System;
using System.Threading.Tasks;


namespace R5T.S0110.Contexts
{
    public static partial class ContextOperationExtensions
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning restore IDE0079 // Remove unnecessary suppression

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

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
