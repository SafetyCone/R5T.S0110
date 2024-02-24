using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good solution context.
    /// </summary>
    [ContextImplementationMarker]
    public class Context003 : IContextImplementationMarker,
        IWithRepositoryDirectoryPath,
        IWithSolutionSpecification,
        IHasSolutionName,
        IWithSolutionDirectoryPath,
        IWithSolutionFilePath,
        IHasFilePath,
        IHasDirectoryPath
    {
        public string RepositoryDirectoryPath { get; set; }

        public string SolutionDirectoryPath { get; set; }
        public string DirectoryPath => this.SolutionDirectoryPath;

        public string SolutionFilePath { get; set; }
        public string FilePath => this.SolutionFilePath;

        public SolutionSpecification SolutionSpecification { get; set; }
        public string SolutionName => this.SolutionSpecification.Name;
    }
}
