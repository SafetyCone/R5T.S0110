using System;


namespace R5T.S0110
{
    public class ProjectOptionsContextOperations : IProjectOptionsContextOperations
    {
        #region Infrastructure

        public static IProjectOptionsContextOperations Instance { get; } = new ProjectOptionsContextOperations();


        private ProjectOptionsContextOperations()
        {
        }

        #endregion
    }
}
