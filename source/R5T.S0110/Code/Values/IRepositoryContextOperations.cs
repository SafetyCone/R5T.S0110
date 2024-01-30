using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.T0131;
using R5T.T0235.T000;

using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IRepositoryContextOperations : IValuesMarker,
        L0078.O001.IRepositoryContextOperations,
        L0080.O001.IRepositoryContextOperations,
        L0081.O001.IRepositoryContextOperations,
        L0081.O002.IRepositoryContextOperations
    {
        public Func<TContext, Task> In_CloneRepositoryLocallyContext<TContext>(
            // Communicates what properties need to be set.
            out (
                IsSet<IHasRepositoryOwnerName>,
                IsSet<IHasRepositoryName>,
                IsSet<IHasRepositoryUrl>) propertiesSet,
            IEnumerable<Func<CloneRepositoryLocallyContext, Task>> operations)
            where TContext : IHasRepository, IHasRepositoryName, IHasRepositoryOwnerName
        {
            // Strangely, the set-properties tuple does not need to be set?
            // Probably because the tuple is a value-type, and thus has a default value,
            // and the IsSet<T> type is a value type (with no properties to boot!), and thus has a default value.

            return context =>
            {
                var cloneUrl = context.Repository.CloneUrl;

                var childContext = new CloneRepositoryLocallyContext
                {
                    RepositoryName = context.RepositoryName,
                    RepositoryOwnerName = context.RepositoryOwnerName,
                    RepositoryUrl = cloneUrl,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_CloneRepositoryLocallyContext<TContext>(
            out (
                IsSet<IHasRepositoryOwnerName>,
                IsSet<IHasRepositoryName>,
                // Communicates that the repository URL is set.
                IsSet<IHasRepositoryUrl>) propertiesSet,
            params Func<CloneRepositoryLocallyContext, Task>[] operations)
            where TContext : IHasRepository, IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_CloneRepositoryLocallyContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            Func<IHasAuthentication, Task> authenticationOutputHandler,
            IEnumerable<Func<GitHubClientedRepositoryContext, Task>> operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            var modifiedOperations = operations.Prepend(
                Instances.GitHubClientContextOperations.In_SetGitHubClientContext<GitHubClientedRepositoryContext>(
                    setGitHubAuthenticationJsonFilePath,
                    Instances.SetGitHubClientContextOperations.Load_Authentication,
                    //async context =>
                    //{
                    //    await authenticationOutputHandler(context);
                    //},
                    authenticationOutputHandler,
                    Instances.SetGitHubClientContextOperations.Set_GitHubClient
                )
            );

            return this.In_GitHubClientContext<TContext>(
                modifiedOperations
            );
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            Func<IHasAuthentication, Task> authenticationOutputHandler,
            params Func<GitHubClientedRepositoryContext, Task>[] operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                authenticationOutputHandler,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            IEnumerable<Func<GitHubClientedRepositoryContext, Task>> operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                Instances.Functions.Do_Nothing,
                operations);
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            params Func<GitHubClientedRepositoryContext, Task>[] operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                operations.AsEnumerable());
        }

        public Task Verify_IsWorking<TContext>(TContext context)
            where TContext : IHasRepository
        {
            return Task.CompletedTask;
        }
    }
}
