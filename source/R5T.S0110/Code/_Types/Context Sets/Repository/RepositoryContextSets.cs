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

    [ContextSetMarker]
    public class RepositoryContextSet002<TRepositoryContext> : RepositoryContextSet001<TRepositoryContext, ApplicationContext001>, IContextSetMarker,
        IWithContext<ApplicationContext001>
    {
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }

    [ContextSetMarker]
    public class RepositoryContextSet003 : RepositoryContextSet002<RepositoryContext001>, IContextSetMarker,
        IWithContext<RepositoryContext001>
    {
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
    }
}
