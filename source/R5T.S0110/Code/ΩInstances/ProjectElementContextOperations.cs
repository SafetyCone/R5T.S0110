using System;


namespace R5T.S0110
{
    public class ProjectElementContextOperations : IProjectElementContextOperations
    {
        #region Infrastructure

        public static IProjectElementContextOperations Instance { get; } = new ProjectElementContextOperations();


        private ProjectElementContextOperations()
        {
        }

        #endregion
    }
}
