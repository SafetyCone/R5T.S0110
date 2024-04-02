using System;
using System.Threading.Tasks;

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
using R5T.T0221;
using R5T.T0235.T000;
using R5T.Z0046;

using R5T.S0110.Contexts;
using System.Collections.Generic;


namespace R5T.S0110
{
    public partial interface IScripts
    {
        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository_Old()
        {
            /// Inputs.
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

            static Func<ProjectContext001, SolutionSetContext003, Task> Set_LibraryProjectFilePath(
                out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet)
            {
                return (projectContext, solutionSetContext) =>
                {
                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                    return Task.CompletedTask;
                };
            }

            static Func<TSolutionContext, SolutionSetContext003, Task> Set_LibrarySolutionFilePath<TSolutionContext>(
                out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasProjectFilePath>> librarySolutionFilePathSet)
                where TSolutionContext : IHasSolutionFilePath
            {
                return (solutionContext, solutionSetContext) =>
                {
                    solutionSetContext.LibrarySolutionFilePath = solutionContext.SolutionFilePath;

                    return Task.CompletedTask;
                };
            }

            static Func<ProjectContext001, SolutionSetContext003, Task> Set_ConstructionProjectFilePath(
                out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet)
            {
                return (projectContext, solutionSetContext) =>
                {
                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                    return Task.CompletedTask;
                };
            }

            static Func<TSolutionContext, SolutionSetContext003, Task> Set_ConstructionSolutionFilePath<TSolutionContext>(
                out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasProjectFilePath>> librarySolutionFilePathSet)
                where TSolutionContext : IHasSolutionFilePath
            {
                return (solutionContext, solutionSetContext) =>
                {
                    solutionSetContext.ConstructionSolutionFilePath = solutionContext.SolutionFilePath;

                    return Task.CompletedTask;
                };
            }

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out ContextSetSpecifier<ApplicationContextSet002> applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ApplicationContextSet002, RepositoryContextSet003>().For_Contexts(applicationContextSpecifier),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet
                        ),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet)> repositoryPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet004, RepositoryContextSet003, SolutionSetContext003, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.For_ContextSets<RepositoryContextSet003, SolutionSetContextSet004>().For_Contexts(
                                repositoryContextSpecifier,
                                applicationContextSpecifier),
                            out ContextSetSpecifier<SolutionSetContextSet004> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext003> solutionSetContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                repositoryPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext003, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            Instances.SolutionSetContextSetOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<ProjectContextSet005, SolutionSetContextSet004, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Library,
                                out var projectContextSpecifier_Library,
                                libraryProjectSpecification,
                                projectOptions,
                                solutionSetContextPropertiesSet,
                                Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                    repositoryPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                out var checkedProjectFileExists_Library,
                                Instances.EnumerableOperator.From(
                                    // Set the project file path.
                                    Set_LibraryProjectFilePath(out var libraryProjectFilePathSet).In_ContextSet(projectContextSetSpecifier_Library)
                                )
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContext003>(librarySolutionSpecification, solutionSetContextPropertiesSet.PropertiesSet,
                                out var checkedSolutionFileExists_Library,
                                Instances.EnumerableOperator.From(
                                    (solutionContext, solutionSetContext) =>
                                    {
                                        Instances.SolutionOperator.AddProjects_Idempotent(
                                            solutionContext.SolutionFilePath,
                                            solutionSetContext.LibraryProjectFilePath);

                                        return Task.CompletedTask;
                                    },
                                    Set_LibrarySolutionFilePath<Context003>(out var librarySolutionFilePathSet)
                                )
                            ).In_ContextSetWithContext(solutionSetContextSetSpecifier),
                            // Create the construction project.
                            Instances.SolutionSetContextSetOperations.Create_StaticHtmlWebApplicationProject<SolutionSetContextSet004, ProjectContextSet005, SolutionSetContext003>(
                                Instances.ContextSetIsomorphisms.For_ContextSets<SolutionSetContextSet004, ProjectContextSet005>().For_Contexts(
                                    solutionSetContextSpecifier,
                                    repositoryContextSpecifier,
                                    applicationContextSpecifier),
                                out ContextSetSpecifier<ProjectContextSet005> projectContextSetSpecifier_Construction,
                                out var projectContextSpecifier_Construction,
                                constructionProjectSpecification,
                                projectOptions,
                                solutionSetContextPropertiesSet,
                                Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                    repositoryPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                out var checkedProjectFileExists_Construction,
                                Instances.EnumerableOperator.From(
                                    // Overwrite the Index.razor file to use the library's Component1.
                                    Instances.CodeFileGenerationContextOperations.Create_IndexRazorComponentFile_ForStaticHtmlWebApplication_WithLibrary<ProjectContext001>(
                                        (Instances.IsSetOperator.IsSet<IHasProjectFilePath>(), Instances.IsSetOperator.IsSet<IHasNamespaceName>()),
                                        out _
                                    ).In_ContextSetWithContext(projectContextSetSpecifier_Construction),
                                    // Add the library project reference.
                                    (projectContextSet, projectContext) =>
                                    {
                                        return Instances.ProjectFileOperator.AddProjectReference_Idempotent(
                                            projectContext.ProjectFilePath,
                                            projectContextSet.SolutionSetContext.LibraryProjectFilePath);
                                    },
                                    // Set the project file path.
                                    Set_ConstructionProjectFilePath(out var constructionProjectFilePathSet).In_ContextSetWithContext(projectContextSetSpecifier_Library)
                                )
                            ).In_ContextSetWithContext(solutionSetContextSpecifier),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContext003>(constructionSolutionSpecification, solutionSetContextPropertiesSet.PropertiesSet,
                                out var checkedSolutionFileExists_Construction,
                                Instances.EnumerableOperator.From(
                                    (solutionContext, solutionSetContext) =>
                                    {
                                        Instances.SolutionOperator.AddProjects_Idempotent(
                                            solutionContext.SolutionFilePath,
                                            solutionSetContext.ConstructionProjectFilePath,
                                            solutionSetContext.LibraryProjectFilePath);

                                        return Task.CompletedTask;
                                    },
                                    Set_ConstructionSolutionFilePath<Context003>(out var constructionSolutionFilePathSet)
                                )
                            ).In_ContextSetWithContext(solutionSetContextSetSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext003>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibraryRepository_Old()
        {
            /// Inputs.
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

            //static Func<ContextSet003, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProject(
            //    ProjectSpecification projectSpecification,
            //    ProjectOptions projectOptions,
            //    ContextPropertiesSet<SingleProjectSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesRequired,
            //    ContextPropertiesSet<Context001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesSet,
            //    out ContextPropertiesSet<SingleProjectSolutionSetContext, IsSet<IHasProjectFilePath>> solutionSetContextPropertiesSet,
            //    out IChecked<IFileExists> checkedProjectFileExists)
            ////where TContextSet : IHasContext<TSolutionSetContext>, IHasContext<TRepositoryContext>
            ////where TSolutionSetContext : IHasSolutionDirectoryPath
            ////where TRepositoryContext : IHasRepositoryUrl
            //{
            //    var output = Instances.ProjectContextOperations.In_ProjectContext<ContextSet004, ContextSet003, ProjectContext001, SingleProjectSolutionSetContext>(
            //        out ContextSetSpecifier<ContextSet004> projectContextSetSpecifier,
            //        out TypeSpecifier<ProjectContext001> projectContextSpecifier,
            //        projectSpecification,
            //        solutionSetContextPropertiesRequired,
            //        out ContextPropertiesSet<ProjectContext001, (
            //            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            //            IsSet<IHasProjectName> ProjectNameSet,
            //            IsSet<IHasProjectDescription> ProjectDescriptionSet,
            //            IsSet<IHasNamespaceName> NamespaceNameSet,
            //            IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            //            IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesSet,
            //        //Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile(
            //        Instances.ProjectContextSetOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile(
            //            projectOptions,
            //            Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(
            //                projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
            //                projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
            //            out checkedProjectFileExists).In_ContextSetAndContext(projectContextSpecifier),
            //        // Create project's files.
            //        Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
            //            out var checkedDocumentationFileExists).In_ContextSetAndContext(projectContextSetSpecifier),
            //        Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
            //            out var checkedInstancesFileExists).In_ContextSetAndContext(projectContextSetSpecifier),
            //        Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.ProjectNameSet, projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet),
            //            out var checkedProjectPlanFileExists).In_ContextSetAndContext(projectContextSetSpecifier),
            //        Instances.CodeFileGenerationContextOperations.Create_Component1File<ProjectContext001>((projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet, projectContextPropertiesSet.PropertiesSet.NamespaceNameSet),
            //            out var checkedComponent1FileExists).In_ContextSetAndContext(projectContextSetSpecifier),
            //        Instances.CodeFileGenerationContextOperations.Create_WwwrootDirectory<ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
            //            out var checkedWwwrootDirectoryExists).In_ContextSetAndContext(projectContextSetSpecifier),
            //        // Set the project file path.
            //        Instances.SolutionSetContextOperations.Set_ProjectFilePath<ProjectContext001, SingleProjectSolutionSetContext>(
            //            out var libraryProjectFilePathSet).In_ContextSetAndContext(projectContextSetSpecifier)
            //    );

            //    return output;
            //}

            //static Func<ContextSet004, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile(
            //    ProjectOptions projectOptions,
            //    ContextPropertiesSet<ProjectContext001, (
            //        IsSet<IHasProjectFilePath> ProjectFilePathSet,
            //        IsSet<IHasProjectDescription> ProjectDescriptionSet
            //    )> projectContextPropertiesSet,
            //    out IChecked<IFileExists> checkedProjectFileExists)
            ////where TProjectContext : IHasProjectFilePath, IHasProjectDescription
            ////where TRepositoryContext : IHasRepositoryUrl
            //{
            //    var o = Instances.ContextOperations;

            //    var output = o.In_ChildContextSet<ContextSet005, ContextSet004>(
            //        out _,
            //        o.In_Context_OfContextSet<ContextSet005, Context005>(
            //            out ContextSetSpecifier<ContextSet005> projectElementContextSetSpecifier,
            //            out TypeSpecifier<Context005> context005Specifier,
            //            o.Construct_Context_OfContextSet<ContextSet005, Context005>(
            //                Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
            //                    out var projectElementContextProjectFilePathSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
            //                Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
            //                    out var projectElementContextProjectDescriptionSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
            //                Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
            //                    out var projectElementSet).In_ContextSetAndContext(projectElementContextSetSpecifier)
            //            ),
            //            Instances.ProjectElementContextOperations.Set_SDK_Razor<Context005>().In_ContextSetAndContext(projectElementContextSetSpecifier),
            //            Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<ContextSet006, ContextSet005, Context005>(
            //                out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier,
            //                out var contextSpecifiers,
            //                projectOptions,
            //                out ContextPropertiesSet<Context006, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
            //                out var checkedPropertyGroupElementAppended_Main,
            //                Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
            //                // Change the target framework from what is specified in the project options, to the library default.
            //                Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
            //            ).In_ContextSetAndContext(context005Specifier),
            //            o.CaptureContext<Context001>(
            //                out var repositoryContextCapture).In_ContextSetAndDifferentContext(
            //                    projectElementContextSetSpecifier,
            //                    context005Specifier),
            //            Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<ContextSet006, ContextSet005, Context005>(
            //                out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier_Package,
            //                out contextSpecifiers,
            //                projectOptions,
            //                Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(
            //                    projectElementSet,
            //                    projectElementContextProjectDescriptionSet),
            //                out ContextPropertiesSet<ProjectOptionsContext,
            //                    IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            //                out ContextPropertiesSet<Context006,
            //                    IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
            //                out var checkedPropertyGroupElementAppended,
            //                Instances.EnumerableOperator.From(
            //                    // Add the repository URL.
            //                    Instances.ContextOperations.In_ContextSet<Context006, Context001>(
            //                        repositoryContextCapture,
            //                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
            //                            propertyGroupContextPropertiesSet_Package.PropertiesSet,
            //                            repositoryContext => Task.FromResult(repositoryContext.RepositoryUrl),
            //                            out _)
            //                    ).In_ContextSet(propertyGroupContextSetSpecifier_Package)
            //                )
            //            ).In_ContextSetAndContext(context005Specifier),
            //            // Add the package reference item group.
            //            Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ContextSet007, ContextSet005, Context005>(
            //                out ContextSetSpecifier<ContextSet007> itemGroupElementContextSetSpecifier,
            //                out var itemGroupElementContextSpecifier,
            //                Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
            //                out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
            //                out var checkedItemGroupElementAppended_PackageReferences,
            //                Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
            //                    itemGroupElementContextPropertiesSet.PropertiesSet,
            //                    Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_8_0_0).In_ContextSet(itemGroupElementContextSetSpecifier)
            //            ).In_ContextSetAndContext(context005Specifier),
            //            //// Add the wwwroot folder include item group.
            //            Instances.ProjectElementContextOperations.Add_ItemGroupElement<ContextSet007, ContextSet005, Context005>(
            //                out itemGroupElementContextSetSpecifier,
            //                out itemGroupElementContextSpecifier,
            //                Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
            //                out itemGroupElementContextPropertiesSet,
            //                out var checkedItemGroupElementAppended,
            //                Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
            //                    itemGroupElementContextPropertiesSet.PropertiesSet,
            //                    @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
            //            ).In_ContextSetAndContext(context005Specifier),
            //            Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
            //                out checkedProjectFileExists).In_ContextSetAndContext(projectElementContextSetSpecifier)
            //        )
            //    );

            //    return output;
            //}

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<ApplicationContextSet002>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ApplicationContextSet002, ApplicationContext001>(
                    out ContextSetSpecifier<ApplicationContextSet002> applicationContextSetSpecifier,
                    out TypeSpecifier<ApplicationContext001> applicationContextSpecifier,
                    out ContextPropertiesSet<ApplicationContext001, (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<RepositoryContextSet003, ApplicationContextSet002, RepositoryContext001, ApplicationContext001>(
                        Instances.ContextSetIsomorphisms.From_ContextSet<ApplicationContextSet002, RepositoryContextSet003, ApplicationContext001>(),
                        out ContextSetSpecifier<RepositoryContextSet003> repositoryContextSetSpecifier,
                        out TypeSpecifier<RepositoryContext001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ApplicationContext001>().For(
                            applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet
                        ),
                        out ContextPropertiesSet<RepositoryContext001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet)> repositoryPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SolutionSetContextSet003, RepositoryContextSet003, SolutionSetContext002, RepositoryContext001>(
                            Instances.ContextSetIsomorphisms.From_ContextSet<RepositoryContextSet003, SolutionSetContextSet003, RepositoryContext001, ApplicationContext001>(),
                            out ContextSetSpecifier<SolutionSetContextSet003> solutionSetContextSetSpecifier,
                            out TypeSpecifier<SolutionSetContext002> solutionContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                repositoryPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<SolutionSetContext002, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            //Create_NonWebAssemblyRazorComponentRazorClassLibraryProject(
                            Instances.SolutionSetContextSetOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<ProjectContextSet004, SolutionSetContextSet003, SolutionSetContext002>(
                                Instances.ContextSetIsomorphisms.From_ContextSet<SolutionSetContextSet003, ProjectContextSet004, SolutionSetContext002, RepositoryContext001, ApplicationContext001>(),
                                out ContextSetSpecifier<ProjectContextSet004> projectContextSetSpecifier,
                                out var projectContextSpecifier,
                                projectSpecification,
                                projectOptions,
                                solutionSetContextPropertiesSet,
                                Instances.ContextOperator.Get_ContextPropertiesSet<RepositoryContext001>().For(
                                    repositoryPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                out var checkedProjectFileExists,
                                //Instances.EnumerableOperator.Empty<Func<ContextSet004, Task>>()
                                Instances.EnumerableOperator.From(
                                    // Set the project file path.
                                    Instances.SolutionSetContextOperations.Set_ProjectFilePath<ProjectContext001, SolutionSetContext002>(
                                        out var libraryProjectFilePathSet).In_ContextSet(projectContextSetSpecifier)
                                )
                            ).In_ContextSetWithContext(solutionContextSpecifier),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<SolutionSetContext002>(solutionSpecification, (solutionSetContextPropertiesSet.PropertiesSet, libraryProjectFilePathSet.PropertiesSet),
                                out var solutionFilePathSet,
                                out var checkedSolutionFileExists).In_ContextSetWithContext(solutionSetContextSetSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SolutionSetContext002>(
                                x => Task.FromResult(x.SolutionFilePath)).In_ContextSetWithContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetWithContext(repositoryContextSpecifier)
                    ).In_ContextSetWithContext(applicationContextSpecifier)
                )
            );
        }

        /// <summary>
        /// Regenerate a repository containing a web application that produces
        /// </summary>
        /// <remarks>
        /// This is based on example solution D8S.E0013-P0003.
        /// </remarks>
        public async Task Regenerate_StaticHtmlWebApplicationRepository_Old()
        {
            /// Inputs.
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

            //static Func<ProjectContext001, SingleProjectSolutionSetContext, Task> Set_ProjectFilePath(
            //    out ContextPropertiesSet<SingleProjectSolutionSetContext, IsSet<IHasProjectFilePath>> projectFilePathSet)
            //{
            //    return (projectContext, solutionSetContext) =>
            //    {
            //        solutionSetContext.ProjectFilePath = projectContext.ProjectFilePath;

            //        return Task.CompletedTask;
            //    };
            //}

            static Func<SingleProjectSolutionSetContext, Task> Create_StaticHtmlWebApplicationProject(
                ProjectSpecification projectSpecification,
                ProjectOptions projectOptions,
                IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                ContextCapture<Context001> context001Capture,
                ContextPropertiesSet<Context001, IsSet<IHasRepository>> repositoryContextPropertiesSet,
                out ContextPropertiesSet<SingleProjectSolutionSetContext, IsSet<IHasProjectFilePath>> projectFilePathSet,
                out IChecked<IFileExists> checkedProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, SingleProjectSolutionSetContext>();

                return Instances.ProjectContextOperations.In_ProjectContext<SingleProjectSolutionSetContext>(
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
                    o.Get<ProjectContext001, (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>)>(
                        (projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
                        out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) codeFilePropertiesRequired).In(contextSet),
                    Create_StaticHtmlApplicationProjectFile2(
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectDescriptionSet),
                        context001Capture,
                        repositoryContextPropertiesSet,
                        out checkedProjectFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet, projectPropertiesSet.ProjectDescriptionSet),
                        out var checkedDocumentationFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>(codeFilePropertiesRequired,
                        out var checkedInstancesFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectNameSet, projectPropertiesSet.ProjectDescriptionSet),
                        out var checkedProjectPlanFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                        out var checkedProgramFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_HostRazorPageFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                        out var checkedHostFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_AppRazorComponentFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                        out var checkedAppFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_IndexRazorComponentFile_ForStaticHtmlWebApplication<ProjectContext001>(codeFilePropertiesRequired,
                        out var checkedIndexFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_AppSettingsJsonFile<ProjectContext001>(projectPropertiesSet.ProjectFilePathSet,
                        out var checkedAppSettingsJsonFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_DevelopmentAppSettingsJsonFile<ProjectContext001>(projectPropertiesSet.ProjectFilePathSet,
                        out var checkedDevelopmentAppSettingsJsonFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_LaunchSettingsJsonFile<ProjectContext001>(projectPropertiesSet.ProjectFilePathSet,
                        out var checkedLaunchSettingsJsonFileExists).In(contextSet),
                    Instances.SolutionSetContextOperations.Set_ProjectFilePath<ProjectContext001, SingleProjectSolutionSetContext>(
                        out projectFilePathSet)
                );
            }

            static Func<ProjectContext001, Task> Create_StaticHtmlApplicationProjectFile2(
                ProjectOptions projectOptions,
                ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
                )> projectContextPropertiesSet,
                ContextCapture<Context001> context001Capture,
                ContextPropertiesSet<Context001, IsSet<IHasRepository>> repositoryContextPropertiesSet,
                out IChecked<IFileExists> checkedProjectFileExists)
            {
                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, Context001>();
                var propertyGroupElementContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

                return Create_StaticHtmlApplicationProjectFile(
                    projectOptions,
                    projectContextPropertiesSet,
                    out IsSet<IHasPropertyGroupElement> propertyGroupElementSet_Package,
                    out checkedProjectFileExists,
                    Instances.EnumerableOperator.From(
                        Instances.ContextOperations.In_ContextSet<Context006, Context001>(
                            context001Capture,
                            Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                                propertyGroupElementSet_Package,
                                context001 => Task.FromResult(context001.Repository.HtmlUrl),
                                out _)
                        ).In(propertyGroupElementContextSet)
                    )
                );
            }

            static Func<ProjectContext001, Task> Create_StaticHtmlApplicationProjectFile(
                ProjectOptions projectOptions,
                ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
                )> projectContextPropertiesSet,
                out IsSet<IHasPropertyGroupElement> propertyGroupElementSet_Package,
                out IChecked<IFileExists> checkedProjectFileExists,
                IEnumerable<Func<Context006, Context005, ProjectOptionsContext, Task>> packagePropertyGroupElementOperations = default)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001>();
                var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

                var output = o.In_ContextSet_A_BA<Context005, ProjectContext001>(
                    o.Construct_Context_B_BA<Context005, ProjectContext001>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet),
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                            out var projectElementSet).In(contextSet)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Web<Context005>().In(contextSet),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main(
                        projectOptions,
                        out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet_Main,
                        out var projectOptionsContextPropertiesSet,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupContextSet)
                    ).In(contextSet),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package(
                        projectOptions,
                        projectElementContextProjectDescriptionSet,
                        out ContextPropertiesSet<Context006, (
                            IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                            IsSet<IHasCompany> CompanySet,
                            IsSet<IHasCopyright> CopyrightSet,
                            IsSet<IHasProjectDescription> DescriptionSet,
                            IsSet<IHasNuGetAuthor> NugetAuthorSet,
                            IsSet<IHasVersion> VersionSet
                            )> propertyElementContextPropertiesSet_Package,
                        out projectOptionsContextPropertiesSet,
                        out var checkedPropertyGroupElementAppended,
                        packagePropertyGroupElementOperations
                    ).In(contextSet),
                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                        out checkedProjectFileExists).In(contextSet)
                );

                propertyGroupElementSet_Package = propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet;

                return output;
            }

            static Func<SingleProjectSolutionSetContext, Context001, Task> Create_SolutionFile(
                SolutionSpecification solutionSpecification)
            {
                var o = Instances.ContextOperations;

                var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, SingleProjectSolutionSetContext>();

                return o.In_ContextSet_AB_A<SingleProjectSolutionSetContext, Context001>(
                    o.In_ContextSet_A_BA<Context003, SingleProjectSolutionSetContext>(
                        o.Construct_Context_B_BA<Context003, SingleProjectSolutionSetContext>(
                            (c, a) =>
                            {
                                c.SolutionDirectoryPath = a.SolutionDirectoryPath;

                                return Task.CompletedTask;
                            },
                            Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
                                out (
                                IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                IsSet<IHasSolutionName> SolutionNameSet
                                ) solutionSpecificationPropertiesSet).In(solutionContextSet),
                            Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
                                out var solutionFilePathSet).In(solutionContextSet)
                        ),
                        Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                            out var checkedSolutionFileDoesNotExist).In(solutionContextSet),
                        Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
                            out var checkedSolutionDirectoryExists).In(solutionContextSet),
                        Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                            out var checkedSolutionFileExists).In(solutionContextSet),
                        // Add library project reference.
                        (c, a) =>
                        {
                            Instances.SolutionOperator.AddProjects_Idempotent(
                                c.SolutionFilePath,
                                a.ProjectFilePath);

                            return Task.CompletedTask;
                        },
                        // Output the library solution file path.
                        (c, a) =>
                        {
                            a.SolutionFilePath = c.SolutionFilePath;

                            return Task.CompletedTask;
                        }
                    )
                );
            }

            var repositoryContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context001, Context000>();
            var solutionSetContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<SingleProjectSolutionSetContext, Context001, Context000>();

            await Instances.ContextOperator.In_ContextSet(
                Instances.ApplicationContextOperations.In_ApplicationContext(
                    out ContextPropertiesSet<Context000, (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext(repositorySpecification, (applicationContextPropertiesSet.PropertiesSet.GitHubClientSet, applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out (
                        IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                        IsSet<IHasRepositoryName> RepositoryNameSet,
                        IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                        IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                        ) repositoryPropertiesSet,
                        out IsSet<IHasRepository> repositorySet,
                        Instances.ContextOperations.CaptureContext<Context001>(
                            out var context001Captured).In(repositoryContextSet),
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<SingleProjectSolutionSetContext>(repositoryPropertiesSet.RepositoryDirectoryPathSet,
                            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                            Create_StaticHtmlWebApplicationProject(projectSpecification, projectOptions,
                                solutionDirectoryPathSet,
                                context001Captured,
                                Instances.IsSetOperator.ContextPropertiesSet<Context001, IHasRepository>(repositorySet),
                                out var projectFilePathSet,
                                out var projectFileExists).In(solutionSetContextSet),
                            Create_SolutionFile(solutionSpecification).In(solutionSetContextSet),// Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<SingleProjectSolutionSetContext>(
                                x => Task.FromResult(x.SolutionFilePath)).In(solutionSetContextSet)
                        )
                    )
                )
            );
        }

        public async Task Regenerate_LibraryWithConstructionRepository_Old()
        {
            /// Inputs.
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

            //static Func<Task> In_ApplicationContext(
            //    out (
            //    IsSet<IHasGitHubClient> GitHubClientSet,
            //    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
            //    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
            //    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
            //    ) applicationContextPropertiesSet,
            //    params Func<Context000, Task>[] operations)
            //{
            //    var o = Instances.ContextOperations;

            //    return o.In_ContextSet<Context000>(
            //        o.Construct_Context<Context000>(
            //            Instances.ContextOperations.Set_ContextProperties<Context000>(
            //                out applicationContextPropertiesSet)
            //        ),
            //        operations);
            //}

            //static Func<Context000, Task> In_RegeneratedRepositoryContext(
            //    RepositorySpecification repositorySpecification,
            //    (
            //    IsSet<IHasGitHubClient> GitHubClientSet,
            //    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
            //    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
            //    ) applicationContextPropertiesSet,
            //    out (
            //    IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            //    IsSet<IHasRepositoryName> RepositoryNameSet,
            //    IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
            //    IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            //    ) repositoryPropertiesSet,
            //    params Func<Context001, Context000, Task>[] operations)
            //{
            //    var o = Instances.ContextOperations;

            //    var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context001, Context000>();

            //    return o.In_ContextSet_A_BA<Context001, Context000>(
            //        o.Construct_Context_B_BA<Context001, Context000>(
            //            Instances.ContextOperations.Set_ContextProperties<Context001, Context000>((applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
            //                out var repositoryContextPropertiesSet),
            //            Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(repositorySpecification,
            //                out repositoryPropertiesSet).In(contextSet),
            //            Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>((
            //                repositoryPropertiesSet.RepositorySpecificationSet,
            //                repositoryPropertiesSet.RepositoryNameSet,
            //                repositoryPropertiesSet.RepositoryOwnerNameSet,
            //                applicationContextPropertiesSet.GitHubClientSet,
            //                applicationContextPropertiesSet.GitHubAuthenticationSet,
            //                repositoryPropertiesSet.RepositoryDirectoryPathSet),
            //                out var repositorySet,
            //                out (
            //                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            //                IChecked<ILocalRepositoryExists> LocalRepositoryExists,
            //                IChecked<IFileExists> GitIgnoreFileExists
            //                ) checkedRepository)
            //        ),
            //        operations
            //    );
            //}

            //static Func<Context001, Context000, Task> In_SolutionSetContext(
            //    IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
            //    out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            //    params Func<LibrarySolutionSetContext, Context001, Context000, Task>[] operations)
            //{
            //    var o = Instances.ContextOperations;

            //    var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<LibrarySolutionSetContext, Context001, Context000>();

            //    return o.In_ContextSet_AB_CAB<LibrarySolutionSetContext, Context001, Context000>(
            //        o.Construct_Context_C_CAB<LibrarySolutionSetContext, Context001, Context000>(
            //            Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<LibrarySolutionSetContext, Context001>(RepositoryDirectoryPathSet,
            //                out solutionDirectoryPathSet).In(contextSet)
            //        ),
            //        operations
            //    );
            //}

            static Func<ProjectContext001, LibrarySolutionSetContext, Task> Set_LibraryProjectFilePath(
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet)
            {
                return (projectContext, solutionSetContext) =>
                {
                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                    return Task.CompletedTask;
                };
            }

            //static Func<LibrarySolutionSetContext, Task> Create_LibraryProject(
            //    ProjectSpecification projectSpecification,
            //    ProjectOptions projectOptions,
            //    IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            //    ContextCapture<Context001> repositoryContextCapture,
            //    out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet,
            //    out IChecked<IFileExists> checkedLibraryProjectFileExists)
            //{
            //    var o = Instances.ContextOperations;

            //    var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, LibrarySolutionSetContext>();

            //    //return o.In_ContextSet_ABC_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
            //    //    o.Construct_Context_D_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
            //    //        Instances.ProjectContextOperations.Set_ProjectSpecification<ProjectContext001>(projectSpecification,
            //    //            out (
            //    //            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            //    //            IsSet<IHasProjectName> ProjectNameSet,
            //    //            IsSet<IHasProjectDescription> ProjectDescriptionSet
            //    //            ) projectSpecificationPropertiesSet).In(contextSet),
            //    //        Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext001>(projectSpecificationPropertiesSet.ProjectNameSet,
            //    //            out var namespaceNameSet).In(contextSet),
            //    //        Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext001, LibrarySolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionDirectoryPathSet,
            //    //            out var projectDirectoryPathSet).In(contextSet),
            //    //        Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext001>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
            //    //            out var projectFilePathSet).In(contextSet)
            //    //    ),
            //    return Instances.ProjectContextOperations.In_ProjectContext<LibrarySolutionSetContext>(
            //        projectSpecification,
            //        solutionDirectoryPathSet,
            //        out (
            //        IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            //        IsSet<IHasProjectName> ProjectNameSet,
            //        IsSet<IHasProjectDescription> ProjectDescriptionSet,
            //        IsSet<IHasNamespaceName> NamespaceNameSet,
            //        IsSet<IHasProjectDirectoryPath> ProjectDirectoryPathSet,
            //        IsSet<IHasProjectFilePath> ProjectFilePathSet
            //        ) projectPropertiesSet,
            //        Instances.ProjectFileContextOperations.Create_LibraryProjectFile(projectOptions,
            //            Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectDescriptionSet),
            //            repositoryContextCapture,
            //            out checkedLibraryProjectFileExists).In(contextSet),
            //        // Create project's files.
            //        Instances.CodeFileGenerationContextOperations.Create_Class1File<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
            //            out var checkedClass1FileExists).In(contextSet),
            //        Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet, projectPropertiesSet.ProjectDescriptionSet),
            //            out var checkedDocumentationFileExists).In(contextSet),
            //        Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.NamespaceNameSet),
            //            out var checkedInstancesFileExists).In(contextSet),
            //        Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectPropertiesSet.ProjectFilePathSet, projectPropertiesSet.ProjectNameSet, projectPropertiesSet.ProjectDescriptionSet),
            //            out var checkedProjectPlanFileExists).In(contextSet),
            //        Set_LibraryProjectFilePath(
            //            out libraryProjectFilePathSet)
            //    );
            //}

            //static Func<ProjectContext001, LibrarySolutionSetContext, Task> Create_LibraryProjectFile(
            //    ProjectOptions projectOptions,
            //    ContextPropertiesSet<ProjectContext001, (
            //    IsSet<IHasProjectFilePath> ProjectFilePathSet,
            //    IsSet<IHasProjectDescription> ProjectDescriptionSet
            //    )> projectContextPropertiesSet,
            //    ContextCapture<Context001> repositoryContextCapture,
            //    out IChecked<IFileExists> checkedProjectFileExists)
            //{
            //    var o = Instances.ContextOperations;

            //    var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, LibrarySolutionSetContext>();
            //    var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

            //    return o.In_ContextSet_AB_CAB<Context005, ProjectContext001, LibrarySolutionSetContext>(
            //        o.Construct_Context_C_CAB<Context005, ProjectContext001, LibrarySolutionSetContext>(
            //            Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
            //                out var projectElementContextProjectFilePathSet).In(contextSet),
            //            Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
            //                out var projectElementContextProjectDescriptionSet).In(contextSet),
            //            Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
            //                out var projectElementSet).In(contextSet)
            //        ),
            //        Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>().In(contextSet),
            //        // Create the main property group element.
            //        //Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
            //        //    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
            //        //        out var propertyGroupElementSet).In(propertyGroupContextSet),
            //        //    Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
            //        //    Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
            //        //    Instances.PropertyGroupElementContextOperations.Set_TargetFramework_NetStandard2_1<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
            //        //    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
            //        //        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
            //        //            Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
            //        //                out var projectOptionsSet).In(propertyGroupOptionsContextSet),
            //        //            Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
            //        //                out (
            //        //                IsSet<IHasTargetFramework> TargetFrameworkSet,
            //        //                IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
            //        //                ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
            //        //        ),
            //        //        Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
            //        //    ).In(propertyGroupContextSet),
            //        //    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
            //        //        out var checkedPropertyGroupElementAppended_Main)
            //        //).In(projectContextSet),
            //        //Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main(
            //        //    projectOptions,
            //        //    Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>,
            //        //    Instances.PropertyGroupElementContextOperations.Set_TargetFramework_NetStandard2_1<Context006>,
            //        //    out (
            //        //    // TODO: IHasOutputType is set.
            //        //    IsSet<IHasTargetFramework> TargetFrameworkSet,
            //        //    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
            //        //    ) mainPropertyGroupPropertiesSet,
            //        //    out var checkedPropertyGroupElementAppended_Main
            //        //).In(projectContextSet),
            //        Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main(
            //            projectOptions,
            //            out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet_Main,
            //            out var projectOptionsContextPropertiesSet,
            //            out var checkedPropertyGroupElementAppended_Main,
            //            Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupContextSet),
            //            // Change the target framework from what is specified in the project options, to the library default.
            //            Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default_ForLibrary<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupContextSet)
            //        ).In(contextSet),
            //        // Create the package property group element, for a library (include package license expression and require licenses acceptance properties).
            //        //Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
            //        //    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
            //        //        out var propertyGroupElementSet).In(propertyGroupContextSet2),
            //        //    Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In(propertyGroupContextSet2),
            //        //    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
            //        //        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
            //        //            Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
            //        //                out var projectOptionsSet).In(propertyGroupOptionsContextSet),
            //        //            Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasPackageLicenseExpression, IHasPackageRequireLicenseAcceptance, IHasVersion>(projectOptionsSet,
            //        //                out (
            //        //                IsSet<IHasCompany> CompanySet,
            //        //                IsSet<IHasCopyright> CopyrightSet,
            //        //                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
            //        //                IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
            //        //                IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptance,
            //        //                IsSet<IHasVersion> VersionSet
            //        //                ) impliedProjectOptionsSet_Package).In(propertyGroupOptionsContextSet)
            //        //        ),
            //        //        Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
            //        //        Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
            //        //        Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
            //        //        Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet),
            //        //        Instances.PropertyGroupElementContextOperations.Set_PackageLicenseExpression<Context006, ProjectOptionsContext>(
            //        //            Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupElementSet),
            //        //            Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageLicenseExpression>(impliedProjectOptionsSet_Package.PackageLicenseExpressionSet)),
            //        //        Instances.PropertyGroupElementContextOperations.Set_PackageRequireLicenseAcceptance<Context006, ProjectOptionsContext>(
            //        //            Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupElementSet),
            //        //            Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageRequireLicenseAcceptance>(impliedProjectOptionsSet_Package.PackageRequireLicenseAcceptance))
            //        //    ).In(propertyGroupContextSet2),
            //        //    Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
            //        //    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
            //        //        out var checkedPropertyGroupElementAppended_Package)
            //        //).In(projectContextSet),
            //        Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary(
            //            projectOptions,
            //            projectElementContextProjectDescriptionSet,
            //            out ContextPropertiesSet<Context006, (
            //                IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
            //                IsSet<IHasCompany> CompanySet,
            //                IsSet<IHasCopyright> CopyrightSet,
            //                IsSet<IHasProjectDescription> DescriptionSet,
            //                IsSet<IHasNuGetAuthor> NugetAuthorSet,
            //                IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
            //                IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptanceSet,
            //                IsSet<IHasVersion> VersionSet
            //                )> propertyElementContextPropertiesSet_Package,
            //            out projectOptionsContextPropertiesSet,
            //            out var checkedPropertyGroupElementAppended,
            //            Instances.EnumerableOperator.From(
            //                Instances.ContextOperations.In_ContextSet<Context006, Context001>(
            //                    repositoryContextCapture,
            //                    Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
            //                        propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet,
            //                        context001 => Task.FromResult(context001.Repository.HtmlUrl),
            //                        out _)
            //                ).In(propertyGroupContextSet)
            //            )
            //        ).In(contextSet),
            //        Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
            //            out checkedProjectFileExists).In(contextSet)
            //    );
            //}

            static Func<ProjectContext001, LibrarySolutionSetContext, Task> Set_ConstructionProjectFilePath(
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet)
            {
                return (projectContext, solutionSetContext) =>
                {
                    solutionSetContext.ConstructionProjectFilePath = projectContext.ProjectFilePath;

                    return Task.CompletedTask;
                };
            }

            static Func<LibrarySolutionSetContext, Task> Create_ConstructionProject(
                ProjectSpecification projectSpecification,
                ProjectOptions projectOptions,
                IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                ContextCapture<Context001> repositoryContextCapture,
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> constructionProjectFilePathSet,
                out IChecked<IFileExists> checkedLibraryProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, LibrarySolutionSetContext>();
                var libraryProjectContextProperties = Instances.ContextOperator.Get_ContextPropertiesSpecifier<IHasProjectFilePath, IHasProjectDescription>();

                return o.In_ContextSet_A_BA<ProjectContext001, LibrarySolutionSetContext>(
                    o.Construct_Context_B_BA<ProjectContext001, LibrarySolutionSetContext>(
                        Instances.ProjectContextOperations.Set_ProjectSpecification<ProjectContext001>(projectSpecification,
                            out (
                            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                            IsSet<IHasProjectName> ProjectNameSet,
                            IsSet<IHasProjectDescription> ProjectDescriptionSet
                            ) projectSpecificationPropertiesSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext001>(projectSpecificationPropertiesSet.ProjectNameSet,
                            out var namespaceNameSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext001, LibrarySolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionDirectoryPathSet,
                            out var projectDirectoryPathSet),
                        Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext001>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                            out var projectFilePathSet).In(contextSet)
                    ),
                    Create_ConstructionProjectFile(projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectFilePathSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        repositoryContextCapture,
                        out checkedLibraryProjectFileExists),
                    // Create project's files.
                    Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForConsole<ProjectContext001>((projectFilePathSet, namespaceNameSet),
                        out var checkedProgramFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectFilePathSet, namespaceNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out var checkedDocumentationFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectFilePathSet, namespaceNameSet),
                        out var checkedInstancesFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out var checkedProjectPlanFileExists).In(contextSet),
                    Set_ConstructionProjectFilePath(
                        out constructionProjectFilePathSet)
                );
            }

            static Func<ProjectContext001, LibrarySolutionSetContext, Task> Create_ConstructionProjectFile(
                ProjectOptions projectOptions,
                ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
                )> projectContextPropertiesSet,
                ContextCapture<Context001> repositoryContextCapture,
                // TODO: create IHasLibraryProjectFilePath for library solution set context.
                out IChecked<IFileExists> checkedProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, LibrarySolutionSetContext>();
                var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();
                var itemGropuContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context007, Context005, LibrarySolutionSetContext>();

                return o.In_ContextSet_AB_CAB<Context005, ProjectContext001, LibrarySolutionSetContext>(
                    o.Construct_Context_C_CAB<Context005, ProjectContext001, LibrarySolutionSetContext>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet).In(contextSet),
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                            out var projectElementSet).In(contextSet)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>().In(contextSet),
                    // Create the main property group element.
                    //Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                    //    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                    //        out var propertyGroupElementSet).In(propertyGroupContextSet),
                    //    Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                    //    Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                    //    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                    //        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                    //            Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                    //                out var projectOptionsSet).In(propertyGroupOptionsContextSet),
                    //            Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                    //                out (
                    //                IsSet<IHasTargetFramework> TargetFrameworkSet,
                    //                IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                    //                ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
                    //        ),
                    //        Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet),
                    //        Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
                    //    ).In(propertyGroupContextSet),
                    //    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                    //        out var checkedPropertyGroupElementAppended_Main)
                    //).In(contextSet),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main(
                        projectOptions,
                        out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet_Main,
                        out var projectOptionsContextPropertiesSet,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupOptionsContextSet)
                    ).In(contextSet),
                    // Create the package property group element.
                    //Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                    //    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                    //        out var propertyGroupElementSet).In(propertyGroupContextSet),
                    //    Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                    //    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                    //        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                    //            Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                    //                out var projectOptionsSet).In(propertyGroupOptionsContextSet2),
                    //            Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
                    //                out (
                    //                IsSet<IHasCompany> CompanySet,
                    //                IsSet<IHasCopyright> CopyrightSet,
                    //                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    //                IsSet<IHasVersion> VersionSet
                    //                ) impliedProjectOptionsSet_Package).In(propertyGroupOptionsContextSet2)
                    //        ),
                    //        Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
                    //        Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
                    //        Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
                    //        Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet)
                    //    ).In(propertyGroupContextSet),
                    //    Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
                    //    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                    //        out var checkedPropertyGroupElementAppended_Package)
                    //).In(contextSet),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package(
                        projectOptions,
                        projectElementContextProjectDescriptionSet,
                        out ContextPropertiesSet<Context006, (
                            IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                            IsSet<IHasCompany> CompanySet,
                            IsSet<IHasCopyright> CopyrightSet,
                            IsSet<IHasProjectDescription> DescriptionSet,
                            IsSet<IHasNuGetAuthor> NugetAuthorSet,
                            IsSet<IHasVersion> VersionSet
                            )> propertyElementContextPropertiesSet_Package,
                        out projectOptionsContextPropertiesSet,
                        out var checkedPropertyGroupElementAppended,
                        Instances.EnumerableOperator.From(
                            Instances.ContextOperations.In_ContextSet<Context006, Context001>(
                                repositoryContextCapture,
                                Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                                    propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet,
                                    context001 => Task.FromResult(context001.Repository.HtmlUrl),
                                    out _)
                            ).In(propertyGroupOptionsContextSet)
                        )
                    ).In(contextSet),
                    // Add the library project reference.
                    o.In_ContextSet_AB_CAB<Context007, Context005, LibrarySolutionSetContext>(
                        o.Construct_Context_C_CAB<Context007, Context005, LibrarySolutionSetContext>(
                        // Do nothing
                        ),
                        Instances.ItemGroupElementContextOperations.Set_ItemGroupElement_New<Context007>(
                            out var itemGroupElementSet).In(itemGropuContextSet),
                        Instances.ItemGroupElementContextOperations.Add_ProjectReference<Context007, Context005, LibrarySolutionSetContext>(
                            x => Task.FromResult(x.LibraryProjectFilePath)),
                        Instances.ItemGroupElementContextOperations.Append_ItemGroupElement<Context007, Context005>(itemGroupElementSet,
                            out var checkedItemGroupElementAppended_ProjectReferences).In(itemGropuContextSet)
                    ).In(contextSet),
                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                        out checkedProjectFileExists).In(contextSet)
                );
            }

            //static Func<LibrarySolutionSetContext, Context001, Task> Create_LibrarySolutionFile(
            //    SolutionSpecification solutionSpecification)
            //{
            //    var o = Instances.ContextOperations;

            //    var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, LibrarySolutionSetContext>();

            //    return o.In_ContextSet_AB_A<LibrarySolutionSetContext, Context001>(
            //        o.In_ContextSet_A_BA<Context003, LibrarySolutionSetContext>(
            //            o.Construct_Context_B_BA<Context003, LibrarySolutionSetContext>(
            //                (c, a) =>
            //                {
            //                    c.SolutionDirectoryPath = a.SolutionDirectoryPath;

            //                    return Task.CompletedTask;
            //                },
            //                Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
            //                    out (
            //                    IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
            //                    IsSet<IHasSolutionName> SolutionNameSet
            //                    ) solutionSpecificationPropertiesSet).In(solutionContextSet),
            //                Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
            //                    out var solutionFilePathSet).In(solutionContextSet)
            //            ),
            //            Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
            //                out var checkedSolutionFileDoesNotExist).In(solutionContextSet),
            //            Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
            //                out var checkedSolutionDirectoryExists).In(solutionContextSet),
            //            Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
            //                out var checkedSolutionFileExists).In(solutionContextSet),
            //            // Add library project reference.
            //            (c, a) =>
            //            {
            //                Instances.SolutionOperator.AddProjects_Idempotent(
            //                    c.SolutionFilePath,
            //                    a.LibraryProjectFilePath);

            //                return Task.CompletedTask;
            //            },
            //            // Output the library solution file path.
            //            (c, a) =>
            //            {
            //                a.LibrarySolutionFilePath = c.SolutionFilePath;

            //                return Task.CompletedTask;
            //            }
            //        )
            //    );
            //}

            static Func<LibrarySolutionSetContext, Context001, Task> Create_ConstructionSolutionFile(
                SolutionSpecification solutionSpecification)
            {
                var o = Instances.ContextOperations;

                var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, LibrarySolutionSetContext>();

                return o.In_ContextSet_AB_A<LibrarySolutionSetContext, Context001>(
                    o.In_ContextSet_A_BA<Context003, LibrarySolutionSetContext>(
                        o.Construct_Context_B_BA<Context003, LibrarySolutionSetContext>(
                            (c, a) =>
                            {
                                c.SolutionDirectoryPath = a.SolutionDirectoryPath;

                                return Task.CompletedTask;
                            },
                            Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
                                out (
                                IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                IsSet<IHasSolutionName> SolutionNameSet
                                ) solutionSpecificationPropertiesSet).In(solutionContextSet),
                            Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
                                out var solutionFilePathSet).In(solutionContextSet)
                        ),
                        Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                            out var checkedSolutionFileDoesNotExist).In(solutionContextSet),
                        Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
                            out var checkedSolutionDirectoryExists).In(solutionContextSet),
                        Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                            out var checkedSolutionFileExists).In(solutionContextSet),
                        // Add construction and library project references.
                        (c, a) =>
                        {
                            Instances.SolutionOperator.AddProjects_Idempotent(
                                c.SolutionFilePath,
                                a.ConstructionProjectFilePath,
                                a.LibraryProjectFilePath);

                            return Task.CompletedTask;
                        },
                        // Set the construction solution file path.
                        (c, a) =>
                        {
                            a.ConstructionSolutionFilePath = c.SolutionFilePath;

                            return Task.CompletedTask;
                        }
                    )
                );
            }

            var solutionSetContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<LibrarySolutionSetContext, Context001, Context000>();

            await Instances.ContextOperator.In_ContextSet(
                Instances.ApplicationContextOperations.In_ApplicationContext(
                    out ContextPropertiesSet<Context000, (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    )> applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext(repositorySpecification, (applicationContextPropertiesSet.PropertiesSet.GitHubClientSet, applicationContextPropertiesSet.PropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet),
                        out (
                        IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                        IsSet<IHasRepositoryName> RepositoryNameSet,
                        IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                        IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                        ) repositoryPropertiesSet,
                        out _,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext(repositoryPropertiesSet.RepositoryDirectoryPathSet,
                            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                            Instances.ContextOperations.CaptureContext<Context001>(
                                out var repositoryContextCapture).In(solutionSetContextSet),
                            Instances.ProjectContextOperations.Create_LibraryProject<LibrarySolutionSetContext>(libraryProjectSpecification, projectOptions, solutionDirectoryPathSet, repositoryContextCapture,
                                out var checkedLibraryProjectFileExists,
                                projectOperations: Instances.EnumerableOperator.From(
                                    Set_LibraryProjectFilePath(
                                        out var libraryProjectFilePathSet)
                                )).In(solutionSetContextSet),
                            Create_ConstructionProject(constructionProjectSpecification, projectOptions, solutionDirectoryPathSet, repositoryContextCapture,
                                out var constructionProjectFilePathSet,
                                out var checkedConstructionProjectFileExists).In(solutionSetContextSet),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<LibrarySolutionSetContext>(
                                librarySolutionSpecification,
                                solutionDirectoryPathSet,
                                out var checkedSolutionFileExists,
                                Instances.EnumerableOperator.From<Func<Context003, LibrarySolutionSetContext, Task>>(
                                    // Add library project reference.
                                    (c, a) =>
                                    {
                                        Instances.SolutionOperator.AddProjects_Idempotent(
                                            c.SolutionFilePath,
                                            a.LibraryProjectFilePath);

                                        return Task.CompletedTask;
                                    },
                                    // Output the library solution file path.
                                    (c, a) =>
                                    {
                                        a.LibrarySolutionFilePath = c.SolutionFilePath;

                                        return Task.CompletedTask;
                                    }
                                )
                            ).In(solutionSetContextSet),
                            Create_ConstructionSolutionFile(constructionSolutionSpecification).In(solutionSetContextSet),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<LibrarySolutionSetContext>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In(solutionSetContextSet)
                        )
                    )
                )
            );
        }

        ///// <summary>
        ///// Generate a repository with a console application.
        ///// </summary>
        //public async Task Regenerate_ConsoleRepository_Old()
        //{
        //    /// Inputs.
        //    var libraryName =
        //        // Use the disposable name since we might have deletion code!
        //        Instances.RepositoryNameExamples.Disposable
        //        ;
        //    var isPrivate =
        //        true
        //        ;
        //    var repositoryOwnerName =
        //        Instances.RepositoryOwnerNameExamples.SafetyCone
        //        ;
        //    var libraryDescription =
        //        Instances.RepositoryDescriptionExamples.ForTesting
        //        ;


        //    /// Run.
        //    var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

        //    var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
        //        repositoryName_UnadjustedForPrivacy,
        //        isPrivate);
        //    var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

        //    var repositorySpecification = new RepositorySpecification
        //    {
        //        Organization = repositoryOwnerName,
        //        Name = repositoryName,
        //        Description = repositoryDescription,
        //        IsPrivate = isPrivate,
        //        License = License.MIT,
        //    };

        //    var solutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
        //    var solutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
        //        solutionName_UnadjustedForPrivacy,
        //        isPrivate);

        //    var solutionSpecification = new SolutionSpecification
        //    {
        //        Name = solutionName
        //    };

        //    var projectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
        //    var projectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

        //    var projectSpecification = new ProjectSpecification
        //    {
        //        Name = projectName,
        //        Description = projectDescription,
        //    };

        //    // Options.
        //    var projectOptions = new ProjectOptions
        //    {
        //        Company = Instances.CompanyNames.Rivet.Value,
        //        Copyright = Instances.CopyrightOperator.Get_CopyrightText(
        //            Instances.CompanyNames.Rivet.Value),
        //        IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
        //        TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
        //        NuGetAuthor = Instances.Authors.DCoats.Value,
        //        Version = Instances.Versions.Initial_Default,
        //    };

        //    // Start with an application context.
        //    var applicationContext = new Context000();

        //    var o = Instances.ContextOperations;

        //    await Instances.ContextOperator.In_ContextSet<Context000>(applicationContext,
        //        Instances.ContextOperations.Set_ContextProperties<Context000>(
        //            out var applicationContextPropertiesSet),
        //        // Create the repository.
        //        o.In_ContextSet_A_BA<Context001, Context000>(_ =>
        //        {
        //            var repositoryContext = new Context001();

        //            return Task.FromResult(repositoryContext);
        //        },
        //        // Transfer properties from the application context to the repository context.
        //        Instances.ContextOperations.Set_ContextProperties<Context001, Context000>((applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
        //            out var repositoryContextPropertiesSet),
        //        o.In_ContextSet_AB_A<Context001, Context000>(
        //            Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(repositorySpecification,
        //                out (
        //                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
        //                IsSet<IHasRepositoryName> RepositoryNameSet,
        //                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
        //                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
        //                ) repositoryPropertiesSet)),
        //            Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>((
        //                repositoryPropertiesSet.RepositorySpecificationSet,
        //                repositoryPropertiesSet.RepositoryNameSet,
        //                repositoryPropertiesSet.RepositoryOwnerNameSet,
        //                applicationContextPropertiesSet.GitHubClientSet,
        //                applicationContextPropertiesSet.GitHubAuthenticationSet,
        //                repositoryPropertiesSet.RepositoryDirectoryPathSet),
        //                out var repositorySet,
        //                out (
        //                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
        //                IChecked<ILocalRepositoryExists> LocalRepositoryExists
        //                ) checkedRepository),
        //            o.In_ContextSet_AB_A<Context001, Context000>(
        //                Instances.GitContextOperations.In_GitPushContext_Start<Context001>(Instances.CommitMessages.InitialCommit,
        //                    out var initialCommitToken),
        //                // Add the Git ignore file while we are in this sub-context.
        //                Instances.RepositoryContextOperations.Add_GitIgnoreFile<Context001>(repositoryPropertiesSet.RepositoryDirectoryPathSet,
        //                    out var checkedGitIgnoreFileExists)
        //            ),
        //            // Create the solution context.
        //            o.In_ContextSet_AB_CAB<Context003, Context001, Context000>((_, _) =>
        //            {
        //                var solutionContext = new Context003();

        //                return Task.FromResult(solutionContext);
        //            },
        //            o.In_ContextSet_ABC_AB<Context003, Context001, Context000>(
        //                Instances.RepositoryContextOperations.Set_RepositoryProperties<Context003, Context001>(repositoryPropertiesSet.RepositoryDirectoryPathSet,
        //                    out var repositoryDirectoryPathSet),
        //                o.In_ContextSet_AB_A<Context003, Context001>(
        //                    Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<Context003>(repositoryDirectoryPathSet,
        //                        out var solutionDirectoryPathSet),
        //                    Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
        //                        out (
        //                        IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
        //                        IsSet<IHasSolutionName> SolutionNameSet
        //                        ) solutionSpecificationPropertiesSet),
        //                    Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((solutionDirectoryPathSet, solutionSpecificationPropertiesSet.SolutionNameSet),
        //                        out var solutionFilePathSet),
        //                    Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
        //                        out var checkedSolutionFileDoesNotExist),
        //                    Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(solutionDirectoryPathSet),
        //                        out var checkedSolutionDirectoryExists),
        //                    Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
        //                        out var checkedSolutionFileExists))
        //            ),
        //            // Create the project context.
        //            o.In_ContextSet_ABC_DABC<Context004, Context003, Context001, Context000>((_, _, _) =>
        //            {
        //                var projectContext = new Context004();

        //                return Task.FromResult(projectContext);
        //            },
        //            o.In_ContextSet_ABCD_AB<Context004, Context003, Context001, Context000>(
        //                Instances.SolutionContextOperations.Set_SolutionProperties<Context004, Context003>((repositoryDirectoryPathSet, solutionFilePathSet),
        //                    out var projectSolutionPropertiesSet),
        //                o.In_ContextSet_AB_A<Context004, Context003>(
        //                    Instances.ProjectContextOperations.Set_ProjectSpecification<Context004>(projectSpecification,
        //                        out var projectSpecificationPropertiesSet),
        //                    Instances.ProjectContextOperations.Set_ProjectDirectoryPath<Context004>((projectSolutionPropertiesSet.SolutionFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet),
        //                        out var projectDirectoryPathSet),
        //                    Instances.ProjectContextOperations.Set_ProjectFilePath<Context004>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
        //                        out var projectFilePathSet),
        //                    Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context004>(Instances.IsSetOperator.Implies<IHasFilePath, IHasProjectFilePath>(projectFilePathSet), out var checkedProjectFilePathDoesNotExist),
        //                    // Create the project console file.
        //                    Instances.ProjectContextOperations.Set_NamespaceName<Context004>(projectSpecificationPropertiesSet.ProjectNameSet, out var namespaceNameSet))
        //            ),
        //            // Create the project file.
        //            o.In_ContextSet_ABCD_EAC<Context005, Context004, Context003, Context001, Context000>((_, _, _, _) =>
        //            {
        //                var projectElementContext = new Context005();

        //                return Task.FromResult(projectElementContext);
        //            },
        //            o.In_ContextSet_ABC_AB<Context005, Context004, Context001>(
        //                Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, Context004>(projectFilePathSet,
        //                    out var projectElementContextProjectFilePathSet),
        //                Instances.ProjectContextOperations.Set_ProjectDescription<Context005, Context004>(projectSpecificationPropertiesSet.ProjectDescriptionSet,
        //                    out var projectElementContextProjectDescriptionSet),
        //                o.In_ContextSet_AB_A<Context005, Context004>(
        //                    Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
        //                        out var projectElementSet),
        //                    Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>(),
        //                    // Create the main property group element.
        //                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
        //                        o.In_ContextSet_AB_A<Context006, Context005>(
        //                            Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
        //                                out var propertyGroupElementSet),
        //                            Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet),
        //                            Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyGroupElementSet),
        //                            o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
        //                                o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
        //                                    o.In_ContextSet_AB_B<Context006, ProjectOptionsContext>(
        //                                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
        //                                            out var projectOptionsSet),
        //                                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
        //                                            out (
        //                                            IsSet<IHasTargetFramework> TargetFrameworkSet,
        //                                            IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
        //                                            ) impliedProjectOptionsSet_Main)
        //                                    )
        //                                ),
        //                                Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet),
        //                                Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
        //                            )
        //                        ),
        //                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
        //                            out var checkedPropertyGroupElementAppended_Main)
        //                    ),
        //                    // Create the package property group element.
        //                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
        //                        o.In_ContextSet_AB_A<Context006, Context005>(
        //                            Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
        //                                out propertyGroupElementSet),
        //                            Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet),
        //                            o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
        //                                o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
        //                                    o.In_ContextSet_AB_B<Context006, ProjectOptionsContext>(
        //                                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
        //                                            out projectOptionsSet),
        //                                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
        //                                            out (
        //                                            IsSet<IHasCompany> CompanySet,
        //                                            IsSet<IHasCopyright> CopyrightSet,
        //                                            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
        //                                            IsSet<IHasVersion> VersionSet
        //                                            ) impliedProjectOptionsSet_Package)
        //                                    )
        //                                ),
        //                                Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
        //                                Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
        //                                Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
        //                                Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet)
        //                            )
        //                        ),
        //                        Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
        //                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
        //                            out var checkedPropertyGroupElementAppended_Package)
        //                    ),
        //                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
        //                        out var checkedProjectFileExists)))
        //            ),
        //            // Create project's files.
        //            o.In_ContextSet_ABCD_A<Context004, Context003, Context001, Context000>(
        //                Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForConsole<Context004>((projectFilePathSet, namespaceNameSet),
        //                    out var checkedProgramFileExists),
        //                Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<Context004>((projectFilePathSet, namespaceNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
        //                    out var checkedDocumentationFileExists),
        //                Instances.CodeFileGenerationContextOperations.Create_InstancesFile<Context004>((projectFilePathSet, namespaceNameSet),
        //                    out var checkedInstancesFileExists),
        //                Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<Context004>((projectFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
        //                    out var checkedProjectPlanFileExists)
        //            ),
        //            o.In_ContextSet_ABCD_A<Context004, Context003, Context001, Context000>(
        //                Instances.ProjectContextOperations.Add_ProjectToSolution<Context004>((projectFilePathSet, projectSolutionPropertiesSet.SolutionFilePathSet),
        //                    out var checkedSolutionHasProject))
        //            ),
        //            o.In_ContextSet_ABC_A<Context003, Context001, Context000>(
        //                // Open the Visual Studio solution file.
        //                Instances.VisualStudioContextOperations.Open_VisualStudioSolution<Context003>(solutionFilePathSet))
        //        ),
        //        o.In_ContextSet_AB_A<Context001, Context000>(
        //            Instances.GitContextOperations.In_GitPushContext_End<Context001>(initialCommitToken, (repositoryPropertiesSet.RepositoryDirectoryPathSet, repositoryContextPropertiesSet.GitHubAuthenticationSet, repositoryContextPropertiesSet.GitHubAuthorSet),
        //                out var checkedLocalChangesPushedToRemote),
        //            // Open the repository directory path while here in this context.
        //            Instances.WindowsExplorerOperations.Open_DirectoryPath<Context001>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasRepositoryDirectoryPath>(repositoryPropertiesSet.RepositoryDirectoryPathSet))))
        //    );

        //    static void Ensure_RequiredChecks_ForRepository(
        //        IChecked<IGitHubRepositoryExists> checkedGitHubRepositoryExists,
        //        IChecked<ILocalRepositoryExists> checkedLocalRepositoryExists,
        //        IChecked<IFileExists> checkedGitIgnoreFileExists,
        //        IChecked<ILocalChangesPushedToRemote> checkedLocalChangesPushedToRemote)
        //    {
        //        // Do nothing. This method just provides required input arguments to make sure things have been done.
        //    }

        //    static void Ensure_RequiredChecks_ForSolution(
        //        IChecked<IFileExists> checkedSolutionFileExists,
        //        IChecked<ISolutionHasProject> chekedSolutionHasProject)
        //    {
        //        // Do nothing. This method just provides required input arguments to make sure things have been done.
        //    }

        //    static void Ensure_RequiredChecks_ForProject(
        //        IChecked<IFileExists> checkedProjectFileExists,
        //        IChecked<ISolutionHasProject> chekedSolutionHasProject,
        //        IChecked<IFileExists> checkedProgramFileExists,
        //        IChecked<IFileExists> checkedDocumentationFileExists,
        //        IChecked<IFileExists> checkedInstancesFileExists,
        //        IChecked<IFileExists> checkedProjectPlanFileExists)
        //    {
        //        // Do nothing. This method just provides required input arguments to make sure things have been done.
        //    }

        //    // Checks.
        //    Ensure_RequiredChecks_ForRepository(
        //        checkedRepository.GitHubRepositoryExists,
        //        checkedRepository.LocalRepositoryExists,
        //        checkedGitIgnoreFileExists,
        //        checkedLocalChangesPushedToRemote
        //    );

        //    Ensure_RequiredChecks_ForSolution(
        //        checkedSolutionFileExists,
        //        checkedSolutionHasProject
        //    );

        //    Ensure_RequiredChecks_ForProject(
        //        checkedProjectFileExists,
        //        checkedSolutionHasProject,
        //        checkedProgramFileExists,
        //        checkedDocumentationFileExists,
        //        checkedInstancesFileExists,
        //        checkedProjectPlanFileExists
        //    );

        //    //await Instances.ContextOperator.In_Context(
        //    //    applicationContext,
        //    //    async applicationContext =>
        //    //    {
        //    //        var repositoryContext = new Context001();

        //    //        //await Instances.ContextOperator.In_ContextSet(
        //    //        //    repositoryContext,
        //    //        //    applicationContext,
        //    //        //    (repositoryContext, applicationContext) =>
        //    //        //    {
        //    //        //        return Task.CompletedTask;
        //    //        //    },
        //    //        //    (repositoryContext, _) =>
        //    //        //    {
        //    //        //        return Task.CompletedTask;
        //    //        //    }
        //    //        //);

        //    //        await Instances.ContextOperator.In_Context(
        //    //            () => new Context001(),
        //    //            Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(
        //    //                repositorySpecification,
        //    //                out (
        //    //                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
        //    //                IsSet<IHasRepositoryName> RepositoryNameSet,
        //    //                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
        //    //                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
        //    //                ) repositoryPropertiesSet
        //    //            ),
        //    //            Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>(
        //    //                applicationContext,
        //    //                (
        //    //                repositoryPropertiesSet.RepositorySpecificationSet,
        //    //                repositoryPropertiesSet.RepositoryNameSet,
        //    //                repositoryPropertiesSet.RepositoryOwnerNameSet,
        //    //                contextPropertiesSet.GitHubClientSet,
        //    //                contextPropertiesSet.GitHubAuthenticationSet,
        //    //                repositoryPropertiesSet.RepositoryDirectoryPathSet
        //    //                ),
        //    //                out _,
        //    //                out _
        //    //            ),
        //    //            Instances.GitContextOperations.In_GitPushContext<Context001>(
        //    //                Instances.CommitMessages.InitialCommit,
        //    //                (repositoryPropertiesSet.RepositoryDirectoryPathSet, contextPropertiesSet.GitHubAuthenticationSet, contextPropertiesSet.GitHubAuthorSet),
        //    //                // Add the Git ignore file.
        //    //                Instances.RepositoryContextOperations.Add_GitIgnoreFile<Context001>(
        //    //                    repositoryPropertiesSet.RepositoryDirectoryPathSet,
        //    //                    out var gitIgnoreFileExists
        //    //                ),
        //    //                // Create the solution.
        //    //                async repositoryContext =>
        //    //                {
        //    //                    await Instances.ContextOperator.In_Context(
        //    //                        () => new Context003(),
        //    //                        Instances.RepositoryContextOperations.Set_RepositoryProperties<Context003, Context001>(
        //    //                            repositoryContext,
        //    //                            repositoryPropertiesSet.RepositoryDirectoryPathSet,
        //    //                            out var repositoryDirectoryPathSet
        //    //                        ),
        //    //                        Instances.SolutionContextOperations.Set_SolutionDirectory_Source<Context003>(
        //    //                            repositoryDirectoryPathSet,
        //    //                            out var solutionDirectoryPathSet
        //    //                        ),
        //    //                        //Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(
        //    //                        //    solutionSpecification,
        //    //                        //    out IsSet<IHasSolutionSpecification> SolutionSpecificationSet
        //    //                        //),
        //    //                        Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(
        //    //                            solutionSpecification,
        //    //                            out (
        //    //                            IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
        //    //                            IsSet<IHasSolutionName> SolutionNameSet
        //    //                            ) solutionSpecificationPropertiesSet
        //    //                        ),
        //    //                        Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>(
        //    //                            (
        //    //                            solutionDirectoryPathSet,
        //    //                            solutionSpecificationPropertiesSet.SolutionNameSet
        //    //                            //Instances.IsSetOperator.Implies<IHasSolutionName, IHasSolutionSpecification>(solutionSpecificationSet)
        //    //                            ),
        //    //                            out var solutionFilePathSet
        //    //                        ),
        //    //                        Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(
        //    //                            Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
        //    //                            out var checkedSolutionFileDoesNotExist
        //    //                        ),
        //    //                        Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(
        //    //                            Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(solutionDirectoryPathSet),
        //    //                            out var checkedSolutionDirectoryExists
        //    //                        ),
        //    //                        Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(
        //    //                            solutionFilePathSet,
        //    //                            checkedSolutionFileDoesNotExist,
        //    //                            out var checkedSolutionFileExists
        //    //                        ),
        //    //                        // Create the project file.
        //    //                        async solutionContext =>
        //    //                        {
        //    //                            await Instances.ContextOperator.In_Context<Context004>(
        //    //                                () => new Context004(),
        //    //                                Instances.SolutionContextOperations.Set_SolutionProperties<Context004, Context003>(
        //    //                                    solutionContext,
        //    //                                    (repositoryDirectoryPathSet, solutionFilePathSet),
        //    //                                    out var solutionPropertiesSet
        //    //                                ),
        //    //                                Instances.ProjectContextOperations.Set_ProjectSpecification<Context004>(
        //    //                                    projectSpecification,
        //    //                                    out var projectSpecificationPropertiesSet
        //    //                                ),
        //    //                                Instances.ProjectContextOperations.Set_ProjectDirectoryPath<Context004>(
        //    //                                    (solutionPropertiesSet.SolutionFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet),
        //    //                                    out var projectDirectoryPathSet
        //    //                                ),
        //    //                                Instances.ProjectContextOperations.Set_ProjectFilePath<Context004>(
        //    //                                    (projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
        //    //                                    out var projectFilePathSet
        //    //                                ),
        //    //                                Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context004>(
        //    //                                    Instances.IsSetOperator.Implies<IHasFilePath, IHasProjectFilePath>(projectFilePathSet),
        //    //                                    out var checkedProjectFilePathDoesNotExist
        //    //                                ),
        //    //                                // Create the project file (by building the project XElement, and then serializing it).
        //    //                                projectContext =>
        //    //                                {


        //    //                                    return Task.CompletedTask;
        //    //                                }
        //    //                            );
        //    //                        }
        //    //                    );
        //    //                }
        //    //            ),
        //    //            Instances.WindowsExplorerOperations.Open_DirectoryPath<Context001>(
        //    //                Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasRepositoryDirectoryPath>(repositoryPropertiesSet.RepositoryDirectoryPathSet)
        //    //            )
        //    //        );

        //    //        // Checks.
        //    //        Ensure_RequiredChecks_ForRepository(
        //    //            gitIgnoreFileExists);
        //    //    }
        //    //);
        //}
    }
}
