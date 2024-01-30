using System;

using Octokit;

using R5T.L0078.T000;
using R5T.T0137;
using R5T.T0235.T000;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class RepositoryContext :
        IWithRepositoryOwnerName,
        IWithRepositoryName,
        IWithGitHubClient,
        IWithRepository
    {
        public GitHubClient GitHubClient { get; set; }
        public string RepositoryOwnerName { get; set; }
        public string RepositoryName { get; set; }
        public Repository Repository { get; set; }
    }
}
