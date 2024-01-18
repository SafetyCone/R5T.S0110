using System;

using R5T.T0142;


namespace R5T.S0110
{
    [DataTypeMarker]
    public interface IHasGitHubAuthenticationJsonFilePath
    {
        string GitHubAuthenticationJsonFilePath { get; }
    }
}
