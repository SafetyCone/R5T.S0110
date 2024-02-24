using System;
using System.Xml.Linq;

using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good project item group-element context.
    /// </summary>
    [ContextImplementationMarker]
    public class Context007 : IContextImplementationMarker,
        IWithItemGroupElement
    {
        public XElement ItemGroupElement { get; set; }
    }
}
