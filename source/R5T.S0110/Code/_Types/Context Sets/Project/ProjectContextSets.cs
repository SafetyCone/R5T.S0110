using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class ProjectContextSet001<TProjectContext, TSolutionContext, TSolutionSetContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithProjectContext<TProjectContext>,
        IWithSolutionContext<TSolutionContext>,
        IWithSolutionSetContext<TSolutionSetContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TProjectContext ProjectContext { get; set; }
        TProjectContext IHasProjectContext<TProjectContext>.ProjectContext => this.ProjectContext;

        public TSolutionContext SolutionContext { get; set; }
        TSolutionContext IHasSolutionContext<TSolutionContext>.SolutionContext => this.SolutionContext;

        public TSolutionSetContext SolutionSetContext { get; set; }
        TSolutionSetContext IHasSolutionSetContext<TSolutionSetContext>.SolutionSetContext => this.SolutionSetContext;

        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;

        public TApplicationContext ApplicationContext { get; set; }
        TApplicationContext IHasApplicationContext<TApplicationContext>.ApplicationContext => this.ApplicationContext;
    }

    [ContextSetMarker]
    public class ProjectContextSet002<TProjectContext, TSolutionSetContext> : ProjectContextSet001<TProjectContext, SolutionContext001, TSolutionSetContext, RepositoryContext001, ApplicationContext001>, IContextSetMarker,
        IWithContext<SolutionContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ApplicationContext001>
    {
        SolutionContext001 IWithContext<SolutionContext001>.Context { get => this.SolutionContext; set => this.SolutionContext = value; }
        SolutionContext001 IHasContext<SolutionContext001>.Context => (this as IWithContext<SolutionContext001>).Context;
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }

    [ContextSetMarker]
    public class ProjectContextSet003<TSolutionSetContext> : ProjectContextSet002<ProjectContext001, TSolutionSetContext>, IContextSetMarker,
        IWithContext<ProjectContext001>
    {
        ProjectContext001 IWithContext<ProjectContext001>.Context { get => this.ProjectContext; set => this.ProjectContext = value; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;
    }

    /// <summary>
    /// For projects in single-project (<see cref="SolutionSetContext002"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectContextSet004 : ProjectContextSet003<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;
    }

    /// <summary>
    /// For projects in library-and-construction (<see cref="SolutionSetContext003"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectContextSet005 : ProjectContextSet003<SolutionSetContext003>, IContextSetMarker,
        IWithContext<SolutionSetContext003>
    {
        SolutionSetContext003 IWithContext<SolutionSetContext003>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext003 IHasContext<SolutionSetContext003>.Context => (this as IWithContext<SolutionSetContext003>).Context;
    }

    /// <summary>
    /// For projects in client-and-server (<see cref="SolutionSetContext004"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectContextSet006 : ProjectContextSet003<SolutionSetContext004>, IContextSetMarker,
        IWithContext<SolutionSetContext004>
    {
        SolutionSetContext004 IWithContext<SolutionSetContext004>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext004 IHasContext<SolutionSetContext004>.Context => (this as IWithContext<SolutionSetContext004>).Context;
    }

    /// <summary>
    /// For projects in client-and-server (<see cref="SolutionSetContext004"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectContextSet007 : ProjectContextSet003<SolutionSetContext005>, IContextSetMarker,
        IWithContext<SolutionSetContext005>
    {
        SolutionSetContext005 IWithContext<SolutionSetContext005>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext005 IHasContext<SolutionSetContext005>.Context => (this as IWithContext<SolutionSetContext005>).Context;
    }
}
