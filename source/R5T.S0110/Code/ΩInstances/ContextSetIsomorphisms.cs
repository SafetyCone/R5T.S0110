using System;


namespace R5T.S0110
{
    public class ContextSetIsomorphisms : IContextSetIsomorphisms
    {
        #region Infrastructure

        public static IContextSetIsomorphisms Instance { get; } = new ContextSetIsomorphisms();


        private ContextSetIsomorphisms()
        {
        }

        #endregion
    }
}
