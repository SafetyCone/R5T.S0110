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
    }
}
