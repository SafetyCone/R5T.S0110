using System;


namespace R5T.S0110
{
    public class GitHubOperator : IGitHubOperator
    {
        #region Infrastructure

        public static IGitHubOperator Instance { get; } = new GitHubOperator();


        private GitHubOperator()
        {
        }

        #endregion
    }
}
