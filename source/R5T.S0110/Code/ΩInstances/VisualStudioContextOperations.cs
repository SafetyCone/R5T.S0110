using System;


namespace R5T.S0110
{
    public class VisualStudioContextOperations : IVisualStudioContextOperations
    {
        #region Infrastructure

        public static IVisualStudioContextOperations Instance { get; } = new VisualStudioContextOperations();


        private VisualStudioContextOperations()
        {
        }

        #endregion
    }
}
