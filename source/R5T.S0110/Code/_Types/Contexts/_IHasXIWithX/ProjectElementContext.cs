using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasProjectElementContext<TProjectElementContext> : IHasXMarker
    {
        TProjectElementContext ProjectElementContext { get; }
    }


    [WithXMarker]
    public interface IWithProjectElementContext<TProjectElementContext> : IWithXMarker,
        IHasProjectElementContext<TProjectElementContext>
    {
        new TProjectElementContext ProjectElementContext { get; set; }
    }
}
