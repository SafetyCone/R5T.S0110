using System;

using R5T.T0131;


namespace R5T.S0110
{
    /// <summary>
    /// Stringly-typed JSON element keys.
    /// </summary>
    [ValuesMarker]
    public partial interface IJsonKeys : IValuesMarker
    {
        /// <summary>
        /// <para><value>GitHubAuthor</value></para>
        /// </summary>
        public string GitHubAuthor => "GitHubAuthor";
    }
}
