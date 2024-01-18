using System;
using System.Threading.Tasks;

using R5T.L0079;
using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        ///// <summary>
        ///// Only creates a remote (GitHub) repository.
        ///// Does not clone the repository local, or add any local files.
        ///// </summary>
        //public async Task Create_RemoteRepositoryOnly()
        //{

        //}

        /// <summary>
        /// A first script to just login to GitHub using the Octokit client.
        /// </summary>
        public async Task Get_GitHubClient()
        {
            /// Inputs.
            var repositoryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate = true;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = Instances.RepositoryDescriptionExamples.ForTesting,
                IsPrivate = isPrivate,
                License = License.MIT,
            };


            /// Run.
            await Instances.RepositoryOperator.In_RepositoryContext(
                repositoryOwnerName,
                repositoryName,
                Instances.RepositoryContextOperations.In_GitHubClientContext<L0080.T001.RepositoryContext>(
                    //Instances.GitHubClientContextOperations.Set_GitHubClient<L0081.T001.RepositoryContext>()
                    Instances.GitHubClientContextOperations.In_SetGitHubClientContext<L0081.T001.RepositoryContext>(
                        Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath,
                        Instances.SetGitHubClientContextOperations.Load_Authentication,
                        Instances.SetGitHubClientContextOperations.Set_GitHubClient
                    ),
                    Instances.GitHubClientContextOperations.Verify_IsWorking
                )
            );
        }
    }
}
