﻿using System;

using R5T.T0142;
using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker, DataTypeMarker]
    public interface IHasRepositoryGitDirectoryPath
    {
        string RepositoryGitDirectoryPath { get; }
    }
}
