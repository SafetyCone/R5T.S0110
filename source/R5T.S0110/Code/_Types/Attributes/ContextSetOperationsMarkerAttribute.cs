using System;

using R5T.T0143;


namespace R5T.S0110
{
    /// <summary>
    /// <para>Context set operation interface names should be <b>plural</b>. Example: "IRepositoryContextOperations".</para>
    /// Attribute indicating an interface contains context set operation values (methods and properties).
    /// Context set perations are implemented as either:
    /// <list type="number">
    /// <item>
    /// Methods with a single generic TContextSet context type parameter, taking in a single input of TContextSet type,
    /// and producing either Task (asynchronous operations, the default) or void (synchronous operations).
    /// </item>
    /// <item>
    /// Methods with a generic TContextSet context type parameter, and zero or more other type parameters, taking in zero or more inputs that are generally <em>not</em> of TContextSet type,
    /// producing a closure of the type Funct&lt;TContextSet, Task&gt; (asynchronous operations, the default) or Action&lt;TContextSet&gt; (synchronous operations).
    /// </item>
    /// <item>
    /// A non-generic type property (because properties cannot be generic) of the type
    /// Funct&lt;ContextType, Task&gt; (asynchronous operations, the default) or Action&lt;ContextType&gt; (synchronous operations) that performs the work of specifying the TContextSet type.
    /// </item>
    /// </list>
    /// <para>Context set operation instance interface types should <em>not</em> be generic in the TContext type! The generic TContext type should be reserved for the individual methods.</para>
    /// The marker attribute is useful for surveying context set operation values classes and building a catalogue of context set operation values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    [MarkerAttributeMarker]
    public class ContextSetOperationsMarkerAttribute : Attribute,
        IMarkerAttributeMarker
    {
        /// <summary>
        /// Allows specifying that an interface is *not* a context set operations values interface.
        /// This is useful for marking interface that end up canonical context set operations code file locations, but are not context set operations interface types.
        /// </summary>
        public bool IsContextSetOperations { get; }


#pragma warning disable IDE0290 // Use primary constructor
        public ContextSetOperationsMarkerAttribute(
#pragma warning restore IDE0290 // Use primary constructor
            bool isContextSetOperations = true)
        {
            this.IsContextSetOperations = isContextSetOperations;
        }
    }
}
