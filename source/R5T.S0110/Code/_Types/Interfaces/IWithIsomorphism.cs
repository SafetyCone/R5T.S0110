using System;


//namespace R5T.S0110
//{
//    /// <summary>
//    /// Interface expressing that a type has an isomophic relationship (read-write) to another type.
//    /// </summary>
//    /// <remarks>
//    /// <para>NOTE: not an IWithX interface. This interface is functional, not descriptive.</para>
//    /// <para>The "with" prefix was chosen to since it suggests the isomorphism is read-write from the perspective of the active object.
//    /// I.e. "this" can copy to the other, so "this" is modifying the other with an isomorphism.</para>
//    /// <para>Generall, all types will use <see cref="IWithIsomorphism{T}"/> instead of <see cref="IHasIsomorphism{T}"/>, but the two are separate in order to assuage concerns about
//    /// isomorphism interactions modifying the source instance.</para>
//    /// <para>
//    /// Synchronous was chosen over asynchronous, since there really should be very little "translation" required for an isomorphism.
//    /// </para>
//    /// </remarks>
//    public interface IWithIsomorphism<T>
//        : IHasIsomorphism<T>
//    {
//        public void Copy_To(T other);
//    }
//}


//namespace R5T.S0110.N001
//{
//    public interface IWithIsomorphism<T>
//    {
//        public void Copy_From(IWithIsomorphism<T> other);
//        public void Copy_To(IWithIsomorphism<T> other);
//    }
//}
