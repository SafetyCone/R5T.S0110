using System;
using System.Threading.Tasks;
using R5T.L0091.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IItemGroupElementContextOperations : IContextOperationsMarker
    {
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
    }
}
