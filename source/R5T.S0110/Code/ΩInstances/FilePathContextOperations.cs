using System;


namespace R5T.S0110
{
    public class FilePathContextOperations : IFilePathContextOperations
    {
        #region Infrastructure

        public static IFilePathContextOperations Instance { get; } = new FilePathContextOperations();


        private FilePathContextOperations()
        {
        }

        #endregion
    }
}
