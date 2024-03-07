using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasItemGroupElementContext<TItemGroupElementContext> : IHasXMarker
    {
        TItemGroupElementContext ItemGroupElementContext { get; }
    }


    [WithXMarker]
    public interface IWithItemGroupElementContext<TItemGroupElementContext> : IWithXMarker,
        IHasItemGroupElementContext<TItemGroupElementContext>
    {
        new TItemGroupElementContext ItemGroupElementContext { get; set; }
    }
}
