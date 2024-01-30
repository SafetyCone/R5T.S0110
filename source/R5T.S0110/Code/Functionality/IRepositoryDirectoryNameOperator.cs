using System;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IRepositoryDirectoryNameOperator : IFunctionalityMarker
    {
        public string Get_RepositoryDirectoryName(string repositoryName)
        {
            // Directory name is just the repository name.
            var output = Instances.DirectoryNameOperator.Ensure_IsValidDirectoryName(repositoryName);
            return output;
        }

        public string Get_RepositoryOwnerDirectoryName(string repositoryOwnerName)
        {
            // Directory name is just the repository owner name.
            var output = Instances.DirectoryNameOperator.Ensure_IsValidDirectoryName(repositoryOwnerName);
            return output;
        }
    }
}
