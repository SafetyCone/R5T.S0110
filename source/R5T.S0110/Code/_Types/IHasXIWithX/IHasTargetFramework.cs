﻿using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a Visual Studio project target framework moniker. (Example: "net8.0")
    /// </summary>
    [HasXMarker]
    public interface IHasTargetFramework : IHasXMarker
    {
        string TargetFramework { get; }
    }
}
