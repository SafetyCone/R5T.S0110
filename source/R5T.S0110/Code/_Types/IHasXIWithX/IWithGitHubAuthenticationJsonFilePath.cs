using System;

using R5T.T0142;


namespace R5T.S0110
{
    [DataTypeMarker]
    public interface IWithGitHubAuthenticationJsonFilePath :
        IHasGitHubAuthenticationJsonFilePath
    {
        new string GitHubAuthenticationJsonFilePath { get; set; }
    }
}
