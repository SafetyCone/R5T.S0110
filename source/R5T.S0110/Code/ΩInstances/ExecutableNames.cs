using System;


namespace R5T.S0110
{
    public class ExecutableNames : IExecutableNames
    {
        #region Infrastructure

        public static IExecutableNames Instance { get; } = new ExecutableNames();


        private ExecutableNames()
        {
        }

        #endregion
    }
}
