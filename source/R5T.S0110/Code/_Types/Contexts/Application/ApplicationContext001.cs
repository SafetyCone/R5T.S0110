using System;

using Octokit;

using R5T.L0078.T000;
using R5T.T0137;
using R5T.T0144;

using Author = R5T.T0046.Author;


namespace R5T.S0110
{
    /// <summary>
    /// An application context with a GitHub client and GitHub and NuGet user information.
    /// <list type="bullet">
    /// <item><see cref="IWithGitHubClient"/></item>
    /// <item><see cref="IWithGitHubAuthor"/></item>
    /// <item><see cref="N001.IWithAuthentication"/> (GitHub authentication)</item>
    /// <item><see cref="IWithNuGetAuthor"/></item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class ApplicationContext001 : IContextImplementationMarker,
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
