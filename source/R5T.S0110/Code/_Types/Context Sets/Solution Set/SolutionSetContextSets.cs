using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class SolutionSetContextSet001<TSolutionSetContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithSolutionSetContext<TSolutionSetContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TSolutionSetContext SolutionSetContext { get; set; }
        TSolutionSetContext IHasSolutionContext<TSolutionSetContext>.SolutionSetContext => this.SolutionSetContext;

        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;

        public TApplicationContext ApplicationContext { get; set; }
        TApplicationContext IHasApplicationContext<TApplicationContext>.ApplicationContext => this.ApplicationContext;
    }

    [ContextSetMarker]
    public class SolutionSetContextSet002<TSolutionSetContext> : SolutionSetContextSet001<TSolutionSetContext, RepositoryContext001, ApplicationContext001>, IContextSetMarker,
        IWithContext<RepositoryContext001>,
        IWithContext<ApplicationContext001>
    {
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }

    [ContextSetMarker]
    public class SolutionSetContextSet003 : SolutionSetContextSet002<SingleProjectSolutionSetContext>, IContextSetMarker,
        IWithContext<SingleProjectSolutionSetContext>
    {
        SingleProjectSolutionSetContext IWithContext<SingleProjectSolutionSetContext>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SingleProjectSolutionSetContext IHasContext<SingleProjectSolutionSetContext>.Context => (this as IWithContext<SingleProjectSolutionSetContext>).Context;
    }
}
