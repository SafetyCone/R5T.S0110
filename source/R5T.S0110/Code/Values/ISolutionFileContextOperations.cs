using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0234;


namespace R5T.S0110
{
    [ValuesMarker]
    public partial interface ISolutionFileContextOperations : IValuesMarker
    {
        public Task Set_SolutionFilePath<TContext>(TContext context)
            where TContext : IWithSolutionFilePath, IHasSolutionName, IHasSolutionDirectoryPath
        {
            context.SolutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                context.SolutionDirectoryPath,
                context.SolutionName);

            return Task.CompletedTask;
        }

        public Task Verify_SolutionFilePath_DoesNotExist<TContext>(TContext context)
            where TContext: IHasSolutionFilePath
        {
            var solutionFileExists = Instances.FileSystemOperator.Exists_File(
                context.SolutionFilePath);

            if(solutionFileExists)
            {
                throw new Exception($"Solution file exists:\n\t{context.SolutionFilePath}");
            }

            return Task.CompletedTask;
        }
    }
}
