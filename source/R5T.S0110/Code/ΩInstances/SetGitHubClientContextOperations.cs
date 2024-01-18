using System;


namespace R5T.S0110
{
    public class SetGitHubClientContextOperations : ISetGitHubClientContextOperations
    {
        #region Infrastructure

        public static ISetGitHubClientContextOperations Instance { get; } = new SetGitHubClientContextOperations();


        private SetGitHubClientContextOperations()
        {
        }

        #endregion
    }
}
