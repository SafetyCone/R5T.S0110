using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0078.T000;
using R5T.S0110.Contexts;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IApplicationContextOperations : IContextOperationsMarker
    {
        public Func<TContextSet, Task> In_ApplicationContext<TContextSet, TApplicationContext>(
            out ContextSetSpecifier<TContextSet> applicationContextSetSpecifier,
            out TypeSpecifier<TApplicationContext> applicationContextSpecifier,
            out (
            IsSet<IHasGitHubClient> GitHubClientSet,
            IsSet<IHasGitHubAuthor> GitHubAuthorSet,
            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
            ) applicationContextPropertiesSet,
            params Func<TContextSet, TApplicationContext, Task>[] operations)
            where TContextSet : IWithContext<TApplicationContext>, new()
            where TApplicationContext : IWithGitHubClient, IWithGitHubAuthor, IWithNuGetAuthor, N001.IWithAuthentication, new()
        {
            var o = Instances.ContextOperations;

            return o.In_ContextSet2<TContextSet, TApplicationContext>(
                out applicationContextSetSpecifier,
                out applicationContextSpecifier,
                o.Construct_Context2<TContextSet, TApplicationContext>(
                    Instances.ContextOperations.Set_ContextProperties<TApplicationContext>(
                        out applicationContextPropertiesSet).In_ContextSetAndContext(applicationContextSetSpecifier)
                ),
                operations
            );
        }

        //public Func<Task> In_ApplicationContext<TContextSet, TApplicationContext>(
        //    out (
        //    IsSet<IHasGitHubClient> GitHubClientSet,
        //    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
        //    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
        //    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
        //    ) applicationContextPropertiesSet,
        //    params Func<TContextSet, Task>[] operations)
        //    where TContextSet : IWithContext<TApplicationContext>, new()
        //    where TApplicationContext : IWithGitHubClient, IWithGitHubAuthor, IWithNuGetAuthor, N001.IWithAuthentication, new()
        //{
        //    var o = Instances.ContextOperations;

        //    return o.In_ContextSet2<TContextSet>(
        //        operations.Prepend(
        //            o.In_ContextSet2A<TContextSet, TApplicationContext>(
        //                o.Construct_Context<TApplicationContext>(
        //                    Instances.ContextOperations.Set_ContextProperties<TApplicationContext>(
        //                        out applicationContextPropertiesSet)
        //                )
        //            )
        //        )
        //    );
        //}

        public Func<Task> In_ApplicationContext(
            out (
            IsSet<IHasGitHubClient> GitHubClientSet,
            IsSet<IHasGitHubAuthor> GitHubAuthorSet,
            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
            ) applicationContextPropertiesSet,
            params Func<Context000, Task>[] operations)
        {
            var o = Instances.ContextOperations;

            return o.In_ContextSet<Context000>(
                o.Construct_Context<Context000>(
                    Instances.ContextOperations.Set_ContextProperties<Context000>(
                        out applicationContextPropertiesSet)
                ),
                operations);
        }
    }
}
