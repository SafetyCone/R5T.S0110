using System;

using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithCompany : IWithXMarker,
        IHasCompany
    {
        new string Company { get; set; }
    }
}
