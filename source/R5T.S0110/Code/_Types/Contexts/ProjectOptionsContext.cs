using System;

using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker]
    public class ProjectOptionsContext : IContextImplementationMarker,
        IWithProjectOptions,
        IHasCompany,
        IHasCopyright,
        IHasTargetFramework,
        IHasIgnoreWarningNumbersList,
        IHasNuGetAuthor,
        IHasPackageLicenseExpression,
        IHasPackageRequireLicenseAcceptance,
        IHasVersion
    {
        public ProjectOptions ProjectOptions { get; set; }
        public string Company => this.ProjectOptions.Company;
        public string Copyright => this.ProjectOptions.Copyright;
        public string TargetFramework => this.ProjectOptions.TargetFramework;
        public string IgnoreWarningNumbersList => this.ProjectOptions.IgnoreWarningNumbersList;
        public string NuGetAuthor => this.ProjectOptions.NuGetAuthor;
        public string PackageLicenseExpression => this.ProjectOptions.PackageLicenseExpression;
        public bool PackageRequireLicenseAcceptance => this.ProjectOptions.PackageRequireLicenseAcceptance;
        public Version Version => this.ProjectOptions.Version;
    }
}
