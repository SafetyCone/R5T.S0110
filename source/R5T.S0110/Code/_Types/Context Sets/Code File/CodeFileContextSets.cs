using System;


namespace R5T.S0110
{
    [ContextSetMarker]
    public class CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext> : IContextSetMarker,
        IWithCodeFileContext<CodeFileContext001>,
        IWithContext<CodeFileContext001>,
        IWithProjectContext<TProjectContext>,
        IWithRepositoryContext<TRepositoryContext>,
        IWithApplicationContext<TApplicationContext>
    {
        public CodeFileContext001 CodeFileContext { get; set; }
        CodeFileContext001 IWithContext<CodeFileContext001>.Context { get => this.CodeFileContext; set => this.CodeFileContext = value; }
        CodeFileContext001 IHasContext<CodeFileContext001>.Context => this.CodeFileContext;

        public TProjectContext ProjectContext { get; set; }
        public TRepositoryContext RepositoryContext { get; set; }
        public TApplicationContext ApplicationContext { get; set; }

    }

    [ContextSetMarker]
    public class CodeFileContextSet002 : IContextSetMarker,
        IWithContext<CodeFileContext001>,
        IWithContext<ProjectContext001>,
        IWithContext<RepositoryContext001>,
        IWithContext<ApplicationContext001>
    {
        CodeFileContext001 IWithContext<CodeFileContext001>.Context { get; set; }
        CodeFileContext001 IHasContext<CodeFileContext001>.Context => (this as IWithContext<CodeFileContext001>).Context;
        ProjectContext001 IWithContext<ProjectContext001>.Context { get; set; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;
        RepositoryContext001 IWithContext<RepositoryContext001>.Context { get; set; }
        RepositoryContext001 IHasContext<RepositoryContext001>.Context => (this as IWithContext<RepositoryContext001>).Context;
        ApplicationContext001 IWithContext<ApplicationContext001>.Context { get; set; }
        ApplicationContext001 IHasContext<ApplicationContext001>.Context => (this as IWithContext<ApplicationContext001>).Context;
    }
}
