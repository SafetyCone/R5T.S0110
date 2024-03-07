using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;

using R5T.S0110.Contexts;
using System.Linq;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ISolutionSetContextOperations : IContextOperationsMarker
    {
        public Func<TParentContextSet, Task> In_SolutionSetContext<TContextSet, TParentContextSet, TSolutionSetContext, TRepositoryContext>(
            IDirectionalIsomorphism<TParentContextSet, TContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TContextSet> solutionSetContextSetSpecifier,
            out TypeSpecifier<TSolutionSetContext> solutionContextSpecifier,
            ContextPropertiesSet<TRepositoryContext, 
                IsSet<IHasRepositoryDirectoryPath>> repositoryContextPropertiesSet,
            out ContextPropertiesSet<TSolutionSetContext,
                IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            IEnumerable<Func<TContextSet, TSolutionSetContext, Task>> operations)
            where TContextSet : IWithContext<TSolutionSetContext>, IHasContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TRepositoryContext>
            where TSolutionSetContext : IWithSolutionDirectoryPath, new()
            where TRepositoryContext : IHasRepositoryDirectoryPath
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out _,
                o.In_Context_OfContextSet<TContextSet, TSolutionSetContext>(
                    out solutionSetContextSetSpecifier,
                    out solutionContextSpecifier,
                    o.Construct_Context_OfContextSet<TContextSet, TSolutionSetContext>(
                        Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<TSolutionSetContext, TRepositoryContext>(repositoryContextPropertiesSet.PropertiesSet,
                            out var solutionDirectoryPathSet).In_ContextSetAndContext(solutionSetContextSetSpecifier)
                    ),
                    operations
                )
            );

            solutionSetContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TSolutionSetContext>().For(
                solutionDirectoryPathSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_SolutionSetContext<TContextSet, TParentContextSet, TSolutionSetContext, TRepositoryContext>(
            IDirectionalIsomorphism<TParentContextSet, TContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TContextSet> solutionSetContextSetSpecifier,
            out TypeSpecifier<TSolutionSetContext> solutionContextSpecifier,
            ContextPropertiesSet<TRepositoryContext,
                IsSet<IHasRepositoryDirectoryPath>> repositoryContextPropertiesSet,
            out ContextPropertiesSet<TSolutionSetContext,
                IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            params Func<TContextSet, TSolutionSetContext, Task>[] operations)
            where TContextSet : IWithContext<TSolutionSetContext>, IHasContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TRepositoryContext>
            where TSolutionSetContext : IWithSolutionDirectoryPath, new()
            where TRepositoryContext : IHasRepositoryDirectoryPath
            => this.In_SolutionSetContext<TContextSet, TParentContextSet, TSolutionSetContext, TRepositoryContext>(
                parentContextSetIsomorphism,
                out solutionSetContextSetSpecifier,
                out solutionContextSpecifier,
                repositoryContextPropertiesSet,
                out solutionSetContextPropertiesSet,
                operations.AsEnumerable());

        public Func<Context001, Context000, Task> In_SolutionSetContext<TSolutionSetContext>(
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            params Func<TSolutionSetContext, Context001, Context000, Task>[] operations)
            where TSolutionSetContext : IWithSolutionDirectoryPath, new()
        {
            var o = Instances.ContextOperations;

            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<TSolutionSetContext, Context001, Context000>();

            return o.In_ContextSet_AB_CAB<TSolutionSetContext, Context001, Context000>(
                o.Construct_Context_C_CAB<TSolutionSetContext, Context001, Context000>(
                    Instances.SolutionContextOperations.Set_SolutionDirectoryPath_Source<TSolutionSetContext, Context001>(RepositoryDirectoryPathSet,
                        out solutionDirectoryPathSet).In(contextSet)
                ),
                operations
            );
        }

        public Func<TProjectContext, TSolutionSetContext, Task> Set_ProjectFilePath<TProjectContext, TSolutionSetContext>(
            out ContextPropertiesSet<TSolutionSetContext, IsSet<IHasProjectFilePath>> projectFilePathSet)
            where TProjectContext : IHasProjectFilePath
            where TSolutionSetContext : IWithProjectFilePath
        {
            return (projectContext, solutionSetContext) =>
            {
                solutionSetContext.ProjectFilePath = projectContext.ProjectFilePath;

                return Task.CompletedTask;
            };
        }
    }
}
