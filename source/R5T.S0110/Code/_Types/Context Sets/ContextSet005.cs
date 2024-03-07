using System;


namespace R5T.S0110
{
    /// <summary>
    /// A good project element context set.
    /// </summary>
    [ContextSetMarker]
    public class ContextSet005 : IContextSetMarker,
        IWithContext<Context000>,
        IWithContext<Context001>,
        IWithContext<SingleProjectSolutionSetContext>,
        IWithContext<ProjectContext001>,
        IWithContext<Context005>
    {
        Context000 IWithContext<Context000>.Context { get; set; }
        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
        Context001 IWithContext<Context001>.Context { get; set; }
        Context001 IHasContext<Context001>.Context => (this as IWithContext<Context001>).Context;
        SingleProjectSolutionSetContext IWithContext<SingleProjectSolutionSetContext>.Context { get; set; }
        SingleProjectSolutionSetContext IHasContext<SingleProjectSolutionSetContext>.Context => (this as IWithContext<SingleProjectSolutionSetContext>).Context;
        ProjectContext001 IWithContext<ProjectContext001>.Context { get; set; }
        ProjectContext001 IHasContext<ProjectContext001>.Context => (this as IWithContext<ProjectContext001>).Context;
        Context005 IWithContext<Context005>.Context { get; set; }
        Context005 IHasContext<Context005>.Context => (this as IWithContext<Context005>).Context;
    }
}
