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
        TSolutionSetContext IHasSolutionSetContext<TSolutionSetContext>.SolutionSetContext => this.SolutionSetContext;

        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;

        public TApplicationContext ApplicationContext { get; set; }
        TApplicationContext IHasApplicationContext<TApplicationContext>.ApplicationContext => this.ApplicationContext;
    }

    /// <summary>
    /// A solution set context using:
    /// <list type="bullet">
    /// <item><see cref="RepositoryContext001"/></item>
    /// <item><see cref="ApplicationContext001"/></item>
    /// </list>
    /// But generic in the solution set context type.
    /// </summary>
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

    /// <summary>
    /// A good single-project solution set context using:
    /// <list type="bullet">
    /// <item><see cref="SolutionSetContext002"/></item>
    /// <item><see cref="RepositoryContext001"/></item>
    /// <item><see cref="ApplicationContext001"/></item>
    /// </list>
    /// </summary>
    [ContextSetMarker]
    public class SolutionSetContextSet003 : SolutionSetContextSet002<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;
    }

    /// <summary>
    /// A good library-with-construction solution set context using:
    /// <list type="bullet">
    /// <item><see cref="SolutionSetContext003"/></item>
    /// <item><see cref="RepositoryContext001"/></item>
    /// <item><see cref="ApplicationContext001"/></item>
    /// </list>
    /// </summary>
    [ContextSetMarker]
    public class SolutionSetContextSet004 : SolutionSetContextSet002<SolutionSetContext003>, IContextSetMarker,
        IWithContext<SolutionSetContext003>
    {
        SolutionSetContext003 IWithContext<SolutionSetContext003>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext003 IHasContext<SolutionSetContext003>.Context => (this as IWithContext<SolutionSetContext003>).Context;
    }
}
