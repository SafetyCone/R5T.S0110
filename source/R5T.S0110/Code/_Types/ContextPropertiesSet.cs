using System;


namespace R5T.S0110
{
    /// <summary>
    /// Empty class (to allow null values) providing the dummy <typeparamref name="TContext"/> type parameter.
    /// </summary>
    public class ContextPropertiesSet<TContext>
    {
        
    }


    /// <summary>
    /// Allows pairing a context type to a tuple of properties.
    /// </summary>
    /// <remarks>
    /// The <typeparamref name="TPropertiesSetTuple"/> should be a tuple of multiple named <see cref="T0221.IsSet{T}"/> values.
    /// </remarks>
    public struct ContextPropertiesSet<TContext, TPropertiesSetTuple>
    {
        public TPropertiesSetTuple PropertiesSet { get; set; }
    }
}
