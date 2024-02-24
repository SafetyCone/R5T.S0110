using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a Visual Studio project options value.
    /// </summary>
    [HasXMarker]
    public interface IHasProjectOptions : IHasXMarker
    {
        ProjectOptions ProjectOptions { get; }
    }
}
