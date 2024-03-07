using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace R5T.S0110
{
    public partial interface IContextOperator
    {
        public async Task In_ChildContextSet<TChildContextSet, TContextSet>(
            TContextSet contextSet,
            IDirectionalIsomorphism<TContextSet, TChildContextSet> contextSetIsomorphism,
            IEnumerable<Func<TChildContextSet, Task>> operations)
            where TChildContextSet : new()
        {
            var childContextSet = new TChildContextSet();

            // Copy the contexts from the parent (as an instance of the parent type, since the child type inherits from the parent).
            await contextSetIsomorphism.Copy_From(contextSet, childContextSet);

            await Instances.ActionOperator.Run_Actions<TChildContextSet>(
                childContextSet,
                operations);
        }

        public Task In_ChildContextSet<TChildContextSet, TContextSet>(
            TContextSet contextSet,
            IDirectionalIsomorphism<TContextSet, TChildContextSet> contextSetIsomorphism,
            params Func<TChildContextSet, Task>[] operations)
            where TChildContextSet : new()
            => this.In_ChildContextSet<TChildContextSet, TContextSet>(
                contextSet,
                contextSetIsomorphism,
                operations.AsEnumerable());

        public Task In_ContextSet2<TContextSet>(
            TContextSet contextSet,
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : new()
        {
            return Instances.ActionOperator.Run_Actions<TContextSet>(
                contextSet,
                operations);
        }

        public Task In_ContextSet2<TContextSet>(
            TContextSet contextSet,
            params Func<TContextSet, Task>[] operations)
            where TContextSet : new()
        {
            return this.In_ContextSet2<TContextSet>(
                contextSet,
                operations.AsEnumerable());
        }

        public Task In_ContextSet2<TContextSet>(
            IEnumerable<Func<TContextSet, Task>> operations)
            where TContextSet : new()
        {
            var contextSet = new TContextSet();

            return this.In_ContextSet2<TContextSet>(
                contextSet,
                operations);
        }

        public Task In_ContextSet2<TContextSet>(
            params Func<TContextSet, Task>[] operations)
            where TContextSet : new()
        {
            return this.In_ContextSet2<TContextSet>(
                operations.AsEnumerable());
        }
    }
}
