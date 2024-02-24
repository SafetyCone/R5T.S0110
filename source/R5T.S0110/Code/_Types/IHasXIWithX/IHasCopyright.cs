using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasCopyright : IHasXMarker
    {
        string Copyright { get; }
    }
}
