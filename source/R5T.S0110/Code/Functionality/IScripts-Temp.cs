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


namespace R5T.S0110
{
    public partial interface IScripts
    {
        public async Task Regenerate_LibraryWithConstructionRepository()
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

            static Func<Task> In_ApplicationContext(
                out (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                ) applicationContextPropertiesSet,
                params Func<Context000, Task>[] operations)
            {
                var o = Instances.ContextOperations;

                return o.In_ContextSet<Context000>(
                    o.Construct_Context<Context000>(
                        Instances.ContextOperations.Set_ContextProperties<Context000>(
                            out applicationContextPropertiesSet)
                    ),
                    operations);
            }

            static Func<Context000, Task> In_RegeneratedRepositoryContext(
                RepositorySpecification repositorySpecification,
                (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                ) applicationContextPropertiesSet,
                out (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                ) repositoryPropertiesSet,
                params Func<Context001, Context000, Task>[] operations)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context001, Context000>();

                return o.In_ContextSet_A_BA<Context001, Context000>(
                    o.Construct_Context_B_BA<Context001, Context000>(
                        Instances.ContextOperations.Set_ContextProperties<Context001, Context000>((applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
                            out var repositoryContextPropertiesSet),
                        Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(repositorySpecification,
                            out repositoryPropertiesSet).In(contextSet),
                        Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>((
                            repositoryPropertiesSet.RepositorySpecificationSet,
                            repositoryPropertiesSet.RepositoryNameSet,
                            repositoryPropertiesSet.RepositoryOwnerNameSet,
                            applicationContextPropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.GitHubAuthenticationSet,
                            repositoryPropertiesSet.RepositoryDirectoryPathSet),
                            out var repositorySet,
                            out (
                            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                            IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                            IChecked<IFileExists> GitIgnoreFileExists
                            ) checkedRepository)
                    ),
                    operations
                );
            }

            static Func<Context001, Context000, Task> In_SolutionSetContext(
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                params Func<LibrarySolutionSetContext, Context001, Context000, Task>[] operations)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<LibrarySolutionSetContext, Context001, Context000>();

                return o.In_ContextSet_AB_CAB<LibrarySolutionSetContext, Context001, Context000>(
                    o.Construct_Context_C_CAB<LibrarySolutionSetContext, Context001, Context000>(
                        Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<LibrarySolutionSetContext, Context001>(RepositoryDirectoryPathSet,
                            out solutionDirectoryPathSet).In(contextSet)
                    ),
                    operations
                );
            }

            static Func<ProjectContext001, LibrarySolutionSetContext, Task> Set_LibraryProjectFilePath()
            {
                return (projectContext, solutionSetContext) =>
                {
                    solutionSetContext.LibraryProjectFilePath = projectContext.ProjectFilePath;

                    return Task.CompletedTask;
                };
            }

