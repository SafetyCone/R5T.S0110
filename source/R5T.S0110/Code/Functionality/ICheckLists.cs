using System;

using R5T.L0081.O002;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0096.O001;
using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface ICheckLists : IFunctionalityMarker
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public void Ensure_RequiredChecks_ForRepository(
            IChecked<IGitHubRepositoryExists> checkedGitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> checkedLocalRepositoryExists,
            IChecked<IFileExists> checkedGitIgnoreFileExists,
            IChecked<ILocalChangesPushedToRemote> checkedLocalChangesPushedToRemote)
        {
            // Do nothing. This method just provides required input arguments to make sure things have been done.
        }

        public void Ensure_RequiredChecks_ForSolution(
            IChecked<IFileExists> checkedSolutionFileExists,
            IChecked<ISolutionHasProject> chekedSolutionHasProject)
        {
            // Do nothing. This method just provides required input arguments to make sure things have been done.
        }

        public void Ensure_RequiredChecks_ForProject(
            IChecked<IFileExists> checkedProjectFileExists,
            IChecked<ISolutionHasProject> chekedSolutionHasProject,
            IChecked<IFileExists> checkedProgramFileExists,
            IChecked<IFileExists> checkedDocumentationFileExists,
            IChecked<IFileExists> checkedInstancesFileExists,
            IChecked<IFileExists> checkedProjectPlanFileExists)
        {
            // Do nothing. This method just provides required input arguments to make sure things have been done.
        }

#pragma warning restore IDE0060 // Remove unused parameter
    }
}
