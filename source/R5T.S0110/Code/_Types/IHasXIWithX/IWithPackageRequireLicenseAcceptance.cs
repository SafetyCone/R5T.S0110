using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a NuGet package require license acceptance.
    /// </summary>
    [WithXMarker]
    public interface IWithPackageRequireLicenseAcceptance : IWithXMarker,
        IHasPackageRequireLicenseAcceptance
    {
        new bool PackageRequireLicenseAcceptance { get; set; }
    }
}
