using System;

using R5T.T0240;


namespace R5T.S0110
{
    [WithXMarker]
    public interface IWithProjectSpecification : IWithXMarker,
        IHasProjectSpecification
    {
        new ProjectSpecification ProjectSpecification { get; set; }
    }
}
