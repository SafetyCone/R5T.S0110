using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.S0110.Contexts;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectElementContextOperations : IContextOperationsMarker
    {
        public Func<TProjectElementContextSet, Task> Add_ItemGroupElement_PackageReferences<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TItemGroupElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TItemGroupElementContextSet> itemGroupElementContextSetSpecifier,
            out TypeSpecifier<Context007> itemGroupElementContextSpecifier,
            ContextPropertiesSet<TProjectElementContext,
                IsSet<IHasProjectElement>> projectElementContextPropertiesSet,
            out ContextPropertiesSet<Context007,
                IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
            out IChecked checkedItemGroupElementAppended,
            IEnumerable<Func<TItemGroupElementContextSet, Task>> operations)
            where TItemGroupElementContextSet : IWithContext<Context007>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
        {
            var output = this.Add_ItemGroupElement<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                projectElementContextIsomorphism,
                out itemGroupElementContextSetSpecifier,
                out itemGroupElementContextSpecifier,
                projectElementContextPropertiesSet,
                out itemGroupElementContextPropertiesSet,
                out checkedItemGroupElementAppended,
                Instances.ItemGroupElementContextOperations.Set_Label_PackageReferences<Context007>(itemGroupElementContextPropertiesSet.PropertiesSet).In_ContextSet(itemGroupElementContextSetSpecifier),
                Instances.ActionOperations.From(operations));

            return output;
        }

        public Func<TProjectElementContextSet, Task> Add_ItemGroupElement_PackageReferences<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TItemGroupElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TItemGroupElementContextSet> itemGroupElementContextSetSpecifier,
            out TypeSpecifier<Context007> itemGroupElementContextSpecifier,
            ContextPropertiesSet<TProjectElementContext,
                IsSet<IHasProjectElement>> projectElementContextPropertiesSet,
            out ContextPropertiesSet<Context007,
                IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
            out IChecked checkedItemGroupElementAppended,
            params Func<TItemGroupElementContextSet, Task>[] operations)
            where TItemGroupElementContextSet : IWithContext<Context007>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
            => this.Add_ItemGroupElement_PackageReferences<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                projectElementContextIsomorphism,
                out itemGroupElementContextSetSpecifier,
                out itemGroupElementContextSpecifier,
                projectElementContextPropertiesSet,
                out itemGroupElementContextPropertiesSet,
                out checkedItemGroupElementAppended,
                operations.AsEnumerable());

        public Func<TProjectElementContextSet, Task> Add_ItemGroupElement<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TItemGroupElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TItemGroupElementContextSet> itemGroupElementContextSetSpecifier,
            out TypeSpecifier<Context007> itemGroupElementContextSpecifier,
            ContextPropertiesSet<TProjectElementContext,
                IsSet<IHasProjectElement>> projectElementContextPropertiesSet,
            out ContextPropertiesSet<Context007,
                IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
            out IChecked checkedItemGroupElementAppended,
            IEnumerable<Func<TItemGroupElementContextSet, Task>> operations)
            where TItemGroupElementContextSet : IWithContext<Context007>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TItemGroupElementContextSet, TProjectElementContextSet>(
                projectElementContextIsomorphism,
                out itemGroupElementContextSetSpecifier,
                o.Set_Context_OfContextSet<TItemGroupElementContextSet, Context007>(
                    out var context006ContextSpecifier,
                    o.Construct_Context_OfContextSet<TItemGroupElementContextSet, Context007>(
                        Instances.ItemGroupElementContextOperations.Set_ItemGroupElement_New<Context007>(
                            out var itemGroupElementSet).In_ContextSetAndContext(itemGroupElementContextSetSpecifier)
                    )
                ),
                Instances.ActionOperations.From(operations),
                Instances.PropertyGroupElementContextOperations.Append_ItemGroupElement<Context007, TProjectElementContext>(
                    Instances.ContextOperator.Get_ContextPropertiesSet<Context007>().For(itemGroupElementSet),
                    projectElementContextPropertiesSet,
                    out checkedItemGroupElementAppended).In_ContextSet(itemGroupElementContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectElementContextSet, Task> Add_ItemGroupElement<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TItemGroupElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TItemGroupElementContextSet> itemGroupElementContextSetSpecifier,
            out TypeSpecifier<Context007> itemGroupElementContextSpecifier,
            ContextPropertiesSet<TProjectElementContext,
                IsSet<IHasProjectElement>> projectElementContextPropertiesSet,
            out ContextPropertiesSet<Context007,
                IsSet<IHasItemGroupElement>> itemGroupElementContextPropertiesSet,
            out IChecked checkedItemGroupElementAppended,
            params Func<TItemGroupElementContextSet, Task>[] operations)
            where TItemGroupElementContextSet : IWithContext<Context007>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
            => this.Add_ItemGroupElement<TItemGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                projectElementContextIsomorphism,
                out itemGroupElementContextSetSpecifier,
                out itemGroupElementContextSpecifier,
                projectElementContextPropertiesSet,
                out itemGroupElementContextPropertiesSet,
                out checkedItemGroupElementAppended,
                operations.AsEnumerable());

        public Func<TProjectElementContextSet, Task> Add_PropertyGroupElement_Package_ForLibrary<TPropertyElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TPropertyElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TPropertyElementContextSet> propertyGroupContextSetSpecifier,
            out (
            TypeSpecifier<Context006> PropertyElementContextSpecifier,
            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier
            ) contextSpecifiers,
            ProjectOptions projectOptions,
            ContextPropertiesSet<TProjectElementContext, (
                IsSet<IHasProjectElement> ProjectElementSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext,
                IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out ContextPropertiesSet<Context006,
                IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<TPropertyElementContextSet, Task>> operations)
            where TPropertyElementContextSet : IWithContext<Context006>, IWithContext<ProjectOptionsContext>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
        {
            var output = this.Add_PropertyGroupElement_Package<TPropertyElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                projectElementContextIsomorphism,
                out propertyGroupContextSetSpecifier,
                out contextSpecifiers,
                projectOptions,
                projectElementContextPropertiesSet,
                out projectOptionsContextPropertiesSet,
                out propertyGroupContextPropertiesSet,
                out checkedPropertyGroupElementAppended,
                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasPackageLicenseExpression, IHasPackageRequireLicenseAcceptance>(projectOptionsContextPropertiesSet.PropertiesSet,
                    out (
                    IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
                    IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptanceSet
                    ) projectOptionContextPropertiesSet_Implied).In_ContextSet(propertyGroupContextSetSpecifier),
                // For libraries, set these extra properties.
                Instances.PropertyGroupElementContextOperations.Set_PackageLicenseExpression<Context006, ProjectOptionsContext>(
                    Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupContextPropertiesSet.PropertiesSet),
                    Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageLicenseExpression>(projectOptionContextPropertiesSet_Implied.PackageLicenseExpressionSet),
                    out var packageLicenseExpressionSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_PackageRequireLicenseAcceptance<Context006, ProjectOptionsContext>(
                    Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyGroupContextPropertiesSet.PropertiesSet),
                    Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageRequireLicenseAcceptance>(projectOptionContextPropertiesSet_Implied.PackageRequireLicenseAcceptanceSet),
                    out var packageRequireLicenseAcceptance).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.ActionOperations.From(operations)
            );

            return output;
        }

        public Func<Context005, Task> Add_PropertyGroupElement_Package_ForLibrary(
            ProjectOptions projectOptions,
            IsSet<IHasProjectDescription> projectDescriptionSet_ProjectElementContextPropertiesSet,
            out ContextPropertiesSet<Context006, (
                IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                IsSet<IHasCompany> CompanySet,
                IsSet<IHasCopyright> CopyrightSet,
                IsSet<IHasProjectDescription> DescriptionSet,
                IsSet<IHasNuGetAuthor> NugetAuthorSet,
                IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
                IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptanceSet,
                IsSet<IHasVersion> VersionSet
                )> propertyElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext, IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<Context006, Context005, ProjectOptionsContext, Task>> propertyGroupProjectOptionsOperations = default)
        {
            var o = Instances.ContextOperations;

            var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

            var output = Instances.ProjectElementContextOperations.Add_PropertyGroupElement_Package(
                projectOptions,
                projectDescriptionSet_ProjectElementContextPropertiesSet,
                out ContextPropertiesSet<Context006, (
                    IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                    IsSet<IHasCompany> CompanySet,
                    IsSet<IHasCopyright> CopyrightSet,
                    IsSet<IHasProjectDescription> DescriptionSet,
                    IsSet<IHasNuGetAuthor> NugetAuthorSet,
                    IsSet<IHasVersion> VersionSet
                    )> propertyElementContextPropertiesSet_Package,
                out projectOptionsContextPropertiesSet,
                out checkedPropertyGroupElementAppended,
                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasPackageLicenseExpression, IHasPackageRequireLicenseAcceptance>(projectOptionsContextPropertiesSet.PropertiesSet,
                    out (
                    IsSet<IHasPackageLicenseExpression> PackageLicenseExpressionSet,
                    IsSet<IHasPackageRequireLicenseAcceptance> PackageRequireLicenseAcceptanceSet
                    ) projectOptionContextPropertiesSet_Implied).In(propertyGroupOptionsContextSet),
                // For libraries, set these extra properties.
                Instances.PropertyGroupElementContextOperations.Set_PackageLicenseExpression<Context006, ProjectOptionsContext>(
                    Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet),
                    Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageLicenseExpression>(projectOptionContextPropertiesSet_Implied.PackageLicenseExpressionSet),
                    out var packageLicenseExpressionSet).In(propertyGroupOptionsContextSet),
                Instances.PropertyGroupElementContextOperations.Set_PackageRequireLicenseAcceptance<Context006, ProjectOptionsContext>(
                    Instances.IsSetOperator.ContextPropertiesSet<Context006, IHasPropertyGroupElement>(propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet),
                    Instances.IsSetOperator.ContextPropertiesSet<ProjectOptionsContext, IHasPackageRequireLicenseAcceptance>(projectOptionContextPropertiesSet_Implied.PackageRequireLicenseAcceptanceSet),
                    out var packageRequireLicenseAcceptance).In(propertyGroupOptionsContextSet),
                o.From(propertyGroupProjectOptionsOperations)
            );

            propertyElementContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<Context006>().For(
                propertyElementContextPropertiesSet_Package.PropertiesSet.PropertyGroupElementSet,
                propertyElementContextPropertiesSet_Package.PropertiesSet.CompanySet,
                propertyElementContextPropertiesSet_Package.PropertiesSet.CopyrightSet,
                propertyElementContextPropertiesSet_Package.PropertiesSet.DescriptionSet,
                propertyElementContextPropertiesSet_Package.PropertiesSet.NugetAuthorSet,
                packageLicenseExpressionSet,
                packageRequireLicenseAcceptance,
                propertyElementContextPropertiesSet_Package.PropertiesSet.VersionSet);

            return output;
        }

        public Func<TProjectElementContextSet, Task> Add_PropertyGroupElement_Package<TPropertyElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TPropertyElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TPropertyElementContextSet> propertyGroupContextSetSpecifier,
            out (
            TypeSpecifier<Context006> PropertyGroupElementContextSpecifier,
            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier
            ) contextSpecifiers,
            ProjectOptions projectOptions,
            ContextPropertiesSet<TProjectElementContext, (
                IsSet<IHasProjectElement> ProjectElementSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext,
                IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out ContextPropertiesSet<Context006,
                IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<TPropertyElementContextSet, Task>> operations)
            where TPropertyElementContextSet : IWithContext<Context006>, IWithContext<ProjectOptionsContext>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TPropertyElementContextSet, TProjectElementContextSet>(
                projectElementContextIsomorphism,
                out propertyGroupContextSetSpecifier,
                o.Set_Context_OfContextSet<TPropertyElementContextSet, Context006>(
                    out var context006ContextSpecifier,
                    o.Construct_Context_OfContextSet<TPropertyElementContextSet, Context006>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out var propertyGroupElementSet).In_ContextSetAndContext(propertyGroupContextSetSpecifier)
                    )
                ),
                o.Set_Context_OfContextSet<TPropertyElementContextSet, ProjectOptionsContext>(
                    out TypeSpecifier<ProjectOptionsContext> projectOptionsContextSpecifier,
                    o.Construct_Context_OfContextSet<TPropertyElementContextSet, ProjectOptionsContext>(
                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                            out var projectOptionsSet).In_ContextSetAndContext(propertyGroupContextSetSpecifier),
                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
                            out (
                            IsSet<IHasCompany> CompanySet,
                            IsSet<IHasCopyright> CopyrightSet,
                            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                            IsSet<IHasVersion> VersionSet
                            ) impliedProjectOptionsSet_Package).In_ContextSetAndContext(propertyGroupContextSetSpecifier)
                    )
                ),
                Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_Description<Context006, TProjectElementContext>(propertyGroupElementSet, projectElementContextPropertiesSet.PropertiesSet.ProjectDescriptionSet,
                    out var projectDescriptionSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.ActionOperations.From(operations),
                Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, TProjectElementContext>(propertyGroupElementSet,
                    out checkedPropertyGroupElementAppended).In_ContextSet(propertyGroupContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectElementContextSet, Task> Add_PropertyGroupElement_Package<TPropertyElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TPropertyElementContextSet> projectElementContextIsomorphism,
            out ContextSetSpecifier<TPropertyElementContextSet> propertyGroupContextSetSpecifier,
            out (
            TypeSpecifier<Context006> PropertyElementContextSpecifier,
            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier
            ) contextSpecifiers,
            ProjectOptions projectOptions,
            ContextPropertiesSet<TProjectElementContext, (
                IsSet<IHasProjectElement> ProjectElementSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext,
                IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out ContextPropertiesSet<Context006,
                IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            params Func<TPropertyElementContextSet, Task>[] operations)
            where TPropertyElementContextSet : IWithContext<Context006>, IWithContext<ProjectOptionsContext>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement, IHasProjectDescription
            => this.Add_PropertyGroupElement_Package<TPropertyElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                projectElementContextIsomorphism,
                out propertyGroupContextSetSpecifier,
                out contextSpecifiers,
                projectOptions,
                projectElementContextPropertiesSet,
                out projectOptionsContextPropertiesSet,
                out propertyGroupContextPropertiesSet,
                out checkedPropertyGroupElementAppended,
                operations.AsEnumerable());

        public Func<Context005, Task> Add_PropertyGroupElement_Package(
            ProjectOptions projectOptions,
            IsSet<IHasProjectDescription> projectDescriptionSet_ProjectElementContextPropertiesSet,
            out ContextPropertiesSet<Context006, (
                IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                IsSet<IHasCompany> CompanySet,
                IsSet<IHasCopyright> CopyrightSet,
                IsSet<IHasProjectDescription> DescriptionSet,
                IsSet<IHasNuGetAuthor> NugetAuthorSet,
                IsSet<IHasVersion> VersionSet
                )> propertyElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext, IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<Context006, Context005, ProjectOptionsContext, Task>> propertyGroupProjectOptionsOperations = default)
        {
            var o = Instances.ContextOperations;

            var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005>();
            var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

            var output = o.In_ContextSet_A_BA<Context006, Context005>(
                o.Construct_Context_B_BA<Context006, Context005>(
                    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                        out var propertyGroupElementSet).In(propertyGroupContextSet)
                ),
                o.In_ContextSet_AB_ABC<Context006, Context005, ProjectOptionsContext>(
                    o.Construct_Context_C_ABC<Context006, Context005, ProjectOptionsContext>(
                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                            out var projectOptionsSet).In(propertyGroupOptionsContextSet),
                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasCompany, IHasCopyright, IHasNuGetAuthor, IHasVersion>(projectOptionsSet,
                            out (
                            IsSet<IHasCompany> CompanySet,
                            IsSet<IHasCopyright> CopyrightSet,
                            IsSet<IHasNuGetAuthor> NuGetAuthorSet,
                            IsSet<IHasVersion> VersionSet
                            ) impliedProjectOptionsSet_Package).In(propertyGroupOptionsContextSet)
                    ),
                    Instances.PropertyGroupElementContextOperations.Set_Label_Package<Context006>(propertyGroupElementSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_Version<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.VersionSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_Author<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.NuGetAuthorSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_Company<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CompanySet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_Copyright<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Package.CopyrightSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_Description<Context006, Context005>(propertyGroupElementSet, projectDescriptionSet_ProjectElementContextPropertiesSet,
                        out var projectDescriptionSet).In(propertyGroupOptionsContextSet),
                    o.From(propertyGroupProjectOptionsOperations),
                    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                        out checkedPropertyGroupElementAppended).In(propertyGroupOptionsContextSet)
                )
            );

            propertyElementContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<Context006>().For(
                propertyGroupElementSet,
                impliedProjectOptionsSet_Package.CompanySet,
                impliedProjectOptionsSet_Package.CopyrightSet,
                projectDescriptionSet,
                impliedProjectOptionsSet_Package.NuGetAuthorSet,
                impliedProjectOptionsSet_Package.VersionSet);

            projectOptionsContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<ProjectOptionsContext>().For(
                projectOptionsSet);

            return output;
        }

        public Func<Context005, Task> Add_PropertyGroupElement_Package(
            ProjectOptions projectOptions,
            IsSet<IHasProjectDescription> projectDescriptionSet_ProjectElementContextPropertiesSet,
            out ContextPropertiesSet<Context006, (
                IsSet<IHasPropertyGroupElement> PropertyGroupElementSet,
                IsSet<IHasCompany> CompanySet,
                IsSet<IHasCopyright> CopyrightSet,
                IsSet<IHasProjectDescription> DescriptionSet,
                IsSet<IHasNuGetAuthor> NugetAuthorSet,
                IsSet<IHasVersion> VersionSet
                )> propertyElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext, IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            params Func<Context006, Context005, ProjectOptionsContext, Task>[] propertyGroupProjectOptionsOperations)
        {
            return this.Add_PropertyGroupElement_Package(
                projectOptions,
                projectDescriptionSet_ProjectElementContextPropertiesSet,
                out propertyElementContextPropertiesSet,
                out projectOptionsContextPropertiesSet,
                out checkedPropertyGroupElementAppended,
                propertyGroupProjectOptionsOperations.AsEnumerable());
        }

        public Func<TProjectElementContextSet, Task> Add_PropertyGroupElement_Main<TPropertyGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TPropertyGroupElementContextSet> propertyGroupContextSetIsomorphism,
            out ContextSetSpecifier<TPropertyGroupElementContextSet> propertyGroupContextSetSpecifier,
            out (
            TypeSpecifier<Context006> Context006Specifier,
            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier
            ) contextSpecifiers,
            ProjectOptions projectOptions,
            out ContextPropertiesSet<Context006, IsSet<IHasPropertyGroupElement>> propertyElementContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<TPropertyGroupElementContextSet, Task>> operations)
            where TPropertyGroupElementContextSet : IWithContext<Context006>, IWithContext<ProjectOptionsContext>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TPropertyGroupElementContextSet, TProjectElementContextSet>(
                propertyGroupContextSetIsomorphism,
                out propertyGroupContextSetSpecifier,
                o.Set_Context_OfContextSet<TPropertyGroupElementContextSet, Context006>(
                    out var context006ContextSpecifier,
                    o.Construct_Context_OfContextSet<TPropertyGroupElementContextSet, Context006>(
                        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                            out var propertyGroupElementSet).In_ContextSetAndContext(propertyGroupContextSetSpecifier)
                    )
                ),
                o.Set_Context_OfContextSet<TPropertyGroupElementContextSet, ProjectOptionsContext>(
                    out var projectOptionsContextSpecifier,
                    o.Construct_Context_OfContextSet<TPropertyGroupElementContextSet, ProjectOptionsContext>(
                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                            out var projectOptionsSet).In_ContextSetAndContext(propertyGroupContextSetSpecifier),
                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                            out (
                            IsSet<IHasTargetFramework> TargetFrameworkSet,
                            IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                            ) impliedProjectOptionsSet_Main).In_ContextSetAndContext(propertyGroupContextSetSpecifier)
                    )
                ),
                Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet,
                    out var targetFrameworkSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet,
                    out var ignoreWarningNumbersListSet).In_ContextSet(propertyGroupContextSetSpecifier),
                Instances.ActionOperations.From(operations),
                Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, TProjectElementContext>(propertyGroupElementSet,
                    out checkedPropertyGroupElementAppended).In_ContextSet(propertyGroupContextSetSpecifier)
            );

            return output;
        }

        public Func<TProjectElementContextSet, Task> Add_PropertyGroupElement_Main<TPropertyGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
            IDirectionalIsomorphism<TProjectElementContextSet, TPropertyGroupElementContextSet> propertyGroupContextSetIsomorphism,
            out ContextSetSpecifier<TPropertyGroupElementContextSet> propertyGroupContextSetSpecifier,
            out (
            TypeSpecifier<Context006> Context006Specifier,
            TypeSpecifier<ProjectOptionsContext> ProjectOptionsContextSpecifier
            ) contextSpecifiers,
            ProjectOptions projectOptions,
            out ContextPropertiesSet<Context006, IsSet<IHasPropertyGroupElement>> propertyElementContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            params Func<TPropertyGroupElementContextSet, Task>[] operations)
            where TPropertyGroupElementContextSet : IWithContext<Context006>, IWithContext<ProjectOptionsContext>, IHasContext<TProjectElementContext>, new()
            where TProjectElementContextSet : IHasContext<TProjectElementContext>
            where TProjectElementContext : IHasProjectElement
            => this.Add_PropertyGroupElement_Main<TPropertyGroupElementContextSet, TProjectElementContextSet, TProjectElementContext>(
                propertyGroupContextSetIsomorphism,
                out propertyGroupContextSetSpecifier,
                out contextSpecifiers,
                projectOptions,
                out propertyElementContextPropertiesSet,
                out checkedPropertyGroupElementAppended,
                operations.AsEnumerable());

        public Func<Context005, Task> Add_PropertyGroupElement_Main(
            ProjectOptions projectOptions,
            out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext, IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended,
            IEnumerable<Func<Context006, Context005, ProjectOptionsContext, Task>> propertyGroupProjectOptionsOperations = default)
        {
            var o = Instances.ContextOperations;

            var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005>();
            var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005, ProjectOptionsContext>();

            var output = o.In_ContextSet_A_BA<Context006, Context005>(
                o.Construct_Context_B_BA<Context006, Context005>(
                    Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
                        out var propertyGroupElementSet).In(propertyGroupContextSet)
                ),
                o.In_ContextSet_AB_ABC<Context006, Context005, ProjectOptionsContext>(
                    o.Construct_Context_C_ABC<Context006, Context005, ProjectOptionsContext>(
                        Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
                            out var projectOptionsSet).In(propertyGroupOptionsContextSet),
                        Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
                            out (
                            IsSet<IHasTargetFramework> TargetFrameworkSet,
                            IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
                            ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
                    ),
                    Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_TargetFramework<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.TargetFrameworkSet,
                        out var targetFrameworkSet).In(propertyGroupOptionsContextSet),
                    Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet,
                        out var ignoreWarningNumbersListSet).In(propertyGroupOptionsContextSet),
                    o.From(propertyGroupProjectOptionsOperations),
                    Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
                        out checkedPropertyGroupElementAppended).In(propertyGroupOptionsContextSet)
                )
            );

            propertyElementContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<Context006>().For(
                propertyGroupElementSet,
                targetFrameworkSet,
                ignoreWarningNumbersListSet);

            projectOptionsContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<ProjectOptionsContext>().For(
                projectOptionsSet);

            return output;
        }

        public Func<Context005, Task> Add_PropertyGroupElement_Main(
            ProjectOptions projectOptions,
            out ContextPropertiesSet<Context006, (IsSet<IHasPropertyGroupElement> PropertyGroupElementSet, IsSet<IHasTargetFramework>, IsSet<IHasIgnoreWarningNumbersList>)> propertyElementContextPropertiesSet,
            out ContextPropertiesSet<ProjectOptionsContext, IsSet<IHasProjectOptions>> projectOptionsContextPropertiesSet,
            out IChecked checkedPropertyGroupElementAppended_Main,
            params Func<Context006, Context005, ProjectOptionsContext, Task>[] propertyGroupProjectOptionsOperations)
        {
            return this.Add_PropertyGroupElement_Main(
                projectOptions,
                out propertyElementContextPropertiesSet,
                out projectOptionsContextPropertiesSet,
                out checkedPropertyGroupElementAppended_Main,
                propertyGroupProjectOptionsOperations.AsEnumerable());
        }

        //public Func<Context005, Task> Add_PropertyGroupElement_Main(
        //    ProjectOptions projectOptions,
        //    Func<IsSet<IHasPropertyGroupElement>, Func<Context006, Task>> setOutputType,
        //    Func<IsSet<IHasPropertyGroupElement>, Func<Context006, Task>> setTargetFramework,
        //    out (
        //    // TODO: IHasOutputType is set.
        //    IsSet<IHasTargetFramework> TargetFrameworkSet,
        //    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
        //    ) mainPropertyGroupPropertiesSet,
        //    out IChecked checkedPropertyGroupElementAppended_Main)
        //{
        //    var o = Instances.ContextOperations;

        //    var propertyGroupContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, Context005>();
        //    var propertyGroupOptionsContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context006, ProjectOptionsContext>();

        //    var output = Instances.ProjectElementContextOperations.In_PropertyGroupElementContext<Context006, Context005>(
        //        Instances.PropertyGroupElementContextOperations.Set_PropertyGroupElement_New<Context006>(
        //            out var propertyGroupElementSet).In(propertyGroupContextSet),
        //        Instances.PropertyGroupElementContextOperations.Set_Label_Main<Context006>(propertyGroupElementSet).In(propertyGroupContextSet),
        //        setOutputType(propertyGroupElementSet).In(propertyGroupContextSet),
        //        setTargetFramework(propertyGroupElementSet).In(propertyGroupContextSet),
        //        o.In_ContextSet_A_AB<Context006, ProjectOptionsContext>(
        //            o.Construct_Context_B_AB<Context006, ProjectOptionsContext>(
        //                Instances.ProjectOptionsContextOperations.Set_ProjectOptions<ProjectOptionsContext>(projectOptions,
        //                    out var projectOptionsSet).In(propertyGroupOptionsContextSet),
        //                Instances.IsSetContextOperations.Implies<ProjectOptionsContext, IHasProjectOptions, IHasTargetFramework, IHasIgnoreWarningNumbersList>(projectOptionsSet,
        //                    out (
        //                    IsSet<IHasTargetFramework> TargetFrameworkSet,
        //                    IsSet<IHasIgnoreWarningNumbersList> IgnoreWarningNumbersListSet
        //                    ) impliedProjectOptionsSet_Main).In(propertyGroupOptionsContextSet)
        //            ),
        //            Instances.PropertyGroupElementContextOperations.Set_NoWarn<Context006, ProjectOptionsContext>(propertyGroupElementSet, impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet)
        //        ).In(propertyGroupContextSet),
        //        Instances.PropertyGroupElementContextOperations.Append_PropertyGroupElement<Context006, Context005>(propertyGroupElementSet,
        //            out checkedPropertyGroupElementAppended_Main)
        //    );

        //    mainPropertyGroupPropertiesSet = (
        //        //,
        //        impliedProjectOptionsSet_Main.TargetFrameworkSet,
        //        impliedProjectOptionsSet_Main.IgnoreWarningNumbersListSet);

        //    return output;
        //}

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TPropertyGroupElementContext, TProjectElementContext>(
            Func<TProjectElementContext, Task<TPropertyGroupElementContext>> propertyGroupElementContextConstructor,
            IEnumerable<Func<TPropertyGroupElementContext, TProjectElementContext, Task>> operations)
            where TProjectElementContext : IHasProjectElement
            where TPropertyGroupElementContext : IHasPropertyGroupElement
        {
            return async context =>
            {
                var propertyGroupElementContext = await propertyGroupElementContextConstructor(context);

                await Instances.ContextOperator.In_ContextSet(
                    propertyGroupElementContext,
                    context,
                    operations);
            };
        }

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TPropertyGroupElementContext, TProjectElementContext>(
            Func<TProjectElementContext, Task<TPropertyGroupElementContext>> propertyGroupElementContextConstructor,
            params Func<TPropertyGroupElementContext, TProjectElementContext, Task>[] operations)
            where TProjectElementContext : IHasProjectElement
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            => this.In_PropertyGroupElementContext(
                propertyGroupElementContextConstructor,
                operations.AsEnumerable());

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TPropertyGroupElementContext, TProjectElementContext>(
            IEnumerable<Func<TPropertyGroupElementContext, TProjectElementContext, Task>> operations)
            where TProjectElementContext : IHasProjectElement
            where TPropertyGroupElementContext : IHasPropertyGroupElement, new()
        {
            return async context =>
            {
                await Instances.ContextOperator.In_ContextSet(
                    new TPropertyGroupElementContext(),
                    context,
                    operations);
            };
        }

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TPropertyGroupElementContext, TProjectElementContext>(
            params Func<TPropertyGroupElementContext, TProjectElementContext, Task>[] operations)
            where TProjectElementContext : IHasProjectElement
            where TPropertyGroupElementContext : IHasPropertyGroupElement, new()
            => this.In_PropertyGroupElementContext(
                operations.AsEnumerable());

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TProjectElementContext>(
            IEnumerable<Func<Context006, TProjectElementContext, Task>> operations)
            where TProjectElementContext : IHasProjectElement
            => this.In_PropertyGroupElementContext<Context006, TProjectElementContext>(
                operations);

        public Func<TProjectElementContext, Task> In_PropertyGroupElementContext<TProjectElementContext>(
            params Func<Context006, TProjectElementContext, Task>[] operations)
            where TProjectElementContext : IHasProjectElement
            => this.In_PropertyGroupElementContext(
                operations.AsEnumerable());


        public Func<TContext, Task> Set_ProjectElement_New<TContext>(
            out IsSet<IHasProjectElement> projectElementSet)
            where TContext : IWithProjectElement
        {
            return context =>
            {
                context.ProjectElement = Instances.ProjectXElementOperator.New_ProjectXElement();

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Serialize_ProjectElement_ToFile<TContext>(
            (IsSet<IHasProjectElement>, IsSet<IHasFilePath>) propertiesRequired,
            out IChecked<IFileExists> projectFileExists)
            where TContext : IHasProjectElement, IHasFilePath
        {
            projectFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.ProjectXElementOperator.To_File_Separated(
                    context.FilePath,
                    context.ProjectElement);
            };
        }

        public Func<TContext, Task> Serialize_ProjectElement_ToFile<TContext>(
            (IsSet<IHasProjectElement>, IsSet<IHasProjectFilePath>) propertiesRequired,
            out IChecked<IFileExists> projectFileExists)
            where TContext : IHasProjectElement, IHasProjectFilePath
        {
            projectFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.ProjectXElementOperator.To_File_Separated(
                    context.ProjectFilePath,
                    context.ProjectElement);
            };
        }

        /// <inheritdoc cref="L0032.Z001.IProjectSdkNames.NET"/>
        public Func<TContext, Task> Set_SDK_Default<TContext>()
            where TContext : IHasProjectElement
        {
            return context =>
            {
                Instances.ProjectXElementOperator.Set_Sdk(
                    context.ProjectElement,
                    Instances.ProjectSdkNames.NET);

                return Task.CompletedTask;
            };
        }

        /// <inheritdoc cref="L0032.Z001.IProjectSdkNames.NET"/>
        public Func<TContext, Task> Set_SDK_NET<TContext>()
            where TContext : IHasProjectElement
        {
            return context =>
            {
                Instances.ProjectXElementOperator.Set_Sdk_NET(
                    context.ProjectElement);

                return Task.CompletedTask;
            };
        }

        /// <inheritdoc cref="L0032.Z001.IProjectSdkNames.Razor"/>
        public Func<TContext, Task> Set_SDK_Razor<TContext>()
            where TContext : IHasProjectElement
        {
            return context =>
            {
                Instances.ProjectXElementOperator.Set_Sdk(
                    context.ProjectElement,
                    Instances.ProjectSdkNames.Razor);

                return Task.CompletedTask;
            };
        }

        /// <inheritdoc cref="L0032.Z001.IProjectSdkNames.Web"/>
        public Func<TContext, Task> Set_SDK_Web<TContext>()
            where TContext : IHasProjectElement
        {
            return context =>
            {
                Instances.ProjectXElementOperator.Set_Sdk(
                    context.ProjectElement,
                    Instances.ProjectSdkNames.Web);

                return Task.CompletedTask;
            };
        }
    }
}
