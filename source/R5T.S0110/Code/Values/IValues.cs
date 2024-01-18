using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        public string GitHubAuthenticationJsonFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Data\Secrets\Authentication-GitHub-davidcoats-R5T.S0110.json";
        public string GitHubProductHeaderValue => "R5T.S0110";
    }
}
