using System;


namespace R5T.S0110
{
    public class ContextOperator : IContextOperator
    {
        #region Infrastructure

        public static IContextOperator Instance { get; } = new ContextOperator();


        private ContextOperator()
        {
        }

        #endregion
    }
}
