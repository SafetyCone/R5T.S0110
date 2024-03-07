using System;


namespace R5T.S0110
{
    public class SolutionSetContextOperations : ISolutionSetContextOperations
    {
        #region Infrastructure

        public static ISolutionSetContextOperations Instance { get; } = new SolutionSetContextOperations();


        private SolutionSetContextOperations()
        {
        }

        #endregion
    }
}
