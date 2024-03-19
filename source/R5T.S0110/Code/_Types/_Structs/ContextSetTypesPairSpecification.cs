using System;

using R5T.T0142;


namespace R5T.S0110
{
    /// <summary>
    /// Allows specifying a pair of context set types using an instance.
    /// </summary>
    [UtilityTypeMarker, TypeMarker]
    public readonly struct ContextSetTypesPairSpecification<TContextSetA, TContextSetB>
    {
        public static readonly ContextSetTypesPairSpecification<TContextSetA, TContextSetB> Instance;
    }
}
