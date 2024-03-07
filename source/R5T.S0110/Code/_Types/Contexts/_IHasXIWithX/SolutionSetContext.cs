using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasSolutionSetContext<TSolutionSetContext> : IHasXMarker
    {
        TSolutionSetContext SolutionSetContext { get; }
    }


    [WithXMarker]
    public interface IWithSolutionSetContext<TSolutionSetContext> : IWithXMarker,
        IHasSolutionSetContext<TSolutionSetContext>
    {
        new TSolutionSetContext SolutionSetContext { get; set; }
    }
}
