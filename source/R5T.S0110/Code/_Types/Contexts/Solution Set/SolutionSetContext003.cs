using System;

using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good library-and-contruction projects solution set context.
    /// <list type="bullet">
    /// <item><see cref="IWithSolutionDirectoryPath"/></item>
    /// <item>With construction solution file path.</item>
    /// <item>With construction project file path.</item>
    /// <item>With library solution file path.</item>
    /// <item>With library project file path.</item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class SolutionSetContext003 : IContextImplementationMarker,
        IWithSolutionDirectoryPath
    {
        public string SolutionDirectoryPath { get; set; }

        public string LibraryProjectFilePath { get; set; }
        public string ConstructionProjectFilePath { get; set; }

        public string LibrarySolutionFilePath { get; set; }
        public string ConstructionSolutionFilePath { get; set; }
    }
}