            static Func<LibrarySolutionSetContext, Context001, Context000, Task> Create_LibraryProject(
                ProjectSpecification projectSpecification,
                ProjectOptions projectOptions,
                IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet,
                out IChecked<IFileExists> checkedLibraryProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>();
                var libraryProjectContextProperties = Instances.ContextOperator.Get_ContextPropertiesSpecifier<IHasProjectFilePath, IHasProjectDescription>();

                return o.In_ContextSet_ABC_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                    o.Construct_Context_D_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                        Instances.ProjectContextOperations.Set_ProjectSpecification<ProjectContext001>(projectSpecification,
                            out (
                            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                            IsSet<IHasProjectName> ProjectNameSet,
                            IsSet<IHasProjectDescription> ProjectDescriptionSet
                            ) projectSpecificationPropertiesSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext001>(projectSpecificationPropertiesSet.ProjectNameSet,
                            out var namespaceNameSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext001, LibrarySolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionDirectoryPathSet,
                            out var projectDirectoryPathSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext001>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                            out var projectFilePathSet).In(contextSet)
                    ),
                    Create_LibraryProjectFile(projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectFilePathSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out libraryProjectFilePathSet,
                        out checkedLibraryProjectFileExists),
                    // Create project's files.
                    // Create a Class1 file (using contexts). TODO
                    Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<ProjectContext001>((projectFilePathSet, namespaceNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out var checkedDocumentationFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_InstancesFile<ProjectContext001>((projectFilePathSet, namespaceNameSet),
                        out var checkedInstancesFileExists).In(contextSet),
                    Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<ProjectContext001>((projectFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out var checkedProjectPlanFileExists).In(contextSet),
                    Set_LibraryProjectFilePath().In(contextSet)
                );
            }

            static Func<ProjectContext001, LibrarySolutionSetContext, Context001, Context000, Task> Create_LibraryProjectFile(
                ProjectOptions projectOptions,
                ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
                )> projectContextPropertiesSet,
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet,
                out IChecked<IFileExists> checkedProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>();
                var projectContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, Context001>();
                var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005>();
                var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, ProjectOptionsContext>();

                return o.In_ContextSet_ABCD_EAC<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                    o.Construct_Context_E_EABCD<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet).In(contextSet)
                    ),
                    Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                        out var projectElementSet).In(projectContextSet),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>().In(projectContextSet),
                    // Create the main property group element.
                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out var propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_NetStandard2_1<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                            o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                    out var projectOptionsSet).In(propertyGroupOptionsContextSet),
                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                                    out (
                                    IsSet<IHasTargetFramework> TargetFrameworkSet,
                                    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                                    ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
                            ),
                            Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
                        ).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                            out var checkedPropertyGroupElementAppended_Main)
                    ).In(projectContextSet),
                    // Create the package property group element.
                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                            o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                    out projectOptionsSet).In(propertyGroupOptionsContextSet),
                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasPackageLicenseExpression, IHasPackageRequireLicenseAcceptance, IHasVersion>(projectOptionsSet,
                                    out (
                                    IsSet<IHasCompany> CompanySet,
                                    IsSet<IHasCopyright> CopyrightSet,
                                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                                    IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
                                    IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptance,
                                    IsSet<IHasVersion> VersionSet
                                    ) impliedProjectOptionsSet_Package).In(propertyGroupOptionsContextSet)
                            ),
                            Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
                            Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
                            Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
                            Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet),
                            Instances.PropertyGroupElementContextOperations.Set_PackageLicenseExpression<Context006, ProjectOptionsContext>(
                                Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupElementSet),
                                Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageLicenseExpression>(impliedProjectOptionsSet_Package.PackageLicenseExpressionSet)),
                            Instances.PropertyGroupElementContextOperations.Set_PackageRequireLicenseAcceptance<Context006, ProjectOptionsContext>(
                                Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupElementSet),
                                Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageRequireLicenseAcceptance>(impliedProjectOptionsSet_Package.PackageRequireLicenseAcceptance))
                        ).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                            out var checkedPropertyGroupElementAppended_Package)
                    ).In(projectContextSet),
                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                        out checkedProjectFileExists).In(projectContextSet)
                );
            }

            static Func<LibrarySolutionSetContext, Context001, Context000, Task> Create_ConstructionProject(
                ProjectSpecification projectSpecification,
                ProjectOptions projectOptions,
                IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet,
                out IChecked<IFileExists> checkedLibraryProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>();
                var libraryProjectContextProperties = Instances.ContextOperator.Get_ContextPropertiesSpecifier<IHasProjectFilePath, IHasProjectDescription>();

                return o.In_ContextSet_ABC_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                    o.Construct_Context_D_DABC<ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                        Instances.ProjectContextOperations.Set_ProjectSpecification<ProjectContext001>(projectSpecification,
                            out (
                            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
                            IsSet<IHasProjectName> ProjectNameSet,
                            IsSet<IHasProjectDescription> ProjectDescriptionSet
                            ) projectSpecificationPropertiesSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_NamespaceName<ProjectContext001>(projectSpecificationPropertiesSet.ProjectNameSet,
                            out var namespaceNameSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDirectoryPath<ProjectContext001, LibrarySolutionSetContext>(projectSpecificationPropertiesSet.ProjectNameSet, solutionDirectoryPathSet,
                            out var projectDirectoryPathSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectFilePath<ProjectContext001>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                            out var projectFilePathSet).In(contextSet)
                    ),
                    Create_ConstructionProjectFile(projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectFilePathSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                        out libraryProjectFilePathSet,
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
                    Set_LibraryProjectFilePath().In(contextSet)
                );
            }

            static Func<ProjectContext001, LibrarySolutionSetContext, Context001, Context000, Task> Create_ConstructionProjectFile(
                ProjectOptions projectOptions,
                ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
                )> projectContextPropertiesSet,
                // TODO: create IHasLibraryProjectFilePath for library solution set context.
                out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasProjectFilePath>> libraryProjectFilePathSet,
                out IChecked<IFileExists> checkedProjectFileExists)
            {
                var o = Instances.ContextOperations;

                var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>();
                var projectContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001, Context001>();
                var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005>();
                var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, ProjectOptionsContext>();
                var itemGropuContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context007, Context005, LibrarySolutionSetContext>();

                return o.In_ContextSet_ABCD_EABCD<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                    o.Construct_Context_E_EABCD<Context005, ProjectContext001, LibrarySolutionSetContext, Context001, Context000>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet).In(contextSet),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet).In(contextSet)
                    ),
                    Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                        out var projectElementSet).In(contextSet),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>().In(contextSet),
                    // Create the main property group element.
                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out var propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                            o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                    out var projectOptionsSet).In(propertyGroupOptionsContextSet),
                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                                    out (
                                    IsSet<IHasTargetFramework> TargetFrameworkSet,
                                    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                                    ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
                            ),
                            Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet),
                            Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
                        ).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                            out var checkedPropertyGroupElementAppended_Main)
                    ).In(contextSet),  
                    // Create the package property group element.
                    Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out propertyGroupElementSet).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
                        o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                            o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                    out projectOptionsSet).In(propertyGroupOptionsContextSet),
                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
                                    out (
                                    IsSet<IHasCompany> CompanySet,
                                    IsSet<IHasCopyright> CopyrightSet,
                                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                                    IsSet<IHasVersion> VersionSet
                                    ) impliedProjectOptionsSet_Package).In(propertyGroupOptionsContextSet)
                            ),
                            Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
                            Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
                            Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
                            Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet)
                        ).In(propertyGroupContextSet),
                        Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
                        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                            out var checkedPropertyGroupElementAppended_Package)
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

            static Func<LibrarySolutionSetContext, Context001, Context000, Task> Create_LibrarySolutionFile(
                SolutionSpecification solutionSpecification)
            {
                var o = Instances.ContextOperations;

                var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, LibrarySolutionSetContext>();

                return o.In_ContextSet_ABC_A<LibrarySolutionSetContext, Context001, Context000>(
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
                );
            }

            static Func<LibrarySolutionSetContext, Context001, Context000, Task> Create_ConstructionSolutionFile(
                SolutionSpecification solutionSpecification)
            {
                var o = Instances.ContextOperations;

                var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, LibrarySolutionSetContext>();

                return o.In_ContextSet_ABC_A<LibrarySolutionSetContext, Context001, Context000>(
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

            await Instances.ContextOperator.In_ContextSet(
                In_ApplicationContext(
                    out (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    ) applicationContextPropertiesSet,
                    In_RegeneratedRepositoryContext(repositorySpecification, (applicationContextPropertiesSet.GitHubClientSet, applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
                        out (
                        IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                        IsSet<IHasRepositoryName> RepositoryNameSet,
                        IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                        IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                        ) repositoryPropertiesSet,
                        In_SolutionSetContext(repositoryPropertiesSet.RepositoryDirectoryPathSet,
                            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
                            Create_LibraryProject(libraryProjectSpecification, projectOptions, solutionDirectoryPathSet,
                                out var libraryProjectFilePathSet,
                                out var checkedLibraryProjectFileExists),
                            Create_ConstructionProject(constructionProjectSpecification, projectOptions, solutionDirectoryPathSet,
                                out var constructionProjectFilePathSet,
                                out var checkedConstructionProjectFileExists),
                            Create_LibrarySolutionFile(librarySolutionSpecification),
                            Create_ConstructionSolutionFile(constructionSolutionSpecification),
                            // Open the construction solution file.
                            o.In_ContextSet_ABC_A<LibrarySolutionSetContext, Context001, Context000>(
                                Instances.VisualStudioContextOperations.Open_VisualStudioSolution<LibrarySolutionSetContext>(
                                    x => Task.FromResult(x.ConstructionSolutionFilePath)))
                        )
                    )
                )
            );
        }
    }
}
