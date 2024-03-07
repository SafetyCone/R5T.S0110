using System;
using System.Threading.Tasks;

using R5T.T0142;


namespace R5T.S0110
{
    [UtilityTypeMarker, TypeMarker]
    public class FunctionBasedDirectionalIsomorphism<TSource, TDestination> : IDirectionalIsomorphism<TSource, TDestination>
    {
        public Func<TSource, TDestination, Task> CopyMethod { get; }


#pragma warning disable IDE0290 // Use primary constructor
        public FunctionBasedDirectionalIsomorphism(Func<TSource, TDestination, Task> copyMethod)
#pragma warning restore IDE0290 // Use primary constructor
        {
            this.CopyMethod = copyMethod;
        }

        public Task Copy_From(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }
    }
}
