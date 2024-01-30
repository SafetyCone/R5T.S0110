using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0235.T000;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface ICloneRepositoryLocallyContextOperations : IValuesMarker
    {
        public Func<TContext, Task> Set_RepositoriesDirectoryPath<TContext>(
            string repositoriesDirectoryPath)
            where TContext : IWithRepositoriesDirectoryPath
        {
            return context =>
            {
                context.RepositoriesDirectoryPath = repositoriesDirectoryPath;

                return Task.CompletedTask;
            };
        }

        public Task Set_RepositoriesDirectoryPath<TContext>(TContext context)
            where TContext  : IWithRepositoriesDirectoryPath
        {
            return Instances.ContextOperator.In_Context(
                context,
                this.Set_RepositoriesDirectoryPath<TContext>(
                    Instances.Values.LocalRepositoriesDirectoryPath));
        }

        public Task Set_RepositoryDirectoryPath<TContext>(TContext context)
            where TContext : IWithRepositoryDirectoryPath, IHasRepositoriesDirectoryPath, IHasRepositoryName, IHasRepositoryOwnerName
        {
            var repositoryOwnerDirectoryName = Instances.RepositoryDirectoryNameOperator.Get_RepositoryOwnerDirectoryName(
                context.RepositoryOwnerName);

            var repositoryDirectoryName = Instances.RepositoryDirectoryNameOperator.Get_RepositoryDirectoryName(
                context.RepositoryName);

            context.RepositoryDirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                context.RepositoriesDirectoryPath,
                repositoryOwnerDirectoryName,
                repositoryDirectoryName);

            return Task.CompletedTask;
        }
    }
}
