using System;

using R5T.T0240;


namespace R5T.S0110
{
    [HasXMarker]
    public interface IHasApplicationContext<TApplicationContext> : IHasXMarker
    {
        TApplicationContext ApplicationContext { get; }
    }


    [WithXMarker]
    public interface IWithApplicationContext<TRepositoryContext> : IWithXMarker,
        IHasApplicationContext<TRepositoryContext>
    {
        new TRepositoryContext ApplicationContext { get; set; }
    }
}
