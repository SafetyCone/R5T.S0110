using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IContextOperations : IContextOperationsMarker,
        L0066.IContextOperations
    {
        public Func<TContext, Task> CaptureContext<TContext>(out ContextCapture<TContext> contextCapture)
        {
            // Intermediate memory local required for out parameters and anonymoust methods to play nicely.
            var contextCapture_Local = new ContextCapture<TContext>();

            contextCapture = contextCapture_Local;

            return context =>
            {
                contextCapture_Local.Context = context;

                return Task.CompletedTask;
            };
        }

        public Func<TContextA, Task> From<TContextA>(
           IEnumerable<Func<TContextA, Task>> operations = default)
           => contextA =>
               Instances.ContextOperator.In_ContextSet(
                   contextA,
                   operations);

        public Func<TContextA, TContextB, Task> From<TContextA, TContextB>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations = default)
            => (contextA, contextB) =>
                Instances.ContextOperator.In_ContextSet(
                    contextA,
                    contextB,
                    operations);

        public Func<TContextA, TContextB, Task> From<TContextA, TContextB>(
            params Func<TContextA, TContextB, Task>[] operations)
            => this.From(operations.AsEnumerable());

        public Func<TContextA, TContextB, TContextC, Task> From<TContextA, TContextB, TContextC>(
            IEnumerable<Func<TContextA, TContextB, TContextC, Task>> operations = default)
            => (contextA, contextB, contextC) =>
                Instances.ContextOperator.In_ContextSet(
                    contextA,
                    contextB,
                    contextC,
                    operations);

        public Func<TContextA, TContextB, TContextC, Task> From<TContextA, TContextB, TContextC>(
            params Func<TContextA, TContextB, TContextC, Task>[] operations)
            => this.From(operations.AsEnumerable());

        public Func<TContext, Task> In_ContextSet<TContext, TCapturedContext>(
            ContextCapture<TCapturedContext> contextCapture,
            IEnumerable<Func<TContext, TCapturedContext, Task>> operations)
        {
            return context =>
            {
                return Instances.ContextOperator.In_ContextSet<TContext, TCapturedContext>(
                    context,
                    contextCapture.Context,
                    operations);
            };
        }

        public Func<TContext, Task> In_ContextSet<TContext, TCapturedContext>(
            ContextCapture<TCapturedContext> contextCapture,
            params Func<TContext, TCapturedContext, Task>[] operations)
            => this.In_ContextSet<TContext, TCapturedContext>(
                contextCapture,
                operations.AsEnumerable());

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

        #region Set Context of Context Set

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            TContext context)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = context;

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextTypeSpecifier,
            TContext context)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = context;

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            Func<TContext> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = contextConstructor();

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextTypeSpecifier,
            Func<TContext> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = contextConstructor();

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            Func<Task<TContext>> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return async contextSet =>
            {
                contextSet.Context = await contextConstructor();
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextTypeSpecifier,
            Func<Task<TContext>> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return async contextSet =>
            {
                contextSet.Context = await contextConstructor();
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            Func<TContextSet, TContext> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = contextConstructor(contextSet);

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextTypeSpecifier,
            Func<TContextSet, TContext> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return contextSet =>
            {
                contextSet.Context = contextConstructor(contextSet);

                return Task.CompletedTask;
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            Func<TContextSet, Task<TContext>> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return async contextSet =>
            {
                contextSet.Context = await contextConstructor(contextSet);
            };
        }

        public Func<TContextSet, Task> Set_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextTypeSpecifier,
            Func<TContextSet, Task<TContext>> contextConstructor)
            where TContextSet : IWithContext<TContext>
        {
            return async contextSet =>
            {
                contextSet.Context = await contextConstructor(contextSet);
            };
        }

        #endregion
    }
}
