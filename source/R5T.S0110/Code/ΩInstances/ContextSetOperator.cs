using System;


namespace R5T.S0110
{
    public class ContextSetOperator : IContextSetOperator
    {
        #region Infrastructure

        public static IContextSetOperator Instance { get; } = new ContextSetOperator();


        private ContextSetOperator()
        {
        }

        #endregion
    }
}
