using System;

using R5T.T0142;
using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker, DataTypeMarker]
    public interface IWithRepositoryGitDirectoryPath :
        IHasRepositoryGitDirectoryPath
    {
        new string RepositoryGitDirectoryPath { get; set; }
    }
}
