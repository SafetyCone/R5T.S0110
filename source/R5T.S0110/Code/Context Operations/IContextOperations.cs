using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using R5T.L0078.T000;
using R5T.T0046;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IContextOperations : IContextOperationsMarker,
        L0066.IContextOperations
    {
        public Func<TContext, TApplicationContext, Task> Set_ContextProperties<TContext, TApplicationContext>(
            (IsSet<IHasGitHubAuthor>, IsSet<N001.IHasAuthentication>) propertiesRequired,
            out (IsSet<IHasGitHubAuthor> GitHubAuthorSet, IsSet<N001.IHasAuthentication> GitHubAuthenticationSet) propertiesSet)
            where TContext :
            IWithGitHubAuthor,
            N001.IWithAuthentication
            where TApplicationContext :
            IHasGitHubAuthor,
            N001.IHasAuthentication
        {
            return (context, applicationContext) =>
            {
                context.GitHubAuthor = applicationContext.GitHubAuthor;
                context.Authentication = applicationContext.Authentication;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_ContextProperties<TContext>(
            out (
            IsSet<IHasGitHubClient> GitHubClientSet,
            IsSet<IHasGitHubAuthor> GitHubAuthorSet,
            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
            ) propertiesSet)
            where TContext :
            IWithGitHubClient,
            IWithGitHubAuthor,
            IWithNuGetAuthor,
            N001.IWithAuthentication
        {
            return Instances.ContextOperations.In_Context<TContext>(
                // Get the GitHub client.
                async context =>
                {
                    await Instances.ContextOperator.In_Context(
                        () =>
                        {
                            var context = new Context002();

                            return Task.FromResult(context);
                        },
                        Instances.SetGitHubClientContextOperations.Set_GitHubAuthenticationJsonFilePath<Context002>(
                            out _
                        ),
                        Instances.SetGitHubClientContextOperations.Load_Authentication_N001<Context002>(
                            out _
                        ),
                        Instances.SetGitHubClientContextOperations.Set_GitHubClient<Context002>(
                            out _
                        ),
                        childContext =>
                        {
                            context.GitHubClient = childContext.GitHubClient;
                            context.Authentication = childContext.Authentication;

                            return Task.CompletedTask;
                        }
                    );
                },
                // Get the GitHub author information.
                async context =>
                {
                    context.GitHubAuthor = await Instances.JsonOperator.Load_FromFile<Author>(
                        Instances.Values.GitHubAuthorJsonFilePath,
                        "GitHubAuthor");
                },
                // Set the NuGet author.
                context =>
                {
                    context.NuGetAuthor = Instances.Authors.DCoats.Value;

                    return Task.CompletedTask;
                }
            );
        }
    }
}
