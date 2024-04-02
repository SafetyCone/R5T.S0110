using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasCodeFileContext<TCodeFileContextContext> : IHasXMarker
    {
        TCodeFileContextContext CodeFileContext { get; }
    }


    [WithXMarker]
    public interface IWithCodeFileContext<TCodeFileContextSetContext> : IWithXMarker,
        IHasCodeFileContext<TCodeFileContextSetContext>
    {
        new TCodeFileContextSetContext CodeFileContext { get; set; }
    }
}
