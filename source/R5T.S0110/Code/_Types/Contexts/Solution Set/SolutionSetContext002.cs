using System;

using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good single-project solution set context.
    /// <list type="bullet">
    /// <item><see cref="IWithSolutionDirectoryPath"/></item>
    /// <item><see cref="IWithSolutionFilePath"/></item>
    /// <item><see cref="IWithProjectFilePath"/></item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class SolutionSetContext002 : IContextImplementationMarker,
        IWithSolutionDirectoryPath,
        IWithSolutionFilePath,
        IWithProjectFilePath
    {
        public string SolutionDirectoryPath { get; set; }
        public string ProjectFilePath { get; set; }
        public string SolutionFilePath { get; set; }
    }
}
