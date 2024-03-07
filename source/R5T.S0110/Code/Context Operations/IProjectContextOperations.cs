using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.S0110.Contexts;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectContextOperations : IContextOperationsMarker,
        L0096.IProjectContextOperations
    {
        public Func<TSolutionContext, Task> Create_LibraryProject<TSolutionContext>(
            ProjectSpecification projectSpecification,
            ProjectOptions projectOptions,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            ContextCapture<Context001> repositoryContextCapture,
            out IChecked<IFileExists> checkedLibraryProjectFileExists,
            IEnumerable<Func<ProjectContext001, TSolutionContext, Task>> projectOperations = default)
            where TSolutionContext : IHasSolutionDirectoryPath
        {
            var o = Instances.ContextOperations;

            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, TSolutionContext>();

            return Instances.ProjectContextOperations.In_ProjectContext<TSolutionContext>(
                projectSpecification,
                solutionDirectoryPathSet,
                out (
                IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasNamespaceName> NamespaceNameSet,
                IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet
                ) projectPropertiesSet,
                Instances.ProjectFileContextOperations.Create_LibraryProjectFile(projectOptions,
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectDescriptionSet),
                    repositoryContextCapture,
                    out checkedLibraryProjectFileExists).In(contextSet),
                // Create project's files.
                Instances.CodeFileGenerationContextOperations.Create_Class1File<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
                    out var checkedClass1FileExists).In(contextSet),
                Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet, projectPropertiesSet.ProjectDescriptionSet),
                    out var checkedDocumentationFileExists).In(contextSet),
                Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
                    out var checkedInstancesFileExists).In(contextSet),
                Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectNameSet, projectPropertiesSet.ProjectDescriptionSet),
                    out var checkedProjectPlanFileExists).In(contextSet),
                o.From(projectOperations)
            );
        }

        public Func<TContext, Task> In_CodeFileContext<TContext>(
            out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            IEnumerable<Func<CodeFileContext, Task>> codeFileContextOperations)
            where TContext : IHasProjectFilePath, IHasNamespaceName
        {
            return context =>
            {
                var childContext = new CodeFileContext
                {
                    ProjectFilePath = context.ProjectFilePath,
                    NamespaceName = context.NamespaceName,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    codeFileContextOperations);
            };
        }

        public Func<TContext, Task> In_CodeFileContext<TContext>(
            out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            params Func<CodeFileContext, Task>[] codeFileContextOperations)
            where TContext : IHasProjectFilePath, IHasNamespaceName
        {
            return this.In_CodeFileContext<TContext>(
                out propertiesSet,
                codeFileContextOperations.AsEnumerable());
        }

        public Func<TSolutionSetContext, Task> In_ProjectContext<TSolutionSetContext>(
            ProjectSpecification projectSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet,
            IsSet<IHasNamespaceName> NamespaceNameSet,
            IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            IsSet<IHasProjectFilePath> ProjectFilePathSet
            ) projectPropertiesSet,
            out IChecked<IFileExists> checkedDocumentationFileExists,
            out IChecked<IFileExists> checkedInstancesFileExists,
            out IChecked<IFileExists> checkedProjectPlanFileExists,
            IEnumerable<Func<ProjectContext001, TSolutionSetContext, Task>> operations)
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, TSolutionSetContext>();

            return this.In_ProjectContext(
                projectSpecification,
                solutionDirectoryPathSet,
                out projectPropertiesSet,
                operations.Append(
                    Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet, projectPropertiesSet.ProjectDescriptionSet),
                        out checkedDocumentationFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
                        out checkedInstancesFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectNameSet, projectPropertiesSet.ProjectDescriptionSet),
                        out checkedProjectPlanFileExists).In(contextSet)));
        }

        public Func<TSolutionSetContext, Task> In_ProjectContext<TSolutionSetContext>(
            ProjectSpecification projectSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet,
            IsSet<IHasNamespaceName> NamespaceNameSet,
            IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            IsSet<IHasProjectFilePath> ProjectFilePathSet
            ) projectPropertiesSet,
            out IChecked<IFileExists> checkedDocumentationFileExists,
            out IChecked<IFileExists> checkedInstancesFileExists,
            out IChecked<IFileExists> checkedProjectPlanFileExists,
            params Func<ProjectContext001, TSolutionSetContext, Task>[] operations)
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            return this.In_ProjectContext(
                projectSpecification,
                solutionDirectoryPathSet,
                out projectPropertiesSet,
                out checkedDocumentationFileExists,
                out checkedInstancesFileExists,
                out checkedProjectPlanFileExists,
                operations.AsEnumerable());
        }

        public Func<TParentContextSet, Task> In_ProjectContext<TContextSet, TParentContextSet, TProjectContext, TSolutionSetContext>(
            IDirectionalIsomorphism<TParentContextSet, TContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TContextSet> contextSetSpecifier,
            out TypeSpecifier<TProjectContext> projectContextSpecifier,
            ProjectSpecification projectSpecification,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            out ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasNamespaceName> NamespaceNameSet,
                IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet
                )> projectContextPropertiesSet,
            IEnumerable<Func<TContextSet, TProjectContext, Task>> operations)
            where TContextSet : IWithContext<TProjectContext>, IHasContext<TSolutionSetContext>, new()
            where TParentContextSet : IHasContext<TSolutionSetContext>
            where TProjectContext : IWithProjectSpecification, IHasProjectName, IWithNamespaceName, IWithProjectDirectoryPath, IWithProjectFilePath, new()
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out _,
                o.In_Context_OfContextSet<TContextSet, TProjectContext>(
                    out contextSetSpecifier,
                    out projectContextSpecifier,
                    o.Construct_Context_OfContextSet<TContextSet, TProjectContext>(
                        Instances.ProjectContextOperations.Set_ProjectSpecification<TProjectContext>(projectSpecification,
                            out var projectSpecificationPropertiesSet).In_ContextSetAndContext(contextSetSpecifier),
                        Instances.ProjectContextOperations.Set_NamespaceName<TProjectContext>(projectSpecificationPropertiesSet.ProjectNameSet,
                            out var namespaceNameSet).In_ContextSetAndContext(contextSetSpecifier),
                        Instances.ProjectContextOperations.Set_ProjectDirectoryPath<TProjectContext, TSolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionSetContextPropertiesSet.PropertiesSet,
                            out var projectDirectoryPathSet).In_ContextSetAndContext(contextSetSpecifier, projectContextSpecifier),
                        Instances.ProjectContextOperations.Set_ProjectFilePath<TProjectContext>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                            out var projectFilePathSet).In_ContextSetAndContext(contextSetSpecifier)
                    ),
                    operations
                )
            );

            projectContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                projectSpecificationPropertiesSet.ProjectSpecificationSet,
                projectSpecificationPropertiesSet.ProjectNameSet,
                projectSpecificationPropertiesSet.ProjectDescriptionSet,
                namespaceNameSet,
                projectDirectoryPathSet,
                projectFilePathSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_ProjectContext<TContextSet, TParentContextSet, TProjectContext, TSolutionSetContext>(
            IDirectionalIsomorphism<TParentContextSet, TContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TContextSet> projectContextSetSpecifier,
            out TypeSpecifier<TProjectContext> projectContextSpecifier,
            ProjectSpecification projectSpecification,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            out ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasNamespaceName> NamespaceNameSet,
                IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet
                )> projectContextPropertiesSet,
            params Func<TContextSet, TProjectContext, Task>[] operations)
            where TContextSet : IWithContext<TProjectContext>, IHasContext<TSolutionSetContext>, new()
            where TParentContextSet : IHasContext<TSolutionSetContext>
            where TProjectContext : IWithProjectSpecification, IHasProjectName, IWithNamespaceName, IWithProjectDirectoryPath, IWithProjectFilePath, new()
            where TSolutionSetContext : IHasSolutionDirectoryPath
            => this.In_ProjectContext<TContextSet, TParentContextSet, TProjectContext, TSolutionSetContext>(
                parentContextSetIsomorphism,
                out projectContextSetSpecifier,
                out projectContextSpecifier,
                projectSpecification,
                solutionSetContextPropertiesSet,
                out projectContextPropertiesSet,
                operations.AsEnumerable());

        public Func<TSolutionSetContext, Task> In_ProjectContext<TSolutionSetContext>(
            ProjectSpecification projectSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet,
            IsSet<IHasNamespaceName> NamespaceNameSet,
            IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            IsSet<IHasProjectFilePath> ProjectFilePathSet
            ) projectPropertiesSet,
            IEnumerable<Func<ProjectContext001, TSolutionSetContext, Task>> operations)
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            var o = Instances.ContextOperations;

            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, TSolutionSetContext>();

            var output = o.In_ContextSet_A_BA<ProjectContext001, TSolutionSetContext>(
                o.Construct_Context_B_BA<ProjectContext001, TSolutionSetContext>(
                    Instances.ProjectContextOperations.Set_ProjectSpecification<ProjectContext001>(projectSpecification,
                        out var projectSpecificationPropertiesSet).In(contextSet),
                    Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext001>(projectSpecificationPropertiesSet.ProjectNameSet,
                        out var namespaceNameSet).In(contextSet),
                    Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext001, TSolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionDirectoryPathSet,
                        out var projectDirectoryPathSet),
                    Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext001>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                        out var projectFilePathSet).In(contextSet)
                ),
                operations
            );

            projectPropertiesSet = (
                projectSpecificationPropertiesSet.ProjectSpecificationSet,
                projectSpecificationPropertiesSet.ProjectNameSet,
                projectSpecificationPropertiesSet.ProjectDescriptionSet,
                namespaceNameSet,
                projectDirectoryPathSet,
                projectFilePathSet);

            return output;
        }

        public Func<TSolutionSetContext, Task> In_ProjectContext<TSolutionSetContext>(
            ProjectSpecification projectSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet,
            IsSet<IHasNamespaceName> NamespaceNameSet,
            IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            IsSet<IHasProjectFilePath> ProjectFilePathSet
            ) projectPropertiesSet,
            params Func<ProjectContext001, TSolutionSetContext, Task>[] operations)
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            return this.In_ProjectContext(
                projectSpecification,
                solutionDirectoryPathSet,
                out projectPropertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, TProjectContext, Task> Set_ProjectDescription<TContext, TProjectContext>(
            IsSet<IHasProjectDescription> projectDescriptionRequired,
            out IsSet<IHasProjectDescription> projectDescriptionSet)
            where TProjectContext : IHasProjectDescription
            where TContext : IWithProjectDescription
        {
            return (context, projectContext) =>
            {
                context.ProjectDescription = projectContext.ProjectDescription;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, TProjectContext, Task> Set_ProjectFilePath<TContext, TProjectContext>(
            IsSet<IHasProjectFilePath> projectFilePathRequired,
            out IsSet<IHasProjectFilePath> projectFilePathSet)
            where TProjectContext : IHasProjectFilePath
            where TContext : IWithProjectFilePath
        {
            return (context, projectContext) =>
            {
                context.ProjectFilePath = projectContext.ProjectFilePath;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_ProjectSpecification<TContext>(
            ProjectSpecification projectSpecification,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet
            ) propertiesSet
            )
            where TContext : IWithProjectSpecification
        {
            return context =>
            {
                context.ProjectSpecification = projectSpecification;

                return Task.CompletedTask;
            };
        }
    }
}
