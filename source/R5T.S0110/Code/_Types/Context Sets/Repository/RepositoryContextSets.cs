using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class RepositoryContextSet001<TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;

        public TApplicationContext ApplicationContext { get; set; }
        TApplicationContext IHasApplicationContext<TApplicationContext>.ApplicationContext => this.ApplicationContext;
    }

    /// <summary>
    /// A repository-level context set using the <see cref="ApplicationContext001"/> application context, and allowing for a generic repository context type.
    /// </summary>
    [ContextSetMarker]
    public class RepositoryContextSet002<TRepositoryContext> : RepositoryContextSet001<TRepositoryContext, ApplicationContext001>, IContextSetMarker,
        IWithContext<ApplicationContext001>
    {
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }

    /// <summary>
    /// A repository-elvel context set using the <see cref="RepositoryContext001"/> (and <see cref="ApplicationContext001"/>).
    /// </summary>
    [ContextSetMarker]
    public class RepositoryContextSet003 : RepositoryContextSet002<RepositoryContext001>, IContextSetMarker,
        IWithContext<RepositoryContext001>
    {
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
    }
}
