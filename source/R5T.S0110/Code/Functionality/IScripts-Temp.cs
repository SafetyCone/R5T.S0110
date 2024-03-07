using System;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0078.T000;
using R5T.L0079;
using R5T.L0081.O002;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0095.T000;
using R5T.L0096.O001;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0235.T000;
using R5T.Z0046;

using R5T.S0110.Contexts;


namespace R5T.S0110
{
    public partial interface IScripts
    {
        public async Task Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplication()
        {
            /// Inputs.
            var libraryName =
                // Use the disposable name since we might have deletion code!
                Instances.RepositoryNameExamples.Disposable
                ;
            var isPrivate =
                true
                ;
            var repositoryOwnerName =
                Instances.RepositoryOwnerNameExamples.SafetyCone
                ;
            var libraryDescription =
                Instances.RepositoryDescriptionExamples.ForTesting
                ;


            /// Run.
            var repositoryName_UnadjustedForPrivacy = Instances.RepositoryNameOperator.GetRepositoryName_FromLibraryName(libraryName);

            var repositoryName = Instances.RepositoryNameOperator.AdjustName_ForPrivacy(
                repositoryName_UnadjustedForPrivacy,
                isPrivate);
            var repositoryDescription = Instances.RepositoryDescriptionOperator.GetRepositoryDescription_FromLibraryDescription(libraryDescription);

            var repositorySpecification = new RepositorySpecification
            {
                Organization = repositoryOwnerName,
                Name = repositoryName,
                Description = repositoryDescription,
                IsPrivate = isPrivate,
                License = License.MIT,
            };

            var librarySolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_SolutionName(libraryName);
            var librarySolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                librarySolutionName_UnadjustedForPrivacy,
                isPrivate);

            var librarySolutionSpecification = new SolutionSpecification
            {
                Name = librarySolutionName
            };

            var libraryProjectName = Instances.ProjectNameOperator.Get_ProjectName_FromLibraryName(libraryName);
            var libraryProjectDescription = Instances.ProjectDescriptionOperator.Get_ProjectDescription_FromLibraryDescription(libraryDescription);

            var libraryProjectSpecification = new ProjectSpecification
            {
                Name = libraryProjectName,
                Description = libraryProjectDescription,
            };

            var constructionSolutionName_UnadjustedForPrivacy = Instances.SolutionNameOperator.Get_ConstructionSolutionName(librarySolutionName_UnadjustedForPrivacy);
            var constructionSolutionName = Instances.SolutionNameOperator.Adjust_Name_ForPrivacy(
                constructionSolutionName_UnadjustedForPrivacy,
                isPrivate);

            var constructionSolutionSpecification = new SolutionSpecification
            {
                Name = constructionSolutionName
            };

            var constructionProjectName = Instances.ProjectNameOperator.Get_LibraryConstructionProjectName_FromLibraryName(libraryName);
            var constructionProjectDescription = Instances.ProjectDescriptionOperator.Get_LibraryConstructionProjectDescription_FromLibraryName(libraryName);

            var constructionProjectSpecification = new ProjectSpecification
            {
                Name = constructionProjectName,
                Description = constructionProjectDescription,
            };

            // Options.
            var projectOptions = new ProjectOptions
            {
                Company = Instances.CompanyNames.Rivet.Value,
                Copyright = Instances.CopyrightOperator.Get_CopyrightText(
                    Instances.CompanyNames.Rivet.Value),
                IgnoreWarningNumbersList = Instances.Values.NoWarn_Default_WarningsList,
                TargetFramework = Instances.TargetFrameworkMonikers.NET_8,
                NuGetAuthor = Instances.Authors.DCoats.Value,
                PackageLicenseExpression = Instances.PackageLicenseExpressions.MIT.Value,
                Version = Instances.Versions.Initial_Default,
            };

            // Start with an application context.
            var o = Instances.ContextOperations;

