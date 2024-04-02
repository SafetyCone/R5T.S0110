using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace R5T.S0110
{
    public partial interface IContextOperations
    {
        public Func<TContextSet, Task<TContext>> Construct_Context<TContextSet, TContext>(
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            where TContext : new()
        {
            return async contextSet =>
            {
                var context = new TContext();

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    context,
                    operations);

                return context;
            };
        }

        public Func<TContextSet, Task<TContext>> Construct_Context<TContextSet, TContext>(
            params Func<TContextSet, TContext, Task>[] operations)
            where TContext : new()
            => this.Construct_Context<TContextSet, TContext>(
                operations.AsEnumerable());

        public Func<TContextSet, Task<TContext>> Construct_Context_OfContextSet<TContextSet, TContext>(
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            where TContextSet : IWithContext<TContext>
            where TContext : new()
        {
            return async contextSet =>
            {
                var context = new TContext();

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    context,
                    operations);

                return context;
            };
        }

        public Func<TContextSet, Task<TContext>> Construct_Context_OfContextSet<TContextSet, TContext>(
            params Func<TContextSet, TContext, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            where TContext : new()
            => this.Construct_Context_OfContextSet<TContextSet, TContext>(
                operations.AsEnumerable());

        public Func<TContext, Task> Get<TContext, T>(
            T value,
            out T outputValue)
        {
            outputValue = value;

            return this.Do_Nothing<TContext>;
        }

        public Func<Task> In_ContextSet2<TContextSet>(
            TContextSet contextSet,
            IEnumerable<Func<TContextSet, Task>> operations)
            => () => Instances.ActionOperator.Run_Actions(
                contextSet,
                operations);

        public Func<Task> In_ContextSet2<TContextSet>(
            TContextSet contextSet,
            params Func<TContextSet, Task>[] operations)
            => this.In_ContextSet2<TContextSet>(
                contextSet,
                operations.AsEnumerable());

        public Func<Task> In_ContextSet2<TContextSet>(
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : new()
        {
            var contextSet = new TContextSet();

            return this.In_ContextSet2<TContextSet>(
                contextSet,
                operations);
        }

        public Func<Task> In_ContextSet2<TContextSet>(
            params Func<TContextSet, Task>[] operations)
            where TContextSet : new()
            => this.In_ContextSet2<TContextSet>(
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ContextSet_WithContext<TContextSet, TContext>(
            Func<Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : IWithContext<TContext>
            => async contextSet =>
            {
                contextSet.Context = await contextConstructor();

                await Instances.ActionOperator.Run_Actions(
                    contextSet,
                    operations);
            };

        public Func<TContextSet, Task> In_ContextSet_WithContext<TContextSet, TContext>(
            Func<Task<TContext>> contextConstructor,
            params Func<TContextSet, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            => this.In_ContextSet_WithContext<TContextSet, TContext>(
                contextConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
            // Use a type adapter instead of just a modifying type adapter so we can use the actual context instance of the context set (which verifies the get/set type adapter functionality).
            TypeAdapter<TContextSet, TContext> contextSetAdapterForContext,
            out TypeSpecifier<TContext> contextSpecifier,
            Func<TContextSet, Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            => async contextSet =>
            {
                var context = await contextConstructor(contextSet);

                contextSetAdapterForContext.Set_T1(contextSet, context);

                var contextForUse = contextSetAdapterForContext.Get_T1(contextSet);

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    contextForUse,
                    operations);
            };

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
           TypeAdapter<TContextSet, TContext> contextSetAdapterForContext,
           out TypeSpecifier<TContext> contextSpecifier,
           Func<TContextSet, Task<TContext>> contextConstructor,
           params Func<TContextSet, TContext, Task>[] operations)
           => this.In_Context_OfContextSet<TContextSet, TContext>(
               contextSetAdapterForContext,
               out contextSpecifier,
               contextConstructor,
               operations.AsEnumerable());

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextSpecifier,
            Func<TContextSet, Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            where TContextSet : IWithContext<TContext>
            => async contextSet =>
            {
                contextSet.Context = await contextConstructor(contextSet);

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    contextSet.Context,
                    operations);
            };

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
            out TypeSpecifier<TContext> contextSpecifier,
            Func<TContextSet, Task<TContext>> contextConstructor,
            params Func<TContextSet, TContext, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            => this.In_Context_OfContextSet<TContextSet, TContext>(
                out contextSpecifier,
                contextConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
            out ContextSetSpecifier<TContextSet> contextSetSpecifier,
            out TypeSpecifier<TContext> contextSet,
            Func<TContextSet, Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            where TContextSet : IWithContext<TContext>
            => async contextSet =>
            {
                contextSet.Context = await contextConstructor(contextSet);

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    contextSet.Context,
                    operations);
            };

        public Func<TContextSet, Task> In_Context_OfContextSet<TContextSet, TContext>(
            out ContextSetSpecifier<TContextSet> contextSetSpecifier,
            out TypeSpecifier<TContext> contextSet,
            Func<TContextSet, Task<TContext>> contextConstructor,
            params Func<TContextSet, TContext, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            => this.In_Context_OfContextSet<TContextSet, TContext>(
                out contextSetSpecifier,
                out contextSet,
                contextConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ContextSet2<TContextSet, TContext>(
            Func<Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : IWithContext<TContext>
            => async contextSet =>
            {
                contextSet.Context = await contextConstructor();

                await Instances.ActionOperator.Run_Actions(
                    contextSet,
                    operations);
            };

        public Func<TContextSet, Task> In_ContextSet2<TContextSet, TContext>(
            Func<Task<TContext>> contextConstructor,
            params Func<TContextSet, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            => this.In_ContextSet2<TContextSet, TContext>(
                contextConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ContextSetWithContext<TContextSet, TContext>(
            out ContextSetSpecifier<TContextSet> contextSetSpecifier,
            out TypeSpecifier<TContext> contextSet,
            Func<TContextSet, Task<TContext>> contextConstructor,
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            where TContextSet : IWithContext<TContext>
            => async contextSet =>
            {
                contextSet.Context = await contextConstructor(contextSet);

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    contextSet.Context,
                    operations);
            };

        public Func<TContextSet, Task> In_ContextSetWithContext<TContextSet, TContext>(
            out ContextSetSpecifier<TContextSet> contextSetSpecifier,
            out TypeSpecifier<TContext> contextSet,
            Func<TContextSet, Task<TContext>> contextConstructor,
            params Func<TContextSet, TContext, Task>[] operations)
            where TContextSet : IWithContext<TContext>
            => this.In_ContextSetWithContext<TContextSet, TContext>(
                out contextSetSpecifier,
                out contextSet,
                contextConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ContextSetAndContext<TContextSet, TContext>(
            Func<TContextSet, Task<TContext>> contextConstructor,
            out TypeSpecifier<TContext> contextSpecifier,
            IEnumerable<Func<TContextSet, TContext, Task>> operations)
            => async contextSet =>
            {
                var context = await contextConstructor(contextSet);

                await Instances.ActionOperator.Run_Actions<TContextSet, TContext>(
                    contextSet,
                    context,
                    operations);
            };

        public Func<TContextSet, Task> In_ContextSetAndContext<TContextSet, TContext>(
            Func<TContextSet, Task<TContext>> contextConstructor,
            out TypeSpecifier<TContext> contextSpecifier,
            params Func<TContextSet, TContext, Task>[] operations)
            => this.In_ContextSetAndContext<TContextSet, TContext>(
                contextConstructor,
                out contextSpecifier,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            Func<TContextSet, Task<TChildContextSet>> contextSetConstructor,
            IEnumerable<Func<TChildContextSet, Task>> operations)
        {
            return async parentContextSet =>
            {
                var contextSet = await contextSetConstructor(parentContextSet);

                await Instances.ActionOperator.Run_Actions(
                    contextSet,
                    operations);
            };
        }

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            Func<TContextSet, Task<TChildContextSet>> contextSetConstructor,
            params Func<TChildContextSet, Task>[] operations)
            => this.In_ChildContextSet<TChildContextSet, TContextSet>(
                contextSetConstructor,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            Func<TContextSet, Task<TChildContextSet>> contextSetConstructor,
            out ContextSetSpecifier<TChildContextSet> childContextSetSpecifier,
            IEnumerable<Func<TChildContextSet, Task>> operations)
            => this.In_ChildContextSet<TChildContextSet, TContextSet>(
                contextSetConstructor,
                operations);

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            Func<TContextSet, Task<TChildContextSet>> contextSetConstructor,
            out ContextSetSpecifier<TChildContextSet> childContextSetSpecifier,
            params Func<TChildContextSet, Task>[] operations)
            => this.In_ChildContextSet<TChildContextSet, TContextSet>(
                contextSetConstructor,
                out childContextSetSpecifier,
                operations.AsEnumerable());

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            IDirectionalIsomorphism<TContextSet, TChildContextSet> contextSetIsomorphism,
            out ContextSetSpecifier<TChildContextSet> childContextSetSpecifier,
            IEnumerable<Func<TChildContextSet, Task>> operations)
            where TChildContextSet : new()
        {
            return async contextSet =>
            {
                var childContextSet = new TChildContextSet();

                // Copy the contexts from the parent (as an instance of the parent type, since the child type inherits from the parent).
                await contextSetIsomorphism.Copy_From(contextSet, childContextSet);

                await Instances.ActionOperator.Run_Actions<TChildContextSet>(
                    childContextSet,
                    operations);
            };
        }

        public Func<TContextSet, Task> In_ChildContextSet<TChildContextSet, TContextSet>(
            IDirectionalIsomorphism<TContextSet, TChildContextSet> contextSetIsomorphism,
            out ContextSetSpecifier<TChildContextSet> childContextSetSpecifier,
            params Func<TChildContextSet, Task>[] operations)
            where TChildContextSet : new()
            => this.In_ChildContextSet<TChildContextSet, TContextSet>(
                contextSetIsomorphism,
                out childContextSetSpecifier,
                operations.AsEnumerable());
    }
}
