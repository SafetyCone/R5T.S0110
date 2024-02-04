using System;

using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker, ContextTypeMarker]
    public class CodeFileContext :
        IWithFilePath,
        IWithNamespaceName,
        IWithProjectFilePath
    {
        public string FilePath { get; set; }
        public string NamespaceName { get; set; }
        public string ProjectFilePath { get; set; }
    }
}
