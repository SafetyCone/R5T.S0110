using System;


namespace R5T.S0110
{
    public class HasAuthenticationContextOperations : IHasAuthenticationContextOperations
    {
        #region Infrastructure

        public static IHasAuthenticationContextOperations Instance { get; } = new HasAuthenticationContextOperations();


        private HasAuthenticationContextOperations()
        {
        }

        #endregion
    }
}
