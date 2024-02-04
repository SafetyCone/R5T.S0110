using System;


namespace R5T.S0110
{
    public class Instances :
        L0055.Instances
    {
        public static L0066.IActionOperator ActionOperator => L0066.ActionOperator.Instance;
        public static L0033.Z002.IAuthors Authors => L0033.Z002.Authors.Instance;
        public static ICloneRepositoryLocallyContextOperations CloneRepositoryLocallyContextOperations => S0110.CloneRepositoryLocallyContextOperations.Instance;
        public static F0083.ICodeFileGenerationOperations CodeFileGenerationOperations => F0083.CodeFileGenerationOperations.Instance;
        public static ICommitMessages CommitMessages => S0110.CommitMessages.Instance;
        public static ICodeFileContextOperations CodeFileContextOperations => S0110.CodeFileContextOperations.Instance;
        public static L0097.ICodeFileGenerationContextOperations CodeFileGenerationContextOperations => L0097.CodeFileGenerationContextOperations.Instance;
        public static L0066.IContextOperations ContextOperations => L0066.ContextOperations.Instance;
        public static L0066.IContextOperator ContextOperator => L0066.ContextOperator.Instance;
        public static L0066.IDirectoryNameOperator DirectoryNameOperator => L0066.DirectoryNameOperator.Instance;
        public static IDirectoryNames DirectoryNames => S0110.DirectoryNames.Instance;
        public static IFileNames FileNames => S0110.FileNames.Instance;
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
        public static L0072.IJsonOperator JsonOperator => L0072.JsonOperator.Instance;
        public static ILocalRepositoryContextOperations LocalRepositoryContextOperations => S0110.LocalRepositoryContextOperations.Instance;
        public static IProjectContextOperations ProjectContextOperations => S0110.ProjectContextOperations.Instance;
        public static F0055.IProjectDescriptionOperator ProjectDescriptionOperator => F0055.ProjectDescriptionOperator.Instance;
        public static IProjectDirectoryPathRelativePaths ProjectDirectoryPathRelativePaths => S0110.ProjectDirectoryPathRelativePaths.Instance;
        public static F0055.IProjectNameOperator ProjectNameOperator => F0055.ProjectNameOperator.Instance;
        public static F0040.F000.IProjectPathsOperator ProjectPathsOperator => F0040.F000.ProjectPathsOperator.Instance;
        public static O0029.O002.IProjectXElementOperationSets ProjectXElementOperationSets => O0029.O002.ProjectXElementOperationSets.Instance;
        public static L0032.F001.IProjectXElementOperator ProjectXElementOperator_F001 => L0032.F001.ProjectXElementOperator.Instance;
        public static L0032.F004.IProjectXElementOperator ProjectXElementOperator_F004 => L0032.F004.ProjectXElementOperator.Instance;
        public static L0032.F004.IPropertyGroupXElementOperator PropertyGroupXElementOperator => L0032.F004.PropertyGroupXElementOperator.Instance;
        public static L0079.Z100.IDescriptions RepositoryDescriptionExamples => L0079.Z100.Descriptions.Instance;
        public static IRepositoryContextOperations RepositoryContextOperations => S0110.RepositoryContextOperations.Instance;
        public static IRepositoryDirectoryNameOperator RepositoryDirectoryNameOperator => S0110.RepositoryDirectoryNameOperator.Instance;
        public static L0080.F001.IRepositoryOperator RepositoryOperator => L0080.F001.RepositoryOperator.Instance;
        public static F0044.IRepositoryNameOperator RepositoryNameOperator => F0044.RepositoryNameOperator.Instance;
        public static IRepositoryPathsOperator RepositoryPathsOperator => S0110.RepositoryPathsOperator.Instance;
        public static ISetGitHubClientContextOperations SetGitHubClientContextOperations => S0110.SetGitHubClientContextOperations.Instance;
        public static ISolutionDirectoryContextOperations SolutionDirectoryContextOperations => S0110.SolutionDirectoryContextOperations.Instance;
        public static ISolutionFileContextOperations SolutionFileContextOperations => S0110.SolutionFileContextOperations.Instance;
        public static F0050.ISolutionPathsOperator SolutionPathsOperator => F0050.SolutionPathsOperator.Instance;
        public static Z0043.Z000.IOwnerNames RepositoryOwnerNameExamples => Z0043.Z000.OwnerNames.Instance;
        public static L0079.Z100.INames RepositoryNameExamples => L0079.Z100.Names.Instance;
        public static IValues Values => S0110.Values.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
        //public static L0085.IWithXContextOperations WithXContextOperations => L0085.WithXContextOperations.Instance;
    }
}