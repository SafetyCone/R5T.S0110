using System;
using System.Threading.Tasks;

using R5T.T0142;


namespace R5T.S0110
{
    /// <summary>
    /// Indicates that a two types <typeparamref name="TSource"/> and <typeparamref name="TDestination"/> have an isomorphism.
    /// </summary>
    /// <typeparam name="TSource">The source type.</typeparam>
    /// <typeparam name="TDestination">The destination type.</typeparam>
    /// <remarks>
    /// Copy operations were chosen to be asynchronous for full applicability.
    /// </remarks>
    [UtilityTypeMarker, TypeMarker]
    public interface IDirectionalIsomorphism<TSource, TDestination>
    {
        /// <summary>
        /// Perform a general copy of state from source to destination type, with the specifics of the copy left up to implementations.
        /// </summary>
        public Task Copy_From(TSource source, TDestination destination);
    }
}
