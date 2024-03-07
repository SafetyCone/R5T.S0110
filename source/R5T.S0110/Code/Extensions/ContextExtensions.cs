using System;

using R5T.T0221;


namespace R5T.S0110.Contexts
{
    public static partial class ContextExtensions
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public static ContextPropertiesSet<TContext, IsSet<T1>> For<TContext, T1>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1)
        {
            return new ContextPropertiesSet<TContext, IsSet<T1>>
            {
                PropertiesSet = isSet1,
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>)> For<TContext, T1, T2>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>)>
            {
                PropertiesSet = (isSet1, isSet2),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>)> For<TContext, T1, T2, T3>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>)> For<TContext, T1, T2, T3, T4>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3,
            IsSet<T4> isSet4)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3, isSet4),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>)> For<TContext, T1, T2, T3, T4, T5>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3,
            IsSet<T4> isSet4,
            IsSet<T5> isSet5)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3, isSet4, isSet5),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>)> For<TContext, T1, T2, T3, T4, T5, T6>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3,
            IsSet<T4> isSet4,
            IsSet<T5> isSet5,
            IsSet<T6> isSet6)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3, isSet4, isSet5, isSet6),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>, IsSet<T7>)> For<TContext, T1, T2, T3, T4, T5, T6, T7>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3,
            IsSet<T4> isSet4,
            IsSet<T5> isSet5,
            IsSet<T6> isSet6,
            IsSet<T7> isSet7)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>, IsSet<T7>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3, isSet4, isSet5, isSet6, isSet7),
            };
        }

        public static ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>, IsSet<T7>, IsSet<T8>)> For<TContext, T1, T2, T3, T4, T5, T6, T7, T8>(this ContextPropertiesSet<TContext> contextPropertiesSet,
            IsSet<T1> isSet1,
            IsSet<T2> isSet2,
            IsSet<T3> isSet3,
            IsSet<T4> isSet4,
            IsSet<T5> isSet5,
            IsSet<T6> isSet6,
            IsSet<T7> isSet7,
            IsSet<T8> isSet8)
        {
            return new ContextPropertiesSet<TContext, (IsSet<T1>, IsSet<T2>, IsSet<T3>, IsSet<T4>, IsSet<T5>, IsSet<T6>, IsSet<T7>, IsSet<T8>)>
            {
                PropertiesSet = (isSet1, isSet2, isSet3, isSet4, isSet5, isSet6, isSet7, isSet8),
            };
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
