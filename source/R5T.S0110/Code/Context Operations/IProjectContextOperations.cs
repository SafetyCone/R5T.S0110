using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.L0091.T000;
using R5T.L0092.T001;
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
    }
}
