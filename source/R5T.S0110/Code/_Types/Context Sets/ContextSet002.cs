using System;


namespace R5T.S0110
{
    /// <summary>
    /// A good repository context set.
    /// </summary>
    [ContextSetMarker]
    public class ContextSet002 : IContextSetMarker,
        IWithContext<Context000>,
        IWithContext<Context001>
    {
        Context000 IWithContext<Context000>.Context { get; set; }
        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
        Context001 IWithContext<Context001>.Context { get; set; }
        Context001 IHasContext<Context001>.Context => (this as IWithContext<Context001>).Context;
    }
}
