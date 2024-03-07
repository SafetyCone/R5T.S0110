using System;


namespace R5T.S0110
{
    public class SolutionSetContextSetOperations : ISolutionSetContextSetOperations
    {
        #region Infrastructure

        public static ISolutionSetContextSetOperations Instance { get; } = new SolutionSetContextSetOperations();


        private SolutionSetContextSetOperations()
        {
        }

        #endregion
    }
}
