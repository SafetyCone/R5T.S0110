using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.L0079;
using R5T.T0131;
using R5T.T0235.T000;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IGitHubClientContextOperations : IValuesMarker,
        L0078.O001.IGitHubClientContextOperations,
        L0081.O002.IGitHubClientContextOperations
    {
        public Func<TContext, Task> In_NewRepositoryContext<TContext>(
            RepositorySpecification repositorySpecification,
            IEnumerable<Func<RepositoryContext, Task>> operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            var modifiedOperations = operations.Prepend(
                Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent_I02<RepositoryContext>(
                    repositorySpecification
                )
            );

            return context =>
            {
                return Instances.ContextOperator.In_Context(
                    context,
                    this.Verify_Repository_DoesNotExist,
                    this.In_RepositoryContext<TContext>(
                        modifiedOperations
                    )
                );
            };
        }

        public Func<TContext, Task> In_NewRepositoryContext<TContext>(
            RepositorySpecification repositorySpecification,
            params Func<RepositoryContext, Task>[] operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            return this.In_NewRepositoryContext<TContext>(
                repositorySpecification,
                operations.AsEnumerable());
        }


        public Func<TContext, Task> In_ExistingRepositoryContext<TContext>(
            IEnumerable<Func<RepositoryContext, Task>> operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            var modifiedOperations = operations.Prepend(
                Instances.RepositoryContextOperations.Get_Repository
            );

            return context =>
            {
                return Instances.ContextOperator.In_Context(
                    context,
                    this.Verify_Repository_Exists,
                    this.In_RepositoryContext<TContext>(
                        modifiedOperations
                    )
                );
            };
        }

        public Func<TContext, Task> In_ExistingRepositoryContext<TContext>(
            params Func<RepositoryContext, Task>[] operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            return this.In_ExistingRepositoryContext<TContext>(
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_RepositoryContext<TContext>(
            IEnumerable<Func<RepositoryContext, Task>> operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            return context =>
            {
                var childContext = new RepositoryContext
                {
                    GitHubClient = context.GitHubClient,
                    RepositoryName = context.RepositoryName,
                    RepositoryOwnerName = context.RepositoryOwnerName
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_RepositoryContext<TContext>(
            params Func<RepositoryContext, Task>[] operations)
            where TContext : IHasGitHubClient, IHasRepositoryOwnerName, IHasRepositoryName
        {
            return this.In_RepositoryContext<TContext>(
                operations.AsEnumerable());
        }

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
