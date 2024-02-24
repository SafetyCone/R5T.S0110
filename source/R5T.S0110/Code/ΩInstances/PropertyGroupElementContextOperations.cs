using System;


namespace R5T.S0110
{
    public class PropertyGroupElementContextOperations : IPropertyGroupElementContextOperations
    {
        #region Infrastructure

        public static IPropertyGroupElementContextOperations Instance { get; } = new PropertyGroupElementContextOperations();


        private PropertyGroupElementContextOperations()
        {
        }

        #endregion
    }
}
