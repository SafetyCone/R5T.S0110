using System;
using System.Threading.Tasks;

using R5T.T0142;


namespace R5T.S0110
{
    /// <summary>
    /// A bi-directional isomorphism between two types.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <remarks>
    /// For a uni-directional isomorphism between two types, see <see cref="IDirectionalIsomorphism{TSource, TDestination}"/>.
    /// </remarks>
    [UtilityTypeMarker, TypeMarker]
    public interface IIsomorphism<T1, T2>
    {
        /// <summary>
        /// Copy from <typeparamref name="T1"/> to <typeparamref name="T2"/>.
        /// </summary>
        public Task Copy_From(T1 value1, T2 value2);

        /// <summary>
        /// Copy from <typeparamref name="T2"/> to <typeparamref name="T1"/>.
        /// </summary>
        public Task Copy_To(T1 value1, T2 value2);
    }
}
