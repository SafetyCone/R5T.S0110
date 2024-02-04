using System;


namespace R5T.S0110
{
    public class ProjectDirectoryPathRelativePaths : IProjectDirectoryPathRelativePaths
    {
        #region Infrastructure

        public static IProjectDirectoryPathRelativePaths Instance { get; } = new ProjectDirectoryPathRelativePaths();


        private ProjectDirectoryPathRelativePaths()
        {
        }

        #endregion
    }
}
