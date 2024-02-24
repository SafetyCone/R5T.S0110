using System;
using System.Threading.Tasks;

using Octokit;

using R5T.L0078.T000;
using R5T.L0079;
using R5T.L0093.T000;
using R5T.T0137;
using R5T.T0144;
using R5T.T0221;
using R5T.T0235.T000;


namespace R5T.S0110
{
    /// <summary>
    /// A good context for generating repositories.
    /// </summary>
    [ContextImplementationMarker]
    public class Context001 : IContextImplementationMarker,
        IWithRepositorySpecification,
        IHasRepositoryName,
        IHasRepositoryOwnerName,
        IWithGitHubClient,
        N001.IWithAuthentication,
        IWithRepositoryDirectoryPath,
        IHasDirectoryPath,
        IWithGitHubAuthor,
        IWithNuGetAuthor,
        IWithRepository
    {
        #region Static

        public static Task<Context001> Constructor(RepositorySpecification repositorySpecification,
            out (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet
#pragma warning disable IDE0060 // Remove unused parameter
            ) propertiesSet
#pragma warning restore IDE0060 // Remove unused parameter
            )
        {
            var context = new Context001
            {
                RepositorySpecification = repositorySpecification
            };

            return Task.FromResult(context);
        }

        #endregion


        public RepositorySpecification RepositorySpecification { get; set; }

        public string RepositoryName => this.RepositorySpecification.Name;
        public string RepositoryOwnerName => this.RepositorySpecification.Organization;

        public Authentication Authentication { get; set; }
        public GitHubClient GitHubClient { get; set; }
        public T0046.Author GitHubAuthor { get; set; }
        public string NuGetAuthor { get; set; }
        public Repository Repository { get; set; }

        public string RepositoryDirectoryPath { get; set; }

        public string DirectoryPath => this.RepositoryDirectoryPath;
    }
}
