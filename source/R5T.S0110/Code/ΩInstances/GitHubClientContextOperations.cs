using System;


namespace R5T.S0110
{
    public class GitHubClientContextOperations : IGitHubClientContextOperations
    {
        #region Infrastructure

        public static IGitHubClientContextOperations Instance { get; } = new GitHubClientContextOperations();


        private GitHubClientContextOperations()
        {
        }

        #endregion
    }
}
