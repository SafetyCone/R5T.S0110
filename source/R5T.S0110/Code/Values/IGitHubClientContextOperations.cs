using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IGitHubClientContextOperations : IValuesMarker,
        L0078.O001.IGitHubClientContextOperations
    {
        public Func<TContext, Task> In_SetGitHubClientContext<TContext>(
            IEnumerable<Func<SetGitHubClientContext, Task>> operations)
            where TContext : IWithGitHubClient
        {
            return async context =>
            {
                var childContext = new SetGitHubClientContext();

                await Instances.ContextOperator.In_Context(
                    childContext,
                    operations);

                context.GitHubClient = childContext.GitHubClient;
            };
        }

        public Func<TContext, Task> In_SetGitHubClientContext<TContext>(
            params Func<SetGitHubClientContext, Task>[] operations)
            where TContext : IWithGitHubClient
        {
            return this.In_SetGitHubClientContext<TContext>(
                operations.AsEnumerable());
        }
    }
}
