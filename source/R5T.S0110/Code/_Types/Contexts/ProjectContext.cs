using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class ProjectContext :
        IWithSolutionFilePath,
        IWithProjectName,
        IWithProjectDescription,
        IWithProjectDirectoryPath,
        IWithProjectFilePath,
        IWithNamespaceName,
        IHasFilePath
    {
        public string SolutionFilePath { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectDirectoryPath { get; set; }
        public string ProjectFilePath { get; set; }
        public string NamespaceName { get; set; }

        string IHasFilePath.FilePath => this.ProjectFilePath;
    }
}
