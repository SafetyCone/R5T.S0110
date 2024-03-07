using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
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
        public Func<TSolutionSetContext, Task> Create_SolutionFile<TSolutionSetContext>(
            SolutionSpecification solutionSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out IChecked<IFileExists> checkedSolutionFileExists,
            IEnumerable<Func<Context003, TSolutionSetContext, Task>> operations = default)
            where TSolutionSetContext : IHasSolutionDirectoryPath
        {
            var o = Instances.ContextOperations;

            var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, TSolutionSetContext>();

            var output = o.In_ContextSet_A_BA<Context003, TSolutionSetContext>(
                o.Construct_Context_B_BA<Context003, TSolutionSetContext>(
                    (c, a) =>
                    {
                        c.SolutionDirectoryPath = a.SolutionDirectoryPath;

                        return Task.CompletedTask;
                    },
                    Instances.SolutionContextOperations.Set_SolutionSpecification<Context003>(solutionSpecification,
                        out (
                        IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                        IsSet<IHasSolutionName> SolutionNameSet
                        ) solutionSpecificationPropertiesSet).In(solutionContextSet),
                    Instances.SolutionContextOperations.Set_SolutionFilePath<Context003>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
                        out var solutionFilePathSet).In(solutionContextSet)
                ),
                Instances.FilePathContextOperations.Verify_File_DoesNotExist<Context003>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                    out var checkedSolutionFileDoesNotExist).In(solutionContextSet),
                Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<Context003>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
                    out var checkedSolutionDirectoryExists).In(solutionContextSet),
                Instances.SolutionFileContextOperations.Create_SolutionFile<Context003>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                    out checkedSolutionFileExists).In(solutionContextSet),
                o.From(operations)
            );

            return output;
        }

        public Func<TSolutionSetContext, Task> Create_SolutionFile<TSolutionSetContext>(
            SolutionSpecification solutionSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out IsSet<IHasSolutionFilePath> solutionFilePathSet,
            out IChecked<IFileExists> checkedSolutionFileExists,
            IEnumerable<Func<Context003, TSolutionSetContext, Task>> operations = default)
            where TSolutionSetContext : IHasSolutionDirectoryPath, IWithSolutionFilePath
        {
            var o = Instances.ContextOperations;

            var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, TSolutionSetContext>();

            return this.Create_SolutionFile<TSolutionSetContext>(
                solutionSpecification,
                solutionDirectoryPathSet,
                out checkedSolutionFileExists,
                Instances.EnumerableOperator.Get_Empty_IfDefault(operations).Append(
                    // Output the library solution file path.
                    (c, a) =>
                    {
                        a.SolutionFilePath = c.SolutionFilePath;

                        return Task.CompletedTask;
                    }
                )
            );
        }

        public Func<TSolutionSetContext, Task> Create_SolutionFile<TSolutionSetContext>(
            SolutionSpecification solutionSpecification,
            (IsSet<IHasSolutionDirectoryPath> SolutionDirectoryPathSet, IsSet<IHasProjectFilePath> ProjectFilePathSet) propertiesSet,
            out IsSet<IHasSolutionFilePath> solutionFilePathSet,
            out IChecked<IFileExists> checkedSolutionFileExists)
            where TSolutionSetContext : IHasSolutionDirectoryPath, IHasProjectFilePath, IWithSolutionFilePath
        {
            var o = Instances.ContextOperations;

            var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context003, TSolutionSetContext>();

            return this.Create_SolutionFile<TSolutionSetContext>(
                solutionSpecification,
                propertiesSet.SolutionDirectoryPathSet,
                out solutionFilePathSet,
                out checkedSolutionFileExists,
                Instances.EnumerableOperator.From<Func<Context003, TSolutionSetContext, Task>>(
                    // Add project reference.
                    (c, a) =>
                    {
                        Instances.SolutionOperator.AddProjects_Idempotent(
                            c.SolutionFilePath,
                            a.ProjectFilePath);

                        return Task.CompletedTask;
                    }
                )
            );
        }

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
