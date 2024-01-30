using System;

using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class SolutionDirectoryContext :
        IWithSolutionDirectoryPath,
        IWithRepositoryDirectoryPath
    {
        public string SolutionDirectoryPath { get; set; }
        public string RepositoryDirectoryPath { get; set; }
    }
}
