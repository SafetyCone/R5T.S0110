using System;


namespace R5T.S0110
{
    public class ProjectContextSetOperations : IProjectContextSetOperations
    {
        #region Infrastructure

        public static IProjectContextSetOperations Instance { get; } = new ProjectContextSetOperations();


        private ProjectContextSetOperations()
        {
        }

        #endregion
    }
}
