using System;


namespace R5T.S0110
{
    public class JsonKeys : IJsonKeys
    {
        #region Infrastructure

        public static IJsonKeys Instance { get; } = new JsonKeys();


        private JsonKeys()
        {
        }

        #endregion
    }
}
