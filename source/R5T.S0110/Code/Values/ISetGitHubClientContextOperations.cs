using System;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.T0131;
using R5T.T0144;
using R5T.T0221;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface ISetGitHubClientContextOperations : IValuesMarker
    {
        public Func<TContext, Task> Set_GitHubAuthenticationJsonFilePath<TContext>(
            string gitHubAuthenticationJsonFilePath)
            where TContext : IWithGitHubAuthenticationJsonFilePath
        {
            return context =>
            {
                context.GitHubAuthenticationJsonFilePath = gitHubAuthenticationJsonFilePath;

                return Task.CompletedTask;
            };
        }

        public Task Set_GitHubAuthenticationJsonFilePath<TContext>(TContext context)
            where TContext : IWithGitHubAuthenticationJsonFilePath
        {
            return Instances.ContextOperator.In_Context(
                context,
                this.Set_GitHubAuthenticationJsonFilePath<TContext>(
                    Instances.Values.GitHubAuthenticationJsonFilePath));
        }

        public Func<TContext, Task> Set_GitHubAuthenticationJsonFilePath<TContext>(
            out IsSet<IHasGitHubAuthenticationJsonFilePath> gitHubAuthenticationJsonFilePathSet)
            where TContext : IWithGitHubAuthenticationJsonFilePath
        {
            return this.Set_GitHubAuthenticationJsonFilePath;
        }

        public async Task Load_Authentication<TContext>(TContext context)
            where TContext : IHasGitHubAuthenticationJsonFilePath, IWithAuthentication
        {
            context.Authentication = await Instances.JsonOperator.Load_FromFile<Authentication>(
                context.GitHubAuthenticationJsonFilePath);
        }

        public Func<TContext, Task> Load_GitHubAuthentication_N001<TContext>(
            IsSet<IHasGitHubAuthenticationJsonFilePath> gitHubAuthenticationRequired,
            out IsSet<N001.IHasAuthentication> gitHubAuthenticationSet)
            where TContext : IHasGitHubAuthenticationJsonFilePath, N001.IWithAuthentication
        {
            return async context =>
            {
                context.Authentication = await Instances.JsonOperator.Load_FromFile<Authentication>(
                    context.GitHubAuthenticationJsonFilePath);
            };
        }

        public Task Set_GitHubClient<TContext>(TContext context)
            where TContext : IHasAuthentication, IWithGitHubClient
        {
            context.GitHubClient = Instances.GitHubClientOperator.Get_GitHubClient(
                context.Authentication.Username,
                context.Authentication.Password,
                Instances.Values.GitHubProductHeaderValue);

            return Task.CompletedTask;
        }

        public Task Set_GitHubClient_N001<TContext>(TContext context)
            where TContext : N001.IHasAuthentication, IWithGitHubClient
        {
            context.GitHubClient = Instances.GitHubClientOperator.Get_GitHubClient(
                context.Authentication.Username,
                context.Authentication.Password,
                Instances.Values.GitHubProductHeaderValue);

            return Task.CompletedTask;
        }

        public Func<TContext, Task> Set_GitHubClient<TContext>(
            IsSet<N001.IHasAuthentication> gitHubAuthenticationRequired,
            out IsSet<IHasGitHubClient> gitHubClientSet)
            where TContext : N001.IHasAuthentication, IWithGitHubClient
        {
            return this.Set_GitHubClient_N001;
        }
    }
}
