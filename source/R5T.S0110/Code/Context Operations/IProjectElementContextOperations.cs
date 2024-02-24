using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectElementContextOperations : IContextOperationsMarker
    {
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
    }
}
