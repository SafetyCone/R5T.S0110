using System;

using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good web library with construction client-and-server web application solution set context.
    /// <list type="bullet">
    /// <item><see cref="IWithSolutionDirectoryPath"/></item>
    /// <item><see cref="IWithSolutionFilePath"/></item>
    /// <item>With library project file path.</item>
    /// <item>With client project file path.</item>
    /// <item>With server project file path.</item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class SolutionSetContext005 : IContextImplementationMarker,
        IWithSolutionDirectoryPath,
        IWithSolutionFilePath
    {
        public string SolutionDirectoryPath { get; set; }
        public string SolutionFilePath { get; set; }

        public string LibraryProjectFilePath { get; set; }
        public string ClientProjectFilePath { get; set; }
        public string ServerProjectFilePath { get; set; }
    }
}
