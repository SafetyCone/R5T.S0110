using System;


namespace R5T.S0110
{
    /// <summary>
    /// A good solution set context set.
    /// </summary>
    [ContextSetMarker]
    public class LibrarySolutionSetContextSet : IContextSetMarker,
        IWithContext<Context000>,
        IWithContext<Context001>,
        IWithContext<LibrarySolutionSetContext>
    {
        Context000 IWithContext<Context000>.Context { get; set; }
        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
        Context001 IWithContext<Context001>.Context { get; set; }
        Context001 IHasContext<Context001>.Context => (this as IWithContext<Context001>).Context;
        LibrarySolutionSetContext IWithContext<LibrarySolutionSetContext>.Context { get; set; }
        LibrarySolutionSetContext IHasContext<LibrarySolutionSetContext>.Context => (this as IWithContext<LibrarySolutionSetContext>).Context;
    }
}
