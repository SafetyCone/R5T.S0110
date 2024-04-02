using System;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;

using R5T.S0110.Contexts;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectFileContextOperations : IContextOperationsMarker
    {
        /// <summary>
        /// Creates a Windows executable application project file.
        /// </summary>
        public Func<TProjectContextSet, Task> Create_WindowsFormsApplicationProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedLibraryProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_WinExe<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Net8_Windows<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_UseWindowsForms<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedLibraryProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        /// <summary>
        /// Creates a class library capable of referencing Windows Forms types.
        /// </summary>
        public Func<TProjectContextSet, Task> Create_WindowsFormsLibraryProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedLibraryProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Net8_Windows<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_UseWindowsForms<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedLibraryProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_BlazorComponentWebAssemblyClientProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_BlazorWebAssembly<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        // No output type.
                        // Fix to the NET8.0 target framework.
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Net8<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_NoDefaultLaunchSettingsFile<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_StaticWebAssetProjectMode<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    // Add 
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_8_0_1).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_WebAssemblyRazorComponentRazorClassLibraryProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Razor<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Net8<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the browser supported platform.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier_PropertiesSet,
                        out _,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet_SupportedPlatform,
                        out var checkedItemGroupElementAppended_SupportedPlatform,
                        Instances.ItemGroupElementContextOperations.Add_SupportedPlatform<Context007>(
                            itemGroupElementContextPropertiesSet_SupportedPlatform.PropertiesSet,
                            Instances.SupportedPlatforms.Browser.Value).In_ContextSet(itemGroupElementContextSetSpecifier_PropertiesSet)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_Web_8_0_1).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_Wwwroot,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_NonWebAssemblyRazorComponentRazorClassLibraryProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Razor<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_8_0_0).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_BlazorComponentsWebAssemblyServerProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Web<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the package reference item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement_PackageReferences<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended_PackageReferences,
                        Instances.ItemGroupElementContextOperations.Add_PackageReference<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            Instances.PackageReferences.Microsoft_AspNetCore_Components_WebAssembly_Server_8_0_1).In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out itemGroupElementContextSetSpecifier,
                        out itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_StaticHtmlApplicationProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_Web<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    // Add the wwwroot folder include item group.
                    Instances.ProjectElementContextOperations.Add_ItemGroupElement<ItemGroupElementContextSet007, ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, ItemGroupElementContextSet007>().For_Contexts(
                            projectElementContextSpecifier),
                        out ContextSetSpecifier<ItemGroupElementContextSet007> itemGroupElementContextSetSpecifier,
                        out var itemGroupElementContextSpecifier,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        out ContextPropertiesSet<Context007, IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
                        out var checkedItemGroupElementAppended,
                        Instances.ItemGroupElementContextOperations.Add_Folder<Context007>(
                            itemGroupElementContextPropertiesSet.PropertiesSet,
                            @"wwwroot\").In_ContextSet(itemGroupElementContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_ConsoleProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedConsoleProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Exe<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedConsoleProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectContextSet, Task> Create_LibraryProjectFile<TProjectContextSet>(
            IDirectionalIsomorphism<TProjectContextSet, ProjectElementContextSet007> projectContextSetIsomorphism,
            ProjectOptions projectOptions,
            ContextPropertiesSet<ProjectContext001, (
                IsSet<IHasProjectDescription> ProjectDescriptionSet,
                IsSet<IHasProjectFilePath> ProjectFilePathSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<RepositoryContext001, IsSet<IHasRepositoryUrl>> repositoryContextPropertiesRequired,
            out IChecked<IFileExists> checkedLibraryProjectFileExists)
            where TProjectContextSet :
            IHasContext<ProjectContext001>,
            IHasContext<RepositoryContext001>
        {
            var o = Instances.ContextOperations;

            var projectContextSpecifier = TypeSpecifier<ProjectContext001>.Instance;
            var repositoryContextSpecifier = TypeSpecifier<RepositoryContext001>.Instance;

            var output = o.In_ChildContextSet<ProjectElementContextSet007, TProjectContextSet>(
                projectContextSetIsomorphism,
                out ContextSetSpecifier<ProjectElementContextSet007> projectElementContextSetSpecifier,
                o.In_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                    out TypeSpecifier<ProjectElementContext001> projectElementContextSpecifier,
                    o.Construct_Context_OfContextSet<ProjectElementContextSet007, ProjectElementContext001>(
                        Instances.ProjectElementContextOperations.Set_ProjectElement_New<ProjectElementContext001>(
                            out var projectElementSet).In_ContextSetWithContext(projectElementContextSetSpecifier)
                    ),
                    Instances.ProjectElementContextOperations.Set_SDK_NET<ProjectElementContext001>().In_ContextSetWithContext(projectElementContextSetSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Main<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers,
                        projectOptions,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Main,
                        out var checkedPropertyGroupElementAppended_Main,
                        Instances.PropertyGroupElementContextOperations.Set_OutputType_Library<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier),
                        Instances.PropertyGroupElementContextOperations.Set_TargetFramework_Default_ForLibrary<PropertyGroupElementContext001>(propertyGroupContextPropertiesSet_Main.PropertiesSet).In_ContextSet(propertyGroupContextSetSpecifier)
                    ).In_ContextSetWithContext(projectElementContextSpecifier),
                    Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package_ForLibrary<PropertyGroupElementContextSet009, ProjectElementContextSet007, PropertyGroupElementContext001, ProjectElementContext001, ProjectContext001>(
                        Instances.ContextSetIsomorphisms.For_ContextSets<ProjectElementContextSet007, PropertyGroupElementContextSet009>().For_Contexts(
                            projectElementContextSpecifier,
                            projectContextSpecifier,
                            repositoryContextSpecifier),
                        out ContextSetSpecifier<PropertyGroupElementContextSet009> propertyGroupContextSetSpecifier_Package,
                        out (
                            TypeSpecifier<PropertyGroupElementContext001> PropertyGroupElementContextSpecifier,
                            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier) contextSpecifiers_Package,
                        projectOptions,
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                        out var projectOptionsContextPropertiesSet,
                        out ContextPropertiesSet<PropertyGroupElementContext001, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet_Package,
                        out var checkedPropertyGroupElementAppended_Pacakge,
                        // Add the repository URL.
                        Instances.PropertyGroupElementContextOperations.Set_RepositoryUrl<PropertyGroupElementContext001, RepositoryContext001>(
                            propertyGroupContextPropertiesSet_Package,
                            repositoryContextPropertiesRequired,
                            out _).In_ContextSet(propertyGroupContextSetSpecifier_Package)
                    ).In_ContextSetWithContext(projectElementContextSpecifier)
                ),
                // Write out the project element.
                Instances.ProjectContextOperations.Serialize_ProjectElement_ToFile<ProjectElementContext001, ProjectContext001>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectElementContext001>().For(projectElementSet),
                    Instances.ContextOperator.Get_ContextPropertiesSet<ProjectContext001>().For(projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                    out checkedLibraryProjectFileExists).In_ContextSet(projectElementContextSetSpecifier)
            );

            return output;
        }

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
