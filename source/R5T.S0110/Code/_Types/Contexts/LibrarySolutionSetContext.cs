using System;

using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker]
    public class LibrarySolutionSetContext : IContextImplementationMarker,
        IWithSolutionDirectoryPath
    {
        public string SolutionDirectoryPath { get; set; }

        public string LibraryProjectFilePath { get; set; }
        public string ConstructionProjectFilePath { get; set; }

        public string LibrarySolutionFilePath { get; set; }
        public string ConstructionSolutionFilePath { get; set; }
    }
}
