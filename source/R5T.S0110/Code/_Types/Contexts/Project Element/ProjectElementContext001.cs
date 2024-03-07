using System;
using System.Xml.Linq;

using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A Visual Studio project file project XML element context without any non-project element properties.
    /// <list type="bullet">
    /// <item><see cref="IWithProjectElement"/></item>
    /// </list>
    /// </summary>
    [ContextImplementationMarker]
    public class ProjectElementContext001 : IContextImplementationMarker,
        IWithProjectElement
    {
        public XElement ProjectElement { get; set; }
    }
}
