using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using R5T.T0046;
using R5T.T0131;
using R5T.T0144;
using R5T.T0239;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IGitContextOperations : IValuesMarker,
        L0084.O001.IGitContextOperations
    {
        public Task Clone_ToLocalRepositoryDirectory_ByUsernameAndPassword<TContext>(TContext context)
            where TContext : IWithRepositoryGitDirectoryPath, IHasRepositoryUrl, IHasRepositoryDirectoryPath, IHasUsername, IHasPassword
        {
            context.RepositoryGitDirectoryPath = Instances.GitOperator.Clone_NonIdempotent(
                context.RepositoryUrl,
                context.RepositoryDirectoryPath,
                context.Username,
                context.Password);

            return Task.CompletedTask;
        }

        public Task Clone_ToLocalRepositoryDirectory_ByAuthentication<TContext>(TContext context)
            where TContext : IWithRepositoryGitDirectoryPath, IHasRepositoryUrl, IHasRepositoryDirectoryPath, IHasAuthentication
        {
            context.RepositoryGitDirectoryPath = Instances.GitOperator.Clone_NonIdempotent(
                context.RepositoryUrl,
                context.RepositoryDirectoryPath,
                context.Authentication.Username,
                context.Authentication.Password);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> In_GitPushContext<TContext>(
            string commitMessage,
            IEnumerable<Func<TContext, Task>> operations)
            where TContext : IHasRepositoryDirectoryPath, IHasAuthor, IHasAuthentication
        {
            return async context =>
            {
                await Instances.ContextOperator.In_Context(
                    context,
                    operations);

                Instances.GitOperator.Push_Changes(
                    context.RepositoryDirectoryPath,
                    commitMessage,
                    context.Author.Name,
                    context.Author.EmailAddress,
                    context.Authentication.Username,
                    context.Authentication.Password);
            };
        }

        public Func<TContext, Task> In_GitPushContext<TContext>(
            string commitMessage,
            string authorName,
            string authorEmailAddress,
            IEnumerable<Func<TContext, Task>> operations)
            where TContext : IHasRepositoryDirectoryPath, IHasAuthentication
        {
            return async context =>
            {
                await Instances.ContextOperator.In_Context(
                    context,
                    operations);

                Instances.GitOperator.Push_Changes(
                    context.RepositoryDirectoryPath,
                    commitMessage,
                    authorName,
                    authorEmailAddress,
                    context.Authentication.Username,
                    context.Authentication.Password);
            };
        }

        public Func<TContext, Task> In_GitPushContext<TContext>(
            string commitMessage,
            string authorName,
            string authorEmailAddress,
            params Func<TContext, Task>[] operations)
            where TContext : IHasRepositoryDirectoryPath, IHasAuthentication
        {
            return this.In_GitPushContext<TContext>(
                commitMessage,
                authorName,
                authorEmailAddress,
                operations.AsEnumerable());
        }
    }
}
