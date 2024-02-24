using System;

using R5T.T0132;
using R5T.T0221;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IIsSetOperator : IFunctionalityMarker,
        T0221.IIsSetOperator
    {
        public ContextPropertiesSet<TContext, IsSet<T>> ContextPropertiesSet<TContext, T>(IsSet<T> set)
            => new()
            {
                PropertiesSet = set
            };
    }
}
