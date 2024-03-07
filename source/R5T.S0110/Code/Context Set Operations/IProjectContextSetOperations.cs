using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0096.T000;
using R5T.T0221;

using R5T.S0110.Contexts;


namespace R5T.S0110
{
    [ContextSetOperationsMarker]
    public partial interface IProjectContextSetOperations : IContextSetOperationsMarker
    {
        public Func<TProjectContextSet, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile<TProjectContextSet>(
            ContextSetContextTypesSpecifier<Context000, Context001, ProjectContext001, Context005> projectContextSetContextTypesSpecifier,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
            )> projectContextPropertiesSet,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<Context000>,
            IHasContext<Context001>,
            IHasContext<ProjectContext001>,
            IHasContext<Context005>
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<ContextSet005, TProjectContextSet>(
                Instances.ContextSetIsomorphisms.To_ContextSet005<TProjectContextSet>(projectContextSetContextTypesSpecifier),
                out _,
                o.In_Context_OfContextSet<ContextSet005, Context005>(
                    out ContextSetSpecifier<ContextSet005> projectElementContextSetSpecifier,
                    out TypeSpecifier<Context005> context005Specifier,
                    o.Construct_Context_OfContextSet<ContextSet005, Context005>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                            out var projectElementSet).In_ContextSetAndContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Razor<Context005>().In_ContextSetAndContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<ContextSet006, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet006>(),
                        out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier,
                        out var contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<Context006, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        // Change the target framework from what is specified in the project options, to the library default.
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    //o.CaptureContext<Context001>(
                    //    out var repositoryContextCapture).In_ContextSetAndDifferentContext(
                    //        projectElementContextSetSpecifier,
                    //        context005Specifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<ContextSet006, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet006>(),
                        out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier_Package,
                        out contextSpecifiers,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(
                            projectElementSet,
                            projectElementContextProjectDescriptionSet),
                        out ContextPropertiesSet<ProjectOptionsContext,
                            IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<Context006,
                            IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended,
                        Instances.EnumerableOperator.From(
                            // Add the repository URL.
                            Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                                propertyGroupContextPropertiesSet_Package.PropertiesSet,
                                repositoryContext => Task.FromResult(repositoryContext.RepositoryUrl),
                                out _).In_ContextSet<ContextSet006, Context006, Context001>()
                            //Instances.ContextOperations.In_ContextSet<Context006, Context001>(
                            //    repositoryContextCapture,
                            //    Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                            //        propertyGroupContextPropertiesSet_Package.PropertiesSet,
                            //        repositoryContext => Task.FromResult(repositoryContext.RepositoryUrl),
                            //        out _)
                            //).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                        )
                    ).In_ContextSetAndContext(context005Specifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ContextSet007, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet007>(),
                        out ContextSetSpecifier<ContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_8_0_0).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    //// Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ContextSet007, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet007>(),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                        out checkedProjectFileExists).In_ContextSetAndContext(projectElementContextSetSpecifier)
                )
            );

            return output;
        }

        public Func<ContextSet004, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile(
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet
            )> projectContextPropertiesSet,
            out IChecked<IFileExists> checkedProjectFileExists)
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<ContextSet005, ContextSet004>(
                Instances.ContextSetIsomorphisms.From_ContextSet004<ContextSet005>(),
                out _,
                o.In_Context_OfContextSet<ContextSet005, Context005>(
                    out ContextSetSpecifier<ContextSet005> projectElementContextSetSpecifier,
                    out TypeSpecifier<Context005> context005Specifier,
                    o.Construct_Context_OfContextSet<ContextSet005, Context005>(
                        Instances.ProjectContextOperations.Set_ProjectFilePath<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectFilePathSet,
                            out var projectElementContextProjectFilePathSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
                        Instances.ProjectContextOperations.Set_ProjectDescription<Context005, ProjectContext001>(projectContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                            out var projectElementContextProjectDescriptionSet).In_ContextSetAndContext(projectElementContextSetSpecifier),
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<Context005>(
                            out var projectElementSet).In_ContextSetAndContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Razor<Context005>().In_ContextSetAndContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<ContextSet006, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet006>(),
                        out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier,
                        out var contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<Context006, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        // Change the target framework from what is specified in the project options, to the library default.
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default<Context006>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    //o.CaptureContext<Context001>(
                    //    out var repositoryContextCapture).In_ContextSetAndDifferentContext(
                    //        projectElementContextSetSpecifier,
                    //        context005Specifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<ContextSet006, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet006>(),
                        out ContextSetSpecifier<ContextSet006> propertyGroupContextSetSpecifier_Package,
                        out contextSpecifiers,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(
                            projectElementSet,
                            projectElementContextProjectDescriptionSet),
                        out ContextPropertiesSet<ProjectOptionsContext,
                            IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<Context006,
                            IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended,
                        Instances.EnumerableOperator.From(
                            // Add the repository URL.
                            Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                                propertyGroupContextPropertiesSet_Package.PropertiesSet,
                                repositoryContext => Task.FromResult(repositoryContext.RepositoryUrl),
                                out _).In_ContextSet<ContextSet006, Context006, Context001>()
                            //Instances.ContextOperations.In_ContextSet<Context006, Context001>(
                            //    repositoryContextCapture,
                            //    Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<Context006, Context001>(
                            //        propertyGroupContextPropertiesSet_Package.PropertiesSet,
                            //        repositoryContext => Task.FromResult(repositoryContext.RepositoryUrl),
                            //        out _)
                            //).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                        )
                    ).In_ContextSetAndContext(context005Specifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ContextSet007, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet007>(),
                        out ContextSetSpecifier<ContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_8_0_0).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    //// Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ContextSet007, ContextSet005, Context005>(
                        Instances.ContextSetIsomorphisms.From_ContextSet005<ContextSet007>(),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<Context005>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetAndContext(context005Specifier),
                    Instances.ProjectElementContextOperations.Serialize_ProjectElement_ToFile<Context005>((projectElementSet, projectElementContextProjectFilePathSet),
                        out checkedProjectFileExists).In_ContextSetAndContext(projectElementContextSetSpecifier)
                )
            );

            return output;
        }
    }
}
