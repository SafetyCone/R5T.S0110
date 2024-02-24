using System;
using System.Threading.Tasks;

using R5T.L0095.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ISolutionContextOperations : IContextOperationsMarker
    {
        public Func<TSolutionContext, TRepositoryContext, Task> Set_SolutionDirectoryPath_Source<TSolutionContext, TRepositoryContext>(
            IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet_RepositoryContextPropertiesRequired,
            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet_SolutionContextPropertiesSet)
            where TSolutionContext : IWithSolutionDirectoryPath
            where TRepositoryContext : IHasRepositoryDirectoryPath
        {
            return (solutionContext, repositoryContext) =>
            {
                solutionContext.SolutionDirectoryPath = Instances.RepositoryPathsOperator.Get_SourceDirectoryPath(
                    repositoryContext.RepositoryDirectoryPath);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_SolutionDirectoryPath_Source<TContext>(
            IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet,
            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet)
            where TContext : IWithSolutionDirectoryPath, IHasRepositoryDirectoryPath
        {
            return Instances.SolutionDirectoryContextOperations.Set_SolutionDirectory_Source;
        }

        public Func<TContext, Task> Set_SolutionFilePath<TContext>(
            (IsSet<IHasSolutionDirectoryPath>, IsSet<IHasSolutionName>) propertiesRequired,
            out IsSet<IHasSolutionFilePath> solutionFilePathSet)
            where TContext : IWithSolutionFilePath, IHasSolutionName, IHasSolutionDirectoryPath
        {
            return context =>
            {
                context.SolutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                    context.SolutionDirectoryPath,
                    context.SolutionName);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_SolutionProperties<TContext, TParentContext>(
            TParentContext parentContext,
            (IsSet<IHasRepositoryDirectoryPath>, IsSet<IHasSolutionFilePath>) propertiesRequired,
            out (
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
            IsSet<IHasSolutionFilePath> SolutionFilePathSet
            ) propertiesSet
            )
            where TParentContext : IHasRepositoryDirectoryPath, IHasSolutionFilePath
            where TContext : IWithRepositoryDirectoryPath, IWithSolutionFilePath
        {
            return context =>
            {
                context.RepositoryDirectoryPath = parentContext.RepositoryDirectoryPath;
                context.SolutionFilePath = parentContext.SolutionFilePath;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, TSolutionContext, Task> Set_SolutionProperties<TContext, TSolutionContext>(
            (IsSet<IHasRepositoryDirectoryPath>, IsSet<IHasSolutionFilePath>) propertiesRequired,
            out (
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
            IsSet<IHasSolutionFilePath> SolutionFilePathSet
            ) propertiesSet
            )
            where TSolutionContext : IHasRepositoryDirectoryPath, IHasSolutionFilePath
            where TContext : IWithRepositoryDirectoryPath, IWithSolutionFilePath
        {
            return (context, solutionContext) =>
            {
                context.RepositoryDirectoryPath = solutionContext.RepositoryDirectoryPath;
                context.SolutionFilePath = solutionContext.SolutionFilePath;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_SolutionSpecification<TContext>(
            SolutionSpecification solutionSpecification,
            out IsSet<IHasSolutionSpecification> SolutionSpecificationSet
            )
            where TContext : IWithSolutionSpecification
        {
            return context =>
            {
                context.SolutionSpecification = solutionSpecification;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_SolutionSpecification<TContext>(
            SolutionSpecification solutionSpecification,
            out (
            IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
            IsSet<IHasSolutionName> SolutionNameSet
            ) propertiesSet
            )
            where TContext : IWithSolutionSpecification
        {
            return context =>
            {
                context.SolutionSpecification = solutionSpecification;

                return Task.CompletedTask;
            };
        }
    }
}
