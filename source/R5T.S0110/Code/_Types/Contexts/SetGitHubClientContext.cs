using System;

using Octokit;

using R5T.L0078.T000;
using R5T.T0144;


namespace R5T.S0110
{
    public class SetGitHubClientContext :
        IWithGitHubAuthenticationJsonFilePath,
        IWithAuthentication,
        IWithGitHubClient
    {
        public string GitHubAuthenticationJsonFilePath { get; set; }
        public Authentication Authentication { get; set; }
        public GitHubClient GitHubClient { get; set; }
    }
}
