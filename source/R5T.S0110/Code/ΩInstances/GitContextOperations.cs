using System;


namespace R5T.S0110
{
    public class GitContextOperations : IGitContextOperations
    {
        #region Infrastructure

        public static IGitContextOperations Instance { get; } = new GitContextOperations();


        private GitContextOperations()
        {
        }

        #endregion
    }
}
