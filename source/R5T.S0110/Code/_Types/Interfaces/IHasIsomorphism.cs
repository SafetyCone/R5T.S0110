using System;


//namespace R5T.S0110
//{
//    /// <summary>
//    /// Interface expressing that a type is has an isomophic relationship (read-only) to another type.
//    /// </summary>
//    /// <remarks>
//    /// <para>NOTE: not an IHasX interface. This interface is functional, not descriptive.</para>
//    /// <para>The "has" prefix was chosen to since it suggests the isomorphism is read-only from the perspective of the active object.
//    /// I.e. "this" is copying from the other, so "this" has an isomorphism to the other.</para>
//    /// <para>
//    /// Synchronous was chosen over asynchronous, since there really should be very little "translation" required for an isomorphism.
//    /// </para>
//    /// </remarks>
//    /// <typeparam name="T">Frequently self-referential (where T is specified as the type implementing the interface), but also for base types.</typeparam>
//    public interface IHasIsomorphism<T>
//    {
//        public void Copy_From(T other);
//    }
//}
