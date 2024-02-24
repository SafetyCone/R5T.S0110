using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a NuGet package license expression.
    /// </summary>
    [WithXMarker]
    public interface IWithPackageLicenseExpression : IWithXMarker,
        IHasPackageLicenseExpression
    {
        new string PackageLicenseExpression { get; set; }
    }
}
