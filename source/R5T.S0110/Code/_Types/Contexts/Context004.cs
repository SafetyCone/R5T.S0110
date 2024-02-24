using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good project context.
    /// </summary>
    [ContextImplementationMarker]
    public class Context004 : IContextImplementationMarker,
        IWithRepositoryDirectoryPath,
        IWithSolutionFilePath,
        IWithProjectSpecification,
        IHasProjectName,
        IHasProjectDescription,
        IWithProjectDirectoryPath,
        IWithProjectFilePath,
        IHasFilePath,
        IHasDirectoryPath,
        IWithNamespaceName
    {
        public string RepositoryDirectoryPath { get; set; }
        public string SolutionFilePath { get; set; }

        public ProjectSpecification ProjectSpecification { get; set; }
        public string ProjectName => this.ProjectSpecification.Name;
        public string ProjectDescription => this.ProjectSpecification.Description;

        public string ProjectDirectoryPath { get; set; }
        public string DirectoryPath => this.ProjectDirectoryPath;

        public string ProjectFilePath { get; set; }
        public string FilePath => this.ProjectFilePath;

        public string NamespaceName { get; set; }
    }
}
