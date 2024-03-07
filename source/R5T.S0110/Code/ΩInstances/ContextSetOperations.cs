using System;


namespace R5T.S0110
{
    public class ContextSetOperations : IContextSetOperations
    {
        #region Infrastructure

        public static IContextSetOperations Instance { get; } = new ContextSetOperations();


        private ContextSetOperations()
        {
        }

        #endregion
    }
}
