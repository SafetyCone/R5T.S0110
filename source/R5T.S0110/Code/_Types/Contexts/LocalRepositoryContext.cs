using System;

using R5T.T0137;
using R5T.T0235.T000;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class LocalRepositoryContext : IContextImplementationMarker,
        IWithRepositoryOwnerName,
        IWithRepositoryName,
        IWithRepositoriesDirectoryPath,
        IWithRepositoryDirectoryPath
    {
        public string RepositoryDirectoryPath { get; set; }
        public string RepositoriesDirectoryPath { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryOwnerName { get; set; }
    }
}
