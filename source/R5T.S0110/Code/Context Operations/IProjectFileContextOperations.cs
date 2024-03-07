using System;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectFileContextOperations : IContextOperationsMarker
    {
        public Func<ProjectContext001, Task> Create_LibraryProjectFile(
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
            IsSet<IHasProjectFilePath> ProjectFilePathSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet
            )> projectContextPropertiesSet,
            ContextCapture<Context001> repositoryContextCapture,
            out IChecked<IFileExists> checkedProjectFileExists)
        {
            var o = Instances.ContextOperations;

            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context005, ProjectContext001>();
            var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

            return o.In_ContextSet_A_BA<Context005, ProjectContext001>(
                o.Construct_Context_B_BA<Context005, ProjectContext001>(
                    Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                        out var projectElementContextProjectFilePathSet),
                    Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                        out var projectElementContextProjectDescriptionSet),
                    Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                        out var projectElementSet).In(contextSet)
                ),
                Instances.ProjectElementContextOperations.Set_SDK_NET<Context005>().In(contextSet),
                Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main(
                    projectOptions,
                    out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet_Main,
                    out var projectOptionsContextPropertiesSet,
                    out var checkedPropertyGroupElementAppended_Main,
                    Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupContextSet),
                    // Change the target framework from what is specified in the project options, to the library default.
                    Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default_ForLibrary<Context006>(propertyElementContextPropertiesSet_Main.PropertiesSet.PropertyGroupElementSet).In(propertyGroupContextSet)
                ).In(contextSet),
                Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary(
                    projectOptions,
                    projectElementContextProjectDescriptionSet,
                    out ContextPropertiesSet<Context006, (
                        IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                        IsSet<IHasCompany> CompanySet,
                        IsSet<IHasCopyright> CopyrightSet,
                        IsSet<IHasProjectDescription> DescriptionSet,
                        IsSet<IHasNuGetAuthor> NugetAuthorSet,
                        IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
                        IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptanceSet,
                        IsSet<IHasVersion> VersionSet
                        )> propertyElementContextPropertiesSet_Package,
                    out projectOptionsContextPropertiesSet,
                    out var checkedPropertyGroupElementAppended,
                    Instances.EnumerableOperator.From(
                        Instances.ContextOperations.In_ContextSet<Context006, Context001>(
                            repositoryContextCapture,
                            Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                                propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet,
                                context001 => Task.FromResult(context001.Repository.HtmlUrl),
                                out _)
                        ).In(propertyGroupContextSet)
                    )
                ).In(contextSet),
                Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                    out checkedProjectFileExists).In(contextSet)
            );
        }
    }
}
