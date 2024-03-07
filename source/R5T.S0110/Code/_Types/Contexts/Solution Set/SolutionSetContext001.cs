using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A basic solution set context with solution directory path information.
    /// <list type="bullet">
    /// <item>
    /// <see cref="IWithSolutionDirectoryPath"/>
    /// <list type="bullet">
    /// <item><see cref="IHasDirectoryPath"/></item>
    /// </list>
    /// </item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class SolutionSetContext001 : IContextImplementationMarker,
        IWithSolutionDirectoryPath,
        IHasDirectoryPath
    {
        public string SolutionDirectoryPath { get; set; }
        public string DirectoryPath => this.SolutionDirectoryPath;
    }
}
