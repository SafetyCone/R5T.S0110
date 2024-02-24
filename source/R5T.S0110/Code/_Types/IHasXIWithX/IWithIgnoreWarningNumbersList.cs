﻿using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// Has a Visual Studio project warning numbers list of warnings to ignore (&lt;NoWarn&gt;). (Example: "1573;1587;1591")
    /// </summary>
    [WithXMarker]
    public interface IWithIgnoreWarningNumbersList : IWithXMarker,
        IHasIgnoreWarningNumbersList
    {
        new string IgnoreWarningNumbersList { get; set; }
    }
}
