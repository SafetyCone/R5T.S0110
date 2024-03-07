using System;

using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker]
    public class SingleProjectSolutionSetContext : IContextImplementationMarker,
        IWithSolutionDirectoryPath,
        IWithSolutionFilePath,
        IWithProjectFilePath
    {
        public string SolutionDirectoryPath { get; set; }
        public string ProjectFilePath { get; set; }
        public string SolutionFilePath { get; set; }
    }
}
