using System;


namespace R5T.S0110
{
    public class ContextSetTypeAdapters : IContextSetTypeAdapters
    {
        #region Infrastructure

        public static IContextSetTypeAdapters Instance { get; } = new ContextSetTypeAdapters();


        private ContextSetTypeAdapters()
        {
        }

        #endregion
    }
}
