using System;

using R5T.T0137;
using R5T.T0234;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class SolutionFileContext :
        IWithSolutionName,
        IWithSolutionFilePath,
        IWithSolutionDirectoryPath,
        IWithRepositoryDirectoryPath
    {
        public string SolutionName { get; set; }
        public string SolutionFilePath { get; set; }
        public string SolutionDirectoryPath { get; set; }
        public string RepositoryDirectoryPath { get; set; }
    }
}
