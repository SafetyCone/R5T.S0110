using System;
using System.Threading.Tasks;

using R5T.L0079;
using R5T.T0144;

using SimpleRepositoryContext = R5T.L0080.T001.RepositoryContext;
using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;
using GitHubRepositoryContext = R5T.S0110.RepositoryContext;
using R5T.T0046;


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

            var author = Instances.JsonOperator.Load_FromFile_Synchronous<Author>(
                Instances.Values.GitHubAuthorJsonFilePath,
                "GitHubAuthor");

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
                                author.Name,
                                author.EmailAddress,
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
                                        Instances.SolutionFileContextOperations.Set_SolutionFilePath,
                                        Instances.SolutionFileContextOperations.Verify_SolutionFilePath_DoesNotExist

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
