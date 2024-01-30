using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IGitHubOperator : IFunctionalityMarker
    {
        public Task In_GitHubClientContext(
            IEnumerable<Func<GitHubClientContext, Task>> operations)
        {
            var context = new GitHubClientContext();

            return Instances.ContextOperator.In_Context(
                context,
                operations);
        }

        public Task In_GitHubClientContext(
            params Func<GitHubClientContext, Task>[] operations)
        {
            return this.In_GitHubClientContext(
                operations.AsEnumerable());
        }
    }
}
