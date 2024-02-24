using System;

using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithNuGetAuthor : IWithXMarker,
        IHasNuGetAuthor
    {
        new string NuGetAuthor { get; set; }
    }
}
