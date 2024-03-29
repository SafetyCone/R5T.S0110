﻿using System;
using System.Dynamic;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class PropertyGroupElementContextSet001<
        TPropertyGroupElementContext, TProjectElementContext, TProjectContext, TSolutionContext, TSolutionSetContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithPropertyGroupElementContext<TPropertyGroupElementContext>,
        IWithProjectElementContext<TProjectElementContext>,
        IWithProjectContext<TProjectContext>,
        IWithSolutionContext<TSolutionContext>,
        IWithSolutionSetContext<TSolutionSetContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public TPropertyGroupElementContext PropertyGroupElementContext { get; set; }
        TPropertyGroupElementContext IHasPropertyGroupElementContext<TPropertyGroupElementContext>.PropertyGroupElementContext => this.PropertyGroupElementContext;

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
    public class PropertyGroupElementContextSet002<TPropertyGroupElementContext, TSolutionSetContext> : PropertyGroupElementContextSet001<TPropertyGroupElementContext, ProjectElementContext001, ProjectContext001, SolutionContext001, TSolutionSetContext, RepositoryContext001, ApplicationContext001>, IContextSetMarker,
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
    public class PropertyGroupElementContextSet003<TSolutionSetContext> : PropertyGroupElementContextSet002<PropertyGroupElementContext001, TSolutionSetContext>, IContextSetMarker,
        IWithContext<PropertyGroupElementContext001>
    {
        PropertyGroupElementContext001 IWithContext<PropertyGroupElementContext001>.Context { get => this.PropertyGroupElementContext; set => this.PropertyGroupElementContext = value; }
        PropertyGroupElementContext001 IHasContext<PropertyGroupElementContext001>.Context => (this as IWithContext<PropertyGroupElementContext001>).Context;
    }

    /// <summary>
    /// For property group elements in single-project (<see cref="SolutionSetContext002"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class PropertyGroupElementContextSet004 : PropertyGroupElementContextSet003<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;
    }

    /// <summary>
    /// For property group elements in library-and-construction (<see cref="SolutionSetContext003"/>) solution sets.
    /// </summary>
    [ContextSetMarker]
    public class PropertyGroupElementContextSet005 : PropertyGroupElementContextSet003<SolutionSetContext003>, IContextSetMarker,
        IWithContext<SolutionSetContext003>
    {
        SolutionSetContext003 IWithContext<SolutionSetContext003>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext003 IHasContext<SolutionSetContext003>.Context => (this as IWithContext<SolutionSetContext003>).Context;
    }

    [ContextSetMarker]
    public class PropertyGroupElementContextSet006 :
        IWithContext<Context005>,
        IWithContext<Context006>,
        IWithContext<ProjectOptionsContext>
    {
        public Context005 ProjectElementContext { get; set; }
        Context005 IWithContext<Context005>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        Context005 IHasContext<Context005>.Context => this.ProjectElementContext;

        public Context006 PropertyGroupElementContext { get; set; }
        Context006 IWithContext<Context006>.Context { get => this.PropertyGroupElementContext; set => this.PropertyGroupElementContext = value; }
        Context006 IHasContext<Context006>.Context => this.PropertyGroupElementContext;

        public ProjectOptionsContext ProjectOptionsContext { get; set; }
        ProjectOptionsContext IWithContext<ProjectOptionsContext>.Context { get => this.ProjectOptionsContext; set => this.ProjectOptionsContext = value; }
        ProjectOptionsContext IHasContext<ProjectOptionsContext>.Context => this.ProjectOptionsContext;
    }

    [ContextSetMarker]
    public class PropertyGroupElementContextSet007 :
        IWithContext<Context005>,
        IWithContext<Context006>,
        IWithContext<ProjectOptionsContext>,
        IWithContext<RepositoryContext001>
    {
        public Context005 ProjectElementContext { get; set; }
        Context005 IWithContext<Context005>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        Context005 IHasContext<Context005>.Context => this.ProjectElementContext;

        public Context006 PropertyGroupElementContext { get; set; }
        Context006 IWithContext<Context006>.Context { get => this.PropertyGroupElementContext; set => this.PropertyGroupElementContext = value; }
        Context006 IHasContext<Context006>.Context => this.PropertyGroupElementContext;

        public ProjectOptionsContext ProjectOptionsContext { get; set; }
        ProjectOptionsContext IWithContext<ProjectOptionsContext>.Context { get => this.ProjectOptionsContext; set => this.ProjectOptionsContext = value; }
        ProjectOptionsContext IHasContext<ProjectOptionsContext>.Context => this.ProjectOptionsContext;

        public RepositoryContext001 RepositoryContext { get; set; }
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => this.RepositoryContext;
    }

    /// <summary>
    /// For property group elements in single-project (<see cref="SolutionSetContext002"/>) solution sets, with a <see cref="ProjectOptionsContext"/>.
    /// </summary>
    [ContextSetMarker]
    public class PropertyGroupElementContextSet008 : PropertyGroupElementContextSet003<SolutionSetContext002>, IContextSetMarker,
        IWithContext<SolutionSetContext002>,
        IWithContext<ProjectOptionsContext>
    {
        SolutionSetContext002 IWithContext<SolutionSetContext002>.Context { get => this.SolutionSetContext; set => this.SolutionSetContext = value; }
        SolutionSetContext002 IHasContext<SolutionSetContext002>.Context => (this as IWithContext<SolutionSetContext002>).Context;

        public ProjectOptionsContext ProjectOptionsContext { get; set; }
        ProjectOptionsContext IWithContext<ProjectOptionsContext>.Context { get => this.ProjectOptionsContext; set => this.ProjectOptionsContext = value; }
        ProjectOptionsContext IHasContext<ProjectOptionsContext>.Context => this.ProjectOptionsContext;
    }

    [ContextSetMarker]
    public class PropertyGroupElementContextSet001<
        TPropertyGroupElementContext, TProjectElementContext, TProjectContext, TRepositoryContext> : IContextSetMarker,
        IWithPropertyGroupElementContext<TPropertyGroupElementContext>,
        IWithProjectElementContext<TProjectElementContext>,
        IWithProjectContext<TProjectContext>,
        IWithRepositoryContext<TRepositoryContext>
    {
        public TPropertyGroupElementContext PropertyGroupElementContext { get; set; }
        TPropertyGroupElementContext IHasPropertyGroupElementContext<TPropertyGroupElementContext>.PropertyGroupElementContext => this.PropertyGroupElementContext;

        public TProjectElementContext ProjectElementContext { get; set; }
        TProjectElementContext IHasProjectElementContext<TProjectElementContext>.ProjectElementContext => this.ProjectElementContext;

        public TProjectContext ProjectContext { get; set; }
        TProjectContext IHasProjectContext<TProjectContext>.ProjectContext => this.ProjectContext;

        public TRepositoryContext RepositoryContext { get; set; }
        TRepositoryContext IHasRepositoryContext<TRepositoryContext>.RepositoryContext => this.RepositoryContext;
    }

    [ContextSetMarker]
    public class PropertyGroupElementContextSet009 : PropertyGroupElementContextSet001<PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001, RepositoryContext001>, IContextSetMarker,
        IWithContext<PropertyGroupElementContext001>,
        IWithContext<ProjectElementContext001>,
        IWithContext<ProjectContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ProjectOptionsContext>
    {
        PropertyGroupElementContext001 IWithContext<PropertyGroupElementContext001>.Context { get => this.PropertyGroupElementContext; set => this.PropertyGroupElementContext = value; }
        PropertyGroupElementContext001 IHasContext<PropertyGroupElementContext001>.Context => (this as IWithContext<PropertyGroupElementContext001>).Context;

        ProjectElementContext001 IWithContext<ProjectElementContext001>.Context { get => this.ProjectElementContext; set => this.ProjectElementContext = value; }
        ProjectElementContext001 IHasContext<ProjectElementContext001>.Context => (this as IWithContext<ProjectElementContext001>).Context;

        ProjectContext001 IWithContext<ProjectContext001>.Context { get => this.ProjectContext; set => this.ProjectContext = value; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;

        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get => this.RepositoryContext; set => this.RepositoryContext = value; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;

        public ProjectOptionsContext ProjectOptionsContext { get; set; }
        ProjectOptionsContext IWithContext<ProjectOptionsContext>.Context { get => this.ProjectOptionsContext; set => this.ProjectOptionsContext = value; }
        ProjectOptionsContext IHasContext<ProjectOptionsContext>.Context => this.ProjectOptionsContext;
    }
}
