using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a NuGet package require license acceptance.
    /// </summary>
    [HasXMarker]
    public interface IHasPackageRequireLicenseAcceptance : IHasXMarker
    {
        bool PackageRequireLicenseAcceptance { get; }
    }
}
