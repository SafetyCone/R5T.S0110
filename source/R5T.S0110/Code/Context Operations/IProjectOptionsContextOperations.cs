using System;
using System.Threading.Tasks;

using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectOptionsContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Set_ProjectOptions<TContext>(
            ProjectOptions projectOptions,
            out IsSet<IHasProjectOptions> projectOptionsSet)
            where TContext : IWithProjectOptions
        {
            return context =>
            {
                context.ProjectOptions = projectOptions;

                return Task.CompletedTask;
            };
        }
    }
}
