using System;

using R5T.T0142;
using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker, DataTypeMarker]
    public interface IWithSolutionDirectoryPath :
        IHasSolutionDirectoryPath
    {
        new string SolutionDirectoryPath { get; set; }
    }
}
