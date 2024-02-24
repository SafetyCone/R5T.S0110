using System;


namespace R5T.S0110
{
    public class Instances :
        L0055.Instances
    {
        public static L0066.IActionOperator ActionOperator => L0066.ActionOperator.Instance;
        public static L0033.Z002.IAuthors Authors => L0033.Z002.Authors.Instance;
        public static ICloneRepositoryLocallyContextOperations CloneRepositoryLocallyContextOperations => S0110.CloneRepositoryLocallyContextOperations.Instance;
        public static L0032.Z002.ICompanyNames CompanyNames => L0032.Z002.CompanyNames.Instance;
        public static F0083.ICodeFileGenerationOperations CodeFileGenerationOperations => F0083.CodeFileGenerationOperations.Instance;
        public static ICodeFileContextOperations CodeFileContextOperations => S0110.CodeFileContextOperations.Instance;
        public static ICodeFileContextOperator CodeFileContextOperator => S0110.CodeFileContextOperator.Instance;
        public static ICodeFileGenerationContextOperations CodeFileGenerationContextOperations => S0110.CodeFileGenerationContextOperations.Instance;
        public static ICommitMessages CommitMessages => S0110.CommitMessages.Instance;
        public static IContextOperations ContextOperations => S0110.ContextOperations.Instance;
        public static IContextOperator ContextOperator => S0110.ContextOperator.Instance;
        public static L0071.ICopyrightOperator CopyrightOperator => L0071.CopyrightOperator.Instance;
        public static L0066.IDirectoryNameOperator DirectoryNameOperator => L0066.DirectoryNameOperator.Instance;
        public static IDirectoryNames DirectoryNames => S0110.DirectoryNames.Instance;
        public static L0093.O000.IDirectoryPathContextOperations DirectoryPathContextOperations => L0093.O000.DirectoryPathContextOperations.Instance;
        public static IFileNames FileNames => S0110.FileNames.Instance;
        public static IFilePathContextOperations FilePathContextOperations => S0110.FilePathContextOperations.Instance;
        public static new IFilePaths FilePaths => S0110.FilePaths.Instance;
        public static L0066.IFunctionOperator FunctionOperator => L0066.FunctionOperator.Instance;
        public static L0066.IFunctions Functions => L0066.Functions.Instance;
        public static IGitContextOperations GitContextOperations => S0110.GitContextOperations.Instance;
        public static IGitHubClientContextOperations GitHubClientContextOperations => S0110.GitHubClientContextOperations.Instance;
        public static L0078.F001.IGitHubClientOperator GitHubClientOperator => L0078.F001.GitHubClientOperator.Instance;
        public static IGitHubOperator GitHubOperator => S0110.GitHubOperator.Instance;
        public static L0084.F001.IGitOperator GitOperator => L0084.F001.GitOperator.Instance;
        public static IHasAuthenticationContextOperations HasAuthenticationContextOperations => S0110.HasAuthenticationContextOperations.Instance;
        public static L0093.O000.IHasDirectoryPathContextOperations HasDirectoryPathContextOperations => L0093.O000.HasDirectoryPathContextOperations.Instance;
        public static L0093.O000.IHasFilePathContextOperations HasFilePathContextOperations => L0093.O000.HasFilePathContextOperations.Instance;
        public static L0085.IHasXContextOperations HasXContextOperations => L0085.HasXContextOperations.Instance;
        public static IIsSetContextOperations IsSetContextOperations => S0110.IsSetContextOperations.Instance;
        public static IIsSetOperator IsSetOperator => S0110.IsSetOperator.Instance;
        public static IItemGroupElementContextOperations ItemGroupElementContextOperations => S0110.ItemGroupElementContextOperations.Instance;
        public static L0032.IItemGroupXElementOperator ItemGroupXElementOperator => L0032.ItemGroupXElementOperator.Instance;
        public static L0072.IJsonOperator JsonOperator => L0072.JsonOperator.Instance;
        public static ILocalRepositoryContextOperations LocalRepositoryContextOperations => S0110.LocalRepositoryContextOperations.Instance;
        public static L0032.Z000.IPackageLicenseExpressions PackageLicenseExpressions => L0032.Z000.PackageLicenseExpressions.Instance;
        public static IProjectContextOperations ProjectContextOperations => S0110.ProjectContextOperations.Instance;
        public static F0055.IProjectDescriptionOperator ProjectDescriptionOperator => F0055.ProjectDescriptionOperator.Instance;
        public static IProjectDirectoryPathRelativePaths ProjectDirectoryPathRelativePaths => S0110.ProjectDirectoryPathRelativePaths.Instance;
        public static IProjectElementContextOperations ProjectElementContextOperations => S0110.ProjectElementContextOperations.Instance;
        public static F0055.IProjectNameOperator ProjectNameOperator => F0055.ProjectNameOperator.Instance;
        public static IProjectOptionsContextOperations ProjectOptionsContextOperations => S0110.ProjectOptionsContextOperations.Instance;
        public static F0040.F000.IProjectPathsOperator ProjectPathsOperator => F0040.F000.ProjectPathsOperator.Instance;
        public static O0029.O002.IProjectXElementOperationSets ProjectXElementOperationSets => O0029.O002.ProjectXElementOperationSets.Instance;
        public static L0032.IProjectXElementOperator ProjectXElementOperator => L0032.ProjectXElementOperator.Instance;
        public static L0032.IProjectXElementsOperator ProjectXElementsOperator => L0032.ProjectXElementsOperator.Instance;
        public static L0032.F001.IProjectXElementOperator ProjectXElementOperator_F001 => L0032.F001.ProjectXElementOperator.Instance;
        public static L0032.F004.IProjectXElementOperator ProjectXElementOperator_F004 => L0032.F004.ProjectXElementOperator.Instance;
        public static L0032.IPropertyGroupXElementOperator PropertyGroupXElementOperator => L0032.PropertyGroupXElementOperator.Instance;
        public static IPropertyGroupElementContextOperations PropertyGroupElementContextOperations => S0110.PropertyGroupElementContextOperations.Instance;
        public static L0079.Z100.IDescriptions RepositoryDescriptionExamples => L0079.Z100.Descriptions.Instance;
        public static IRepositoryContextOperations RepositoryContextOperations => S0110.RepositoryContextOperations.Instance;
        public static F0046.IRepositoryDescriptionOperator RepositoryDescriptionOperator => F0046.RepositoryDescriptionOperator.Instance;
        public static IRepositoryDirectoryNameOperator RepositoryDirectoryNameOperator => S0110.RepositoryDirectoryNameOperator.Instance;
        public static L0080.F001.IRepositoryOperator RepositoryOperator => L0080.F001.RepositoryOperator.Instance;
        public static F0046.IRepositoryNameOperator RepositoryNameOperator => F0046.RepositoryNameOperator.Instance;
        public static IRepositoryPathsOperator RepositoryPathsOperator => S0110.RepositoryPathsOperator.Instance;
        public static ISetGitHubClientContextOperations SetGitHubClientContextOperations => S0110.SetGitHubClientContextOperations.Instance;
        public static ISolutionContextOperations SolutionContextOperations => S0110.SolutionContextOperations.Instance;
        public static ISolutionDirectoryContextOperations SolutionDirectoryContextOperations => S0110.SolutionDirectoryContextOperations.Instance;
        public static ISolutionFileContextOperations SolutionFileContextOperations => S0110.SolutionFileContextOperations.Instance;
        public static F0024.F001.ISolutionOperator SolutionOperator => F0024.F001.SolutionOperator.Instance;
        public static F0048.ISolutionNameOperator SolutionNameOperator => F0048.SolutionNameOperator.Instance;
        public static F0050.ISolutionPathsOperator SolutionPathsOperator => F0050.SolutionPathsOperator.Instance;
        public static Z0043.Z000.IOwnerNames RepositoryOwnerNameExamples => Z0043.Z000.OwnerNames.Instance;
        public static L0079.Z100.INames RepositoryNameExamples => L0079.Z100.Names.Instance;
        public static Z0057.Platform.ITargetFrameworkMonikers TargetFrameworkMonikers => Z0057.Platform.TargetFrameworkMonikers.Instance;
        public static IValues Values => S0110.Values.Instance;
        public static L0066.IVersions Versions => L0066.Versions.Instance;
        public static IVisualStudioContextOperations VisualStudioContextOperations => S0110.VisualStudioContextOperations.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
        public static IWindowsExplorerOperations WindowsExplorerOperations => S0110.WindowsExplorerOperations.Instance;
    }
}