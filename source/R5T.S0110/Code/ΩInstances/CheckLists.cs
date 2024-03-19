using System;


namespace R5T.S0110
{
    public class CheckLists : ICheckLists
    {
        #region Infrastructure

        public static ICheckLists Instance { get; } = new CheckLists();


        private CheckLists()
        {
        }

        #endregion
    }
}
