using System;
using System.Threading.Tasks;

using R5T.L0079;
using R5T.T0046;

using SimpleRepositoryContext = R5T.L0080.T001.RepositoryContext;
using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;
using GitHubRepositoryContext = R5T.S0110.RepositoryContext;


namespace R5T.S0110
{
    public partial interface IScripts
    {
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
                                context =>
                                {
                                    var gitIgnoreSourceFilePath = Instances.FilePaths.GitIgnoreTemplateFilePath;
                                    var gitIgnoreDestinationFilePath = Instances.RepositoryPathsOperator.Get_GitIgnoreFilePath(context.RepositoryDirectoryPath);

                                    Instances.FileSystemOperator._Platform.Copy_File(
                                        gitIgnoreSourceFilePath,
                                        gitIgnoreDestinationFilePath);

                                    return Task.CompletedTask;
                                },
                                Instances.LocalRepositoryContextOperations.In_SolutionDirectoryContext<CloneRepositoryLocallyContext>(
                                    out _,
                                    Instances.SolutionDirectoryContextOperations.Set_SolutionDirectory_Source,
                                    Instances.SolutionDirectoryContextOperations.In_SolutionContext<SolutionDirectoryContext>(
                                        solutionSpecification,
                                        out _,
                                        Instances.ContextOperations.DisplayContext_AtDesignTime_ForAsynchronous<SolutionFileContext>(),
                                        Instances.SolutionFileContextOperations.Set_SolutionFilePath<SolutionFileContext>(out var solutionFilePathSet),
                                        Instances.SolutionFileContextOperations.Verify_SolutionFile_DoesNotExist<SolutionFileContext>(out var solutionFileDoesNotExist),
                                        // Create solution file (including direcctory for file if it does not exist).
                                        Instances.HasDirectoryPathContextOperations.Create_Directory_IfNotExists<SolutionFileContext>(out var solutionDirectoryExists),
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
                                            Instances.ProjectContextOperations.Add_ProjectToSolution<ProjectContext>(),
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
    }
}
