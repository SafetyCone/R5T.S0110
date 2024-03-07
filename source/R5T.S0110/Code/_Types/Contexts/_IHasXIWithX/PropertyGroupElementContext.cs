using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasPropertyGroupElementContext<TPropertyGroupElementContext> : IHasXMarker
    {
        TPropertyGroupElementContext PropertyGroupElementContext { get; }
    }


    [WithXMarker]
    public interface IWithPropertyGroupElementContext<TPropertyGroupElementContext> : IWithXMarker,
        IHasPropertyGroupElementContext<TPropertyGroupElementContext>
    {
        new TPropertyGroupElementContext PropertyGroupElementContext { get; set; }
    }
}
