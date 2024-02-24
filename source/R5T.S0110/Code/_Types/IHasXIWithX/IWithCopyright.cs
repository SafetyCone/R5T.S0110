using System;

using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithCopyright : IWithXMarker,
        IHasCopyright
    {
        new string Copyright { get; set; }
    }
}
