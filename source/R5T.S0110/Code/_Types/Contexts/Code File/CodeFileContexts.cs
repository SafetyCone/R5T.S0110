using System;

using R5T.L0093.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker]
    public class CodeFileContext001 : IContextImplementationMarker,
        IWithFilePath
    {
        public string FilePath { get; set; }
    }
}
