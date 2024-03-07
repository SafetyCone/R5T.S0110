using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasSolutionContext<TSolutionContext> : IHasXMarker
    {
        TSolutionContext SolutionContext { get; }
    }


    [WithXMarker]
    public interface IWithSolutionContext<TSolutionContext> : IWithXMarker,
        IHasSolutionContext<TSolutionContext>
    {
        new TSolutionContext SolutionContext { get; set; }
    }
}
