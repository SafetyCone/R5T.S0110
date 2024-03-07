using System;


namespace R5T.S0110
{
    /// <summary>
    /// A good application context set.
    /// </summary>
    [ContextSetMarker]
    public class ContextSet001 : IContextSetMarker,
        IWithContext<Context000>
    {
        Context000 IWithContext<Context000>.Context { get; set; }
        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
    }
}
