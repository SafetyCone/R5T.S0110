using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.S0110.Contexts;
using R5T.T0046;
using R5T.T0131;
using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface ICodeFileGenerationContextOperations : IContextOperationsMarker,
        L0097.ICodeFileGenerationContextOperations
    {
        public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
            out TypeSpecifier<CodeFileContext001> codeFileContextSpecifier,
            string projectDirectoryRelativeFilePath,
            ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
            out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
            IEnumerable<Func<TCodeFileContextSet, CodeFileContext001, Task>> operations)
            where TCodeFileContextSet : IWithContext<CodeFileContext001>, IHasContext<TProjectContext>, new()
            where TProjectContext : IHasProjectFilePath
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TCodeFileContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out codeFileContextSetSpecifier,
                o.In_Context_OfContextSet<TCodeFileContextSet, CodeFileContext001>(
                    out codeFileContextSpecifier,
                    o.Construct_Context_OfContextSet<TCodeFileContextSet, CodeFileContext001>(
                        this.Set_CodeFilePath<CodeFileContext001, TProjectContext>(
                            projectDirectoryRelativeFilePath,
                            projectContextPropertiesRequired.PropertiesSet,
                            out var codeFilePathSet).In_ContextSetWithContext(codeFileContextSetSpecifier)
                    ),
                    operations
                )
            );

            codeFileContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<CodeFileContext001>().For(
                codeFilePathSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
            out TypeSpecifier<CodeFileContext001> codeFileContextSpecifier,
            string projectDirectoryRelativeFilePath,
            ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
            out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
            params Func<TCodeFileContextSet, CodeFileContext001, Task>[] operations)
            where TCodeFileContextSet : IWithContext<CodeFileContext001>, IHasContext<TProjectContext>, new()
            where TProjectContext : IHasProjectFilePath
            => this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
                parentContextSetIsomorphism,
                out codeFileContextSetSpecifier,
                out codeFileContextSpecifier,
                projectDirectoryRelativeFilePath,
                projectContextPropertiesRequired,
                out codeFileContextPropertiesSet,
                operations.AsEnumerable());

        public Func<TParentContextSet, Task> Create_ImportsComponent_ForBlazorServer<TParentContextSet, TCodeFileContextSet, TProjectContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectName> ProjectNameSet)> projectContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContextSet : IWithContext<CodeFileContext001>, IHasContext<TProjectContext>, new()
            where TProjectContext : IHasProjectFilePath, IHasProjectName, IHasProjectDescription
        {
            return this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
                parentContextSetIsomorphism,
                out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
                out var codeFileContextSpecifier,
                Instances.ProjectDirectoryPathRelativePaths._Imports_razor_ForComponents,
                Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                    projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
                this.Create_ImportsComponent_ForBlazorServer<CodeFileContext001, TProjectContext>(
                    codeFileContextPropertiesSet,
                    Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                        projectContextPropertiesRequired.PropertiesSet.ProjectNameSet),
                    out fileExists
                ).In_ContextSetWithContext(codeFileContextSetSpecifier)
            );
        }

        public Func<TCodeFileContext, TProjectContext, Task> Create_ImportsComponent_ForBlazorServer<TCodeFileContext, TProjectContext>(
            ContextPropertiesSet<TCodeFileContext,
                IsSet<IHasFilePath>> codeFileContextPropertiesRequired,
            ContextPropertiesSet<TProjectContext,
                IsSet<IHasProjectName>> propertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContext : IHasFilePath
            where TProjectContext : IHasProjectName
        {
            fileExists = Checked.Check<IFileExists>();

            return (codeFileContext, projectContext) =>
            {
                return Instances.CodeFileGenerator.Generate_File(
                    codeFileContext.FilePath,
                    Instances.CodeFileContentGenerator.Generate_ImportsComponent_ForBlazorServer(
                        projectContext.ProjectName,
                        // Wrong project name! Should be client and server.
                        projectContext.ProjectName));
            };
        }

        public Func<TParentContextSet, Task> Create_AppComponent_ForBlazorClient<TParentContextSet, TCodeFileContextSet, TProjectContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectName> ProjectNameSet)> projectContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContextSet : IWithContext<CodeFileContext001>, IHasContext<TProjectContext>, new()
            where TProjectContext : IHasProjectFilePath, IHasProjectName, IHasProjectDescription
        {
            return this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
                parentContextSetIsomorphism,
                out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
                out var codeFileContextSpecifier,
                Instances.ProjectDirectoryPathRelativePaths.App_razor,
                Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                    projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
                this.Create_AppComponent_ForBlazorClient<CodeFileContext001, TProjectContext>(
                    codeFileContextPropertiesSet,
                    Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                        projectContextPropertiesRequired.PropertiesSet.ProjectNameSet),
                    out fileExists
                ).In_ContextSetWithContext(codeFileContextSetSpecifier)
            );
        }

        public Func<TCodeFileContext, TProjectContext, Task> Create_AppComponent_ForBlazorClient<TCodeFileContext, TProjectContext>(
            ContextPropertiesSet<TCodeFileContext,
                IsSet<IHasFilePath>> codeFileContextPropertiesRequired,
            ContextPropertiesSet<TProjectContext,
                IsSet<IHasProjectName>> propertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContext : IHasFilePath
            where TProjectContext : IHasProjectName
        {
            fileExists = Checked.Check<IFileExists>();

            return (codeFileContext, projectContext) =>
            {
                return Instances.CodeFileGenerator.Generate_File(
                    codeFileContext.FilePath,
                    Instances.CodeFileContentGenerator.Generate_AppComponent_ForBlazorServer(
                        projectContext.ProjectName));
            };
        }

        //public Func<TParentContextSet, Task> Create_PackageJson<TParentContextSet, TCodeFileContextSet, TProjectContext, TRepositoryContext, TApplicationContext>(
        //    IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
        //    ContextPropertiesSet<TProjectContext, (
        //        IsSet<IHasProjectFilePath> ProjectFilePathSet,
        //        IsSet<IHasProjectName> ProjectNameSet,
        //        IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectContextPropertiesRequired,
        //    ContextPropertiesSet<TRepositoryContext, IsSet<IHasLicenseName>> repositoryContextPropertiesRequired,
        //    ContextPropertiesSet<TApplicationContext, IsSet<IHasGitHubAuthor>> applicationContextPropertiesRequired,
        //    out IChecked<IFileExists> fileExists)
        //    where TCodeFileContextSet : IWithContext<CodeFileContext001>, IHasContext<TProjectContext>, IHasContext<TRepositoryContext>, IHasContext<TApplicationContext>, new()
        //    where TProjectContext : IHasProjectFilePath, IHasProjectName, IHasProjectDescription
        //    where TRepositoryContext : IHasLicenseName
        //    where TApplicationContext : IHasGitHubAuthor
        //{
        //    return this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
        //        parentContextSetIsomorphism,
        //        out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
        //        out var codeFileContextSpecifier,
        //        Instances.ProjectDirectoryPathRelativePaths.package_json,
        //        Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
        //            projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
        //        out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
        //        this.Create_PackageJson<CodeFileContext001, TProjectContext, TRepositoryContext, TApplicationContext>(
        //            codeFileContextPropertiesSet,
        //            Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
        //                projectContextPropertiesRequired.PropertiesSet.ProjectNameSet,
        //                projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
        //            repositoryContextPropertiesRequired,
        //            applicationContextPropertiesRequired,
        //            out fileExists
        //        ).In_ContextSetAndContext(codeFileContextSetSpecifier)
        //    );
        //}

        //public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
        //    IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
        //    TypeAdapter<TCodeFileContextSet, CodeFileContext001, TProjectContext> codeFileContextSetAdapter,
        //    out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
        //    out TypeSpecifier<CodeFileContext001> codeFileContextSpecifier,
        //    string projectDirectoryRelativeFilePath,
        //    ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
        //    out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
        //    IEnumerable<Func<TCodeFileContextSet, CodeFileContext001, Task>> operations)
        //    where TCodeFileContextSet : new()
        //    where TProjectContext : IHasProjectFilePath
        //{
        //    var o = Instances.ContextOperations;

        //    var output = o.In_ChildContextSet<TCodeFileContextSet, TParentContextSet>(
        //        parentContextSetIsomorphism,
        //        out codeFileContextSetSpecifier,
        //        o.In_Context_OfContextSet<TCodeFileContextSet, CodeFileContext001>(
        //            codeFileContextSetAdapter,
        //            out codeFileContextSpecifier,
        //            o.Construct_Context<TCodeFileContextSet, CodeFileContext001>(
        //                this.Set_CodeFilePath<CodeFileContext001, TProjectContext>(
        //                    projectDirectoryRelativeFilePath,
        //                    projectContextPropertiesRequired.PropertiesSet,
        //                    out var codeFilePathSet).In_ContextSetAndContext(codeFileContextSetAdapter)
        //            ),
        //            operations
        //        )
        //    );

        //    codeFileContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<CodeFileContext001>().For(
        //        codeFilePathSet);

        //    return output;
        //}

        //public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
        //    IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
        //    TypeAdapter<TCodeFileContextSet, CodeFileContext001, TProjectContext> codeFileContextSetAdapter,
        //    out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
        //    out TypeSpecifier<CodeFileContext001> codeFileContextSpecifier,
        //    string projectDirectoryRelativeFilePath,
        //    ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
        //    out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
        //    params Func<TCodeFileContextSet, CodeFileContext001, Task>[] operations)
        //    where TCodeFileContextSet : new()
        //    where TProjectContext : IHasProjectFilePath
        //    => this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext>(
        //        parentContextSetIsomorphism,
        //        codeFileContextSetAdapter,
        //        out codeFileContextSetSpecifier,
        //        out codeFileContextSpecifier,
        //        projectDirectoryRelativeFilePath,
        //        projectContextPropertiesRequired,
        //        out codeFileContextPropertiesSet,
        //        operations.AsEnumerable());

        public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext, TCodeFileContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            TypeAdapter<TCodeFileContextSet, TCodeFileContext, TProjectContext> codeFileContextSetAdapter,
            out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
            out TypeSpecifier<TCodeFileContext> codeFileContextSpecifier,
            string projectDirectoryRelativeFilePath,
            ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
            out ContextPropertiesSet<TCodeFileContext, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
            IEnumerable<Func<TCodeFileContextSet, TCodeFileContext, Task>> operations)
            where TCodeFileContextSet : new()
            where TProjectContext : IHasProjectFilePath
            where TCodeFileContext : IWithFilePath, new()
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TCodeFileContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out codeFileContextSetSpecifier,
                o.In_Context_OfContextSet<TCodeFileContextSet, TCodeFileContext>(
                    codeFileContextSetAdapter,
                    out codeFileContextSpecifier,
                    o.Construct_Context<TCodeFileContextSet, TCodeFileContext>(
                        this.Set_CodeFilePath<TCodeFileContext, TProjectContext>(
                            projectDirectoryRelativeFilePath,
                            projectContextPropertiesRequired.PropertiesSet,
                            out var codeFilePathSet).In_ContextSetAndContext<TCodeFileContextSet, TCodeFileContext, TProjectContext>(codeFileContextSetAdapter)
                    ),
                    operations
                )
            );

            codeFileContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TCodeFileContext>().For(
                codeFilePathSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext, TCodeFileContext>(
            IDirectionalIsomorphism<TParentContextSet, TCodeFileContextSet> parentContextSetIsomorphism,
            TypeAdapter<TCodeFileContextSet, TCodeFileContext, TProjectContext> codeFileContextSetAdapter,
            out ContextSetSpecifier<TCodeFileContextSet> codeFileContextSetSpecifier,
            out TypeSpecifier<TCodeFileContext> codeFileContextSpecifier,
            string projectDirectoryRelativeFilePath,
            ContextPropertiesSet<TProjectContext, IsSet<IHasProjectFilePath>> projectContextPropertiesRequired,
            out ContextPropertiesSet<TCodeFileContext, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
            params Func<TCodeFileContextSet, TCodeFileContext, Task>[] operations)
            where TCodeFileContextSet : new()
            where TProjectContext : IHasProjectFilePath
            where TCodeFileContext : IWithFilePath, new()
            => this.In_CodeFileContextSet<TParentContextSet, TCodeFileContextSet, TProjectContext, TCodeFileContext>(
                parentContextSetIsomorphism,
                codeFileContextSetAdapter,
                out codeFileContextSetSpecifier,
                out codeFileContextSpecifier,
                projectDirectoryRelativeFilePath,
                projectContextPropertiesRequired,
                out codeFileContextPropertiesSet,
                operations.AsEnumerable());

        public Func<TParentContextSet, Task> Create_PackageJson<TParentContextSet, TProjectContext, TRepositoryContext, TApplicationContext>(
            IDirectionalIsomorphism<TParentContextSet, CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>> parentContextSetIsomorphism,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasLicenseName>> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TApplicationContext, IsSet<IHasGitHubAuthor>> applicationContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TProjectContext : IHasProjectFilePath, IHasProjectName, IHasProjectDescription
            where TRepositoryContext : IHasLicenseName
            where TApplicationContext : IHasGitHubAuthor
        {
            var codeFileContextSetAdapter = Instances.ContextSetTypeAdapters.For_CodeFileContextSet001(
                TypeSpecifier<TProjectContext>.Instance,
                TypeSpecifier<TRepositoryContext>.Instance,
                TypeSpecifier<TApplicationContext>.Instance);

            return this.In_CodeFileContextSet<TParentContextSet, CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>, TProjectContext, CodeFileContext001>(
                parentContextSetIsomorphism,
                codeFileContextSetAdapter,
                out ContextSetSpecifier<CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>> codeFileContextSetSpecifier,
                out var codeFileContextSpecifier,
                Instances.ProjectDirectoryPathRelativePaths.package_json,
                Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                    projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
                this.Create_PackageJson<CodeFileContext001, TProjectContext, TRepositoryContext, TApplicationContext>(
                    codeFileContextPropertiesSet,
                    Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                        projectContextPropertiesRequired.PropertiesSet.ProjectNameSet,
                        projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                    repositoryContextPropertiesRequired,
                    applicationContextPropertiesRequired,
                    out fileExists
                ).In_ContextSetAndContext(codeFileContextSetAdapter)
            );
        }

        public Func<TCodeFileContext, TProjectContext, TRepositoryContext, TApplicationContext, Task> Create_PackageJson<TCodeFileContext, TProjectContext, TRepositoryContext, TApplicationContext>(
            ContextPropertiesSet<TCodeFileContext,
                IsSet<IHasFilePath>> codeFileContextPropertiesRequired,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescription)> propertiesRequired,
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasLicenseName>> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TApplicationContext, IsSet<IHasGitHubAuthor>> applicationContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContext : IHasFilePath
            where TProjectContext : IHasProjectName, IHasProjectDescription
            where TRepositoryContext : IHasLicenseName
            where TApplicationContext : IHasGitHubAuthor
        {
            fileExists = Checked.Check<IFileExists>();

            return (codeFileContext, projectContext, repositoryContext, applicationContext) =>
            {
                return Instances.CodeFileGenerator.Generate_File(
                    codeFileContext.FilePath,
                    Instances.CodeFileContentGenerator.Generate_PackageJson(
                        projectContext.ProjectName,
                        projectContext.ProjectDescription,
                        applicationContext.GitHubAuthor.Name,
                        repositoryContext.LicenseName));
            };
        }

        public Func<TParentContextSet, Task> Create_PackageJson_ForBlog<TParentContextSet, TProjectContext, TRepositoryContext, TApplicationContext>(
            IDirectionalIsomorphism<TParentContextSet, CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>> parentContextSetIsomorphism,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectFilePath> ProjectFilePathSet,
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescriptionSet)> projectContextPropertiesRequired,
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasLicenseName>> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TApplicationContext, IsSet<IHasGitHubAuthor>> applicationContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TProjectContext : IHasProjectFilePath, IHasProjectName, IHasProjectDescription
            where TRepositoryContext : IHasLicenseName
            where TApplicationContext : IHasGitHubAuthor
        {
            var codeFileContextSetAdapter = Instances.ContextSetTypeAdapters.For_CodeFileContextSet001(
                TypeSpecifier<TProjectContext>.Instance,
                TypeSpecifier<TRepositoryContext>.Instance,
                TypeSpecifier<TApplicationContext>.Instance);

            return this.In_CodeFileContextSet<TParentContextSet, CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>, TProjectContext, CodeFileContext001>(
                parentContextSetIsomorphism,
                codeFileContextSetAdapter,
                out ContextSetSpecifier<CodeFileContextSet001<TProjectContext, TRepositoryContext, TApplicationContext>> codeFileContextSetSpecifier,
                out var codeFileContextSpecifier,
                Instances.ProjectDirectoryPathRelativePaths.package_json,
                Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                    projectContextPropertiesRequired.PropertiesSet.ProjectFilePathSet),
                out ContextPropertiesSet<CodeFileContext001, IsSet<IHasFilePath>> codeFileContextPropertiesSet,
                this.Create_PackageJson_ForBlog<CodeFileContext001, TProjectContext, TRepositoryContext, TApplicationContext>(
                    codeFileContextPropertiesSet,
                    Instances.ContextOperator.Get_ContextPropertiesSet<TProjectContext>().For(
                        projectContextPropertiesRequired.PropertiesSet.ProjectNameSet,
                        projectContextPropertiesRequired.PropertiesSet.ProjectDescriptionSet),
                    repositoryContextPropertiesRequired,
                    applicationContextPropertiesRequired,
                    out fileExists
                ).In_ContextSetAndContext(codeFileContextSetAdapter)
            );
        }

        public Func<TCodeFileContext, TProjectContext, TRepositoryContext, TApplicationContext, Task> Create_PackageJson_ForBlog<TCodeFileContext, TProjectContext, TRepositoryContext, TApplicationContext>(
            ContextPropertiesSet<TCodeFileContext,
                IsSet<IHasFilePath>> codeFileContextPropertiesRequired,
            ContextPropertiesSet<TProjectContext, (
                IsSet<IHasProjectName> ProjectNameSet,
                IsSet<IHasProjectDescription> ProjectDescription)> propertiesRequired,
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasLicenseName>> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TApplicationContext, IsSet<IHasGitHubAuthor>> applicationContextPropertiesRequired,
            out IChecked<IFileExists> fileExists)
            where TCodeFileContext : IHasFilePath
            where TProjectContext : IHasProjectName, IHasProjectDescription
            where TRepositoryContext : IHasLicenseName
            where TApplicationContext : IHasGitHubAuthor
        {
            fileExists = Checked.Check<IFileExists>();

            return (codeFileContext, projectContext, repositoryContext, applicationContext) =>
            {
                return Instances.CodeFileGenerator.Generate_File(
                    codeFileContext.FilePath,
                    Instances.CodeFileContentGenerator.Generate_PackageJson_ForBlog(
                        projectContext.ProjectName,
                        projectContext.ProjectDescription,
                        applicationContext.GitHubAuthor.Name,
                        repositoryContext.LicenseName));
            };
        }
    }
}
