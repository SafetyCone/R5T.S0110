using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ICodeFileContextOperations : IContextOperationsMarker
    {
        [Obsolete("See R5T.L0097.O001.ICodeFileGenerationContextOperations.Create_ProgramFile_ForConsole().")]
        public Func<TContext, Task> Create_ProgramFile_ForConsole<TContext>(
            out IChecked<IFileExists> programFileExists)
            where TContext : IHasFilePath, IHasNamespaceName
        {
            programFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.CodeFileGenerationOperations.Create_ProgramFile_ForConsole(
                    context.FilePath,
                    context.NamespaceName);
            };
        }

        public Func<TContext, Task> Set_FilePath<TContext>(
            string projectDirectoryRelativeFilePath,
            out IsSet<IHasFilePath> codeFilePathSet)
            where TContext : IWithFilePath, IHasProjectFilePath
        {
            return context =>
            {
                context.FilePath = Instances.ProjectPathsOperator.Get_Path_ForProjectDirectoryRelativePath(
                    context.ProjectFilePath,
                    projectDirectoryRelativeFilePath);

                return Task.CompletedTask;
            };
        }
    }
}
