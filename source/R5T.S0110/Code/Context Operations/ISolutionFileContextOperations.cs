using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0095.T000;
using R5T.L0096.T000;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ISolutionFileContextOperations : IContextOperationsMarker,
        L0095.ISolutionFileContextOperations
    {
        public Func<TContext, Task> In_ProjectContext<TContext>(
            ProjectSpecification projectSpecification,
            out (IsSet<IHasProjectName>, IsSet<IHasProjectDescription>, IsSet<IHasSolutionFilePath>) propertiesSet,
            IEnumerable<Func<ProjectContext, Task>> projectOperations)
            where TContext : IHasSolutionFilePath
        {
            return context =>
            {
                var childContext = new ProjectContext
                {
                    SolutionFilePath = context.SolutionFilePath,
                    ProjectName = projectSpecification.Name,
                    ProjectDescription = projectSpecification.Description,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    projectOperations);
            };
        }

        public Func<TContext, Task> In_ProjectContext<TContext>(
            ProjectSpecification projectSpecification,
            out (IsSet<IHasProjectName>, IsSet<IHasProjectDescription>, IsSet<IHasSolutionFilePath>) propertiesSet,
            params Func<ProjectContext, Task>[] projectOperations)
            where TContext : IHasSolutionFilePath
        {
            return this.In_ProjectContext<TContext>(
                projectSpecification,
                out propertiesSet,
                projectOperations.AsEnumerable());
        }
    }
}
