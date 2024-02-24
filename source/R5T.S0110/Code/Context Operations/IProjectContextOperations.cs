using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IProjectContextOperations : IContextOperationsMarker,
        L0096.IProjectContextOperations
    {
        public Func<TContext, Task> In_CodeFileContext<TContext>(
            out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            IEnumerable<Func<CodeFileContext, Task>> codeFileContextOperations)
            where TContext : IHasProjectFilePath, IHasNamespaceName
        {
            return context =>
            {
                var childContext = new CodeFileContext
                {
                    ProjectFilePath = context.ProjectFilePath,
                    NamespaceName = context.NamespaceName,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    codeFileContextOperations);
            };
        }

        public Func<TContext, Task> In_CodeFileContext<TContext>(
            out (IsSet<IHasProjectFilePath>, IsSet<IHasNamespaceName>) propertiesSet,
            params Func<CodeFileContext, Task>[] codeFileContextOperations)
            where TContext : IHasProjectFilePath, IHasNamespaceName
        {
            return this.In_CodeFileContext<TContext>(
                out propertiesSet,
                codeFileContextOperations.AsEnumerable());
        }

        public Func<TContext, TProjectContext, Task> Set_ProjectDescription<TContext, TProjectContext>(
            IsSet<IHasProjectDescription> projectDescriptionRequired,
            out IsSet<IHasProjectDescription> projectDescriptionSet)
            where TProjectContext : IHasProjectDescription
            where TContext : IWithProjectDescription
        {
            return (context, projectContext) =>
            {
                context.ProjectDescription = projectContext.ProjectDescription;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, TProjectContext, Task> Set_ProjectFilePath<TContext, TProjectContext>(
            IsSet<IHasProjectFilePath> projectFilePathRequired,
            out IsSet<IHasProjectFilePath> projectFilePathSet)
            where TProjectContext : IHasProjectFilePath
            where TContext : IWithProjectFilePath
        {
            return (context, projectContext) =>
            {
                context.ProjectFilePath = projectContext.ProjectFilePath;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_ProjectSpecification<TContext>(
            ProjectSpecification projectSpecification,
            out (
            IsSet<IHasProjectSpecification> ProjectSpecificationSet,
            IsSet<IHasProjectName> ProjectNameSet,
            IsSet<IHasProjectDescription> ProjectDescriptionSet
            ) propertiesSet
            )
            where TContext : IWithProjectSpecification
        {
            return context =>
            {
                context.ProjectSpecification = projectSpecification;

                return Task.CompletedTask;
            };
        }
    }
}
