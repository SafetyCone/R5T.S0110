using System;

using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithContext<TContext> : IWithXMarker,
        IHasContext<TContext>
    {
        new TContext Context { get; set; }
    }
}
