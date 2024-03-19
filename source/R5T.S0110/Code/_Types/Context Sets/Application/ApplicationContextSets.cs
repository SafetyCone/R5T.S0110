using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class ApplicationContextSet001<TApplicationContext> : IContextSetMarker,
        IWithApplicationContext<TApplicationContext>
    {
        public TApplicationContext ApplicationContext { get; set; }
        TApplicationContext IHasApplicationContext<TApplicationContext>.ApplicationContext => this.ApplicationContext;
    }


    /// <summary>
    /// An application-level context set using the <see cref="ApplicationContext001"/> context.
    /// <para>
    /// <see cref="ApplicationContext001"/>:
    /// </para>
    /// <inheritdoc cref="ApplicationContext001" path="/summary"/>
    /// </summary>
    [ContextSetMarker]
    public class ApplicationContextSet002 : ApplicationContextSet001<ApplicationContext001>, IContextSetMarker,
        IWithContext<ApplicationContext001>
    {
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context { get => this.ApplicationContext; }
    }
}
