using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasContext<TContext> : IHasXMarker
    {
        TContext Context { get; }
    }
}
