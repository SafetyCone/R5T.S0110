using System;


namespace R5T.S0110
{
    public class CodeFileGenerationContextOperations : ICodeFileGenerationContextOperations
    {
        #region Infrastructure

        public static ICodeFileGenerationContextOperations Instance { get; } = new CodeFileGenerationContextOperations();


        private CodeFileGenerationContextOperations()
        {
        }

        #endregion
    }
}
