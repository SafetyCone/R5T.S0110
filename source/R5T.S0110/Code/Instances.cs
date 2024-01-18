using System;


namespace R5T.S0110
{
    public class Instances :
        L0055.Instances
    {
        public static L0066.IContextOperator ContextOperator => L0066.ContextOperator.Instance;
        public static IGitHubClientContextOperations GitHubClientContextOperations => S0110.GitHubClientContextOperations.Instance;
        public static L0078.F001.IClientOperator GitHubClientOperator => L0078.F001.ClientOperator.Instance;
        public static L0072.IJsonOperator JsonOperator => L0072.JsonOperator.Instance;
        public static L0079.Z100.IDescriptions RepositoryDescriptionExamples => L0079.Z100.Descriptions.Instance;
        public static L0081.O001.IRepositoryContextOperations RepositoryContextOperations => L0081.O001.RepositoryContextOperations.Instance;
        public static L0080.F001.IRepositoryOperator RepositoryOperator => L0080.F001.RepositoryOperator.Instance;
        public static ISetGitHubClientContextOperations SetGitHubClientContextOperations => S0110.SetGitHubClientContextOperations.Instance;
        public static Z0043.Z000.IOwnerNames RepositoryOwnerNameExamples => Z0043.Z000.OwnerNames.Instance;
        public static L0079.Z100.INames RepositoryNameExamples => L0079.Z100.Names.Instance;
        public static IValues Values => S0110.Values.Instance;
    }
}