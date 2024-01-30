using System;


namespace R5T.S0110
{
    public class RepositoryDirectoryNameOperator : IRepositoryDirectoryNameOperator
    {
        #region Infrastructure

        public static IRepositoryDirectoryNameOperator Instance { get; } = new RepositoryDirectoryNameOperator();


        private RepositoryDirectoryNameOperator()
        {
        }

        #endregion
    }
}
