using System;
using System.Threading.Tasks;

using R5T.L0093.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IWindowsExplorerOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Open_DirectoryPath<TContext>(
            IsSet<IHasDirectoryPath> directoryPathSet)
            where TContext : IHasDirectoryPath
        {
            return context =>
            {
                Instances.WindowsExplorerOperator.Open(
                    context.DirectoryPath);

                return Task.CompletedTask;
            };
        }
    }
}
