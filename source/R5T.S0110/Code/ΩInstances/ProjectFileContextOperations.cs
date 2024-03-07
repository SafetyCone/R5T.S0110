using System;


namespace R5T.S0110
{
    public class ProjectFileContextOperations : IProjectFileContextOperations
    {
        #region Infrastructure

        public static IProjectFileContextOperations Instance { get; } = new ProjectFileContextOperations();


        private ProjectFileContextOperations()
        {
        }

        #endregion
    }
}
