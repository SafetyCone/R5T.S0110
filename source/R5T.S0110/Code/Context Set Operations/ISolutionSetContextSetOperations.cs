using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0131;
using R5T.T0221;

using R5T.S0110.Contexts;


namespace R5T.S0110
{
    [ContextSetOperationsMarker]
    public partial interface ISolutionSetContextSetOperations : IContextSetOperationsMarker
    {
        public Func<TSolutionSetContextSet, Task> Create_StaticHtmlWebApplicationProject<TSolutionSetContextSet, TProjectContextSet, TSolutionSetContext>(
            IDirectionalIsomorphism<TSolutionSetContextSet, TProjectContextSet> solutionSetContextSetIsomorphism,
            out ContextSetSpecifier<TProjectContextSet> projectContextSetSpecifier,
            out TypeSpecifier<ProjectContext001> projectContextSpecifier,
            ProjectSpecification projectSpecification,
            ProjectOptions projectOptions,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesSet,
            out IChecked<IFileExists> checkedProjectFileExists,
            IEnumerable<Func<TProjectContextSet, ProjectContext001, Task>> operations
            )
            where TProjectContextSet :
            IWithContext<ProjectContext001>,
            IHasContext<TSolutionSetContext>,
            IHasContext<ApplicationContext001>,
            IHasContext<RepositoryContext001>, new()
            where TSolutionSetContext :
            IHasSolutionDirectoryPath
        {
            var o = Instances.ContextOperations;

            var output = Instances.ProjectContextOperations.In_ProjectContext<TProjectContextSet, TSolutionSetContextSet, ProjectContext001, TSolutionSetContext>(
                solutionSetContextSetIsomorphism,
                out projectContextSetSpecifier,
                out projectContextSpecifier,
                projectSpecification,
                solutionSetContextPropertiesRequired,
                out ContextPropertiesSet<ProjectContext001, (
                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                    IsSet<IHasProjectName> ProjectNameSet,
                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                    IsSet<IHasNamespaceName> NamespaceNameSet,
                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                    IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesSet,
                Instances.ProjectContextSetOperations.Create_StaticHtmlWebApplicationProjectFile<TProjectContextSet>(
                    projectOptions,
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out checkedProjectFileExists
                //).In_ContextSetAndContext(
                //    Instances.ContextSetIsomorphisms.To_ContextSet004<TProjectContextSet>(
                //        ContextSetContextTypesSpecifier<Context000, Context001, ProjectContext001>.Instance),
                //    projectContextSpecifier),
                ).In_ContextSetWithContext(projectContextSpecifier),
                o.Get<ProjectContext001, (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>)>(
                    (projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                    out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) codeFilePropertiesRequired
                ).In_ContextSetWithContext(projectContextSetSpecifier),
                // Create project's files.
                Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out var checkedDocumentationFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                    out var checkedInstancesFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.ProjectNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out var checkedProjectPlanFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                    out var checkedProgramFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_HostRazorPageFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                    out var checkedHostFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_AppRazorComponentFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                    out var checkedAppFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_IndexRazorComponentFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                    out var checkedIndexFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_AppSettingsJsonFile<ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                    out var checkedAppSettingsJsonFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_DevelopmentAppSettingsJsonFile<ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                    out var checkedDevelopmentAppSettingsJsonFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_LaunchSettingsJsonFile<ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                    out var checkedLaunchSettingsJsonFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                o.From(operations)
            );

            return output;
        }

        public Func<TSolutionSetContextSet, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<TProjectContextSet, TSolutionSetContextSet, TSolutionSetContext>(
            IDirectionalIsomorphism<TSolutionSetContextSet, TProjectContextSet> solutionSetContextSetIsomorphism,
            out ContextSetSpecifier<TProjectContextSet> projectContextSetSpecifier,
            out TypeSpecifier<ProjectContext001> projectContextSpecifier,
            ProjectSpecification projectSpecification,
            ProjectOptions projectOptions,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesSet,
            out IChecked<IFileExists> checkedProjectFileExists,
            IEnumerable<Func<TProjectContextSet, Task>> operations
            )
            where TProjectContextSet : IWithContext<ProjectContext001>, IHasContext<TSolutionSetContext>, IHasContext<ApplicationContext001>, IHasContext<RepositoryContext001>, new()
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            var output = Instances.ProjectContextOperations.In_ProjectContext<TProjectContextSet, TSolutionSetContextSet, ProjectContext001, TSolutionSetContext>(
                solutionSetContextSetIsomorphism,
                out projectContextSetSpecifier,
                out projectContextSpecifier,
                projectSpecification,
                solutionSetContextPropertiesRequired,
                out ContextPropertiesSet<ProjectContext001, (
                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                    IsSet<IHasProjectName> ProjectNameSet,
                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                    IsSet<IHasNamespaceName> NamespaceNameSet,
                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                    IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesSet,
                Instances.ProjectContextSetOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile<TProjectContextSet>(
                    projectOptions,
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out checkedProjectFileExists
                //).In_ContextSetAndContext(
                //    Instances.ContextSetIsomorphisms.To_ContextSet004<TProjectContextSet>(
                //        ContextSetContextTypesSpecifier<Context000, Context001, ProjectContext001>.Instance),
                //    projectContextSpecifier),
                ).In_ContextSetWithContext(projectContextSpecifier),
                // Create project's files.
                Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out var checkedDocumentationFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                    out var checkedInstancesFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.ProjectNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
                    out var checkedProjectPlanFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_Component1File<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                    out var checkedComponent1FileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_WwwrootDirectory<ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                    out var checkedWwwrootDirectoryExists).In_ContextSetWithContext(projectContextSetSpecifier),
                Instances.ActionOperations.From(operations).In_ContextSetWithContext(projectContextSpecifier)
            );

            return output;
        }
    }
}
