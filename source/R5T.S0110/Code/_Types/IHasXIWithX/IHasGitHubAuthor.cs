using System;

using R5T.T0046;
using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasGitHubAuthor : IHasXMarker
    {
        Author GitHubAuthor { get; }
    }
}
