using System;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IContextOperator : IFunctionalityMarker,
        L0066.IContextOperator
    {
        public ContextPropertiesSet<TContext> Get_ContextPropertiesSet<TContext>() => null;
    }
}
