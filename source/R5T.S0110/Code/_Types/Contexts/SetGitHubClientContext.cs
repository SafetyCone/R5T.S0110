using System;

using Octokit;

using R5T.L0078.T000;
using R5T.L0085;
using R5T.T0137;
//using R5T.T0144;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class SetGitHubClientContext :
        IWithGitHubAuthenticationJsonFilePath,
        IWithAuthentication,
        IWithGitHubClient
    {
        public string GitHubAuthenticationJsonFilePath { get; set; }
        public GitHubClient GitHubClient { get; set; }

        public T0144.Authentication Authentication { get; set; }

        T0144.Authentication IWithX<T0144.Authentication>.X
        {
            get => this.Authentication;
            set => this.Authentication = value;
        }

        T0144.Authentication IHasX<T0144.Authentication>.X => this.Authentication;
    }
}
