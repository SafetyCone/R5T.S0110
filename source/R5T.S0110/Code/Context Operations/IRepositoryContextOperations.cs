using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0066.Contexts;
using R5T.L0078.T000;
using R5T.L0079;
using R5T.L0081.O002;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.T0221;
using R5T.T0235.T000;
using R5T.T0241;

using GitHubClientedRepositoryContext = R5T.L0081.T001.RepositoryContext;

using R5T.S0110.Contexts;
using Octokit;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IRepositoryContextOperations : IContextOperationsMarker,
        L0078.O001.IRepositoryContextOperations,
        L0080.O001.IRepositoryContextOperations,
        L0081.O001.IRepositoryContextOperations,
        L0081.O002.IRepositoryContextOperations
    {
        /// <summary>
        /// Allow deleting a repository if it already exists, based on an input parameter.
        /// If the repository exists, but deletion is not allowed, an exception is thrown.
        /// If the repository exists, and deletion is allowed, the repository is deleted, and the repository generation operations are run.
        /// If the repository does not exist, the repository generation operations are run.
        /// </summary>
        public Func<TContextSet, Task> Regenerate_Repository_OrExceptionIfExists<TContextSet, TRepositoryContext, TGitHubContext>(
            // No default value since allowing deletion is an important thing.
            bool allowDeletionIfExists,
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, IsSet<IHasGitHubClient>> gitHubContextPropertiesRequired,
            IEnumerable<Func<TContextSet, Task>> repositoryGenerationOperations)
            where TContextSet :
            IHasContext<TRepositoryContext>,
            IHasContext<TGitHubContext>
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
            where TGitHubContext :
            IHasGitHubClient
        {
            var contextSetSpecifier = ContextSetSpecifier<TContextSet>.Instance;

            return Instances.ContextOperations.In_ContextSetAndContext<TContextSet, CheckRepositoryExistsContext>(
                contextSet =>
                {
                    var checkRepositoryExistsContext = new CheckRepositoryExistsContext();

                    return Task.FromResult(checkRepositoryExistsContext);
                },
                out TypeSpecifier<CheckRepositoryExistsContext> contextSpecifier,
                Instances.ContextOperations.If_InContextSetAndContext<TContextSet, CheckRepositoryExistsContext>(
                    allowDeletionIfExists,
                    // Since we are allowed to delete the repository, go ahead and delete it idempotently since we are inside of a regenerate method.
                    this.Clear_Repository<TRepositoryContext, TGitHubContext>(
                        repositoryContextPropertiesRequired,
                        gitHubContextPropertiesRequired,
                        out var @checked
                    ).In_ContextSetAndContext_ABC<TContextSet, CheckRepositoryExistsContext, TRepositoryContext, TGitHubContext>(contextSetSpecifier, contextSpecifier),
                    // Since we are not allowed to delete the repository, verify it does not already exist.
                    Instances.ContextOperations.From(
                        this.Check_LocalRepositoryExists<TRepositoryContext>(
                            Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                                repositoryContextPropertiesRequired.PropertiesSet.RepositoryDirectoryPathSet),
                            out var localRepositoryExistsSet
                        ).In_ContextSetAndContext(contextSetSpecifier),
                        this.Check_RemoteRepositoryExists<TRepositoryContext, TGitHubContext>(
                            Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                                repositoryContextPropertiesRequired.PropertiesSet.RepositoryNameSet,
                                repositoryContextPropertiesRequired.PropertiesSet.RepositoryOwnerNameSet),
                            gitHubContextPropertiesRequired,
                            out var remoteRepositoryExistsSet
                        ).In_ContextSetAndContext(contextSetSpecifier),
                        this.Verify_RepositoryDoesNotExist<TRepositoryContext>(
                            Instances.ContextOperator.Get_ContextPropertiesSet<CheckRepositoryExistsContext>().For(
                                localRepositoryExistsSet.PropertiesSet,
                                remoteRepositoryExistsSet.PropertiesSet),
                            repositoryContextPropertiesRequired
                        ).In_ContextSetAndContext(contextSetSpecifier)
                    )
                ),
                Instances.ContextOperations.From(repositoryGenerationOperations).In_ContextSetAndContext(contextSpecifier)
            );
        }

        /// <inheritdoc cref="Regenerate_Repository_OrExceptionIfExists{TContextSet, TRepositoryContext, TGitHubContext}(bool, ContextPropertiesSet{TRepositoryContext, ValueTuple{IsSet{IHasRepositoryName}, IsSet{IHasRepositoryOwnerName}, IsSet{IHasRepositoryDirectoryPath}}}, ContextPropertiesSet{TGitHubContext, IsSet{IHasGitHubClient}}, Func{TContextSet, Task}[])"/>
        public Func<TContextSet, Task> Regenerate_Repository_OrExceptionIfExists<TContextSet, TRepositoryContext, TGitHubContext>(
            // No default value since allowing deletion is an important thing.
            bool allowDeletionIfExists,
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, IsSet<IHasGitHubClient>> gitHubContextPropertiesRequired,
            params Func<TContextSet, Task>[] repositoryGenerationOperations)
            where TContextSet :
            IHasContext<TRepositoryContext>,
            IHasContext<TGitHubContext>
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
            where TGitHubContext :
            IHasGitHubClient
            => this.Regenerate_Repository_OrExceptionIfExists<TContextSet, TRepositoryContext, TGitHubContext>(
                allowDeletionIfExists,
                repositoryContextPropertiesRequired,
                gitHubContextPropertiesRequired,
                repositoryGenerationOperations.AsEnumerable());

        public Func<CheckRepositoryExistsContext, TRepositoryContext, Task> Check_LocalRepositoryExists<TRepositoryContext>(
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasRepositoryDirectoryPath>> repositoryContextPropertiesRequired,
            out ContextPropertiesSet<CheckRepositoryExistsContext, IsSet<IHasValue>> localRepositoryExistsSet)
            where TRepositoryContext :
            IHasRepositoryDirectoryPath
        {
            return (checkRepositoryExistsContext, repositoryContext) =>
            {
                checkRepositoryExistsContext.LocalRepositoryExists = Instances.FileSystemOperator.Exists_Directory(
                    repositoryContext.RepositoryDirectoryPath);

                return Task.CompletedTask;
            };
        }

        public Func<CheckRepositoryExistsContext, TRepositoryContext, TGitHubContext, Task> Check_RemoteRepositoryExists<TRepositoryContext, TGitHubContext>(
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, IsSet<IHasGitHubClient>> gitHubContextPropertiesRequired,
            out ContextPropertiesSet<CheckRepositoryExistsContext, IsSet<IHasValue>> remoteRepositoryExistsSet)
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName
            where TGitHubContext :
            IHasGitHubClient
        {
            return async (checkRepositoryExistsContext, repositoryContext, gitHubContext) =>
            {
                checkRepositoryExistsContext.RemoteRepositoryExists = await Instances.GitHubClientOperator.Exists_Repository(
                    gitHubContext.GitHubClient,
                    repositoryContext.RepositoryOwnerName,
                    repositoryContext.RepositoryName);
            };
        }

        public Func<CheckRepositoryExistsContext, TRepositoryContext, Task> Verify_RepositoryDoesNotExist<TRepositoryContext>(
            ContextPropertiesSet<CheckRepositoryExistsContext, (
                IsSet<IHasValue> localRepositoryExistsSet,
                IsSet<IHasValue> remoteRepositoryExistsSet)> checkRepositoryExistsContextPropertiesRequired,
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> propertiesRequired)
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
        {
            return (checkRepositoryExistsContext, repositoryContext) =>
            {
                if (checkRepositoryExistsContext.LocalRepositoryExists || checkRepositoryExistsContext.RemoteRepositoryExists)
                {
                    Console.WriteLine($"Local repository for {repositoryContext.RepositoryName}/{repositoryContext.RepositoryOwnerName} exists: {checkRepositoryExistsContext.LocalRepositoryExists}");
                    Console.WriteLine($"Remote repository for {repositoryContext.RepositoryName}/{repositoryContext.RepositoryOwnerName} exists: {checkRepositoryExistsContext.LocalRepositoryExists}");

                    var message = $"{repositoryContext.RepositoryName}/{repositoryContext.RepositoryOwnerName}: repository exists.\n\tDirectory path: {repositoryContext.RepositoryDirectoryPath}";

                    Console.WriteLine(message);

                    throw new Exception(message);
                }

                return Task.CompletedTask;
            };
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Generate_Repository<TRepositoryContext, TGitHubContext>(
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> gitHubContextPropertiesRequired,
            out ContextPropertiesSet<TRepositoryContext, IsSet<IHasRepository>> repositoryContextPropertiesSet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists
            ) checkedResults
            )
            where TGitHubContext :
            IHasGitHubClient,
            N001.IHasAuthentication
            where TRepositoryContext :
            IHasRepositorySpecification,
            IHasRepositoryDirectoryPath,
            IWithRepository
        {
            var output = Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                // Create the repository, both remote and local.
                // Create the remote repository.
                Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent<TRepositoryContext, TGitHubContext>(
                    (gitHubContextPropertiesRequired.PropertiesSet.GitHubClientSet, repositoryContextPropertiesRequired.PropertiesSet.RepositorySpecificationSet),
                    out var repositorySet,
                    out var checkedGitHubRepositoryExists
                ),
                // Create the local repository.
                Instances.GitContextOperations.Clone_ToLocalRepository<TRepositoryContext, TGitHubContext>(
                    (repositorySet, gitHubContextPropertiesRequired.PropertiesSet.GitHubAuthenticationSet, repositoryContextPropertiesRequired.PropertiesSet.RepositoryDirectoryPathSet),
                    out var checkedLocalRepositoryExists
                )
            );

            repositoryContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                repositorySet);

            checkedResults = (
                checkedGitHubRepositoryExists,
                checkedLocalRepositoryExists
                );

            return output;
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Generate_Repository<TRepositoryContext, TGitHubContext>(
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> gitHubContextPropertiesRequired,
            out ContextPropertiesSet<TRepositoryContext, IsSet<IHasRepository>> repositoryContextPropertiesSet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists,
            IChecked<IFileExists> GitIgnoreFileExists
            ) checkedResults
            )
            where TGitHubContext :
            IHasGitHubClient,
            N001.IHasAuthentication
            where TRepositoryContext :
            IHasRepositorySpecification,
            IHasRepositoryDirectoryPath,
            IWithRepository
        {
            var output = Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                this.Generate_Repository<TRepositoryContext, TGitHubContext>(
                    repositoryContextPropertiesRequired,
                    gitHubContextPropertiesRequired,
                    out repositoryContextPropertiesSet,
                    out (
                    IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                    IChecked<ILocalRepositoryExists> LocalRepositoryExists
                    ) checkedResults_Inner),
                Instances.ContextOperations.In_ContextSet_AB_A<TRepositoryContext, TGitHubContext>(
                    this.Add_GitIgnoreFile<TRepositoryContext>(
                        repositoryContextPropertiesRequired.PropertiesSet.RepositoryDirectoryPathSet,
                        out var checkedGitIgnoreFileExists))
            );

            checkedResults = (
                checkedResults_Inner.GitHubRepositoryExists,
                checkedResults_Inner.LocalRepositoryExists,
                checkedGitIgnoreFileExists
                );

            return output;
        }

        public Func<TParentContextSet, Task> In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
            // Most important argument, first.
            bool allowDeletionIfExists,
            IDirectionalIsomorphism<TParentContextSet, TRepositoryContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TRepositoryContextSet> repositoryContextSetSpecifier,
            out TypeSpecifier<TRepositoryContext> repositoryContextSpecifier,
            RepositorySpecification repositorySpecification,
            ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesRequired,
            out ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                IsSet<IHasRepository> RepositorySet,
                IsSet<IHasRepositoryUrl> RepositoryUrlSet)> repositoryContextPropertiesSet,
            out (
                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                IChecked<IFileExists> GitIgnoreFileExists) checkedRepositoryResults,
            IEnumerable<Func<TRepositoryContextSet, TRepositoryContext, Task>> operations)
            where TRepositoryContextSet : IHasContext<TApplicationContext>, IWithContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TApplicationContext>
            where TApplicationContext : IHasGitHubClient, IHasGitHubAuthor, N001.IHasAuthentication
            where TRepositoryContext : IWithRepositorySpecification, IHasRepositoryName, IHasRepositoryOwnerName, IWithRepositoryDirectoryPath, IWithRepository, IWithRepositoryUrl, new()
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TRepositoryContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out _,
                o.In_Context_OfContextSet<TRepositoryContextSet, TRepositoryContext>(
                    out repositoryContextSetSpecifier,
                    out repositoryContextSpecifier,
                    o.Construct_Context_OfContextSet<TRepositoryContextSet, TRepositoryContext>(
                        Instances.RepositoryContextOperations.Set_RepositoryProperties<TRepositoryContext>(repositorySpecification,
                            out (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                            ) repositorySpecificationPropertiesSet).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ),
                    this.Regenerate_Repository_OrExceptionIfExists<TRepositoryContextSet, TRepositoryContext, TApplicationContext>(
                        allowDeletionIfExists,
                        Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                            repositorySpecificationPropertiesSet.RepositoryNameSet,
                            repositorySpecificationPropertiesSet.RepositoryOwnerNameSet,
                            repositorySpecificationPropertiesSet.RepositoryDirectoryPathSet),
                        Instances.ContextOperator.Get_ContextPropertiesSet<TApplicationContext>().For(
                            applicationContextPropertiesRequired.PropertiesSet.GitHubClientSet),
                        this.Generate_Repository<TRepositoryContext, TApplicationContext>(
                            Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                                repositorySpecificationPropertiesSet.RepositorySpecificationSet,
                                repositorySpecificationPropertiesSet.RepositoryDirectoryPathSet),
                            Instances.ContextOperator.Get_ContextPropertiesSet<TApplicationContext>().For(
                                applicationContextPropertiesRequired.PropertiesSet.GitHubClientSet,
                                applicationContextPropertiesRequired.PropertiesSet.GitHubAuthenticationSet),
                            out ContextPropertiesSet<TRepositoryContext, IsSet<IHasRepository>> repositoryContextPropertiesSet_Inner,
                            out checkedRepositoryResults
                        ).In_ContextSet(repositoryContextSetSpecifier)
                    ).In_ContextSetAndContext(repositoryContextSetSpecifier, repositoryContextSpecifier),
                    Instances.RepositoryContextOperations.Set_RepositoryUrl<TRepositoryContext>(
                        repositoryContextPropertiesSet_Inner.PropertiesSet,
                        out var repositoryUrlSet).In_ContextSetWithContext(repositoryContextSetSpecifier),
                    Instances.ContextOperations.From(operations)
                )
            );

            repositoryContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                repositorySpecificationPropertiesSet.RepositorySpecificationSet,
                repositorySpecificationPropertiesSet.RepositoryNameSet,
                repositorySpecificationPropertiesSet.RepositoryOwnerNameSet,
                repositorySpecificationPropertiesSet.RepositoryDirectoryPathSet,
                repositoryContextPropertiesSet_Inner.PropertiesSet,
                repositoryUrlSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
            // Most important argument, first.
            bool allowDeletionIfExists,
            IDirectionalIsomorphism<TParentContextSet, TRepositoryContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TRepositoryContextSet> repositoryContextSetSpecifier,
            out TypeSpecifier<TRepositoryContext> repositoryContextSpecifier,
            RepositorySpecification repositorySpecification,
            ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet)> applicationContextPropertiesRequired,
            out ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                IsSet<IHasRepository> RepositorySet,
                IsSet<IHasRepositoryUrl> RepositoryUrlSet)> repositoryContextPropertiesSet,
            out (
                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                IChecked<IFileExists> GitIgnoreFileExists) checkedRepositoryResults,
            params Func<TRepositoryContextSet, TRepositoryContext, Task>[] operations)
            where TRepositoryContextSet : IHasContext<TApplicationContext>, IWithContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TApplicationContext>
            where TApplicationContext : IHasGitHubClient, IHasGitHubAuthor, N001.IHasAuthentication
            where TRepositoryContext : IWithRepositorySpecification, IHasRepositoryName, IHasRepositoryOwnerName, IWithRepositoryDirectoryPath, IWithRepository, IWithRepositoryUrl, new()
            => this.In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
                allowDeletionIfExists,
                parentContextSetIsomorphism,
                out repositoryContextSetSpecifier,
                out repositoryContextSpecifier,
                repositorySpecification,
                applicationContextPropertiesRequired,
                out repositoryContextPropertiesSet,
                out checkedRepositoryResults,
                operations.AsEnumerable());

        public Func<TContext, Task> Add_GitIgnoreFile<TContext>(
            IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet,
            out IChecked<IFileExists> gitIgnoreFileExists)
            where TContext : IHasRepositoryDirectoryPath
        {
            gitIgnoreFileExists = Checked.Check<IFileExists>();

            return context =>
            {
                var gitIgnoreSourceFilePath = Instances.FilePaths.GitIgnoreTemplateFilePath;
                var gitIgnoreDestinationFilePath = Instances.RepositoryPathsOperator.Get_GitIgnoreFilePath(context.RepositoryDirectoryPath);

                Instances.FileSystemOperator.Copy_File(
                    gitIgnoreSourceFilePath,
                    gitIgnoreDestinationFilePath);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Clear_Repository<TContext>(
            (IsSet<IHasRepositoryName>, IsSet<IHasRepositoryOwnerName>, IsSet<IHasGitHubClient>, IsSet<IHasRepositoryDirectoryPath>) propertiesRequired,
            out (IChecked<IGitHubRepositoryDoesNotExist> GitHubRepositoryDoesNotExist, IChecked<ILocalRepositoryDoesNotExist> LocalRepositoryDoesNotExist) @checked)
            where TContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasGitHubClient,
            IHasRepositoryDirectoryPath
        {
            @checked = (Checked.Check<IGitHubRepositoryDoesNotExist>(), Checked.Check<ILocalRepositoryDoesNotExist>());

            return Instances.ContextOperations.In_Context<TContext>(
                // Delete the remote repository, if it exists.
                Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<TContext>(
                    (context, gitHubRepositoryExisted) =>
                    {
                        Console.WriteLine($"{gitHubRepositoryExisted}: GitHub-repository-existed, {context.RepositoryOwnerName}/{context.RepositoryName}");

                        return Task.CompletedTask;
                    }
                ),
                // Delete the local repository, if it exists.
                Instances.LocalRepositoryContextOperations.Delete_LocalRepositoryDirectory_Idempotent<TContext>(
                    (context, directoryExisted) =>
                    {
                        Console.WriteLine($"{directoryExisted}: local-repository-directory-existed, {context.RepositoryOwnerName}/{context.RepositoryName}\n\t{context.RepositoryDirectoryPath}");

                        return Task.CompletedTask;
                    }
                )
            );
        }

        public Func<TRepositoryContext, Task> Clear_Repository<TRepositoryContext, TGitHubContext>(
            TGitHubContext gitHubContext,
            (IsSet<IHasRepositoryName>, IsSet<IHasRepositoryOwnerName>, IsSet<IHasGitHubClient>, IsSet<IHasRepositoryDirectoryPath>) propertiesRequired,
            out (IChecked<IGitHubRepositoryDoesNotExist> GitHubRepositoryDoesNotExist, IChecked<ILocalRepositoryDoesNotExist> LocalRepositoryDoesNotExist) @checked)
            where TGitHubContext :
            IHasGitHubClient
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
        {
            @checked = (Checked.Check<IGitHubRepositoryDoesNotExist>(), Checked.Check<ILocalRepositoryDoesNotExist>());

            return Instances.ContextOperations.In_Context<TRepositoryContext>(
                // Delete the remote repository, if it exists.
                Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<TRepositoryContext, TGitHubContext>(
                    gitHubContext,
                    (context, gitHubRepositoryExisted) =>
                    {
                        Console.WriteLine($"{gitHubRepositoryExisted}: GitHub-repository-existed, {context.RepositoryOwnerName}/{context.RepositoryName}");

                        return Task.CompletedTask;
                    }
                ),
                // Delete the local repository, if it exists.
                Instances.LocalRepositoryContextOperations.Delete_LocalRepositoryDirectory_Idempotent<TRepositoryContext>(
                    (context, directoryExisted) =>
                    {
                        Console.WriteLine($"{directoryExisted}: local-repository-directory-existed, {context.RepositoryOwnerName}/{context.RepositoryName}\n\t{context.RepositoryDirectoryPath}");

                        return Task.CompletedTask;
                    }
                )
            );
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Clear_Repository<TRepositoryContext, TGitHubContext>(
            (IsSet<IHasRepositoryName>, IsSet<IHasRepositoryOwnerName>, IsSet<IHasGitHubClient>, IsSet<IHasRepositoryDirectoryPath>) propertiesRequired,
            out (IChecked<IGitHubRepositoryDoesNotExist> GitHubRepositoryDoesNotExist, IChecked<ILocalRepositoryDoesNotExist> LocalRepositoryDoesNotExist) @checked)
            where TGitHubContext :
            IHasGitHubClient
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
        {
            @checked = (Checked.Check<IGitHubRepositoryDoesNotExist>(), Checked.Check<ILocalRepositoryDoesNotExist>());

            return Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                // Delete the remote repository, if it exists.
                Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<TRepositoryContext, TGitHubContext>(
                    (context, gitHubRepositoryExisted) =>
                    {
                        Console.WriteLine($"{gitHubRepositoryExisted}: GitHub-repository-existed, {context.RepositoryOwnerName}/{context.RepositoryName}");

                        return Task.CompletedTask;
                    }
                ),
                // Delete the local repository, if it exists.
                Instances.ContextOperations.In_ContextSet_AB_A<TRepositoryContext, TGitHubContext>(
                    Instances.LocalRepositoryContextOperations.Delete_LocalRepositoryDirectory_Idempotent<TRepositoryContext>(
                        (context, directoryExisted) =>
                        {
                            Console.WriteLine($"{directoryExisted}: local-repository-directory-existed, {context.RepositoryOwnerName}/{context.RepositoryName}\n\t{context.RepositoryDirectoryPath}");

                            return Task.CompletedTask;
                        }
                    )
                )
            );
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Clear_Repository<TRepositoryContext, TGitHubContext>(
            ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet)> repositoryContextPropertiesRequired,
            ContextPropertiesSet<TGitHubContext, IsSet<IHasGitHubClient>> gitHubContextPropertiesRequired,
            out (IChecked<IGitHubRepositoryDoesNotExist> GitHubRepositoryDoesNotExist, IChecked<ILocalRepositoryDoesNotExist> LocalRepositoryDoesNotExist) @checked)
            where TGitHubContext :
            IHasGitHubClient
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath
        {
            @checked = (Checked.Check<IGitHubRepositoryDoesNotExist>(), Checked.Check<ILocalRepositoryDoesNotExist>());

            return Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                // Delete the remote repository, if it exists.
                Instances.GitHubClientContextOperations.Delete_Repository_Idempotent<TRepositoryContext, TGitHubContext>(
                    (context, gitHubRepositoryExisted) =>
                    {
                        Console.WriteLine($"{gitHubRepositoryExisted}: GitHub-repository-existed, {context.RepositoryOwnerName}/{context.RepositoryName}");

                        return Task.CompletedTask;
                    }
                ),
                // Delete the local repository, if it exists.
                Instances.ContextOperations.In_ContextSet_AB_A<TRepositoryContext, TGitHubContext>(
                    Instances.LocalRepositoryContextOperations.Delete_LocalRepositoryDirectory_Idempotent<TRepositoryContext>(
                        (context, directoryExisted) =>
                        {
                            Console.WriteLine($"{directoryExisted}: local-repository-directory-existed, {context.RepositoryOwnerName}/{context.RepositoryName}\n\t{context.RepositoryDirectoryPath}");

                            return Task.CompletedTask;
                        }
                    )
                )
            );
        }

        public Func<TContext, Task> In_CloneRepositoryLocallyContext<TContext>(
            // Communicates what properties need to be set.
            out (
                IsSet<IHasRepositoryOwnerName>,
                IsSet<IHasRepositoryName>,
                IsSet<IHasRepositoryUrl>) propertiesSet,
            IEnumerable<Func<CloneRepositoryLocallyContext, Task>> operations)
            where TContext : IHasRepository, IHasRepositoryName, IHasRepositoryOwnerName
        {
            // Strangely, the set-properties tuple does not need to be set?
            // Probably because the tuple is a value-type, and thus has a default value,
            // and the IsSet<T> type is a value type (with no properties to boot!), and thus has a default value.

            return context =>
            {
                var cloneUrl = context.Repository.CloneUrl;

                var childContext = new CloneRepositoryLocallyContext
                {
                    RepositoryName = context.RepositoryName,
                    RepositoryOwnerName = context.RepositoryOwnerName,
                    RepositoryUrl = cloneUrl,
                };

                return Instances.ContextOperator.In_Context(
                    childContext,
                    operations);
            };
        }

        public Func<TContext, Task> In_CloneRepositoryLocallyContext<TContext>(
            out (
                IsSet<IHasRepositoryOwnerName>,
                IsSet<IHasRepositoryName>,
                // Communicates that the repository URL is set.
                IsSet<IHasRepositoryUrl>) propertiesSet,
            params Func<CloneRepositoryLocallyContext, Task>[] operations)
            where TContext : IHasRepository, IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_CloneRepositoryLocallyContext<TContext>(
                out propertiesSet,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            Func<IHasAuthentication, Task> authenticationOutputHandler,
            IEnumerable<Func<GitHubClientedRepositoryContext, Task>> operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            var modifiedOperations = operations.Prepend(
                Instances.GitHubClientContextOperations.In_SetGitHubClientContext<GitHubClientedRepositoryContext>(
                    setGitHubAuthenticationJsonFilePath,
                    Instances.SetGitHubClientContextOperations.Load_Authentication,
                    //async context =>
                    //{
                    //    await authenticationOutputHandler(context);
                    //},
                    authenticationOutputHandler,
                    Instances.SetGitHubClientContextOperations.Set_GitHubClient
                )
            );

            return this.In_GitHubClientContext<TContext>(
                modifiedOperations
            );
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            Func<IHasAuthentication, Task> authenticationOutputHandler,
            params Func<GitHubClientedRepositoryContext, Task>[] operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                authenticationOutputHandler,
                operations.AsEnumerable());
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            IEnumerable<Func<GitHubClientedRepositoryContext, Task>> operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                Instances.Functions.Do_Nothing,
                operations);
        }

        public Func<TContext, Task> In_GitHubClientContext<TContext>(
            Func<IWithGitHubAuthenticationJsonFilePath, Task> setGitHubAuthenticationJsonFilePath,
            params Func<GitHubClientedRepositoryContext, Task>[] operations)
            where TContext : IHasRepositoryName, IHasRepositoryOwnerName
        {
            return this.In_GitHubClientContext<TContext>(
                setGitHubAuthenticationJsonFilePath,
                operations.AsEnumerable());
        }

        public Func<TParentContextSet, Task> In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
            IDirectionalIsomorphism<TParentContextSet, TRepositoryContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TRepositoryContextSet> repositoryContextSetSpecifier,
            out TypeSpecifier<TRepositoryContext> repositoryContextSpecifier,
            RepositorySpecification repositorySpecification,
            ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                )> applicationContextPropertiesSet,
            out ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                IsSet<IHasRepository> RepositorySet,
                IsSet<IHasRepositoryUrl> RepositoryUrlSet
                )> repositoryContextPropertiesSet,
            out (
                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                IChecked<IFileExists> GitIgnoreFileExists
                ) checkedRepository,
            IEnumerable<Func<TRepositoryContextSet, TRepositoryContext, Task>> operations)
            where TRepositoryContextSet : IHasContext<TApplicationContext>, IWithContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TApplicationContext>
            where TApplicationContext : IHasGitHubClient, IHasGitHubAuthor, N001.IHasAuthentication
            where TRepositoryContext : IWithRepositorySpecification, IHasRepositoryName, IHasRepositoryOwnerName, IWithRepositoryDirectoryPath, IWithRepository, IWithRepositoryUrl, new()
        {
            var o = Instances.ContextOperations;

            var output = o.In_ChildContextSet<TRepositoryContextSet, TParentContextSet>(
                parentContextSetIsomorphism,
                out _,
                o.In_Context_OfContextSet<TRepositoryContextSet, TRepositoryContext>(
                    out repositoryContextSetSpecifier,
                    out repositoryContextSpecifier,
                    o.Construct_Context_OfContextSet<TRepositoryContextSet, TRepositoryContext>(
                        Instances.RepositoryContextOperations.Set_RepositoryProperties<TRepositoryContext>(repositorySpecification,
                            out (
                            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                            IsSet<IHasRepositoryName> RepositoryNameSet,
                            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                            ) repositorySpecificationPropertiesSet).In_ContextSetWithContext(repositoryContextSetSpecifier)
                    ),
                    Instances.RepositoryContextOperations.Regenerate_Repository<TRepositoryContext, TApplicationContext>((
                        repositorySpecificationPropertiesSet.RepositorySpecificationSet,
                        repositorySpecificationPropertiesSet.RepositoryNameSet,
                        repositorySpecificationPropertiesSet.RepositoryOwnerNameSet,
                        applicationContextPropertiesSet.PropertiesSet.GitHubClientSet,
                        applicationContextPropertiesSet.PropertiesSet.GitHubAuthenticationSet,
                        repositorySpecificationPropertiesSet.RepositoryDirectoryPathSet),
                        out var repositorySet,
                        out checkedRepository).In_ContextSetWithContext(repositoryContextSetSpecifier),
                    Instances.RepositoryContextOperations.Set_RepositoryUrl<TRepositoryContext>(
                        repositorySet,
                        out var repositoryUrlSet).In_ContextSetWithContext(repositoryContextSetSpecifier),
                    Instances.ContextOperations.From(operations)
                )
            );

            repositoryContextPropertiesSet = Instances.ContextOperator.Get_ContextPropertiesSet<TRepositoryContext>().For(
                repositorySpecificationPropertiesSet.RepositorySpecificationSet,
                repositorySpecificationPropertiesSet.RepositoryNameSet,
                repositorySpecificationPropertiesSet.RepositoryOwnerNameSet,
                repositorySpecificationPropertiesSet.RepositoryDirectoryPathSet,
                repositorySet,
                repositoryUrlSet);

            return output;
        }

        public Func<TParentContextSet, Task> In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
            IDirectionalIsomorphism<TParentContextSet, TRepositoryContextSet> parentContextSetIsomorphism,
            out ContextSetSpecifier<TRepositoryContextSet> repositoryContextSetSpecifier,
            out TypeSpecifier<TRepositoryContext> repositoryContextSpecifier,
            RepositorySpecification repositorySpecification,
            ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                )> applicationContextPropertiesSet,
            out ContextPropertiesSet<TRepositoryContext, (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet,
                IsSet<IHasRepository> RepositorySet,
                IsSet<IHasRepositoryUrl> RepositoryUrlSet
                )> repositoryContextPropertiesSet,
            out (
                IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                IChecked<IFileExists> GitIgnoreFileExists
                ) checkedRepository,
            params Func<TRepositoryContextSet, TRepositoryContext, Task>[] operations)
            where TRepositoryContextSet : IHasContext<TApplicationContext>, IWithContext<TRepositoryContext>, new()
            where TParentContextSet : IHasContext<TApplicationContext>
            where TApplicationContext : IHasGitHubClient, IHasGitHubAuthor, N001.IHasAuthentication
            where TRepositoryContext : IWithRepositorySpecification, IHasRepositoryName, IHasRepositoryOwnerName, IWithRepositoryDirectoryPath, IWithRepository, IWithRepositoryUrl, new()
            => this.In_RegeneratedRepositoryContext<TRepositoryContextSet, TParentContextSet, TRepositoryContext, TApplicationContext>(
                parentContextSetIsomorphism,
                out repositoryContextSetSpecifier,
                out repositoryContextSpecifier,
                repositorySpecification,
                applicationContextPropertiesSet,
                out repositoryContextPropertiesSet,
                out checkedRepository,
                operations.AsEnumerable());

        public Func<Context000, Task> In_RegeneratedRepositoryContext(
                RepositorySpecification repositorySpecification,
                (
                IsSet<IHasGitHubClient> GitHubClientSet,
                IsSet<IHasGitHubAuthor> GitHubAuthorSet,
                IsSet<N001.IHasAuthentication> GitHubAuthenticationSet
                ) applicationContextPropertiesSet,
                out (
                IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
                IsSet<IHasRepositoryName> RepositoryNameSet,
                IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
                IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
                ) repositoryPropertiesSet,
                out IsSet<IHasRepository> repositorySet,
                params Func<Context001, Context000, Task>[] operations)
        {
            var o = Instances.ContextOperations;

            var contextSet = Instances.ContextOperator.Get_ContextSetSpecifier<Context001, Context000>();

            return o.In_ContextSet_A_BA<Context001, Context000>(
                o.Construct_Context_B_BA<Context001, Context000>(
                    Instances.ContextOperations.Set_ContextProperties<Context001, Context000>((applicationContextPropertiesSet.GitHubAuthorSet, applicationContextPropertiesSet.GitHubAuthenticationSet),
                        out var repositoryContextPropertiesSet),
                    Instances.RepositoryContextOperations.Set_RepositoryProperties<Context001>(repositorySpecification,
                        out repositoryPropertiesSet).In(contextSet),
                    Instances.RepositoryContextOperations.Regenerate_Repository<Context001, Context000>((
                        repositoryPropertiesSet.RepositorySpecificationSet,
                        repositoryPropertiesSet.RepositoryNameSet,
                        repositoryPropertiesSet.RepositoryOwnerNameSet,
                        applicationContextPropertiesSet.GitHubClientSet,
                        applicationContextPropertiesSet.GitHubAuthenticationSet,
                        repositoryPropertiesSet.RepositoryDirectoryPathSet),
                        out repositorySet,
                        out (
                        IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                        IChecked<ILocalRepositoryExists> LocalRepositoryExists,
                        IChecked<IFileExists> GitIgnoreFileExists
                        ) checkedRepository)
                ),
                operations
            );
        }

        public Func<TContext, Task> Set_RepositoryUrl<TContext>(
            IsSet<IHasRepository> repositorySet,
            out IsSet<IHasRepositoryUrl> repositoryUrlSet)
            where TContext : IWithRepositoryUrl, IHasRepository
        {
            return context =>
            {
                context.RepositoryUrl = Instances.RepositoryOperator.Get_RepositoryUrl(context.Repository);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_RepositoryDirectoryPath<TContext>(
            (IsSet<IHasRepositoryOwnerName>, IsSet<IHasRepositoryName>) propertiesRequired,
            out IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet)
            where TContext : IWithRepositoryDirectoryPath, IHasRepositoryOwnerName, IHasRepositoryName
        {
            return async context =>
            {
                await Instances.ContextOperator.In_Context(
                    () =>
                    {
                        var childContext = new LocalRepositoryContext
                        {
                            RepositoryOwnerName = context.RepositoryOwnerName,
                            RepositoryName = context.RepositoryName,
                        };

                        return Task.FromResult(childContext);
                    },
                    Instances.CloneRepositoryLocallyContextOperations.Set_RepositoriesDirectoryPath,
                    Instances.CloneRepositoryLocallyContextOperations.Set_RepositoryDirectoryPath,
                    childContext =>
                    {
                        context.RepositoryDirectoryPath = childContext.RepositoryDirectoryPath;

                        return Task.CompletedTask;
                    }
                );
            };
        }

        public Func<TRepositoryContext, TApplicationContext, Task> Push_AllFiles<TRepositoryContext, TApplicationContext>(
            string commitMessage,
            ContextPropertiesSet<TRepositoryContext, IsSet<IHasRepositoryDirectoryPath>> repositoryContextPropertiesSet,
            ContextPropertiesSet<TApplicationContext, (
                IsSet<IHasGitHubAuthor> gitHubAuthorSet,
                IsSet<N001.IHasAuthentication> AuthenticationSet)> applicationContextPropertiesSet,
            out IChecked<ILocalChangesPushedToRemote> checkedLocalChangesPushedToRemote)
            where TRepositoryContext : IHasRepositoryDirectoryPath
            where TApplicationContext : IHasGitHubAuthor, N001.IHasAuthentication
        {
            checkedLocalChangesPushedToRemote = Checked.Check<ILocalChangesPushedToRemote>();

            return (repositoryContext, applicationContext) =>
            {
                Instances.GitOperator.Push_WithStageAndCommit(
                    repositoryContext.RepositoryDirectoryPath,
                    commitMessage,
                    applicationContext.GitHubAuthor.Name,
                    applicationContext.GitHubAuthor.EmailAddress,
                    applicationContext.Authentication.Username,
                    applicationContext.Authentication.Password);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Regenerate_Repository<TContext>(
            (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerSet,
            IsSet<IHasGitHubClient> GitHubClientSet,
            // Needed since LibGit2Sharp is different from Octokit. TODO: checkout if Octokit has a clone functionality.
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet,
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            ) propertiesRequired,
            out IsSet<IHasRepository> propertiesSet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists
            ) resultsChecked
            )
            where TContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasGitHubClient,
            IHasRepositoryDirectoryPath,
            IHasRepositorySpecification,
            IWithRepository,
            N001.IHasAuthentication
        {
            resultsChecked = (Checked.Check<IGitHubRepositoryExists>(), Checked.Check<ILocalRepositoryExists>());

            return Instances.ContextOperations.In_Context<TContext>(
                // Delete both the remote and local repositories, if they exist.
                this.Clear_Repository<TContext>(
                    (propertiesRequired.RepositoryNameSet, propertiesRequired.RepositoryOwnerSet, propertiesRequired.GitHubClientSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out _),
                // Create the repository, both remote and local.
                // Create the remote repository.
                Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent<TContext>(
                    (propertiesRequired.GitHubClientSet, propertiesRequired.RepositorySpecificationSet),
                    out var repositorySet,
                    out _
                ),
                // Create the local repository.
                Instances.GitContextOperations.Clone_ToLocalRepository<TContext>(
                    (repositorySet, propertiesRequired.GitHubAuthenticationSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out _
                )
            );
        }

        public Func<TRepositoryContext, Task> Regenerate_Repository<TRepositoryContext, TGitHubContext>(
            TGitHubContext gitHubContext,
            (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerSet,
            IsSet<IHasGitHubClient> GitHubClientSet,
            // Needed since LibGit2Sharp is different from Octokit. TODO: checkout if Octokit has a clone functionality.
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet,
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            ) propertiesRequired,
            out IsSet<IHasRepository> repositorySet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists
            ) resultsChecked
            )
            where TGitHubContext:
            IHasGitHubClient,
            N001.IHasAuthentication
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath,
            IHasRepositorySpecification,
            IWithRepository
        {
            resultsChecked = (Checked.Check<IGitHubRepositoryExists>(), Checked.Check<ILocalRepositoryExists>());

            return Instances.ContextOperations.In_Context<TRepositoryContext>(
                // Delete both the remote and local repositories, if they exist.
                this.Clear_Repository<TRepositoryContext, TGitHubContext>(
                    gitHubContext,
                    (propertiesRequired.RepositoryNameSet, propertiesRequired.RepositoryOwnerSet, propertiesRequired.GitHubClientSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out _),
                // Create the repository, both remote and local.
                // Create the remote repository.
                Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent<TRepositoryContext, TGitHubContext>(
                    gitHubContext,
                    (propertiesRequired.GitHubClientSet, propertiesRequired.RepositorySpecificationSet),
                    out repositorySet,
                    out _
                ),
                // Create the local repository.
                Instances.GitContextOperations.Clone_ToLocalRepository<TRepositoryContext, TGitHubContext>(
                    gitHubContext,
                    (repositorySet, propertiesRequired.GitHubAuthenticationSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out _
                )
            );
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Regenerate_Repository<TRepositoryContext, TGitHubContext>(
            (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerSet,
            IsSet<IHasGitHubClient> GitHubClientSet,
            // Needed since LibGit2Sharp is different from Octokit. TODO: checkout if Octokit has a clone functionality.
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet,
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            ) propertiesRequired,
            out IsSet<IHasRepository> repositorySet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists,
            IChecked<IFileExists> GitIgnoreFileExists
            ) resultsChecked
            )
            where TGitHubContext :
            IHasGitHubClient,
            N001.IHasAuthentication
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath,
            IHasRepositorySpecification,
            IWithRepository
        {
            var output = Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                this.Regenerate_Repository<TRepositoryContext, TGitHubContext>(
                    propertiesRequired,
                    out repositorySet,
                    out (
                    IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
                    IChecked<ILocalRepositoryExists> LocalRepositoryExists
                    ) checkedResults),
                Instances.ContextOperations.In_ContextSet_AB_A<TRepositoryContext, TGitHubContext>(
                    this.Add_GitIgnoreFile<TRepositoryContext>(propertiesRequired.RepositoryDirectoryPathSet,
                        out var checkedGitIgnoreFileExists))
            );

            resultsChecked = (
                checkedResults.GitHubRepositoryExists,
                checkedResults.LocalRepositoryExists,
                checkedGitIgnoreFileExists
                );

            return output;
        }

        public Func<TRepositoryContext, TGitHubContext, Task> Regenerate_Repository<TRepositoryContext, TGitHubContext>(
            (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerSet,
            IsSet<IHasGitHubClient> GitHubClientSet,
            // Needed since LibGit2Sharp is different from Octokit. TODO: checkout if Octokit has a clone functionality.
            IsSet<N001.IHasAuthentication> GitHubAuthenticationSet,
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            ) propertiesRequired,
            out IsSet<IHasRepository> repositorySet,
            out (
            IChecked<IGitHubRepositoryExists> GitHubRepositoryExists,
            IChecked<ILocalRepositoryExists> LocalRepositoryExists
            ) resultsChecked
            )
            where TGitHubContext :
            IHasGitHubClient,
            N001.IHasAuthentication
            where TRepositoryContext :
            IHasRepositoryName,
            IHasRepositoryOwnerName,
            IHasRepositoryDirectoryPath,
            IHasRepositorySpecification,
            IWithRepository
        {
            var output = Instances.ContextOperations.In_ContextSet<TRepositoryContext, TGitHubContext>(
                // Delete both the remote and local repositories, if they exist.
                this.Clear_Repository<TRepositoryContext, TGitHubContext>(
                    (propertiesRequired.RepositoryNameSet, propertiesRequired.RepositoryOwnerSet, propertiesRequired.GitHubClientSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out _),
                // Create the repository, both remote and local.
                // Create the remote repository.
                Instances.GitHubClientContextOperations.Create_Repository_NonIdempotent<TRepositoryContext, TGitHubContext>(
                    (propertiesRequired.GitHubClientSet, propertiesRequired.RepositorySpecificationSet),
                    out repositorySet,
                    out var checkedGitHubRepositoryExists
                ),
                // Create the local repository.
                Instances.GitContextOperations.Clone_ToLocalRepository<TRepositoryContext, TGitHubContext>(
                    (repositorySet, propertiesRequired.GitHubAuthenticationSet, propertiesRequired.RepositoryDirectoryPathSet),
                    out var checkedLocalRepositoryExists
                )
            );

            resultsChecked = (
                checkedGitHubRepositoryExists,
                checkedLocalRepositoryExists
                );

            return output;
        }

        public Func<TContext, Task> Set_RepositoryProperties<TContext>(
            RepositorySpecification repositorySpecification,
            out (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet
            ) propertiesSet
            )
            where TContext : IWithRepositorySpecification, IHasRepositoryName, IHasRepositoryOwnerName
        {
            return context =>
            {
                context.RepositorySpecification = repositorySpecification;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_RepositoryProperties<TContext>(
            RepositorySpecification repositorySpecification,
            out (
            IsSet<IHasRepositorySpecification> RepositorySpecificationSet,
            IsSet<IHasRepositoryName> RepositoryNameSet,
            IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet,
            IsSet<IHasRepositoryDirectoryPath> RepositoryDirectoryPathSet
            ) propertiesSet
            )
            where TContext : IWithRepositorySpecification, IWithRepositoryDirectoryPath, IHasRepositoryName, IHasRepositoryOwnerName
        {
            return Instances.ContextOperations.In_Context(
                this.Set_RepositoryProperties<TContext>(
                    repositorySpecification,
                    // Use explicit type for tuple to select correct method.
                    out (IsSet<IHasRepositorySpecification> RepositorySpecificationSet, IsSet<IHasRepositoryName> RepositoryNameSet, IsSet<IHasRepositoryOwnerName> RepositoryOwnerNameSet) repositoryPropertiesSet
                ),
                this.Set_RepositoryDirectoryPath<TContext>(
                    (repositoryPropertiesSet.RepositoryOwnerNameSet, repositoryPropertiesSet.RepositoryNameSet),
                    out _
                )
            );
        }

        public Func<TContext, Task> Set_RepositoryProperties<TContext, TParentContext>(
            TParentContext parentContext,
            IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathRequired,
            out IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet)
            where TParentContext : IHasRepositoryDirectoryPath
            where TContext : IWithRepositoryDirectoryPath
        {
            return context =>
            {
                context.RepositoryDirectoryPath = parentContext.RepositoryDirectoryPath;

                return Task.CompletedTask;
            };
        }

        public Func<TContext, TRepositoryContext, Task> Set_RepositoryProperties<TContext, TRepositoryContext>(
            IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathRequired,
            out IsSet<IHasRepositoryDirectoryPath> repositoryDirectoryPathSet)
            where TRepositoryContext : IHasRepositoryDirectoryPath
            where TContext : IWithRepositoryDirectoryPath
        {
            return (context, repositoryContext) =>
            {
                context.RepositoryDirectoryPath = repositoryContext.RepositoryDirectoryPath;

                return Task.CompletedTask;
            };
        }

        public Task Verify_IsWorking<TContext>(TContext context)
            where TContext : IHasRepository
        {
            return Task.CompletedTask;
        }
    }
}
