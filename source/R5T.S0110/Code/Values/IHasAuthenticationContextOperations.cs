using System;
using System.Threading.Tasks;

using R5T.T0131;
//using R5T.T0144;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker, ValuesMarker]
    public partial interface IHasAuthenticationContextOperations : IValuesMarker
    {
        public Func<IHasAuthentication, Task> Set_AuthenticationTo_Better(IWithAuthentication withAuthentication)
            => Instances.HasXContextOperations.Set_To<IWithAuthentication, IHasAuthentication, T0144.Authentication>(withAuthentication);

        //public Func<IHasAuthentication, Task> Set_AuthenticationTo(IWithAuthentication withAuthentication)
        //{
        //    return hasAuthentication =>
        //    {
        //        withAuthentication.Authentication = hasAuthentication.Authentication;

        //        return Task.CompletedTask;
        //    };
        //}

        public Func<IWithAuthentication, Task> Set_AuthenticationFrom_Better(IHasAuthentication hasAuthentication)
            => Instances.HasXContextOperations.Set_From<IHasAuthentication, IWithAuthentication, T0144.Authentication>(hasAuthentication);

        //public Func<IWithAuthentication, Task> Set_AuthenticationFrom(IHasAuthentication hasAuthentication)
        //{
        //    return withAuthentication =>
        //    {
        //        withAuthentication.Authentication = hasAuthentication.Authentication;

        //        return Task.CompletedTask;
        //    };
        //}
    }
}
