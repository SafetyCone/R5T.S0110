using System;


namespace R5T.S0110
{
    public class CommitMessages : ICommitMessages
    {
        #region Infrastructure

        public static ICommitMessages Instance { get; } = new CommitMessages();


        private CommitMessages()
        {
        }

        #endregion
    }
}
