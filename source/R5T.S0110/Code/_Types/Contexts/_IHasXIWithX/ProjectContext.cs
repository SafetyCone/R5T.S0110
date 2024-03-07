using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasProjectContext<TProjectContext> : IHasXMarker
    {
        TProjectContext ProjectContext { get; }
    }


    [WithXMarker]
    public interface IWithProjectContext<TProjectContext> : IWithXMarker,
        IHasProjectContext<TProjectContext>
    {
        new TProjectContext ProjectContext { get; set; }
    }
}
