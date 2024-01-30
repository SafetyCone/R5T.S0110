using System;


namespace R5T.S0110
{
    public class SolutionDirectoryContextOperations : ISolutionDirectoryContextOperations
    {
        #region Infrastructure

        public static ISolutionDirectoryContextOperations Instance { get; } = new SolutionDirectoryContextOperations();


        private SolutionDirectoryContextOperations()
        {
        }

        #endregion
    }
}
