using System;


namespace R5T.S0110
{
    public class RepositoryPathsOperator : IRepositoryPathsOperator
    {
        #region Infrastructure

        public static IRepositoryPathsOperator Instance { get; } = new RepositoryPathsOperator();


        private RepositoryPathsOperator()
        {
        }

        #endregion
    }
}
