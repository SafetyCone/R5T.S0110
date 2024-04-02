using System;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IContextSetTypeAdapters : IValuesMarker
    {
        public AccessorTypeAdapter<TContextSet, TContextA, TContextB, TContextC>
            For_ContextSet_AccessorOnly<TContextSet, TContextA, TContextB, TContextC>()
            where TContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
            => new(
                x => (x as IHasContext<TContextA>).Context,
                x => (x as IHasContext<TContextB>).Context,
                x => (x as IHasContext<TContextC>).Context);

        public AccessorTypeAdapter<TContextSet, TContextA, TContextB, TContextC>
            For_ContextSet_AccessorOnly<TContextSet, TContextA, TContextB, TContextC>(
            TypeSpecifier<TContextSet> contextSetSpecifier,
            TypeSpecifier<TContextA> contextASpecifier,
            TypeSpecifier<TContextB> contextBSpecifier,
            TypeSpecifier<TContextC> contextCSpecifier)
            where TContextSet :
            IHasContext<TContextA>,
            IHasContext<TContextB>,
            IHasContext<TContextC>
            => new(
                x => (x as IHasContext<TContextA>).Context,
                x => (x as IHasContext<TContextB>).Context,
                x => (x as IHasContext<TContextC>).Context);

        public TypeAdapter<CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>, CodeFileContext001, TProjectContext, TRepositoryContext, TApplicationContext>
            For_CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>(
            TypeSpecifier<TProjectContext> projectContextSpecifier,
            TypeSpecifier<TRepositoryContext> repositoryContextSpecifier,
            TypeSpecifier<TApplicationContext> applicationContextSpecifier)
            => new(
                x => x.CodeFileContext,
                (x, y) => x.CodeFileContext = y,
                x => x.ProjectContext,
                (x, y) => x.ProjectContext = y,
                x => x.RepositoryContext,
                (x, y) => x.RepositoryContext = y,
                x => x.ApplicationContext,
                (x, y) => x.ApplicationContext = y);
    }
}
