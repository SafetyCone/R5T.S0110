using System;


namespace R5T.S0110
{
    public class LocalRepositoryContextOperations : ILocalRepositoryContextOperations
    {
        #region Infrastructure

        public static ILocalRepositoryContextOperations Instance { get; } = new LocalRepositoryContextOperations();


        private LocalRepositoryContextOperations()
        {
        }

        #endregion
    }
}
