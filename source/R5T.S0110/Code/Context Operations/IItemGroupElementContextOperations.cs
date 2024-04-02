using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0096.T000;
using R5T.T0206;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IItemGroupElementContextOperations : IContextOperationsMarker
    {
        public Func<TItemGroupElementContext, Task> Add_SupportedPlatform<TItemGroupElementContext>(
            IsSet<IHasItemGroupElement> itemGroupElementSet,
            string includeValue)
            where TItemGroupElementContext : IHasItemGroupElement
        {
            return itemGroupElementContext =>
            {
                // Ignore the package reference element.
                _ = Instances.ItemGroupXElementOperator.Add_SupportedPlatform(
                    itemGroupElementContext.ItemGroupElement,
                    includeValue);

                return Task.CompletedTask;
            };
        }

        public Func<TItemGroupElementContext, Task> Add_Folder<TItemGroupElementContext>(
            IsSet<IHasItemGroupElement> itemGroupElementSet,
            string relativePath)
            where TItemGroupElementContext : IHasItemGroupElement
        {
            return itemGroupElementContext =>
            {
                // Ignore the package reference element.
                _ = Instances.ItemGroupXElementOperator.Add_Folder(
                    itemGroupElementContext.ItemGroupElement,
                    relativePath);

                return Task.CompletedTask;
            };
        }

        public Func<TItemGroupElementContext, Task> Add_PackageReference<TItemGroupElementContext>(
            IsSet<IHasItemGroupElement> itemGroupElementSet,
            PackageReference packageReference)
            where TItemGroupElementContext : IHasItemGroupElement
        {
            return itemGroupElementContext =>
            {
                // Ignore the package reference element.
                _ = Instances.ItemGroupXElementOperator.Add_PackageReference(
                    itemGroupElementContext.ItemGroupElement,
                    packageReference);

                return Task.CompletedTask;
            };
        }

        public Func<TItemGroupContext, TProjectContext, TContext, Task> Add_ProjectReference<TItemGroupContext, TProjectContext, TContext>(
            Func<TContext, Task<string>> projectReferenceProjectFilePathProvider)
            where TItemGroupContext : IHasItemGroupElement
            where TProjectContext : IHasProjectFilePath
        {
            return async (itemGroupContext, projectContext, context) =>
            {
                var projectReferenceProjectFilePath = await projectReferenceProjectFilePathProvider(context);

                Instances.ItemGroupXElementOperator.Add_ProjectReference(
                    itemGroupContext.ItemGroupElement,
                    projectContext.ProjectFilePath,
                    projectReferenceProjectFilePath);
            };
        }

        public Func<TItemGroupElementContext, TProjectElementContext, Task> Append_ItemGroupElement<TItemGroupElementContext, TProjectElementContext>(
            IsSet<IHasItemGroupElement> propertyGroupElementRequired,
            out IChecked checkedPropertyGroupElementAppended)
            where TItemGroupElementContext : IHasItemGroupElement
            where TProjectElementContext : IHasProjectElement
        {
            checkedPropertyGroupElementAppended = Checked.Check();

            return (propertyGroupElementContext, projectElementContext) =>
            {
                Instances.ProjectXElementsOperator.Append_ItemGroupXElement(
                    projectElementContext.ProjectElement,
                    propertyGroupElementContext.ItemGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TItemGroupContext, Task> Set_ItemGroupElement_New<TItemGroupContext>(
            out IsSet<IHasItemGroupElement> itemGroupElementSet)
            where TItemGroupContext : IWithItemGroupElement
        {
            return context =>
            {
                context.ItemGroupElement = Instances.ProjectXElementsOperator.New_ItemGroupXElement();

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_Label_PackageReferences<TContext>(
            IsSet<IHasItemGroupElement> itemGroupElementSet)
            where TContext : IHasItemGroupElement
        {
            return context =>
            {
                Instances.ItemGroupXElementOperator.Set_Label_PackageReferences(
                    context.ItemGroupElement);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_Label_ProjectReferences<TContext>(
            IsSet<IHasItemGroupElement> itemGroupElementSet)
            where TContext : IHasItemGroupElement
        {
            return context =>
            {
                Instances.ItemGroupXElementOperator.Set_Label_ProjectReferences(
                    context.ItemGroupElement);

                return Task.CompletedTask;
            };
        }
    }
}
