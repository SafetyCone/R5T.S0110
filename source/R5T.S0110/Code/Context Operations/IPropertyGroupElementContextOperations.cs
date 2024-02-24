using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IPropertyGroupElementContextOperations : IContextOperationsMarker
    {
        public Func<TPropertyGroupElementContext, TProjectElementContext, Task> Append_PropertyGroupElement<TPropertyGroupElementContext, TProjectElementContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElementRequired,
            out IChecked checkedPropertyGroupElementAppended)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TProjectElementContext : IHasProjectElement
        {
            checkedPropertyGroupElementAppended = Checked.Check();

            return (propertyGroupElementContext, projectElementContext) =>
            {
                Instances.ProjectXElementsOperator.Append_PropertyGroupXElement(
                    projectElementContext.ProjectElement,
                    propertyGroupElementContext.PropertyGroupElement);

                return Task.CompletedTask;
            };
        }

        //public Func<TProjectElementContext, Task<TPropertyGroupElementContext>> Construct_PropertyGroupElementContext<TProjectElementContext, TPropertyGroupElementContext>(
        //    out IsSet<IHasProjectElement> projectElementSet)
        //    where TProjectElementContext : IHasProjectElement
        //    where TPropertyGroupElementContext : IHasPropertyGroupElement
        //{
        //    return projectElementContext =>
        //    {

        //    };
        //}

        public Func<TPropertyGroupElementContext, TOptionsContext, Task> Set_Author<TPropertyGroupElementContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupElementContextPropertiesRequired,
            IsSet<IHasNuGetAuthor> nuGetAuthor_OptionsContextPropertiesRequired)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TOptionsContext : IHasNuGetAuthor
        {
            return (propertyGroupElementContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_Authors(
                    propertyGroupElementContext.PropertyGroupElement,
                    optionsContext.NuGetAuthor);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupElementContext, TOptionsContext, Task> Set_Company<TPropertyGroupElementContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupElementContextPropertiesRequired,
            IsSet<IHasCompany> company_OptionsContextPropertiesRequired)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TOptionsContext : IHasCompany
        {
            return (propertyGroupElementContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_Company(
                    propertyGroupElementContext.PropertyGroupElement,
                    optionsContext.Company);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupElementContext, TOptionsContext, Task> Set_Copyright<TPropertyGroupElementContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupElementContextPropertiesRequired,
            IsSet<IHasCopyright> copyright_OptionsContextPropertiesRequired)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TOptionsContext : IHasCopyright
        {
            return (propertyGroupElementContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_Copyright(
                    propertyGroupElementContext.PropertyGroupElement,
                    optionsContext.Copyright);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupElementContext, TOptionsContext, Task> Set_Description<TPropertyGroupElementContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupElementContextPropertiesRequired,
            IsSet<IHasProjectDescription> projectDescription_OptionsContextPropertiesRequired)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TOptionsContext : IHasProjectDescription
        {
            return (propertyGroupElementContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_Company(
                    propertyGroupElementContext.PropertyGroupElement,
                    optionsContext.ProjectDescription);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_Label_Main<TContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElementSet)
            where TContext : IHasPropertyGroupElement
        {
            return context =>
            {
                Instances.PropertyGroupXElementOperator.Set_Label_Main(
                    context.PropertyGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_Label_Package<TContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElementSet)
            where TContext : IHasPropertyGroupElement
        {
            return context =>
            {
                Instances.PropertyGroupXElementOperator.Set_Label_Package(
                    context.PropertyGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupElementContext, TOptionsContext, Task> Set_NoWarn<TPropertyGroupElementContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement>  propertyGroupElement_PropertyGroupContextPropertiesRequired,
            IsSet<IHasIgnoreWarningNumbersList> ignoreWarningNumbersList_OptionsContextPropertiesRequired)
            where TPropertyGroupElementContext : IHasPropertyGroupElement
            where TOptionsContext : IHasIgnoreWarningNumbersList
        {
            return (propertyGroupElementContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_NoWarn(
                    propertyGroupElementContext.PropertyGroupElement,
                    optionsContext.IgnoreWarningNumbersList);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_OutputType_Exe<TContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElementSet)
            where TContext : IHasPropertyGroupElement
        {
            return context =>
            {
                Instances.PropertyGroupXElementOperator.Set_OutputType_Exe(
                    context.PropertyGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_OutputType_Library<TContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElementSet)
            where TContext : IHasPropertyGroupElement
        {
            return context =>
            {
                Instances.PropertyGroupXElementOperator.Set_OutputType_Library(
                    context.PropertyGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupContext, TOptionsContext, Task> Set_PackageLicenseExpression<TPropertyGroupContext, TOptionsContext>(
            ContextPropertiesSet<TPropertyGroupContext, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesRequired,
            ContextPropertiesSet<TOptionsContext, IsSet<IHasPackageLicenseExpression>> optionsContextPropertiesRequired)
            where TPropertyGroupContext : IHasPropertyGroupElement
            where TOptionsContext : IHasPackageLicenseExpression
        {
            return (propertyGroupContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_PackageLicenseExpression(
                    propertyGroupContext.PropertyGroupElement,
                    optionsContext.PackageLicenseExpression);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupContext, TOptionsContext, Task> Set_PackageRequireLicenseAcceptance<TPropertyGroupContext, TOptionsContext>(
            ContextPropertiesSet<TPropertyGroupContext, IsSet<IHasPropertyGroupElement>> propertyGroupContextPropertiesRequired,
            ContextPropertiesSet<TOptionsContext, IsSet<IHasPackageRequireLicenseAcceptance>> optionsContextPropertiesRequired)
            where TPropertyGroupContext : IHasPropertyGroupElement
            where TOptionsContext : IHasPackageRequireLicenseAcceptance
        {
            return (propertyGroupContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_PackageRequireLicenseAcceptance(
                    propertyGroupContext.PropertyGroupElement,
                    optionsContext.PackageRequireLicenseAcceptance);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_PropertyGroupElement_New<TContext>(
            out IsSet<IHasPropertyGroupElement> propertyGroupElementSet)
            where TContext : IWithPropertyGroupElement
        {
            return context =>
            {
                context.PropertyGroupElement = Instances.ProjectXElementsOperator.New_PropertyGroupXElement();

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupContext, TOptionsContext, Task> Set_TargetFramework<TPropertyGroupContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupContextPropertiesRequired,
            IsSet<IHasTargetFramework> targetFramework_OptionsContextPropertiesRequired)
            where TPropertyGroupContext : IHasPropertyGroupElement
            where TOptionsContext : IHasTargetFramework
        {
            return (propertyGroupContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_TargetFramework(
                    propertyGroupContext.PropertyGroupElement,
                    optionsContext.TargetFramework);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupContext, Task> Set_TargetFramework_NetStandard2_1<TPropertyGroupContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupContextPropertiesRequired)
            where TPropertyGroupContext : IHasPropertyGroupElement
        {
            return propertyGroupContext =>
            {
                Instances.PropertyGroupXElementOperator.Set_TargetFramework(
                    propertyGroupContext.PropertyGroupElement,
                    Instances.TargetFrameworkMonikers.Net_Standard2_1);

                return Task.CompletedTask;
            };
        }

        public Func<TPropertyGroupContext, TOptionsContext, Task> Set_Version<TPropertyGroupContext, TOptionsContext>(
            IsSet<IHasPropertyGroupElement> propertyGroupElement_PropertyGroupContextPropertiesRequired,
            IsSet<IHasVersion> version_OptionsContextPropertiesRequired)
            where TPropertyGroupContext : IHasPropertyGroupElement
            where TOptionsContext : IHasVersion
        {
            return (propertyGroupContext, optionsContext) =>
            {
                Instances.PropertyGroupXElementOperator.Set_Version(
                    propertyGroupContext.PropertyGroupElement,
                    optionsContext.Version);

                return Task.CompletedTask;
            };
        }
    }
}
