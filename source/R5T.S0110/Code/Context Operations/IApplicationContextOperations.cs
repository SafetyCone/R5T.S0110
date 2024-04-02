using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.S0110.Contexts;
using R5T.T0046;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IApplicationContextOperations : IContextOperationsMarker
    {
        /// <summary>
        /// Sets <see cref="R5T.S0110"/>-specific application properties for the provided application context set and application context types.
        /// </summary>
        public Func<TContextSet, Task> In_ApplicationContext<TContextSet, TApplicationContext>(
            out ContextSetSpecifier<TContextSet> applicationContextSetSpecifier,
            out TypeSpecifier<TApplicationContext> applicationContextSpecifier,
            out ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                )> applicationContextPropertiesSet,
            params Func<TContextSet, TApplicationContext, Task>[] operations)
            where TContextSet : IWithContext<TApplicationContext>, new()
            where TApplicationContext :
            IWithGitHubClient,
            IWithGitHubAuthor,
            IWithNuGetAuthor,
            N001.IWithAuthentication, new()
        {
            var o = Instances.ContextOperations;

            return o.In_ContextSetWithContext<TContextSet, TApplicationContext>(
                out applicationContextSetSpecifier,
                out applicationContextSpecifier,
                o.Construct_Context_OfContextSet<TContextSet, TApplicationContext>(
                    this.Set_ApplicationContextProperties<TApplicationContext>(
                        out applicationContextPropertiesSet).In_ContextSetWithContext(applicationContextSetSpecifier)
                ),
                operations
            );
        }

        public Func<Task> In_ApplicationContext(
            out ContextPropertiesSet<Context000, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                )> applicationContextPropertiesSet,
            params Func<Context000, Task>[] operations)
        {
            var o = Instances.ContextOperations;

            return o.In_ContextSet<Context000>(
                o.Construct_Context<Context000>(
                    this.Set_ApplicationContextProperties<Context000>(
                        out applicationContextPropertiesSet)
                ),
                operations);
        }

        /// <summary>
        /// Sets <see cref="R5T.S0110"/>-specific application properties for the provided application context type.
        /// </summary>
        /// <remarks>
        /// <para>Uses the <see cref="Context002"/> context type internally:</para>
        /// <inheritdoc cref="Context002" path="/summary"/>
        /// </remarks>
        public Func<TApplicationContext, Task> Set_ApplicationContextProperties<TApplicationContext>(
            out ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                )> applicationContextPropertiesSet
            )
            where TApplicationContext :
            IWithGitHubClient,
            IWithGitHubAuthor,
            IWithNuGetAuthor,
            N001.IWithAuthentication
        {
            IsSet<IHasGitHubClient> gitHubClientSet;
            IsSet<IHasGitHubAuthor> gitHubAuthorSet;
            IsSet<IHasNuGetAuthor> nuGetAuthorSet;
            IsSet<N001.IHasAuthentication> gitHubAuthenticationSet;

            Func<TApplicationContext, Task>[] operations = [
                // Get the GitHub client.
                async applicationContext =>
                {
                    await Instances.ContextOperator.In_Context_UsingParameterlessConstructor<Context002>(
                        Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath<Context002>(
                            out var gitHubAuthenticationJsonFilePathSet),
                        Instances.SetGitHubClientContextOperations.Load_GitHubAuthentication_N001<Context002>(
                            gitHubAuthenticationJsonFilePathSet,
                            out gitHubAuthenticationSet),
                        Instances.SetGitHubClientContextOperations.Set_GitHubClient<Context002>(
                            gitHubAuthenticationSet,
                            out gitHubClientSet),
                        childContext =>
                        {
                            applicationContext.GitHubClient = childContext.GitHubClient;
                            applicationContext.Authentication = childContext.Authentication;

                            return Task.CompletedTask;
                        }
                    );
                },
                // Get the GitHub author information.
                async applicationContext =>
                {
                    applicationContext.GitHubAuthor = await Instances.JsonOperator.Load_FromFile<Author>(
                        Instances.Values.GitHubAuthorJsonFilePath,
                        Instances.JsonKeys.GitHubAuthor);
                },
                // Set the NuGet author.
                applicationContext =>
                {
                    applicationContext.NuGetAuthor = Instances.Authors.DCoats.Value;

                    return Task.CompletedTask;
                }
            ];

            applicationContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TApplicationContext>().For(
                gitHubClientSet,
                gitHubAuthorSet,
                nuGetAuthorSet,
                gitHubAuthenticationSet);

            return Instances.ContextOperations.In_Context<TApplicationContext>(operations);
        }
    }
}
