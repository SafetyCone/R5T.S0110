using System;

using R5T.T0221;


namespace R5T.S0110.Contexts
{
    public static partial class ContextExtensions
    {
        public static TContext Get_Context<TContextSet, TContext>(this TContextSet contextSet)
            where TContextSet : IHasContext<TContext>
        {
            var output = (contextSet as IHasContext<TContext>).Context;
            return output;
        }

        public static TContext Get_Context<TContextSet, TContext>(this TContextSet contextSet,
#pragma warning disable IDE0060 // Remove unused parameter
            TypeSpecifier<TContext> typeSpecifier)
#pragma warning restore IDE0060 // Remove unused parameter
            where TContextSet : IHasContext<TContext>
        {
            var output = (contextSet as IHasContext<TContext>).Context;
            return output;
        }
    }
}
