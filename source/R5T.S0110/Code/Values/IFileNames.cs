using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IFileNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>.gitignore</value></para>
        /// </summary>
        public string GitIgnore => ".gitignore";
    }
}
