using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.L0091.T000;
using R5T.T0046;
using R5T.T0131;
using R5T.T0144;
using R5T.T0221;
using R5T.T0239;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IGitContextOperations : IValuesMarker,
        L0084.O001.IGitContextOperations
    {
        public Func<TContext, Task> Clone_ToLocalRepository<TContext, TApplicationContext>(
            TApplicationContext applicationContext,
            (IsSet<IHasRepository> RepositorySet, IsSet<N001.IHasAuthentication> GitHubAuthenticationSet, IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet) propertiesRequired,
            out IChecked<ILocalRepositoryExists> @checked)
            where TApplicationContext :
            N001.IHasAuthentication
            where TContext :
            IHasRepository,
            IHasRepositoryDirectoryPath
        {
            @checked = Checked.Check<ILocalRepositoryExists>();

            return context =>
            {
                var cloneUrl = context.Repository.CloneUrl;

                Instances.GitOperator.Clone_NonIdempotent(
                    cloneUrl,
                    context.RepositoryDirectoryPath,
                    applicationContext.Authentication.Username,
                    applicationContext.Authentication.Password);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, TApplicationContext, Task> Clone_ToLocalRepository<TContext, TApplicationContext>(
            (IsSet<IHasRepository> RepositorySet, IsSet<N001.IHasAuthentication> GitHubAuthenticationSet, IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet) propertiesRequired,
            out IChecked<ILocalRepositoryExists> @checked)
            where TApplicationContext :
            N001.IHasAuthentication
            where TContext :
            IHasRepository,
            IHasRepositoryDirectoryPath
        {
            @checked = Checked.Check<ILocalRepositoryExists>();

            return (context, applicationContext) =>
            {
                var cloneUrl = context.Repository.CloneUrl;

                Instances.GitOperator.Clone_NonIdempotent(
                    cloneUrl,
                    context.RepositoryDirectoryPath,
                    applicationContext.Authentication.Username,
                    applicationContext.Authentication.Password);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Clone_ToLocalRepository<TContext>(
            (IsSet<IHasRepository> RepositorySet, IsSet<N001.IHasAuthentication> GitHubAuthenticationSet, IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet) propertiesRequired,
            out IChecked<ILocalRepositoryExists> @checked)
            where TContext : IHasRepository, IHasRepositoryDirectoryPath, N001.IHasAuthentication
        {
            @checked = Checked.Check<ILocalRepositoryExists>();

            return context =>
            {
                var cloneUrl = context.Repository.CloneUrl;

                Instances.GitOperator.Clone_NonIdempotent(
                    cloneUrl,
                    context.RepositoryDirectoryPath,
                    context.Authentication.Username,
                    context.Authentication.Password);

                return Task.CompletedTask;
            };
        }

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

                Instances.GitOperator.Push_WithStageAndCommit(
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

                Instances.GitOperator.Push_WithStageAndCommit(
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


        public Func<TContext, Task> In_GitPushContext<TContext>(
            string commitMessage,
            (IsSet<IHasRepositoryDirectoryPath>, IsSet<N001.IHasAuthentication>, IsSet<IHasGitHubAuthor>) propertiesRequired,
            IEnumerable<Func<TContext, Task>> operations)
            where TContext : IHasRepositoryDirectoryPath, N001.IHasAuthentication, IHasGitHubAuthor
        {
            return async context =>
            {
                await Instances.ContextOperator.In_Context(
                    context,
                    operations);

                Instances.GitOperator.Push_WithStageAndCommit(
                    context.RepositoryDirectoryPath,
                    commitMessage,
                    context.GitHubAuthor.Name,
                    context.GitHubAuthor.EmailAddress,
                    context.Authentication.Username,
                    context.Authentication.Password);
            };
        }

        public Func<TContext, Task> In_GitPushContext<TContext>(
            string commitMessage,
            (IsSet<IHasRepositoryDirectoryPath>, IsSet<N001.IHasAuthentication>, IsSet<IHasGitHubAuthor>) propertiesRequired,
            params Func<TContext, Task>[] operations)
            where TContext : IHasRepositoryDirectoryPath, N001.IHasAuthentication, IHasGitHubAuthor
        {
            return this.In_GitPushContext<TContext>(
                commitMessage,
                propertiesRequired,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_GitPushContext_Start<TContext>(
            string commitMessage,
            out GitPushContextToken token)
        {
            token = new GitPushContextToken
            {
                CommitMessage = commitMessage
            };

            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> In_GitPushContext_End<TContext>(
            GitPushContextToken token,
            (
            IsSet<IHasRepositoryDirectoryPath>,
            IsSet<N001.IHasAuthentication>,
            IsSet<IHasGitHubAuthor>
            ) propertiesRequired,
            out IChecked<ILocalChangesPushedToRemote> checkedLocalChangesPushedToRemote)
            where TContext :
            IHasRepositoryDirectoryPath,
            N001.IHasAuthentication,
            IHasGitHubAuthor
        {
            checkedLocalChangesPushedToRemote = Checked.Check<ILocalChangesPushedToRemote>();

            return context =>
            {
                Instances.GitOperator.Push_WithStageAndCommit(
                    context.RepositoryDirectoryPath,
                    token.CommitMessage,
                    context.GitHubAuthor.Name,
                    context.GitHubAuthor.EmailAddress,
                    context.Authentication.Username,
                    context.Authentication.Password);

                return Task.CompletedTask;
            };
        }
    }
}
