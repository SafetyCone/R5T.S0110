 using System;

using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A project context without any non-project properties.
    /// <list type="bullet">
    /// <item>
    /// <see cref="IWithProjectSpecification"/>
    /// <list type="bullet">
    /// <item><see cref="IHasProjectName"/></item>
    /// <item><see cref="IHasProjectDescription"/></item>
    /// </list>
    /// </item>
    /// <item>
    /// <see cref="IWithProjectDirectoryPath"/>
    /// <list type="bullet">
    /// <item><see cref="IHasDirectoryPath"/></item>
    /// </list>
    /// </item>
    /// <item>
    /// <see cref="IWithProjectFilePath"/>
    /// <list type="bullet">
    /// <item><see cref="IHasFilePath"/></item>
    /// </list>
    /// </item>
    /// <item><see cref="IWithNamespaceName"/></item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class ProjectContext001 : IContextImplementationMarker,
        IWithProjectSpecification,
        IHasProjectName,
        IHasProjectDescription,
        IWithProjectDirectoryPath,
        IHasFilePath,
        IWithProjectFilePath,
        IHasDirectoryPath,
        IWithNamespaceName
    {
        public ProjectSpecification ProjectSpecification { get; set; }
        public string ProjectName => this.ProjectSpecification.Name;
        public string ProjectDescription => this.ProjectSpecification.Description;

        public string ProjectDirectoryPath { get; set; }
        public string DirectoryPath => this.ProjectDirectoryPath;

        public string ProjectFilePath { get; set; }
        public string FilePath => this.ProjectFilePath;

        public string NamespaceName { get; set; }
    }
}
