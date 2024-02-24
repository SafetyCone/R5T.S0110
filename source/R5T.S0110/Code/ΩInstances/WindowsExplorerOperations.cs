using System;


namespace R5T.S0110
{
    public class WindowsExplorerOperations : IWindowsExplorerOperations
    {
        #region Infrastructure

        public static IWindowsExplorerOperations Instance { get; } = new WindowsExplorerOperations();


        private WindowsExplorerOperations()
        {
        }

        #endregion
    }
}
