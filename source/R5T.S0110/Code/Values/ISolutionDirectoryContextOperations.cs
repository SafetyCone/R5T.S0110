using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface ISolutionDirectoryContextOperations : IValuesMarker
    {
        public Task Set_SolutionDirectory_Source<TContext>(TContext context)
            where TContext : IWithSolutionDirectoryPath, IHasRepositoryDirectoryPath
        {
            context.SolutionDirectoryPath = Instances.RepositoryPathsOperator.Get_SourceDirectoryPath(
                context.RepositoryDirectoryPath);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> In_SolutionContext<TContext>(
            SolutionSpecification solutionSpecification,
            out (IsSet<IHasSolutionName>, IsSet<IHasSolutionDirectoryPath>, IsSet<IHasRepositoryDirectoryPath>) propertiesSet,
            IEnumerable<Func<SolutionFileContext, Task>> operations)
            where TContext : IHasSolutionDirectoryPath, IHasRepositoryDirectoryPath
        {
            return context =>
            {
                var childContext = new SolutionFileContext
                {
                    SolutionName = solutionSpecification.Name,
                    SolutionDirectoryPath = context.SolutionDirectoryPath,
                    RepositoryDirectoryPath = context.RepositoryDirectoryPath,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_SolutionContext<TContext>(
            SolutionSpecification solutionSpecification,
            out (IsSet<IHasSolutionName>, IsSet<IHasSolutionDirectoryPath>, IsSet<IHasRepositoryDirectoryPath>) propertiesSet,
            params Func<SolutionFileContext, Task>[] operations)
            where TContext : IHasSolutionDirectoryPath, IHasRepositoryDirectoryPath
        {
            return this.In_SolutionContext<TContext>(
                solutionSpecification,
                out propertiesSet,
                operations.AsEnumerable());
        }
    }
}
