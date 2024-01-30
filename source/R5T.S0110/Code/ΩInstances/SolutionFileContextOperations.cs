using System;


namespace R5T.S0110
{
    public class SolutionFileContextOperations : ISolutionFileContextOperations
    {
        #region Infrastructure

        public static ISolutionFileContextOperations Instance { get; } = new SolutionFileContextOperations();


        private SolutionFileContextOperations()
        {
        }

        #endregion
    }
}
