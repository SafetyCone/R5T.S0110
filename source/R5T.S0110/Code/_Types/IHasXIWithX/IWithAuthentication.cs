using System;

using R5T.L0085;
using R5T.T0142;
using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker, DataTypeMarker]
    public interface IWithAuthentication : IWithX<T0144.Authentication>,
        IHasAuthentication
    {
        new T0144.Authentication Authentication { get; set; }
    }
}
