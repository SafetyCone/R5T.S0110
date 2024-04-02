using System;

using R5T.T0137;


namespace R5T.S0110
{
    [ContextImplementationMarker]
    public class CheckRepositoryExistsContext : IContextImplementationMarker
    {
        public bool RemoteRepositoryExists { get; set; }
        public bool LocalRepositoryExists { get; set; }
    }
}
