using System;

using Octokit;

using R5T.L0078.T000;
using R5T.L0079;
using R5T.L0093.T000;
using R5T.T0137;
using R5T.T0235.T000;


namespace R5T.S0110
{
    /// <summary>
    /// A code repository context with both local and remote (GitHub) values.
    /// <list type="bullet">
    /// <item>
    /// <see cref="IWithRepositorySpecification"/>
    /// <list type="bullet">
    /// <item><see cref="IHasRepositoryName"/></item>
    /// <item><see cref="IHasRepositoryOwnerName"/></item>
    /// </list>
    /// </item>
    /// <item>
    /// <see cref="IWithRepositoryDirectoryPath"/> (local)
    /// <list type="bullet">
    /// <item><see cref="IHasDirectoryPath"/></item>
    /// </list>
    /// </item>
    /// <item><see cref="IWithRepository"/> (Octokit)</item>
    /// <item><see cref="IWithRepositoryUrl"/> (GitHub)</item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class RepositoryContext001 : IContextImplementationMarker,
        IWithRepositorySpecification,
        IHasRepositoryName,
        IHasRepositoryOwnerName,
        IWithRepositoryDirectoryPath,
        IHasDirectoryPath,
        IWithRepository,
        IWithRepositoryUrl,
        IHasLicenseName
    {
        public RepositorySpecification RepositorySpecification { get; set; }
        public string RepositoryName => this.RepositorySpecification.Name;
        public string RepositoryOwnerName => this.RepositorySpecification.Organization;

        public Repository Repository { get; set; }

        public string RepositoryDirectoryPath { get; set; }
        public string DirectoryPath => this.RepositoryDirectoryPath;

        public string RepositoryUrl { get; set; }

        public string LicenseName => this.RepositorySpecification.License.ToString();
    }
}
