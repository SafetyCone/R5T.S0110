using System;


namespace R5T.S0110
{
    public class IsSetContextOperations : IIsSetContextOperations
    {
        #region Infrastructure

        public static IIsSetContextOperations Instance { get; } = new IsSetContextOperations();


        private IsSetContextOperations()
        {
        }

        #endregion
    }
}
