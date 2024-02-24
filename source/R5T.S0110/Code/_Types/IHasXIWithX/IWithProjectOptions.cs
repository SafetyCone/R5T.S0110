using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a Visual Studio project options value.
    /// </summary>
    [WithXMarker]
    public interface IWithProjectOptions : IWithXMarker,
        IHasProjectOptions
    {
        new ProjectOptions ProjectOptions { get; set; }
    }
}
