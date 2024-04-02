using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IExecutableNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>NPM</value></para>
        /// </summary>
        public string NPM => "npm";

        /// <summary>
        /// <para><value>NPX</value></para>
        /// </summary>
        public string NPX => "npx";
    }
}
