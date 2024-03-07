using System;

using Octokit;

using R5T.T0132;


namespace R5T.S0110
{
    [FunctionalityMarker]
    public partial interface IRepositoryOperator : IFunctionalityMarker,
        L0080.F001.IRepositoryOperator,
        L0083.F001.IRepositoryOperator
    {
        public string Get_RepositoryUrl(Repository repository)
        {
            var output = repository.HtmlUrl;

            return output;
        }
    }
}
