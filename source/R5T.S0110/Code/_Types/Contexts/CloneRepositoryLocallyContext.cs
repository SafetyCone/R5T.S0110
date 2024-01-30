using System;

using R5T.L0085;
using R5T.T0137;
//using R5T.T0144;
using R5T.T0235.T000;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class CloneRepositoryLocallyContext :
        IWithRepositoryOwnerName,
        IWithRepositoryName,
        IWithRepositoriesDirectoryPath,
        IWithRepositoryDirectoryPath,
        IWithRepositoryGitDirectoryPath,
        IWithRepositoryUrl,
        IWithGitHubAuthenticationJsonFilePath,
        IWithAuthentication
    {
        public string RepositoryOwnerName { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryUrl { get; set; }
        public string RepositoryDirectoryPath { get; set; }
        public string RepositoriesDirectoryPath { get; set; }
        public string GitHubAuthenticationJsonFilePath { get; set; }
        public string RepositoryGitDirectoryPath { get; set; }

        public T0144.Authentication Authentication { get; set; }
        T0144.Authentication IWithX<T0144.Authentication>.X { get => this.Authentication; set => this.Authentication = value; }
        T0144.Authentication IHasX<T0144.Authentication>.X => this.Authentication;
    }
}
