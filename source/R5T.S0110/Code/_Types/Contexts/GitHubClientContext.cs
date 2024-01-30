using System;

using Octokit;

using R5T.L0078.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class GitHubClientContext :
        IWithGitHubClient
    {
        public GitHubClient GitHubClient { get; set; }
    }
}
