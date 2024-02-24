using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker,
        L0032.Z002.IValues
    {
        public string GitHubAuthenticationJsonFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Data\Secrets\Authentication-GitHub-davidcoats-R5T.S0110.json";
        public string GitHubAuthorJsonFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Data\Secrets\GitHub-Author-David.json";
        public string GitHubProductHeaderValue => "R5T.S0110";
        public string LocalRepositoriesDirectoryPath => @"C:\Code\DEV\Git\GitHub\";
    }
}
