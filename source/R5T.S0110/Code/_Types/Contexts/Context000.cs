using System;

using Octokit;

using R5T.L0078.T000;
using R5T.T0137;
using R5T.T0144;

using Author = R5T.T0046.Author;


namespace R5T.S0110
{
    /// <summary>
    /// A good application context.
    /// </summary>
    [ContextImplementationMarker]
    public class Context000 : IContextImplementationMarker,
        IWithGitHubAuthor,
        IWithNuGetAuthor,
        IWithGitHubClient,
        N001.IWithAuthentication
    {
        public Author GitHubAuthor { get; set; }
        public string NuGetAuthor { get; set; }
        public GitHubClient GitHubClient { get; set; }
        /// <summary>
        /// Meant to the be the GitHub authentication.
        /// </summary>
        public Authentication Authentication { get; set; }
    }
}
