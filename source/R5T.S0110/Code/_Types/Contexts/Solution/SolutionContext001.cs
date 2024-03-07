using System;

using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good solution context with solution-related information.
    /// <list type="bullet">
    /// <item>
    /// <see cref="IWithSolutionSpecification"/>
    /// <list type="bullet">
    /// <item><see cref="IHasSolutionName"/></item>
    /// </list>
    /// </item>
    /// <item>
    /// <see cref="IWithSolutionDirectoryPath"/>
    /// <list type="bullet">
    /// <item><see cref="IHasDirectoryPath"/></item>
    /// </list>
    /// </item>
    /// <item>
    /// <see cref="IWithSolutionFilePath"/>
    /// <list type="bullet">
    /// <item><see cref="IHasFilePath"/></item>
    /// </list>
    /// </item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class SolutionContext001 : IContextImplementationMarker,
        IWithSolutionSpecification,
        IHasSolutionName,
        IWithSolutionDirectoryPath,
        IHasDirectoryPath,
        IWithSolutionFilePath,
        IHasFilePath
    {
        public string SolutionDirectoryPath { get; set; }
        public string DirectoryPath => this.SolutionDirectoryPath;

        public string SolutionFilePath { get; set; }
        public string FilePath => this.SolutionFilePath;

        public SolutionSpecification SolutionSpecification { get; set; }
        public string SolutionName => this.SolutionSpecification.Name;
    }
}
