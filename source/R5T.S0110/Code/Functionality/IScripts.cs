using System;
using System.Threading.Tasks;

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

using SimpleRepositoryContext = R5T.L0080.T001.RepositoryContext;
using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;
using GitHubRepositoryContext = R5T.S0110.RepositoryContext;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        public class In_CreatedRemoteRepositoryContext_GlobalContext :
            IWithAuthentication
        {
            public Authentication Authentication { get; set; }
            Authentication L0085.IWithX<Authentication>.X { get => this.Authentication; set => this.Authentication = value; }
            Authentication L0085.IHasX<Authentication>.X => this.Authentication;
        }

        /// <summary>
        /// Generate a repository with a console application.
        /// </summary>
        public async Task Regenerate_ConsoleRepository()
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
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var applicationContext = new Context000();

            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet<Context000>(applicationContext,
                Instances.ContextOperations.Set_ContextProperties<Context000>(
                    out var applicationContextPropertiesSet),
                // Create the repository.
                o.In_ContextSet_A_BA<Context001, Context000>(_ =>
                {
                    var repositoryContext = new Context001();

                    return Task.FromResult(repositoryContext);
                },
                // Transfer properties from the application context to the repository context.
                Instances.ContextOperations.Set_ContextProperties<Context001, Context000>((applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
                    out var repositoryContextPropertiesSet),
                o.In_ContextSet_AB_A<Context001, Context000>(
                    Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(repositorySpecification,
                        out (
                        IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                        IsSet<IHasRepositoryName> RepositoryNameSet,
                        IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                        IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                        ) repositoryPropertiesSet)),
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
                        IChecked<ILocalRepositoryExists> LocalRepositoryExists
                        ) checkedRepository),
                    o.In_ContextSet_AB_A<Context001, Context000>(
                        Instances.GitContextOperations.In_GitPushContext_Start<Context001>(Instances.CommitMessages.InitialCommit,
                            out var initialCommitToken),
                        // Add the Git ignore file while we are in this sub-context.
                        Instances.RepositoryContextOperations.Add_GitIgnoreFile<Context001>(repositoryPropertiesSet.RepositoryDirectoryPathSet,
                            out var checkedGitIgnoreFileExists)
                    ),
                    // Create the solution context.
                    o.In_ContextSet_AB_CAB<Context003, Context001, Context000>((_, _) =>
                    {
                        var solutionContext = new Context003();

                        return Task.FromResult(solutionContext);
                    },
                    o.In_ContextSet_ABC_AB<Context003, Context001, Context000>(
                        Instances.RepositoryContextOperations.Set_RepositoryProperties<Context003, Context001>(repositoryPropertiesSet.RepositoryDirectoryPathSet,
                            out var repositoryDirectoryPathSet),
                        o.In_ContextSet_AB_A<Context003, Context001>(
                            Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<Context003>(repositoryDirectoryPathSet,
                                out var solutionDirectoryPathSet),
                            Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
                                out (
                                IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                                IsSet<IHasSolutionName> SolutionNameSet
                                ) solutionSpecificationPropertiesSet),
                            Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((solutionDirectoryPathSet, solutionSpecificationPropertiesSet.SolutionNameSet),
                                out var solutionFilePathSet),
                            Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                                out var checkedSolutionFileDoesNotExist),
                            Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(solutionDirectoryPathSet),
                                out var checkedSolutionDirectoryExists),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                                out var checkedSolutionFileExists))
                    ),
                    // Create the project context.
                    o.In_ContextSet_ABC_DABC<Context004, Context003, Context001, Context000>((_, _, _) =>
                    {
                        var projectContext = new Context004();

                        return Task.FromResult(projectContext);
                    },
                    o.In_ContextSet_ABCD_AB<Context004, Context003, Context001, Context000>(
                        Instances.SolutionContextOperations.Set_SolutionProperties<Context004, Context003>((repositoryDirectoryPathSet, solutionFilePathSet),
                            out var projectSolutionPropertiesSet),
                        o.In_ContextSet_AB_A<Context004, Context003>(
                            Instances.ProjectContextOperations.Set_ProjectSpecification<Context004>(projectSpecification,
                                out var projectSpecificationPropertiesSet),
                            Instances.ProjectContextOperations.Set_ProjectDirectoryPath<Context004>((projectSolutionPropertiesSet.SolutionFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                                out var projectDirectoryPathSet),
                            Instances.ProjectContextOperations.Set_ProjectFilePath<Context004>((projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
                                out var projectFilePathSet),
                            Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context004>(Instances.IsSetOperator.Implies<IHasFilePath, IHasProjectFilePath>(projectFilePathSet), out var checkedProjectFilePathDoesNotExist),
                            // Create the project console file.
                            Instances.ProjectContextOperations.Set_NamespaceName<Context004>(projectSpecificationPropertiesSet.ProjectNameSet, out var namespaceNameSet))
                    ),
                    // Create the project file.
                    o.In_ContextSet_ABCD_EAC<Context005, Context004, Context003, Context001, Context000>((_, _, _, _) =>
                    {
                        var projectElementContext = new Context005();

                        return Task.FromResult(projectElementContext);
                    },
                    o.In_ContextSet_ABC_AB<Context005, Context004, Context001>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, Context004>(projectFilePathSet,
                            out var projectElementContextProjectFilePathSet),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, Context004>(projectSpecificationPropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet),
                        o.In_ContextSet_AB_A<Context005, Context004>(
                            Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                                out var projectElementSet),
                            Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>(),
                            // Create the main property group element.
                            Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                                o.In_ContextSet_AB_A<Context006, Context005>(
                                    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                                        out var propertyGroupElementSet),
                                    Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet),
                                    Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<Context006>(propertyGroupElementSet),
                                    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                                        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                            o.In_ContextSet_AB_B<Context006, ProjectOptionsContext>(
                                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                                    out var projectOptionsSet),
                                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                                                    out (
                                                    IsSet<IHasTargetFramework> TargetFrameworkSet,
                                                    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                                                    ) impliedProjectOptionsSet_Main)
                                            )
                                        ),
                                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet),
                                        Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
                                    )
                                ),
                                Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                                    out var checkedPropertyGroupElementAppended_Main)
                            ),
                            // Create the package property group element.
                            Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
                                o.In_ContextSet_AB_A<Context006, Context005>(
                                    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                                        out propertyGroupElementSet),
                                    Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet),
                                    o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
                                        o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
                                            o.In_ContextSet_AB_B<Context006, ProjectOptionsContext>(
                                                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                                                    out projectOptionsSet),
                                                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
                                                    out (
                                                    IsSet<IHasCompany> CompanySet,
                                                    IsSet<IHasCopyright> CopyrightSet,
                                                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                                                    IsSet<IHasVersion> VersionSet
                                                    ) impliedProjectOptionsSet_Package)
                                            )
                                        ),
                                        Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet),
                                        Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet),
                                        Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet),
                                        Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet)
                                    )
                                ),
                                Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectElementContextProjectDescriptionSet),
                                Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                                    out var checkedPropertyGroupElementAppended_Package)
                            ),
                            Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                                out var checkedProjectFileExists)))
                    ),
                    // Create project's files.
                    o.In_ContextSet_ABCD_A<Context004, Context003, Context001, Context000>(
                        Instances.CodeFileGenerationContextOperations.Create_ProgramFile_ForConsole<Context004>((projectFilePathSet, namespaceNameSet),
                            out var checkedProgramFileExists),
                        Instances.CodeFileGenerationContextOperations.Create_DocumentationFile<Context004>((projectFilePathSet, namespaceNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                            out var checkedDocumentationFileExists),
                        Instances.CodeFileGenerationContextOperations.Create_InstancesFile<Context004>((projectFilePathSet, namespaceNameSet),
                            out var checkedInstancesFileExists),
                        Instances.CodeFileGenerationContextOperations.Create_ProjectPlanFile<Context004>((projectFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet, projectSpecificationPropertiesSet.ProjectDescriptionSet),
                            out var checkedProjectPlanFileExists)
                    ),
                    o.In_ContextSet_ABCD_A<Context004, Context003, Context001, Context000>(
                        Instances.ProjectContextOperations.Add_ProjectToSolution<Context004>((projectFilePathSet, projectSolutionPropertiesSet.SolutionFilePathSet),
                            out var checkedSolutionHasProject))
                    ),
                    o.In_ContextSet_ABC_A<Context003, Context001, Context000>(
                        // Open the Visual Studio solution file.
                        Instances.VisualStudioContextOperations.Open_VisualStudioSolution<Context003>(solutionFilePathSet))
                ),
                o.In_ContextSet_AB_A<Context001, Context000>(
                    Instances.GitContextOperations.In_GitPushContext_End<Context001>(initialCommitToken, (repositoryPropertiesSet.RepositoryDirectoryPathSet, repositoryContextPropertiesSet.GitHubAuthenticationSet, repositoryContextPropertiesSet.GitHubAuthorSet),
                        out var checkedLocalChangesPushedToRemote),
                    // Open the repository directory path while here in this context.
                    Instances.WindowsExplorerOperations.Open_DirectoryPath<Context001>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasRepositoryDirectoryPath>(repositoryPropertiesSet.RepositoryDirectoryPathSet))))
            );

            static void Ensure_RequiredChecks_ForRepository(
                IChecked<IGitHubRepositoryExists> checkedGitHubRepositoryExists,
                IChecked<ILocalRepositoryExists> checkedLocalRepositoryExists,
                IChecked<IFileExists> checkedGitIgnoreFileExists,
                IChecked<ILocalChangesPushedToRemote> checkedLocalChangesPushedToRemote)
            {
                // Do nothing. This method just provides required input arguments to make sure things have been done.
            }

            static void Ensure_RequiredChecks_ForSolution(
                IChecked<IFileExists> checkedSolutionFileExists,
                IChecked<ISolutionHasProject> chekedSolutionHasProject)
            {
                // Do nothing. This method just provides required input arguments to make sure things have been done.
            }

            static void Ensure_RequiredChecks_ForProject(
                IChecked<IFileExists> checkedProjectFileExists,
                IChecked<ISolutionHasProject> chekedSolutionHasProject,
                IChecked<IFileExists> checkedProgramFileExists,
                IChecked<IFileExists> checkedDocumentationFileExists,
                IChecked<IFileExists> checkedInstancesFileExists,
                IChecked<IFileExists> checkedProjectPlanFileExists)
            {
                // Do nothing. This method just provides required input arguments to make sure things have been done.
            }

            // Checks.
            Ensure_RequiredChecks_ForRepository(
                checkedRepository.GitHubRepositoryExists,
                checkedRepository.LocalRepositoryExists,
                checkedGitIgnoreFileExists,
                checkedLocalChangesPushedToRemote
            );

            Ensure_RequiredChecks_ForSolution(
                checkedSolutionFileExists,
                checkedSolutionHasProject
            );

            Ensure_RequiredChecks_ForProject(
                checkedProjectFileExists,
                checkedSolutionHasProject,
                checkedProgramFileExists,
                checkedDocumentationFileExists,
                checkedInstancesFileExists,
                checkedProjectPlanFileExists
            );

            //await Instances.ContextOperator.In_Context(
            //    applicationContext,
            //    async applicationContext =>
            //    {
            //        var repositoryContext = new Context001();

            //        //await Instances.ContextOperator.In_ContextSet(
            //        //    repositoryContext,
            //        //    applicationContext,
            //        //    (repositoryContext, applicationContext) =>
            //        //    {
            //        //        return Task.CompletedTask;
            //        //    },
            //        //    (repositoryContext, _) =>
            //        //    {
            //        //        return Task.CompletedTask;
            //        //    }
            //        //);

            //        await Instances.ContextOperator.In_Context(
            //            () => new Context001(),
            //            Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(
            //                repositorySpecification,
            //                out (
            //                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            //                IsSet<IHasRepositoryName> RepositoryNameSet,
            //                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
            //                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            //                ) repositoryPropertiesSet
            //            ),
            //            Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>(
            //                applicationContext,
            //                (
            //                repositoryPropertiesSet.RepositorySpecificationSet,
            //                repositoryPropertiesSet.RepositoryNameSet,
            //                repositoryPropertiesSet.RepositoryOwnerNameSet,
            //                contextPropertiesSet.GitHubClientSet,
            //                contextPropertiesSet.GitHubAuthenticationSet,
            //                repositoryPropertiesSet.RepositoryDirectoryPathSet
            //                ),
            //                out _,
            //                out _
            //            ),
            //            Instances.GitContextOperations.In_GitPushContext<Context001>(
            //                Instances.CommitMessages.InitialCommit,
            //                (repositoryPropertiesSet.RepositoryDirectoryPathSet, contextPropertiesSet.GitHubAuthenticationSet, contextPropertiesSet.GitHubAuthorSet),
            //                // Add the Git ignore file.
            //                Instances.RepositoryContextOperations.Add_GitIgnoreFile<Context001>(
            //                    repositoryPropertiesSet.RepositoryDirectoryPathSet,
            //                    out var gitIgnoreFileExists
            //                ),
            //                // Create the solution.
            //                async repositoryContext =>
            //                {
            //                    await Instances.ContextOperator.In_Context(
            //                        () => new Context003(),
            //                        Instances.RepositoryContextOperations.Set_RepositoryProperties<Context003, Context001>(
            //                            repositoryContext,
            //                            repositoryPropertiesSet.RepositoryDirectoryPathSet,
            //                            out var repositoryDirectoryPathSet
            //                        ),
            //                        Instances.SolutionContextOperations.Set_SolutionDirectory_Source<Context003>(
            //                            repositoryDirectoryPathSet,
            //                            out var solutionDirectoryPathSet
            //                        ),
            //                        //Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(
            //                        //    solutionSpecification,
            //                        //    out IsSet<IHasSolutionSpecification> SolutionSpecificationSet
            //                        //),
            //                        Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(
            //                            solutionSpecification,
            //                            out (
            //                            IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
            //                            IsSet<IHasSolutionName> SolutionNameSet
            //                            ) solutionSpecificationPropertiesSet
            //                        ),
            //                        Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>(
            //                            (
            //                            solutionDirectoryPathSet,
            //                            solutionSpecificationPropertiesSet.SolutionNameSet
            //                            //Instances.IsSetOperator.Implies<IHasSolutionName, IHasSolutionSpecification>(solutionSpecificationSet)
            //                            ),
            //                            out var solutionFilePathSet
            //                        ),
            //                        Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(
            //                            Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
            //                            out var checkedSolutionFileDoesNotExist
            //                        ),
            //                        Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(
            //                            Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(solutionDirectoryPathSet),
            //                            out var checkedSolutionDirectoryExists
            //                        ),
            //                        Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(
            //                            solutionFilePathSet,
            //                            checkedSolutionFileDoesNotExist,
            //                            out var checkedSolutionFileExists
            //                        ),
            //                        // Create the project file.
            //                        async solutionContext =>
            //                        {
            //                            await Instances.ContextOperator.In_Context<Context004>(
            //                                () => new Context004(),
            //                                Instances.SolutionContextOperations.Set_SolutionProperties<Context004, Context003>(
            //                                    solutionContext,
            //                                    (repositoryDirectoryPathSet, solutionFilePathSet),
            //                                    out var solutionPropertiesSet
            //                                ),
            //                                Instances.ProjectContextOperations.Set_ProjectSpecification<Context004>(
            //                                    projectSpecification,
            //                                    out var projectSpecificationPropertiesSet
            //                                ),
            //                                Instances.ProjectContextOperations.Set_ProjectDirectoryPath<Context004>(
            //                                    (solutionPropertiesSet.SolutionFilePathSet, projectSpecificationPropertiesSet.ProjectNameSet),
            //                                    out var projectDirectoryPathSet
            //                                ),
            //                                Instances.ProjectContextOperations.Set_ProjectFilePath<Context004>(
            //                                    (projectDirectoryPathSet, projectSpecificationPropertiesSet.ProjectNameSet),
            //                                    out var projectFilePathSet
            //                                ),
            //                                Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context004>(
            //                                    Instances.IsSetOperator.Implies<IHasFilePath, IHasProjectFilePath>(projectFilePathSet),
            //                                    out var checkedProjectFilePathDoesNotExist
            //                                ),
            //                                // Create the project file (by building the project XElement, and then serializing it).
            //                                projectContext =>
            //                                {


            //                                    return Task.CompletedTask;
            //                                }
            //                            );
            //                        }
            //                    );
            //                }
            //            ),
            //            Instances.WindowsExplorerOperations.Open_DirectoryPath<Context001>(
            //                Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasRepositoryDirectoryPath>(repositoryPropertiesSet.RepositoryDirectoryPathSet)
            //            )
            //        );

            //        // Checks.
            //        Ensure_RequiredChecks_ForRepository(
            //            gitIgnoreFileExists);
            //    }
            //);
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
