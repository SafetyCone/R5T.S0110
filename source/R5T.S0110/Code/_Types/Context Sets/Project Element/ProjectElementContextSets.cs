﻿using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class ProjectElementContextSet001<TProjectElementContext, TProjectContext, TSolutionContext, TSolutionSetContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithProjectElementContext<TProjectElementContext>,
        IWithProjectContext<TProjectContext>,
        IWithSolutionContext<TSolutionContext>,
        IWithSolutionSetContext<TSolutionSetContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TProjectElementContext ProjectElementContext { get; set; }
        TProjectElementContext IHasProjectElementContext<TProjectElementContext>.ProjectElementContext => this.ProjectElementContext;

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
    public class ProjectElementContextSet002<TProjectElementContext, TSolutionSetContext> : ProjectElementContextSet001<TProjectElementContext, ProjectContext001, SolutionContext001, TSolutionSetContext, RepositoryContext001, ApplicationContext001>, IContextSetMarker,
        IWithContext<ProjectContext001>,
        IWithContext<SolutionContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ApplicationContext001>
    {
        ProjectContext001 IWithContext<ProjectContext001>.Context { get => this.ProjectContext; set => this.ProjectContext = value; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;
        SolutionContext001 IWithContext<SolutionContext001>.Context { get => this.SolutionContext; set => this.SolutionContext = value; }
        SolutionContext001 IHasContext<SolutionContext001>.Context => (this as IWithContext<SolutionContext001>).Context;
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }

    [ContextSetMarker]
    public class ProjectElementContextSet003<TSolutionSetContext> : ProjectElementContextSet002<ProjectElementContext001, TSolutionSetContext>, IContextSetMarker,
        IWithContext<ProjectElementContext001>
    {
        ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => (this as IWithContext<ProjectElementContext001>).Context;
    }

    /// <summary>
    /// For project elements in single-project (<see cref="SolutionSetContext002"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectElementContextSet004 : ProjectElementContextSet003<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;
    }

    /// <summary>
    /// For project elements in library-and-construction (<see cref="SolutionSetContext003"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ProjectElementContextSet005 : ProjectElementContextSet003<SolutionSetContext003>, IContextSetMarker,
        IWithContext<SolutionSetContext003>
    {
        SolutionSetContext003 IWithContext<SolutionSetContext003>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext003 IHasContext<SolutionSetContext003>.Context => (this as IWithContext<SolutionSetContext003>).Context;
    }

    [ContextSetMarker]
    public class ProjectElementContextSet006 :
        IWithContext<ApplicationContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ProjectContext001>,
        //IWithContext<ProjectElementContext001>
        IWithContext<Context005>
    {
        public ApplicationContext001 ApplicationContext { get; set; }
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get => this.ApplicationContext; set => this.ApplicationContext = value; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => this.ApplicationContext;

        public RepositoryContext001 RepositoryContext001 { get; set; }
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext001; set => this.RepositoryContext001 = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => this.RepositoryContext001;

        public ProjectContext001 ProjectContext001 { get; set; }
        ProjectContext001 IWithContext<ProjectContext001>.Context { get => this.ProjectContext001; set => this.ProjectContext001 = value; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => this.ProjectContext001;

        //public ProjectElementContext001 ProjectElementContext { get; set; }
        //ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        //ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => this.ProjectElementContext;

        public Context005 ProjectElementContext { get; set; }
        Context005 IWithContext<Context005>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        Context005 IHasContext<Context005>.Context => this.ProjectElementContext;
    }

    [ContextSetMarker]
    public class ProjectElementContextSet001<TProjectElementContext, TProjectContext, TRepositoryContext> : IContextSetMarker,
        IWithProjectElementContext<TProjectElementContext>,
        IWithProjectContext<TProjectContext>,
        IWithRepositoryContext<TRepositoryContext>
    {
        public TProjectElementContext ProjectElementContext { get; set; }
        TProjectElementContext IHasProjectElementContext<TProjectElementContext>.ProjectElementContext => this.ProjectElementContext;

        public TProjectContext ProjectContext { get; set; }
        TProjectContext IHasProjectContext<TProjectContext>.ProjectContext => this.ProjectContext;

        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;
    }

    [ContextSetMarker]
    public class ProjectElementContextSet007 : ProjectElementContextSet001<ProjectElementContext001, ProjectContext001, RepositoryContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ProjectContext001>,
        IWithContext<ProjectElementContext001>
    {
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;

        ProjectContext001 IWithContext<ProjectContext001>.Context { get => this.ProjectContext; set => this.ProjectContext = value; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;

        ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => (this as IWithContext<ProjectElementContext001>).Context;
    }
}
