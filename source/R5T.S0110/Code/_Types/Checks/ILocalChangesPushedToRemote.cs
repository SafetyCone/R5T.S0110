using System;

using R5T.T0244;


namespace R5T.S0110
{
    /// <summary>
    /// Indicates local repository changes have been pushed to the remote repository.
    /// </summary>
    [CheckMarker]
    public interface ILocalChangesPushedToRemote : ICheckMarker
    {
    }
}
