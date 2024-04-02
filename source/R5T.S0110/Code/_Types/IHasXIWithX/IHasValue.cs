using System;

using R5T.T0240;


namespace R5T.S0110
{
    /// <summary>
    /// An empty general IHasX interface for use when a <see cref="T0221.IsSet{T}"/> value is required, but the IHasX interface for that value has not been created yet.
    /// </summary>
    [HasXMarker]
    public interface IHasValue : IHasXMarker
    {
        
    }
}
