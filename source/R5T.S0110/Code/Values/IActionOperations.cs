using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0131;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface IActionOperations : IValuesMarker
    {
        public Func<T, Task> From<T>(IEnumerable<Func<T, Task>> operations)
        {
            return value => Instances.ActionOperator.Run_Actions(
                value,
                operations);
        }

        public Func<T, Task> From<T>(params Func<T, Task>[] operations)
            => this.From(operations.AsEnumerable());
    }
}