            await Instances.ContextOperator.In_ContextSet2<ContextSet001>(
                Instances.ApplicationContextOperations.In_ApplicationContext<ContextSet001, Context000>(
                    out ContextSetSpecifier<ContextSet001> applicationContextSetSpecifier,
                    out TypeSpecifier<Context000> applicationContextSpecifier,
                    out (
                    IsSet<IHasGitHubClient> GitHubClientSet,
                    IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                    IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                    IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                    ) applicationContextPropertiesSet,
                    Instances.RepositoryContextOperations.In_RegeneratedRepositoryContext<ContextSet002, ContextSet001, Context001, Context000>(
                        out ContextSetSpecifier<ContextSet002> repositoryContextSetSpecifier,
                        out TypeSpecifier<Context001> repositoryContextSpecifier,
                        repositorySpecification,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context000>().For(
                            applicationContextPropertiesSet.GitHubClientSet,
                            applicationContextPropertiesSet.GitHubAuthorSet,
                            applicationContextPropertiesSet.GitHubAuthenticationSet
                        ),
                        out ContextPropertiesSet<Context001, (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                            IsSet<IHasRepository> RepositorySet,
                            IsSet<IHasRepositoryUrl> RepositoryUrlSet)> repositoryPropertiesSet,
                        out var checkedRepository,
                        Instances.SolutionSetContextOperations.In_SolutionSetContext<LibrarySolutionSetContextSet, ContextSet002, LibrarySolutionSetContext, Context001>(
                            out ContextSetSpecifier<LibrarySolutionSetContextSet> solutionSetContextSetSpecifier,
                            out TypeSpecifier<LibrarySolutionSetContext> solutionContextSpecifier,
                            Instances.ContextOperator.Get_ContextPropertiesSet<Context001>().For(
                                repositoryPropertiesSet.PropertiesSet.RepositoryDirectoryPathSet),
                            out ContextPropertiesSet<LibrarySolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
                            //Create_NonWebAssemblyRazorComponentRazorClassLibraryProject(
                            Instances.SolutionSetContextSetOperations.Create_NonWebAssemblyRazorComponentRazorClassLibraryProject<ContextSet004, LibrarySolutionSetContextSet, LibrarySolutionSetContext>(
                                Instances.ContextSetIsomorphisms.For<LibrarySolutionSetContextSet, ContextSet004>(
                                    ContextSetContextTypesSpecifier<Context000, Context001>.Instance),
                                out ContextSetSpecifier<ContextSet004> projectContextSetSpecifier,
                                out var projectContextSpecifier,
                                libraryProjectSpecification,
                                projectOptions,
                                solutionSetContextPropertiesSet,
                                Instances.ContextOperator.Get_ContextPropertiesSet<Context001>().For(
                                    repositoryPropertiesSet.PropertiesSet.RepositoryUrlSet),
                                out var checkedProjectFileExists,
                                Instances.EnumerableOperator.Empty<Func<ContextSet004, Task>>()
                            //Instances.EnumerableOperator.From(
                            //    // Set the project file path.
                            //    Instances.SolutionSetContextOperations.Set_ProjectFilePath<ProjectContext001, LibrarySolutionSetContext>(
                            //        out var libraryProjectFilePathSet).In_ContextSet(projectContextSetSpecifier)
                            //)
                            ).In_ContextSetAndContext(solutionContextSpecifier),
                            Instances.SolutionFileContextOperations.Create_SolutionFile<LibrarySolutionSetContext>(librarySolutionSpecification, (solutionSetContextPropertiesSet.PropertiesSet, libraryProjectFilePathSet.PropertiesSet),
                                out var solutionFilePathSet,
                                out var checkedSolutionFileExists).In_ContextSetAndContext(solutionSetContextSetSpecifier),
                            // Open the construction solution file.
                            Instances.VisualStudioContextOperations.Open_VisualStudioSolution<LibrarySolutionSetContext>(
                                x => Task.FromResult(x.ConstructionSolutionFilePath)).In_ContextSetAndContext(solutionSetContextSetSpecifier)
                        ).In_ContextSetAndContext(repositoryContextSpecifier)
                    ).In_ContextSetAndContext(applicationContextSpecifier)
                )
            );
        }
    }
}
