using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0095.T000;
using R5T.T0131;
using R5T.T0221;
/// <see cref="R5T.T0241.Documentation"/>
using R5T.T0241; 


namespace R5T.S0110
{
    [ContextOperationsMarker, ValuesMarker]
    public partial interface ILocalRepositoryContextOperations : IValuesMarker
    {
        public Func<TContext, Task> Delete_LocalRepositoryDirectory_Idempotent<TContext>(
            Func<TContext, bool, Task> directoryExistedOutputHandler = default)
            where TContext : IHasRepositoryDirectoryPath
        {
            return async context =>
            {
                var directoryExisted = Instances.FileSystemOperator._Platform.Delete_Directory_Idempotent(
                    context.RepositoryDirectoryPath);

                await Instances.FunctionOperator.Run(
                    context,
                    directoryExisted,
                    directoryExistedOutputHandler);
            };
        }

        public Task Delete_LocalRepositoryDirectory_Idempotent<TContext>(TContext context)
            where TContext : IHasRepositoryDirectoryPath
        {
            return Instances.ContextOperator.In_Context(
                context,
                this.Delete_LocalRepositoryDirectory_Idempotent<TContext>());
        }

        public Func<TContext, Task> In_SolutionDirectoryContext_Source<TContext>(
            out (IsSet<IHasRepositoryDirectoryPath>, IsSet<IHasSolutionDirectoryPath>) propertiesSet,
            IEnumerable<Func<SolutionDirectoryContext, Task>> operations)
            where TContext : IHasRepositoryDirectoryPath
        {
            return context =>
            {
                var sourceDirectoryPath = Instances.RepositoryPathsOperator.Get_SourceDirectoryPath(
                    context.RepositoryDirectoryPath);

                var childContext = new SolutionDirectoryContext
                {
                    RepositoryDirectoryPath = context.RepositoryDirectoryPath,
                    SolutionDirectoryPath = sourceDirectoryPath,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_SolutionDirectoryContext_Source<TContext>(
            out (IsSet<IHasRepositoryDirectoryPath>, IsSet<IHasSolutionDirectoryPath>) propertiesSet,
            params Func<SolutionDirectoryContext, Task>[] operations)
            where TContext : IHasRepositoryDirectoryPath
        {
            return this.In_SolutionDirectoryContext_Source<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_SolutionDirectoryContext<TContext>(
            out IsSet<IHasRepositoryDirectoryPath> propertiesSet,
            IEnumerable<Func<SolutionDirectoryContext, Task>> operations)
            where TContext : IHasRepositoryDirectoryPath
        {
            return context =>
            {
                var childContext = new SolutionDirectoryContext
                {
                    RepositoryDirectoryPath = context.RepositoryDirectoryPath,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_SolutionDirectoryContext<TContext>(
            out IsSet<IHasRepositoryDirectoryPath> propertiesSet,
            params Func<SolutionDirectoryContext, Task>[] operations)
            where TContext : IHasRepositoryDirectoryPath
        {
            return this.In_SolutionDirectoryContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
