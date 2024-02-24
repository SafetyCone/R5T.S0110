using System;

using R5T.T0221;


namespace R5T.S0110.Contexts
{
    public static class ContextExtensions
    {
        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>)> For<TContext, T1, T2>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>)>
            {
                PropertiesSet = (isSet1, isSet2),
            };
        }
    }
}
