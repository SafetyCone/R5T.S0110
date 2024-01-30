using System;


namespace R5T.S0110
{
    public class CloneRepositoryLocallyContextOperations : ICloneRepositoryLocallyContextOperations
    {
        #region Infrastructure

        public static ICloneRepositoryLocallyContextOperations Instance { get; } = new CloneRepositoryLocallyContextOperations();


        private CloneRepositoryLocallyContextOperations()
        {
        }

        #endregion
    }
}
