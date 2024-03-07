using System;

using R5T.T0143;


namespace R5T.S0110
{
    /// <summary>
    /// Attribute indicating a class is a context set.
    /// The marker attribute is useful for surveying context set classes and building a catalogue of those classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    [MarkerAttributeMarker]
    public class ContextSetMarkerAttribute : Attribute,
        IMarkerAttributeMarker
    {
        /// <summary>
        /// Allows specifying that a class is *not* a context set.
        /// This is useful for marking classes that end up canonical context set code file locations, but are not context set classes.
        /// </summary>
        public bool IsContextSet { get; }


#pragma warning disable IDE0290 // Use primary constructor
        public ContextSetMarkerAttribute(
#pragma warning restore IDE0290 // Use primary constructor
            bool isContextSet = true)
        {
            this.IsContextSet = isContextSet;
        }
    }
}
