using System;


namespace R5T.S0110
{
    public class Scripts : IScripts
    {
        #region Infrastructure

        public static IScripts Instance { get; } = new Scripts();


        private Scripts()
        {
        }

        #endregion
    }
}
