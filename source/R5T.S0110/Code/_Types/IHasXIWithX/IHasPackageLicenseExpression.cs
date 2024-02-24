using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a NuGet package license expression.
    /// </summary>
    [HasXMarker]
    public interface IHasPackageLicenseExpression : IHasXMarker
    {
        string PackageLicenseExpression { get; }
    }
}
