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

using R5T.S0110.Contexts;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ISolutionFileContextOperations : IContextOperationsMarker,
        L0095.ISolutionFileContextOperations
    {
        public Func<TSolutionSetContextSet, Task> Create_SolutionFile<TSolutionSetContextSet, TSolutionContextSet, TSolutionSetContext, TSolutionContext>(
            IDirectionalIsomorphism<TSolutionSetContextSet, TSolutionContextSet> solutionSetIsomorphism,
            out ContextSetSpecifier<TSolutionContextSet> solutionContextSetSpecifier,
            out TypeSpecifier<TSolutionContext> solutionContextSpecifier,
            SolutionSpecification solutionSpecification,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            out ContextPropertiesSet<TSolutionContext, (
                IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
            out IChecked<IFileExists> checkedSolutionFileExists,
            IEnumerable<Func<TSolutionContextSet, TSolutionContext, Task>> operations
            )
            where TSolutionContextSet : IWithContext<TSolutionContext>, IHasContext<TSolutionSetContext>, new()
            where TSolutionSetContext : IHasSolutionDirectoryPath
            where TSolutionContext :
            IWithSolutionDirectoryPath,
            IHasDirectoryPath,
            IWithSolutionSpecification,
            IWithSolutionFilePath,
            IHasFilePath,
            IHasSolutionName, new()
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TSolutionContextSet, TSolutionSetContextSet>(
                solutionSetIsomorphism,
                out solutionContextSetSpecifier,
                o.In_Context_OfContextSet<TSolutionContextSet, TSolutionContext>(
                    out solutionContextSpecifier,
                    o.Construct_Context_OfContextSet<TSolutionContextSet, TSolutionContext>(
                        (solutionContextSet, solutionContext) =>
                        {
                            var solutionSetContext = solutionContextSet.Get_Context<TSolutionContextSet, TSolutionSetContext>();

                            solutionContext.SolutionDirectoryPath = solutionSetContext.SolutionDirectoryPath;

                            return Task.CompletedTask;
                        },
                        Instances.SolutionContextOperations.Set_SolutionSpecification<TSolutionContext>(solutionSpecification,
                            out (
                            IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                            IsSet<IHasSolutionName> SolutionNameSet
                            ) solutionSpecificationPropertiesSet).In_ContextSetWithContext(solutionContextSetSpecifier),
                        Instances.SolutionContextOperations.Set_SolutionFilePath<TSolutionContext>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
                            out var solutionFilePathSet).In_ContextSetWithContext(solutionContextSetSpecifier)
                    ),
                    Instances.FilePathContextOperations.Verify_File_DoesNotExist<TSolutionContext>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                        out var checkedSolutionFileDoesNotExist).In_ContextSetWithContext(solutionContextSetSpecifier),
                    Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<TSolutionContext>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
                        out _).In_ContextSetWithContext(solutionContextSetSpecifier),
                    Instances.SolutionFileContextOperations.Create_SolutionFile<TSolutionContext>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                        out checkedSolutionFileExists).In_ContextSetWithContext(solutionContextSetSpecifier),
                    o.From(operations)
                )
            );

            solutionContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TSolutionContext>().For(
                solutionSpecificationPropertiesSet.SolutionSpecificationSet,
                solutionFilePathSet);

            return output;
        }

        public Func<TSolutionSetContextSet, Task> Create_SolutionFile<TSolutionSetContextSet, TSolutionContextSet, TSolutionSetContext, TSolutionContext>(
            IDirectionalIsomorphism<TSolutionSetContextSet, TSolutionContextSet> solutionSetIsomorphism,
            out ContextSetSpecifier<TSolutionContextSet> solutionContextSetSpecifier,
            out TypeSpecifier<TSolutionContext> solutionContextSpecifier,
            SolutionSpecification solutionSpecification,
            ContextPropertiesSet<TSolutionSetContext, IsSet<IHasSolutionDirectoryPath>> solutionSetContextPropertiesSet,
            out ContextPropertiesSet<TSolutionContext, (
                IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                IsSet<IHasSolutionFilePath> SolutionFilePathSet)> solutionContextPropertiesSet,
            out IChecked<IFileExists> checkedSolutionFileExists,
            params Func<TSolutionContextSet, TSolutionContext, Task>[] operations
            )
            where TSolutionContextSet : IWithContext<TSolutionContext>, IHasContext<TSolutionSetContext>, new()
            where TSolutionSetContext : IHasSolutionDirectoryPath
            where TSolutionContext :
            IWithSolutionDirectoryPath,
            IHasDirectoryPath,
            IWithSolutionSpecification,
            IWithSolutionFilePath,
            IHasFilePath,
            IHasSolutionName, new()
            => this.Create_SolutionFile<TSolutionSetContextSet, TSolutionContextSet, TSolutionSetContext, TSolutionContext>(
                solutionSetIsomorphism,
                out solutionContextSetSpecifier,
                out solutionContextSpecifier,
                solutionSpecification,
                solutionSetContextPropertiesSet,
                out solutionContextPropertiesSet,
                out checkedSolutionFileExists,
                operations.AsEnumerable());

        public Func<TSolutionSetContext, Task> Create_SolutionFile<TSolutionSetContext, TSolutionContext>(
            SolutionSpecification solutionSpecification,
            IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet,
            out IChecked<IFileExists> checkedSolutionFileExists,
            IEnumerable<Func<TSolutionContext, TSolutionSetContext, Task>> operations = default)
            where TSolutionSetContext : IHasSolutionDirectoryPath
            where TSolutionContext :
            IWithSolutionDirectoryPath,
            IHasDirectoryPath,
            IWithSolutionSpecification,
            IWithSolutionFilePath,
            IHasFilePath,
            IHasSolutionName, new()
        {
            var o = Instances.ContextOperations;

            var solutionContextSet = Instances.ContextOperator.Get_ContextSetSpecifier<TSolutionContext, TSolutionSetContext>();

            var output = o.In_ContextSet_A_BA<TSolutionContext, TSolutionSetContext>(
                o.Construct_Context_B_BA<TSolutionContext, TSolutionSetContext>(
                    (c, a) =>
                    {
                        c.SolutionDirectoryPath = a.SolutionDirectoryPath;

                        return Task.CompletedTask;
                    },
                    Instances.SolutionContextOperations.Set_SolutionSpecification<TSolutionContext>(solutionSpecification,
                        out (
                        IsSet<IHasSolutionSpecification> SolutionSpecificationSet,
                        IsSet<IHasSolutionName> SolutionNameSet
                        ) solutionSpecificationPropertiesSet).In(solutionContextSet),
                    Instances.SolutionContextOperations.Set_SolutionFilePath<TSolutionContext>((new IsSet<IHasSolutionDirectoryPath>(), solutionSpecificationPropertiesSet.SolutionNameSet),
                        out var solutionFilePathSet).In(solutionContextSet)
                ),
                Instances.FilePathContextOperations.Verify_File_DoesNotExist<TSolutionContext>(Instances.IsSetOperator.Implies<IHasFilePath, IHasSolutionFilePath>(solutionFilePathSet),
                    out var checkedSolutionFileDoesNotExist).In(solutionContextSet),
                Instances.DirectoryPathContextOperations.Create_Directory_IfNotExists<TSolutionContext>(Instances.IsSetOperator.Implies<IHasDirectoryPath, IHasSolutionDirectoryPath>(new IsSet<IHasSolutionDirectoryPath>()),
                    out var checkedSolutionDirectoryExists).In(solutionContextSet),
                Instances.SolutionFileContextOperations.Create_SolutionFile<TSolutionContext>(solutionFilePathSet, checkedSolutionFileDoesNotExist,
                    out checkedSolutionFileExists).In(solutionContextSet),
                o.From(operations)
            );

            return output;
        }

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
            out IChecked<IFileExists> checkedSolutionFileExists,
            params Func<Context003, TSolutionSetContext, Task>[] operations)
            where TSolutionSetContext : IHasSolutionDirectoryPath
            => this.Create_SolutionFile<TSolutionSetContext>(
                solutionSpecification,
                solutionDirectoryPathSet,
                out checkedSolutionFileExists,
                operations.AsEnumerable());

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
