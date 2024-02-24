using System;

using R5T.T0046;
using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithGitHubAuthor : IWithXMarker,
        IHasGitHubAuthor
    {
        new Author GitHubAuthor { get; set; }
    }
}
