﻿using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class ItemGroupElementContextSet001<
        TItemGroupElementContext, TProjectElementContext, TProjectContext, TSolutionContext, TSolutionSetContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithItemGroupElementContext<TItemGroupElementContext>,
        IWithProjectElementContext<TProjectElementContext>,
        IWithProjectContext<TProjectContext>,
        IWithSolutionContext<TSolutionContext>,
        IWithSolutionSetContext<TSolutionSetContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TItemGroupElementContext ItemGroupElementContext { get; set; }
        TItemGroupElementContext IHasItemGroupElementContext<TItemGroupElementContext>.ItemGroupElementContext => this.ItemGroupElementContext;

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
    public class ItemGroupElementContextSet002<TItemGroupElementContext, TSolutionSetContext> : ItemGroupElementContextSet001<TItemGroupElementContext, ProjectElementContext001, ProjectContext001, SolutionContext001, TSolutionSetContext, RepositoryContext001, ApplicationContext001>, IContextSetMarker,
        IWithContext<ProjectElementContext001>,
        IWithContext<ProjectContext001>,
        IWithContext<SolutionContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ApplicationContext001>
    {
        ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => (this as IWithContext<ProjectElementContext001>).Context;
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
    public class ItemGroupElementContextSet003<TSolutionSetContext> : ItemGroupElementContextSet002<ItemGroupElementContext001, TSolutionSetContext>, IContextSetMarker,
        IWithContext<ItemGroupElementContext001>
    {
        ItemGroupElementContext001 IWithContext<ItemGroupElementContext001>.Context { get => this.ItemGroupElementContext; set => this.ItemGroupElementContext = value; }
        ItemGroupElementContext001 IHasContext<ItemGroupElementContext001>.Context => (this as IWithContext<ItemGroupElementContext001>).Context;
    }

    /// <summary>
    /// For item group elements in single-project (<see cref="SolutionSetContext002"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ItemGroupElementContextSet004 : ItemGroupElementContextSet003<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;
    }

    /// <summary>
    /// For item group elements in library-and-construction (<see cref="SolutionSetContext003"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class ItemGroupElementContextSet005 : ItemGroupElementContextSet003<SolutionSetContext003>, IContextSetMarker,
        IWithContext<SolutionSetContext003>
    {
        SolutionSetContext003 IWithContext<SolutionSetContext003>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext003 IHasContext<SolutionSetContext003>.Context => (this as IWithContext<SolutionSetContext003>).Context;
    }

    [ContextSetMarker]
    public class ItemGroupElementContextSet006 :
        IWithContext<Context005>,
        IWithContext<Context007>
    {
        public Context005 ProjectElementContext { get; set; }
        Context005 IWithContext<Context005>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        Context005 IHasContext<Context005>.Context => this.ProjectElementContext;

        public Context007 ItemGroupElementContext { get; set; }
        Context007 IWithContext<Context007>.Context { get => this.ItemGroupElementContext; set => this.ItemGroupElementContext = value; }
        Context007 IHasContext<Context007>.Context => this.ItemGroupElementContext;
    }

    [ContextSetMarker]
    public class ItemGroupElementContextSet007 :
        IWithContext<ProjectElementContext001>,
        IWithContext<Context007>
    {
        public ProjectElementContext001 ProjectElementContext { get; set; }
        ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => this.ProjectElementContext;

        public Context007 ItemGroupElementContext { get; set; }
        Context007 IWithContext<Context007>.Context { get => this.ItemGroupElementContext; set => this.ItemGroupElementContext = value; }
        Context007 IHasContext<Context007>.Context => this.ItemGroupElementContext;
    }
}
