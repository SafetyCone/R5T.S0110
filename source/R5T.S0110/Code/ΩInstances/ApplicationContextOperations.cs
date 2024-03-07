using System;


namespace R5T.S0110
{
    public class ApplicationContextOperations : IApplicationContextOperations
    {
        #region Infrastructure

        public static IApplicationContextOperations Instance { get; } = new ApplicationContextOperations();


        private ApplicationContextOperations()
        {
        }

        #endregion
    }
}
