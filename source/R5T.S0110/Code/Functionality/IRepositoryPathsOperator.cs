using System;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IRepositoryPathsOperator : IFunctionalityMarker
    {
        public string Get_GitIgnoreFilePath(string repositoryDirectoryPath)
        {
            var gitIgnoreFilePath = Instances.PathOperator.Get_FilePath(
                repositoryDirectoryPath,
                Instances.FileNames.GitIgnore);

            return gitIgnoreFilePath;
        }

        public string Get_SourceDirectoryPath(string repositoryDirectoryPath)
        {
            var sourceDirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                repositoryDirectoryPath,
                Instances.DirectoryNames.Source);

            return sourceDirectoryPath;
        }
    }
}
