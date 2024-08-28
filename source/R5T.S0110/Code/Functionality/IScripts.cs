using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.F0078.Extensions;
using R5T.L0066.Contexts;
using R5T.L0078.T000;
using R5T.L0079;
using R5T.L0081.O002;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.L0096.O001;
using R5T.L0096.T000;
using R5T.T0046;
using R5T.T0132;
using R5T.T0144;
using R5T.T0221;
using R5T.T0235.T000;

using R5T.S0110.Contexts;

using SimpleRepositoryContext = R5T.L0080.T001.RepositoryContext;
using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;
using GitHubRepositoryContext = R5T.S0110.RepositoryContext;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository_WithTailwindCss()
        {
            /// Inputs.
            var allowDeletionIfExists = true;

            var libraryName =
                //// Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "R5T.R0014"
                ;
            var isPrivate =
                //true
                false
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                //Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "Razor component-based, non-interactive, non-TailwindCSS-based."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var librarySolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var librarySolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                librarySolutionName_UnadjustedForPrivacy,
                isPrivate);

            var librarySolutionSpecification = new SolutionSpecification
            {
                Name = librarySolutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectDescription,
            };

            var constructionSolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_ConstructionSolutionName(librarySolutionName_UnadjustedForPrivacy);
            var constructionSolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                constructionSolutionName_UnadjustedForPrivacy,
                isPrivate);

            var constructionSolutionSpecification = new SolutionSpecification
            {
                Name = constructionSolutionName
            };

            var constructionProjectName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);
            var constructionProjectDescription = Instances.ProjectDescriptionOperator.Get_LibraryConstructionProjectDescription_FromLibraryName(libraryName);

            var constructionProjectSpecification = new ProjectSpecification
            {
                Name = constructionProjectName,
                Description = constructionProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet004, RepositoryContextSet003, SolutionSetContext003, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet004>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet004> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext003> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            // Create the Razor components library project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject_WithTailwindCss<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the static HTML web application project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                constructionProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_StaticHtmlApplicationProject_WithTailwindCss<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet,
                                        Instances.IsSetContextOperations.Implies<IHasRepositorySpecification, IHasLicenseName>(repositoryContextPropertiesSet.PropertiesSet.RepositorySpecificationSet)),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                        applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Overwrite the Index.razor file to use the library's Component1.
                                Instances.CodeFileGenerationContextOperations.Create_IndexRazorComponentFile_ForStaticHtmlWebApplication_WithLibrary<ProjectContext001>(
                                    (projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    out var checkeIndexFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);
                                },
                                // Run post-generation project setup.
                                Instances.ProjectContextOperations.Run_NPM_Install<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindContentPathsAggregation<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet)
                                ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindCss<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                ).In_ContextSetWithContext(projectContextSetSpecifier),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the library solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier_Library,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier_Library,
                                librarySolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet_Library,
                                out var checkedLibrarySolutionFileExists,
                                // Add project to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,

                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibrarySolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the console solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                constructionSolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the construction project first so it will be the default startup project.
                                        solutionSetContext.ConstructionProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionSolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext003>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Create a Blazor (WebAssembly) components library with a construction Blazor (WebAssembly) client-and-server web application,
        /// where the front-end project is Blazor (WebAssembly) client and the back-end is an ASP.NET Core back-end project to host it.
        /// </summary>
        /// <remarks>
        /// This project is based on the D8S.E0013-P0008 example solution.
        /// </remarks>
        public async Task Regenerate_BlazorComponentsLibrary_WithConstructionWebAssemblyClientAndServerRepository_WithTailwindCss()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "R5T.R0015"
                ;
            var isPrivate =
                //true
                false
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                //Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "Interactive-WebAssembly, non-TailwindCSS-based."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryName);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectName,
            };

            var constructionLibraryName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);

            var clientProjectName = Instances.ProjectNameOperator.Get_WebBlazorClientProjectName_FromLibraryName(constructionLibraryName);
            var clientProjectDescription = Instances.ProjectDescriptionOperator.Get_WebBlazorClientProjectDescription_FromLibraryName(constructionLibraryName);

            var clientProjectSpecification = new ProjectSpecification
            {
                Name = clientProjectName,
                Description = clientProjectDescription,
            };

            var serverProjectName = Instances.ProjectNameOperator.Get_WebServerForBlazorClientProjectName_FromLibraryName(constructionLibraryName);
            var serverProjectDescription = Instances.ProjectDescriptionOperator.Get_WebServerForBlazorClientProjectDescription_FromLibraryName(constructionLibraryName);

            var serverProjectSpecification = new ProjectSpecification
            {
                Name = serverProjectName,
                Description = serverProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet006, RepositoryContextSet003, SolutionSetContext005, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet006>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet006> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext005> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext005, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,

                            // Create the Blazor components library project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet007, SolutionSetContextSet006, ProjectContext001, SolutionSetContext005>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet006, ProjectContextSet007>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet007> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_WebAssemblyRazorComponentRazorClassLibraryProject<ProjectContextSet007>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet007, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetAndContext(projectContextSpecifier_Library),
                                // Set the library project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the construction Blazor client WebAssembly project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet007, SolutionSetContextSet006, ProjectContext001, SolutionSetContext005>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet006, ProjectContextSet007>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet007> projectContextSetSpecifier_Client,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Client,
                                clientProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Client,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_BlazorComponentWebAssemblyClientProject<ProjectContextSet007>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet007, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Client,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Client.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Client.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Client.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Client.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedClientProject).In_ContextSetWithContext(projectContextSpecifier_Client),
                                // Overwrite the Home page component to reference a component from the library project.
                                Instances.CodeFileGenerationContextOperations.Create_HomeRazorComponent_ForBlazorClient_WithComponentLibrary<ProjectContext001>(projectContextPropertiesSet_Client.PropertiesSet.ProjectFilePathSet,
                                    out _).In_ContextSetWithContext(projectContextSetSpecifier_Client),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);
                                },
                                // Set the client project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ClientProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the ASP.NET Core server project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet007, SolutionSetContextSet006, ProjectContext001, SolutionSetContext005>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet006, ProjectContextSet007>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet007> projectContextSetSpecifier_Server,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Server,
                                serverProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Server,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_BlazorComponentsWebAssemblyServerProject<ProjectContextSet007>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet007, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Server,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Server.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet,
                                        Instances.IsSetContextOperations.Implies<IHasRepositorySpecification, IHasLicenseName>(repositoryContextPropertiesSet.PropertiesSet.RepositorySpecificationSet)),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                        applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet),
                                    out var checkedServerProject).In_ContextSetWithContext(projectContextSpecifier_Server),
                                // Add a reference to the client project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.ClientProjectFilePath);
                                },
                                Instances.ProjectContextOperations.Run_NPM_Install<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier_Server),
                                Instances.ProjectContextOperations.Run_NPX_TailwindContentPathsAggregation<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectFilePathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier_Server),
                                Instances.ProjectContextOperations.Run_NPX_TailwindCss<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Server.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier_Server),
                                // Set the server project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ServerProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet006, SolutionContextSet007, SolutionSetContext005, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet006, SolutionContextSet007>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet007> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the server project first so it will be the default startup project.
                                        solutionSetContext.ServerProjectFilePath,
                                        solutionSetContext.ClientProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext005>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public Func<TProjectContextSet, Task> Create_WebAssemblyRazorComponentRazorClassLibraryProject<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasNamespaceName> NamespaceNameSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists
            )
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSetSpecifier = ContextSetSpecifier<TProjectContextSet>.Instance;
            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            Func<TProjectContextSet, Task>[] operations = [
                // Create the project file.
                Instances.ProjectFileContextOperations.Create_WebAssemblyRazorComponentRazorClassLibraryProjectFile<TProjectContextSet>(
                    projectContextSetIsomorphism,
                    projectOptions,
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                        projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet,
                        projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    repositoryContextPropertiesRequired,
                    out checkedProjectFileExists
                ),
                o.Get<ProjectContext001, (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>)>(
                    (projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet, projectContextPropertiesRequired.PropertiesSet.NamespaceNameSet),
                    out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) codeFilePropertiesRequired).In_ContextSet(projectContextSetSpecifier),
                // Create project files.
                Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet, projectContextPropertiesRequired.PropertiesSet.NamespaceNameSet, projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                    out var checkedDocumentationFileExists).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet, projectContextPropertiesRequired.PropertiesSet.NamespaceNameSet),
                    out var checkedInstancesFileExists).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet, projectContextPropertiesRequired.PropertiesSet.ProjectNameSet, projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                    out var checkedProjectPlanFileExists).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_Component1File<ProjectContext001>((projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet, projectContextPropertiesRequired.PropertiesSet.NamespaceNameSet),
                    out var checkedComponent1FileExists).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_ImportsComponent_ForBlazorLibrary<ProjectContext001>(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet,
                    out var checkedWwwrootDirectoryExists).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_TailwindContentPathsJsonFile_Default<ProjectContext001>(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet,
                    out _).In_ContextSet(projectContextSetSpecifier),
                Instances.CodeFileGenerationContextOperations.Create_WwwrootDirectory<ProjectContext001>(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet,
                    out _).In_ContextSet(projectContextSetSpecifier)
            ];

            return Instances.ContextOperations.From(operations);
        }

        /// <summary>
        /// Regenerate a repository containing a web application that uses Razor components on the server to produce page HTML (without any client-side WebAssembly functionality),
        /// and also includes TailwindCSS and the TailwindCSS Typography plugin.
        /// </summary>
        /// <remarks>
        /// This is based on example solution D8S.E0013-P0009.
        /// </remarks>
        public async Task Regenerate_BlogStaticHtmlWebApplicationRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "D8S.W0006"
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                //Instances.RepositoryOwnerNameExamples.SafetyCone
                Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "An internal, personal, technical blog project."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_BlogStaticHtmlApplicationProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet,
                                        Instances.IsSetContextOperations.Implies<IHasRepositorySpecification, IHasLicenseName>(repositoryContextPropertiesSet.PropertiesSet.RepositorySpecificationSet)),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                        applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Run post-generation project setup.
                                Instances.ProjectContextOperations.Run_NPM_Install<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindContentPathsAggregation<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindCss<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Create a Blazor components WebAssembly application front-end project with an ASP.NET Core back-end project to host it.
        /// </summary>
        /// <returns></returns>
        public async Task Regenerate_BlazorComponentsWebAssemblyClientAndServerRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = true;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "R5T.W0008"
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "A projects file search website."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var clientProjectName = Instances.ProjectNameOperator.Get_WebBlazorClientProjectName_FromLibraryName(libraryName);
            var clientProjectDescription = Instances.ProjectDescriptionOperator.Get_WebBlazorClientProjectDescription_FromLibraryName(libraryName);

            var clientProjectSpecification = new ProjectSpecification
            {
                Name = clientProjectName,
                Description = clientProjectDescription,
            };

            var serverProjectName = Instances.ProjectNameOperator.Get_WebServerForBlazorClientProjectName_FromLibraryName(libraryName);
            var serverProjectDescription = Instances.ProjectDescriptionOperator.Get_WebServerForBlazorClientProjectDescription_FromLibraryName(libraryName);

            var serverProjectSpecification = new ProjectSpecification
            {
                Name = serverProjectName,
                Description = serverProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet005, RepositoryContextSet003, SolutionSetContext004, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet005>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet005> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext004> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext004, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            // Create the client Blazor components WebAssembly project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet006, SolutionSetContextSet005, ProjectContext001, SolutionSetContext004>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet005, ProjectContextSet006>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet006> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                clientProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_BlazorComponentWebAssemblyClientProject<ProjectContextSet006>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet006, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedClientProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ClientProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the ASP.NET Core server project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet006, SolutionSetContextSet005, ProjectContext001, SolutionSetContext004>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet005, ProjectContextSet006>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet006> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                serverProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_BlazorComponentsWebAssemblyServerProject<ProjectContextSet006>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet006, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet,
                                        Instances.IsSetContextOperations.Implies<IHasRepositorySpecification, IHasLicenseName>(repositoryContextPropertiesSet.PropertiesSet.RepositorySpecificationSet)),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                        applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet),
                                    out var checkedServerProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.ClientProjectFilePath);
                                },
                                Instances.ProjectContextOperations.Run_NPM_Install<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindContentPathsAggregation<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                Instances.ProjectContextOperations.Run_NPX_TailwindCss<ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDirectoryPathSet)
                                    ).In_ContextSetWithContext(projectContextSetSpecifier),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ServerProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet005, SolutionContextSet006, SolutionSetContext004, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet005, SolutionContextSet006>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet006> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the server project first so it will be the default startup project.
                                        solutionSetContext.ServerProjectFilePath,
                                        solutionSetContext.ClientProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext004>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public async Task Regenerate_WindowsFormsApplication_WithWindowsFormsLibraryRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var librarySolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var librarySolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                librarySolutionName_UnadjustedForPrivacy,
                isPrivate);

            var librarySolutionSpecification = new SolutionSpecification
            {
                Name = librarySolutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectDescription,
            };

            var constructionSolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_ConstructionSolutionName(librarySolutionName_UnadjustedForPrivacy);
            var constructionSolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                constructionSolutionName_UnadjustedForPrivacy,
                isPrivate);

            var constructionSolutionSpecification = new SolutionSpecification
            {
                Name = constructionSolutionName
            };

            var constructionProjectName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);
            var constructionProjectDescription = Instances.ProjectDescriptionOperator.Get_LibraryConstructionProjectDescription_FromLibraryName(libraryName);

            var constructionProjectSpecification = new ProjectSpecification
            {
                Name = constructionProjectName,
                Description = constructionProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet004, RepositoryContextSet003, SolutionSetContext003, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet004>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet004> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext003> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            // Create the Windows Forms-capable library project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_WindowsFormsLibraryProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the Windows Forms application project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                constructionProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_WindowsFormsApplicationProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);
                                },
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the library solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier_Library,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier_Library,
                                librarySolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet_Library,
                                out var checkedLibrarySolutionFileExists,
                                // Add project to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,

                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibrarySolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the console solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                constructionSolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the construction project first so it will be the default startup project.
                                        solutionSetContext.ConstructionProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionSolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext003>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Generate a repository with a Windows Forms application.
        /// </summary>
        public async Task Regenerate_WindowsFormsApplicationRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var applicationContext = new Context000();

            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_WindowsFormsApplicationProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Regenerate (or generate if the repository does not exist) a GitHub repository containing a solution with a Windows forms class library project.
        /// </summary>
        public async Task Regenerate_WindowsFormsLibraryRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_WindowsFormsLibraryProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier),
                                // Overwrite the Index.razor file to use the library's Component1.
                                Instances.CodeFileGenerationContextOperations.Create_Class1File_ForWindowsFormsLibrary<ProjectContext001>(
                                    (projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    out var checkeIndexFileExists).In_ContextSetWithContext(projectContextSetSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                //// Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "R5T.R0014"
                ;
            var isPrivate =
                //true
                false
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                //Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "Razor component-based, non-interactive, non-TailwindCSS-based."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var librarySolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var librarySolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                librarySolutionName_UnadjustedForPrivacy,
                isPrivate);

            var librarySolutionSpecification = new SolutionSpecification
            {
                Name = librarySolutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectDescription,
            };

            var constructionSolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_ConstructionSolutionName(librarySolutionName_UnadjustedForPrivacy);
            var constructionSolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                constructionSolutionName_UnadjustedForPrivacy,
                isPrivate);

            var constructionSolutionSpecification = new SolutionSpecification
            {
                Name = constructionSolutionName
            };

            var constructionProjectName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);
            var constructionProjectDescription = Instances.ProjectDescriptionOperator.Get_LibraryConstructionProjectDescription_FromLibraryName(libraryName);

            var constructionProjectSpecification = new ProjectSpecification
            {
                Name = constructionProjectName,
                Description = constructionProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet004, RepositoryContextSet003, SolutionSetContext003, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet004>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet004> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext003> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            // Create the Razor components library project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the static HTML web application project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                constructionProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_StaticHtmlApplicationProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Overwrite the Index.razor file to use the library's Component1.
                                Instances.CodeFileGenerationContextOperations.Create_IndexRazorComponentFile_ForStaticHtmlWebApplication_WithLibrary<ProjectContext001>(
                                    (projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    out var checkeIndexFileExists).In_ContextSetWithContext(projectContextSetSpecifier),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);
                                },
                                // Set the project file path.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the library solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier_Library,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier_Library,
                                librarySolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet_Library,
                                out var checkedLibrarySolutionFileExists,
                                // Add project to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,

                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibrarySolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the console solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                constructionSolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the construction project first so it will be the default startup project.
                                        solutionSetContext.ConstructionProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionSolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext003>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibraryRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Regenerate a repository containing a web application that uses Razor components on the server to produce page HTML (without any client-side WebAssembly functionality).
        /// </summary>
        /// <remarks>
        /// This is based on example solution D8S.E0013-P0003.
        /// </remarks>
        public async Task Regenerate_StaticHtmlWebApplicationRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_StaticHtmlApplicationProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public async Task Regenerate_LibraryWithConstructionRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                //// Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "D8S.L0003"
                ;
            var isPrivate =
                //false
                true
                ;
            var repositoryOwnerName =
                //Instances.RepositoryOwnerNameExamples.SafetyCone
                Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "Private, personal, latest .NET version catch-all library."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var librarySolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var librarySolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                librarySolutionName_UnadjustedForPrivacy,
                isPrivate);

            var librarySolutionSpecification = new SolutionSpecification
            {
                Name = librarySolutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectDescription,
            };

            var constructionSolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_ConstructionSolutionName(librarySolutionName_UnadjustedForPrivacy);
            var constructionSolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                constructionSolutionName_UnadjustedForPrivacy,
                isPrivate);

            var constructionSolutionSpecification = new SolutionSpecification
            {
                Name = constructionSolutionName
            };

            var constructionProjectName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);
            var constructionProjectDescription = Instances.ProjectDescriptionOperator.Get_LibraryConstructionProjectDescription_FromLibraryName(libraryName);

            var constructionProjectSpecification = new ProjectSpecification
            {
                Name = constructionProjectName,
                Description = constructionProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet004, RepositoryContextSet003, SolutionSetContext003, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet004>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet004> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext003> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            // Create the library project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Library,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet_Library,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_LibraryProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Set the project file path.
                                //Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext003, ProjectContext001>(
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                //    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the console project.
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet005, SolutionSetContextSet004, ProjectContext001, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                constructionProjectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_ConsoleProject<ProjectContextSet005>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet005, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier_Library,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet_Library.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier_Library),
                                // Add a reference to the library project.
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                        projectContext.ProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);
                                },
                                // Set the project file path.
                                //Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext003, ProjectContext001>(
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                //    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                                (projectContextSet, projectContext) =>
                                {
                                    var solutionSetContext = projectContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the library solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier_Library,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier_Library,
                                librarySolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet_Library,
                                out var checkedLibrarySolutionFileExists,
                                // Add project to the solution.
                                //Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext003, SolutionContext001>(
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext003>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                //    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,

                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.LibrarySolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the console solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet004, SolutionContextSet005, SolutionSetContext003, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, SolutionContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet005> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                constructionSolutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add projects to the solution.
                                //Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext003, SolutionContext001>(
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext003>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                //    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet_Library.PropertiesSet.SolutionFilePathSet),
                                //    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier_Library, solutionContextSpecifier_Library),
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    Instances.SolutionOperator.AddProjects_Idempotent(
                                        solutionContext.SolutionFilePath,
                                        // Add the construction project first so it will be the default startup project.
                                        solutionSetContext.ConstructionProjectFilePath,
                                        solutionSetContext.LibraryProjectFilePath);

                                    return Task.CompletedTask;
                                },
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.ConstructionSolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext003>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Regenerate (or generate if the library does not exist) a GitHub repository containing a solution with a class library project.
        /// </summary>
        public async Task Regenerate_ClassLibraryRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_LibraryProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedLibraryProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Generate a repository with a console application.
        /// </summary>
        public async Task Regenerate_ConsoleRepository()
        {
            /// Inputs.
            var allowDeletionIfExists = false;

            var libraryName =
                //// Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "D8S.S0011"
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                //Instances.RepositoryOwnerNameExamples.SafetyCone
                Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var libraryDescription =
                //Instances.RepositoryDescriptionExamples.ForTesting
                "Instances survey script."
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                solutionName_UnadjustedForPrivacy,
                isPrivate);

            var solutionSpecification = new SolutionSpecification
            {
                Name = solutionName
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var applicationContext = new Context000();

            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out var applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                        IsSet<IHasGitHubClient> GitHubClientSet,
                        IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                        IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                        IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                        )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        allowDeletionIfExists,
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(
                            applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet
                            )> repositoryContextPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet003>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.ProjectContextOperations.In_ProjectContext<ProjectContextSet004, SolutionSetContextSet003, ProjectContext001, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, ProjectContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out TypeSpecifier<ProjectContext001> projectContextSpecifier,
                                projectSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<ProjectContext001, (
                                    IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                                    IsSet<IHasProjectName> ProjectNameSet,
                                    IsSet<IHasProjectDescription> ProjectDescriptionSet,
                                    IsSet<IHasNamespaceName> NamespaceNameSet,
                                    IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
                                    IsSet<IHasProjectFilePath> ProjectFilePathSet
                                    )> projectContextPropertiesSet,
                                // Create the project.
                                Instances.ProjectContextOperations.Create_ConsoleProject<ProjectContextSet004>(
                                    Instances.ContextSetIsomorphisms.For_ContextSets<ProjectContextSet004, ProjectElementContextSet007>().For_Contexts(
                                        projectContextSpecifier,
                                        repositoryContextSpecifier),
                                    projectOptions,
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
                                        projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                                        projectContextPropertiesSet.PropertiesSet.ProjectNameSet,
                                        projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                        repositoryContextPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                    out var checkedConsoleProject).In_ContextSetWithContext(projectContextSpecifier),
                                // Set the project file path.
                                Instances.ProjectContextOperations.Set_ProjectFilePath<SolutionSetContext002, ProjectContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet),
                                    out var solutionSetContext_ProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier, projectContextSpecifier)
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Create the solution.
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContextSet003, SolutionContextSet004, SolutionSetContext002, SolutionContext001>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet003, SolutionContextSet004>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<SolutionContextSet004> solutionContextSetSpecifier,
                                out TypeSpecifier<SolutionContext001> solutionContextSpecifier,
                                solutionSpecification,
                                solutionSetContextPropertiesSet,
                                out ContextPropertiesSet<SolutionContext001, (
                                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                    IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
                                out var checkedSolutionFileExists,
                                // Add project to the solution.
                                Instances.ProjectContextOperations.Add_ProjectToSolution<SolutionSetContext002, SolutionContext001>(
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionSetContext002>().For(solutionSetContext_ProjectFilePathSet.PropertiesSet),
                                    Instances.ContextOperator.Get_ContextPropertiesSet<SolutionContext001>().For(solutionContextPropertiesSet.PropertiesSet.SolutionFilePathSet),
                                    out var checkedSolutionHasProject).In_ContextSetAndContext(solutionContextSetSpecifier, solutionContextSpecifier),
                                // Set the solution file path.
                                (solutionContextSet, solutionContext) =>
                                {
                                    var solutionSetContext = solutionContextSet.Get_Context(solutionSetContextSpecifier);

                                    solutionSetContext.SolutionFilePath = solutionContext.SolutionFilePath;

                                    return Task.CompletedTask;
                                }
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier),
                        // Push all files using Git.
                        Instances.RepositoryContextOperations.Push_AllFiles<RepositoryContext001, ApplicationContext001>(
                            Instances.CommitMessages.InitialCommit,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(repositoryContextPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                                applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                            out var checkedLocalChangesPushedToRemote).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );

            // Checks.
            Instances.CheckLists.Ensure_RequiredChecks_ForRepository(
                checkedRepository.GitHubRepositoryExists,
                checkedRepository.LocalRepositoryExists,
                checkedRepository.GitIgnoreFileExists,
                checkedLocalChangesPushedToRemote
            );

            Instances.CheckLists.Ensure_RequiredChecks_ForSolution(
                checkedSolutionFileExists,
                checkedSolutionHasProject
            );

            Instances.CheckLists.Ensure_RequiredChecks_ForProject(
                checkedConsoleProject.ConsoleProjectFileExists,
                checkedSolutionHasProject,
                checkedConsoleProject.ProgramFileExists,
                checkedConsoleProject.DocumentationFileExists,
                checkedConsoleProject.InstancesFileExists,
                checkedConsoleProject.ProjectPlanFileExists
            );
        }

        public class In_CreatedRemoteRepositoryContext_GlobalContext :
            IWithAuthentication
        {
            public Authentication Authentication { get; set; }
            Authentication L0085.IWithX<Authentication>.X { get => this.Authentication; set => this.Authentication = value; }
            Authentication L0085.IHasX<Authentication>.X => this.Authentication;
        }

        /// <summary>
        /// Deletes the repository if it exists, then creates a new repository.
        /// </summary>
        public async Task Generate_Repository()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var repositoryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var privacyAdjustedRepositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = privacyAdjustedRepositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var solutionSpecification = new SolutionSpecification
            {
                Name = repositorySpecification.Name,
            };

            var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(repositoryName);
            var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(repositoryDescription);

            var projectSpecification = new ProjectSpecification
            {
                Name = projectName,
                Description = projectDescription,
            };

            var gitHubAuthor = Instances.JsonOperator.Load_FromFile_Synchronous<Author>(
                Instances.Values.GitHubAuthorJsonFilePath,
                "GitHubAuthor");
            var nuGetAuthor = Instances.Authors.DCoats;

            await Instances.RepositoryOperator.In_RepositoryContext(
                repositorySpecification.Organization,
                repositorySpecification.Name,
                // Ensure the repository does not exist, both remotely and locally.
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<GitHubClientedRepositoryContext>(
                        (context, gitHubRepositoryExisted) =>
                        {
                            Console.WriteLine($"{gitHubRepositoryExisted}: GitHub-repository-existed, {context.RepositoryOwnerName}/{context.RepositoryName}");

                            return Task.CompletedTask;
                        }
                    )
                ),
                Instances.ContextOperations.In_ChildContext_O01<SimpleRepositoryContext, LocalRepositoryContext>(
                    context =>
                    {
                        var childContext = new LocalRepositoryContext
                        {
                            RepositoryOwnerName = context.RepositoryOwnerName,
                            RepositoryName = context.RepositoryName,
                        };

                        return Task.FromResult(childContext);
                    },
                    Instances.CloneRepositoryLocallyContextOperations.Set_RepositoriesDirectoryPath,
                    Instances.CloneRepositoryLocallyContextOperations.Set_RepositoryDirectoryPath,
                    Instances.LocalRepositoryContextOperations.Delete_LocalRepositoryDirectory_Idempotent<LocalRepositoryContext>(
                        (context, directoryExisted) =>
                        {
                            Console.WriteLine($"{directoryExisted}: local-repository-directory-existed, {context.RepositoryOwnerName}/{context.RepositoryName}\n\t{context.RepositoryDirectoryPath}");

                            return Task.CompletedTask;
                        }
                    )
                ),
                // Now create a new repository.
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    Instances.GitHubClientContextOperations.In_NewRepositoryContext<GitHubClientedRepositoryContext>(
                        repositorySpecification,
                        Instances.RepositoryContextOperations.In_CloneRepositoryLocallyContext<GitHubRepositoryContext>(
                            out _,
                            Instances.CloneRepositoryLocallyContextOperations.Set_RepositoriesDirectoryPath,
                            Instances.CloneRepositoryLocallyContextOperations.Set_RepositoryDirectoryPath,
                            Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                            Instances.SetGitHubClientContextOperations.Load_Authentication,
                            Instances.GitContextOperations.Clone_ToLocalRepositoryDirectory_ByAuthentication,
                            // In a Git-push context.
                            Instances.GitContextOperations.In_GitPushContext<CloneRepositoryLocallyContext>(
                                Instances.CommitMessages.InitialCommit,
                                gitHubAuthor.Name,
                                gitHubAuthor.EmailAddress,
                                //context =>
                                //{
                                //    var gitIgnoreSourceFilePath = Instances.FilePaths.GitIgnoreTemplateFilePath;
                                //    var gitIgnoreDestinationFilePath = Instances.RepositoryPathsOperator.Get_GitIgnoreFilePath(context.RepositoryDirectoryPath);

                                //    Instances.FileSystemOperator.Copy_File(
                                //        gitIgnoreSourceFilePath,
                                //        gitIgnoreDestinationFilePath);

                                //    return Task.CompletedTask;
                                //},
                                Instances.RepositoryContextOperations.Add_GitIgnoreFile<CloneRepositoryLocallyContext>(
                                    new IsSet<IHasRepositoryDirectoryPath>(),
                                    out _
                                ),
                                Instances.LocalRepositoryContextOperations.In_SolutionDirectoryContext<CloneRepositoryLocallyContext>(
                                    out _,
                                    Instances.SolutionDirectoryContextOperations.Set_SolutionDirectory_Source,
                                    Instances.SolutionDirectoryContextOperations.In_SolutionContext<SolutionDirectoryContext>(solutionSpecification,
                                        out (
                                        IsSet<IHasSolutionName> SolutionNameSet,
                                        IsSet<IHasSolutionDirectoryPath> SolutionDirectoryPathSet,
                                        IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                                        ) solutionSpecificationPropertiesSet,
                                        Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<SolutionFileContext>(),
                                        Instances.SolutionFileContextOperations.Set_SolutionFilePath<SolutionFileContext>((solutionSpecificationPropertiesSet.SolutionNameSet, solutionSpecificationPropertiesSet.SolutionDirectoryPathSet),
                                            out var solutionFilePathSet),
                                        Instances.SolutionFileContextOperations.Verify_SolutionFile_DoesNotExist<SolutionFileContext>(solutionFilePathSet,
                                            out var solutionFileDoesNotExist),
                                        // Create solution file (including direcctory for file if it does not exist).
                                        Instances.HasDirectoryPathContextOperations.Create_Directory_IfNotExists<SolutionFileContext>(
                                            out var solutionDirectoryExists),
                                        Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionFileContext>(
                                            solutionFileDoesNotExist,
                                            out var solutionfileExists),
                                        // In project context (a project context that includes solution information).
                                        Instances.SolutionFileContextOperations.In_ProjectContext<SolutionFileContext>(
                                            projectSpecification,
                                            out _,
                                            Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<ProjectContext>(),
                                            // Set project directory from solution directory and name.
                                            Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext>(out _),
                                            // Set the project file path.
                                            Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext>(out _),
                                            // Verify project file does not exist.
                                            Instances.HasFilePathContextOperations.Verify_File_DoesNotExist<ProjectContext>(out _),
                                            // Create project file, by running project element context operations.
                                            Instances.ProjectContextOperations.In_CreateProjectFileContext<ProjectContext>(
                                                out _,
                                                context =>
                                                {
                                                    var projectXElementContextOperations = Instances.ProjectXElementOperationSets.Console_Net_8(
                                                        context.ProjectFilePath,
                                                        context.ProjectDescription,
                                                        nuGetAuthor.Value,
                                                        Instances.EnumerableOperator.Empty<string>(),
                                                        propertyGroupXElement =>
                                                        {
                                                            // Use the solution file path, since it should exist by now.
                                                            var repositoryUrl = Instances.GitOperator.Get_RepositoryUrl(context.SolutionFilePath);

                                                            Instances.PropertyGroupXElementOperator.Set_RepositoryUrl(
                                                                propertyGroupXElement,
                                                                repositoryUrl);
                                                        });

                                                    return projectXElementContextOperations;
                                                }
                                            ),
                                            // Add the project to the solution.
                                            Instances.ProjectContextOperations.Add_ProjectToSolution<ProjectContext>(
                                                out var solutionHasProjectChecked
                                            ),
                                            // Add files to the project.
                                            // First, set the namespace name.
                                            Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext>(out _),
                                            //Instances.ProjectContextOperations.In_CodeFileContext<ProjectContext>(
                                            //    out _,
                                            //    Instances.CodeFileContextOperations.Set_FilePath<CodeFileContext>(
                                            //        Instances.ProjectDirectoryPathRelativePaths.Program_cs,
                                            //        out _
                                            //    ),
                                            //    //Instances.CodeFileContextOperations.Create_ProgramFile_ForConsole<CodeFileContext>(
                                            //    //    out _
                                            //    //)
                                            //    Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForConsole<CodeFileContext>(
                                            //        out _
                                            //    )
                                            //)
                                            Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForConsole<ProjectContext>(
                                                out _
                                            )
                                        ),
                                        // Finally, open the solution.
                                        context =>
                                        {
                                            Instances.VisualStudioOperator.Open_SolutionFile(context.SolutionFilePath);

                                            return Task.CompletedTask;
                                        }
                                    )
                                )
                            ),
                            // Finally, open the output directory.
                            context =>
                            {
                                Instances.WindowsExplorerOperator._Platform.Open(context.RepositoryDirectoryPath);

                                return Task.CompletedTask;
                            }
                        )
                    )
                )
            //Instances.RepositoryContextOperations
            // Create the repository remotely, and clone locally.
            );
        }

        /// <summary>
        /// Creates a GitHub remote repository, then explores running operations in the context of that GitHub remote repository.
        /// </summary>
        public async Task In_CreatedRemoteRepositoryContext()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var repositoryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var privacyAdjustedRepositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = privacyAdjustedRepositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            // Lame, in that you have to do extra work.
            // But at least you get a reference type that can be passed into 
            var globalContext = new In_CreatedRemoteRepositoryContext_GlobalContext();

            //// Does not work!
            //var globalContext = new(Authentication GitHubAuthentication, string x);

            //static (Authentication GitHubAuthentication, string x) Construct_GlobalContext()
            //{
            //    return (null, "");
            //}

            //// This is a value tuple, which is dangerous, because if you pass it to a method (instead of just using it in the current scope)
            // changes to properties of the context will not persist (since the value-type instance inside the method is not the same instance as outside the method).
            //var globalContext = Construct_GlobalContext();

            await Instances.RepositoryOperator.In_RepositoryContext(
                repositoryOwnerName,
                privacyAdjustedRepositoryName,
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    // Save the GitHub authentication for later use, since loading it from the file system does involve time.
                    //context =>
                    //{
                    //    globalContext.Authentication = context.Authentication;

                    //    return Task.CompletedTask;
                    //},
                    Instances.HasAuthenticationContextOperations.Set_AuthenticationTo_Better(globalContext),
                    Instances.GitHubClientContextOperations.In_NewRepositoryContext<GitHubClientedRepositoryContext>(
                        repositorySpecification,
                        Instances.RepositoryContextOperations.Is_Private<GitHubRepositoryContext>(
                            Instances.RepositoryContextOperations.Display_IsPrivate_ToConsole
                        ),
                        Instances.RepositoryContextOperations.In_CloneRepositoryLocallyContext<GitHubRepositoryContext>(
                            out _,
                            Instances.CloneRepositoryLocallyContextOperations.Set_RepositoriesDirectoryPath,
                            Instances.CloneRepositoryLocallyContextOperations.Set_RepositoryDirectoryPath,
                            //// Load the GitHub client authentication, using the same methods as work in any {IHasGitHubAuthenticationJsonFilePath, IHasGitHubAuthentication} context! Yay!!!
                            //Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                            //Instances.SetGitHubClientContextOperations.Load_Authentication,
                            // Use the GitHub authentication from the global context.
                            //context =>
                            //{
                            //    context.Authentication = globalContext.Authentication;

                            //    return Task.CompletedTask;
                            //},
                            Instances.HasAuthenticationContextOperations.Set_AuthenticationFrom_Better(globalContext),
                            Instances.GitContextOperations.Clone_ToLocalRepositoryDirectory_ByAuthentication,
                            // Open the output directory.
                            context =>
                            {
                                Instances.WindowsExplorerOperator._Platform.Open(context.RepositoryDirectoryPath);

                                return Task.CompletedTask;
                            }
                        )
                    )
                )
            );
        }

        /// <summary>
        /// Only creates a remote (GitHub) repository.
        /// Does not clone the repository local, or add any local files.
        /// </summary>
        public async Task Create_RemoteRepositoryOnly()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var repositoryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var privacyAdjustedRepositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = privacyAdjustedRepositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            await Instances.RepositoryOperator.In_RepositoryContext(
                repositoryOwnerName,
                privacyAdjustedRepositoryName,
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    //Instances.GitHubClientContextOperations.Verify_Repository_DoesNotExist,
                    Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent_I01<GitHubClientedRepositoryContext>(
                        repositorySpecification
                    )
                //Instances.GitHubClientContextOperations.In_RepositoryContext<GitHubClientedRepositoryContext>(

                //)
                //Instances.GitHubClientContextOperations.In_ExistingRepositoryContext<GitHubClientedRepositoryContext>(
                //    Instances.RepositoryContextOperations.Is_Private<GitHubRepositoryContext>(
                //        Instances.RepositoryContextOperations.Display_IsPrivate_ToConsole
                //    )
                //)
                )
            );
        }

        public async Task Delete_RemoteRepositoryOnly()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                //Instances.RepositoryNameExamples.Disposable
                "R5T.R0014"
                ;
            var isPrivate =
                false
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                //Instances.RepositoryOwnerNameExamples.davidcoats
                ;
            var repositoryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var privacyAdjustedRepositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = privacyAdjustedRepositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            await Instances.RepositoryOperator.In_RepositoryContext(
                repositoryOwnerName,
                privacyAdjustedRepositoryName,
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    //Instances.GitHubClientContextOperations.Verify_Repository_Exists,
                    //Instances.GitHubClientContextOperations.Delete_Repository_NonIdempotent
                    Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<GitHubClientedRepositoryContext>(
                        (context, wasDeleted) =>
                        {
                            Console.WriteLine($"{wasDeleted}: was-deleted {context.RepositoryOwnerName}/{context.RepositoryName}");

                            return Task.CompletedTask;
                        }
                    )
                //Instances.GitHubClientContextOperations.In_RepositoryContext<GitHubClientedRepositoryContext>(

                //)
                )
            );
        }

        /// <summary>
        /// Queries a remote GitHub repository to find out:
        /// * Does it exist? (query at the GitHub client-level)
        /// * Is it private? (query at the GitHub repository-level)
        /// </summary>
        public async Task Query_GitHubRepository()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var repositoryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var privacyAdjustedRepositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = privacyAdjustedRepositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            await Instances.RepositoryOperator.In_RepositoryContext(
                repositoryOwnerName,
                privacyAdjustedRepositoryName,
                Instances.RepositoryContextOperations.In_GitHubClientContext<SimpleRepositoryContext>(
                    Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<GitHubClientedRepositoryContext>(
                        //context =>
                        //{
                        //    context.GitHubClient
                        //}
                    ),
                    Instances.GitHubClientContextOperations.In_SetGitHubClientContext<GitHubClientedRepositoryContext>(
                        Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<SetGitHubClientContext>(
                            //context =>
                            //{
                            //    context.GitHubClient
                            //}
                        ),
                        Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                        Instances.SetGitHubClientContextOperations.Load_Authentication,
                        Instances.SetGitHubClientContextOperations.Set_GitHubClient
                    ),
                    Instances.GitHubClientContextOperations.Display_CurrentUser_ToConsole,
                    Instances.GitHubClientContextOperations.Exists_Repository<GitHubClientedRepositoryContext>(
                        Instances.RepositoryContextOperations.Display_ExistsRepository_ToConsole),
                    Instances.GitHubClientContextOperations.In_RepositoryContext<GitHubClientedRepositoryContext>(
                        Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<GitHubRepositoryContext>(
                            //context =>
                            //{
                            //    context.GitHubClient
                            //}
                        ),
                        Instances.RepositoryContextOperations.Get_Repository,
                        Instances.RepositoryContextOperations.Is_Private<GitHubRepositoryContext>(
                            Instances.RepositoryContextOperations.Display_IsPrivate_ToConsole
                        )
                    )
                )
            );
        }

        /// <summary>
        /// A first script to just login to GitHub using the Octokit client.
        /// </summary>
        public async Task Get_GitHubClient()
        {
            /// Inputs.
            

            /// Run.
            await Instances.GitHubOperator.In_GitHubClientContext(
                Instances.GitHubClientContextOperations.In_SetGitHubClientContext<GitHubClientContext>(
                    Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                    Instances.SetGitHubClientContextOperations.Load_Authentication,
                    Instances.SetGitHubClientContextOperations.Set_GitHubClient
                ),
                Instances.GitHubClientContextOperations.Verify_IsWorking
            );
        }
    }
}
