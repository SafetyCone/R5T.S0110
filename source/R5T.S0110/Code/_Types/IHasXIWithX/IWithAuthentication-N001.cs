using System;

using R5T.T0144;
using R5T.T0240;


namespace R5T.S0110.N001
{
    [WithXMarker]
    public interface IWithAuthentication : IWithXMarker,
        IHasAuthentication
    {
        new Authentication Authentication { get; set; }
    }
}
