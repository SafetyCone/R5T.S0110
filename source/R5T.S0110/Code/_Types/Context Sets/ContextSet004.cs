using System;


namespace R5T.S0110
{
    /// <summary>
    /// A good project context set.
    /// </summary>
    [ContextSetMarker]
    public class ContextSet004 : IContextSetMarker,
        IWithContext<Context000>,
        IWithContext<Context001>,
        IWithContext<SingleProjectSolutionSetContext>,
        IWithContext<ProjectContext001>
    {
        Context000 IWithContext<Context000>.Context { get; set; }
        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
        Context001 IWithContext<Context001>.Context { get; set; }
        Context001 IHasContext<Context001>.Context => (this as IWithContext<Context001>).Context;
        SingleProjectSolutionSetContext IWithContext<SingleProjectSolutionSetContext>.Context { get; set; }
        SingleProjectSolutionSetContext IHasContext<SingleProjectSolutionSetContext>.Context => (this as IWithContext<SingleProjectSolutionSetContext>).Context;
        ProjectContext001 IWithContext<ProjectContext001>.Context { get; set; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;
    }
}
