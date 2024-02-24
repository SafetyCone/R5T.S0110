using System;


namespace R5T.S0110
{
    public class IsSetOperator : IIsSetOperator
    {
        #region Infrastructure

        public static IIsSetOperator Instance { get; } = new IsSetOperator();


        private IsSetOperator()
        {
        }

        #endregion
    }
}
