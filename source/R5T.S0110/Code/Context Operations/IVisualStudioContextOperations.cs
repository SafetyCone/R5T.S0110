using System;
using System.Threading.Tasks;

using R5T.L0095.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IVisualStudioContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Open_VisualStudioSolution<TContext>(
            IsSet<IHasSolutionFilePath> solutionFilePathSet)
            where TContext : IHasSolutionFilePath
        {
            return context =>
            {
                Instances.VisualStudioOperator.Open_SolutionFile(
                    context.SolutionFilePath);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Open_VisualStudioSolution<TContext>(
            Func<TContext, Task<string>> solutionFilePathProvider)
        {
            return async context =>
            {
                var solutionFilePath = await solutionFilePathProvider(context);

                Instances.VisualStudioOperator.Open_SolutionFile(
                    solutionFilePath);
            };
        }
    }
}
