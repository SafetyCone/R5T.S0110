using System;
using System.Xml.Linq;

using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    /// <summary>
    /// A good project-element context.
    /// </summary>
    [ContextImplementationMarker]
    public class Context005 : IContextImplementationMarker,
        IWithProjectElement,
        IWithProjectFilePath,
        IWithProjectDescription
    {
        public XElement ProjectElement { get; set; }
        public string ProjectFilePath { get; set; }
        public string ProjectDescription { get; set; }
    }
}
