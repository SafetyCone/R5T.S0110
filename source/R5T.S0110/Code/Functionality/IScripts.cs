using System;
using System.Threading.Tasks;

using R5T.L0079;
using R5T.T0132;
using R5T.T0144;

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
