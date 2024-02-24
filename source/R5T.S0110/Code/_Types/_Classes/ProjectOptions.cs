using System;

using R5T.T0142;


namespace R5T.S0110
{
    [DataTypeMarker]
    public class ProjectOptions : IDataTypeMarker,
        IWithCompany,
        IWithCopyright,
        IWithIgnoreWarningNumbersList,
        IWithNuGetAuthor,
        IWithPackageLicenseExpression,
        IWithPackageRequireLicenseAcceptance,
        IWithTargetFramework,
        IWithVersion
    {
        public string Company { get; set; }
        public string Copyright { get; set; }
        public string IgnoreWarningNumbersList { get; set; }
        public string NuGetAuthor { get; set; }
        public string PackageLicenseExpression { get; set; }
        public bool PackageRequireLicenseAcceptance { get; set; }
        public string TargetFramework { get; set; }
        public Version Version { get; set; }
    }
}
