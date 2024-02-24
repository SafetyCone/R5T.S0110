using System;


namespace R5T.S0110
{
    public class ItemGroupElementContextOperations : IItemGroupElementContextOperations
    {
        #region Infrastructure

        public static IItemGroupElementContextOperations Instance { get; } = new ItemGroupElementContextOperations();


        private ItemGroupElementContextOperations()
        {
        }

        #endregion
    }
}
