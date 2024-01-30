using System;

using R5T.L0085;
using R5T.T0142;
using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker, DataTypeMarker]
    public interface IHasAuthentication : IHasX<T0144.Authentication>
    {
        T0144.Authentication Authentication { get; }
    }
}
