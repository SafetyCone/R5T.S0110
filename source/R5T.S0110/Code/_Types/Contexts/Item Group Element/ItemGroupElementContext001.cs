using System;
using System.Xml.Linq;

using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A Visual Studio project file item group XML element context.
    /// <list type="bullet">
    /// <item><see cref="IWithItemGroupElement"/></item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class ItemGroupElementContext001 : IContextImplementationMarker,
        IWithItemGroupElement
    {
        public XElement ItemGroupElement { get; set; }
    }
}
