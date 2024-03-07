//using System;


//namespace R5T.S0110
//{
//    /// <summary>
//    /// A good solution set context set.
//    /// </summary>
//    [ContextSetMarker]
//    public class SolutionSetContextSet<TSolutionSetContext, TParentContextSet> : TParentContextSet, IContextSetMarker,
//        IWithIsomorphism<SolutionSetContextSet<TSolutionSetContext, TParentContextSet>>,
//        IWithIsomorphism<TParentContextSet>,
//        IWithContext<Context000>,
//        IWithContext<Context001>,
//        IWithContext<TSolutionSetContext>
//    //where TParentContextSet : IWithIsomorphism<TParentContextSet>, IHasContext<Context000>, IHasContext<Context001>
//    {
//        Context000 IWithContext<Context000>.Context { get; set; }
//        Context000 IHasContext<Context000>.Context => (this as IWithContext<Context000>).Context;
//        Context001 IWithContext<Context001>.Context { get; set; }
//        Context001 IHasContext<Context001>.Context => (this as IWithContext<Context001>).Context;
//        TSolutionSetContext IWithContext<TSolutionSetContext>.Context { get; set; }
//        TSolutionSetContext IHasContext<TSolutionSetContext>.Context => (this as IWithContext<TSolutionSetContext>).Context;


//        public void Copy_From(SolutionSetContextSet<TSolutionSetContext, TParentContextSet> other)
//        {
//            Instances.ContextSetOperator.Copy_Context(
//                other,
//                this,
//                new TypeSpecifier<TSolutionSetContext>());
//        }

//        public void Copy_To(SolutionSetContextSet<TSolutionSetContext, TParentContextSet> other)
//        {
//            Instances.ContextSetOperator.Copy_Context(
//                this,
//                other,
//                new TypeSpecifier<TSolutionSetContext>());
//        }

//        public void Copy_From(TParentContextSet other)
//        {
//            throw new NotImplementedException();
//        }

//        public void Copy_To(TParentContextSet other)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
