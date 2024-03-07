using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasRepositoryContext<TRepositoryContext> : IHasXMarker
    {
        TRepositoryContext RepositoryContext { get; }
    }


    [WithXMarker]
    public interface IWithRepositoryContext<TSolutionSetContext> : IWithXMarker,
        IHasRepositoryContext<TSolutionSetContext>
    {
        new TSolutionSetContext RepositoryContext { get; set; }
    }
}
