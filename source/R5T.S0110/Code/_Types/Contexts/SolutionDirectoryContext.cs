using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class SolutionDirectoryContext :
        IHasDirectoryPath,
        IWithSolutionDirectoryPath,
        IWithRepositoryDirectoryPath
    {
        public string SolutionDirectoryPath { get; set; }
        public string RepositoryDirectoryPath { get; set; }

        public string DirectoryPath => this.SolutionDirectoryPath;
    }
}
