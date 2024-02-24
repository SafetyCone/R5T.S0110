using System;
using System.Threading.Tasks;

using R5T.T0221;
using R5T.T0241;


namespace R5T.S0110
{
    [ContextOperationsMarker]
    public partial interface IIsSetContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Implies<TContext, TImplication, TImplied>(
            IsSet<TImplication> implicationSet,
            out IsSet<TImplied> impliedSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> Implies<TContext, TImplication, TImplied1, TImplied2>(
            IsSet<TImplication> implicationSet,
            out (
            IsSet<TImplied1> implied1Set,
            IsSet<TImplied2> implied2Set
            ) impliedsSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> Implies<TContext, TImplication, TImplied1, TImplied2, TImplied3>(
            IsSet<TImplication> implicationSet,
            out (
            IsSet<TImplied1> implied1Set,
            IsSet<TImplied2> implied2Set,
            IsSet<TImplied3> implied3Set
            ) impliedsSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> Implies<TContext, TImplication, TImplied1, TImplied2, TImplied3, TImplied4>(
            IsSet<TImplication> implicationSet,
            out (
            IsSet<TImplied1> implied1Set,
            IsSet<TImplied2> implied2Set,
            IsSet<TImplied3> implied3Set,
            IsSet<TImplied4> implied4Set
            ) impliedsSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> Implies<TContext, TImplication, TImplied1, TImplied2, TImplied3, TImplied4, TImplied5>(
            IsSet<TImplication> implicationSet,
            out (
            IsSet<TImplied1> implied1Set,
            IsSet<TImplied2> implied2Set,
            IsSet<TImplied3> implied3Set,
            IsSet<TImplied4> implied4Set,
            IsSet<TImplied5> implied5Set
            ) impliedsSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }

        public Func<TContext, Task> Implies<TContext, TImplication, TImplied1, TImplied2, TImplied3, TImplied4, TImplied5, TImplied6>(
            IsSet<TImplication> implicationSet,
            out (
            IsSet<TImplied1> implied1Set,
            IsSet<TImplied2> implied2Set,
            IsSet<TImplied3> implied3Set,
            IsSet<TImplied4> implied4Set,
            IsSet<TImplied5> implied5Set,
            IsSet<TImplied6> implied6Set
            ) impliedsSet)
        {
            return Instances.ContextOperations.Do_Nothing;
        }
    }
}
