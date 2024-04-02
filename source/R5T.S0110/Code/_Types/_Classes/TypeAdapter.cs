using System;


namespace R5T.S0110
{
    public class ModifyingTypeAdapter<T, T1>
    {
        protected Action<T, T1> T1_Modifier { get; }


        public ModifyingTypeAdapter(Action<T, T1> modifier)
        {
            this.T1_Modifier = modifier;
        }

        public void Set_T1(T tValue, T1 t1Value) => this.T1_Modifier(tValue, t1Value);
    }


    public class AccessorTypeAdapter<T, T1>
    {
        protected Func<T, T1> T1_Accessor { get; }


        public AccessorTypeAdapter(Func<T, T1> accessor)
        {
            this.T1_Accessor = accessor;
        }

        public T1 Get_T1(T value) => this.T1_Accessor(value);
    }


    public class AccessorTypeAdapter<T, T1, T2> : AccessorTypeAdapter<T, T1>
    {
        protected Func<T, T2> T2_Accessor { get; }


        public AccessorTypeAdapter(
            Func<T, T1> t1Accessor,
            Func<T, T2> t2Accessor)
            : base(t1Accessor)
        {
            this.T2_Accessor = t2Accessor;
        }

        public T2 Get_T2(T value) => this.T2_Accessor(value);
    }


    public class AccessorTypeAdapter<T, T1, T2, T3> : AccessorTypeAdapter<T, T1, T2>
    {
        protected Func<T, T3> T3_Accessor { get; }


        public AccessorTypeAdapter(
            Func<T, T1> t1Accessor,
            Func<T, T2> t2Accessor,
            Func<T, T3> t3Accessor)
            : base(t1Accessor, t2Accessor)
        {
            this.T3_Accessor = t3Accessor;
        }

        public T3 Get_T3(T value) => this.T3_Accessor(value);
    }


    public class TypeAdapter<T, T1>
    {
        #region Static

        public static implicit operator AccessorTypeAdapter<T, T1>(TypeAdapter<T, T1> typeAdapter)
        {
            var output = new AccessorTypeAdapter<T, T1>(typeAdapter.T1_Accessor);
            return output;
        }

        public static implicit operator ModifyingTypeAdapter<T, T1>(TypeAdapter<T, T1> typeAdapter)
        {
            var output = new ModifyingTypeAdapter<T, T1>(typeAdapter.T1_Modifier);
            return output;
        }

        #endregion


        protected Func<T, T1> T1_Accessor { get; }
        protected Action<T, T1> T1_Modifier { get; }


        public TypeAdapter(
            Func<T, T1> accessor,
            Action<T, T1> modifier)
        {
            this.T1_Accessor = accessor;
            this.T1_Modifier = modifier;
        }

        public T1 Get_T1(T value) => this.T1_Accessor(value);
        public void Set_T1(T tValue, T1 t1Value) => this.T1_Modifier(tValue, t1Value);
    }


    public class TypeAdapter<T, T1, T2> : TypeAdapter<T, T1>
    {
        #region Static

        public static implicit operator AccessorTypeAdapter<T, T2>(TypeAdapter<T, T1, T2> typeAdapter)
        {
            var output = new AccessorTypeAdapter<T, T2>(typeAdapter.T2_Accessor);
            return output;
        }

        public static implicit operator ModifyingTypeAdapter<T, T2>(TypeAdapter<T, T1, T2> typeAdapter)
        {
            var output = new ModifyingTypeAdapter<T, T2>(typeAdapter.T2_Modifier);
            return output;
        }

        public static implicit operator TypeAdapter<T, T2>(TypeAdapter<T, T1, T2> typeAdapter)
        {
            var output = new TypeAdapter<T, T2>(
                typeAdapter.T2_Accessor,
                typeAdapter.T2_Modifier);

            return output;
        }

        #endregion


        protected Func<T, T2> T2_Accessor { get; }
        protected Action<T, T2> T2_Modifier { get; }

        public TypeAdapter(
            Func<T, T1> t1Accessor,
            Action<T, T1> t1Modifier,
            Func<T, T2> t2Accessor,
            Action<T, T2> t2Modifier)
            : base(t1Accessor, t1Modifier)
        {
            this.T2_Accessor = t2Accessor;
            this.T2_Modifier = t2Modifier;
        }

        public T2 Get_T2(T value) => this.T2_Accessor(value);
        public void Set_T2(T tValue, T2 t2Value) => this.T2_Modifier(tValue, t2Value);
    }


    public class TypeAdapter<T, T1, T2, T3> : TypeAdapter<T, T1, T2>
    {
        #region Static

        public static implicit operator AccessorTypeAdapter<T, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        {
            var output = new AccessorTypeAdapter<T, T3>(typeAdapter.T3_Accessor);
            return output;
        }

        public static implicit operator ModifyingTypeAdapter<T, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        {
            var output = new ModifyingTypeAdapter<T, T3>(typeAdapter.T3_Modifier);
            return output;
        }

        public static implicit operator TypeAdapter<T, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        {
            var output = new TypeAdapter<T, T3>(
                typeAdapter.T3_Accessor,
                typeAdapter.T3_Modifier);

            return output;
        }

        public static implicit operator TypeAdapter<T, T1, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        {
            var output = new TypeAdapter<T, T1, T3>(
                typeAdapter.T1_Accessor,
                typeAdapter.T1_Modifier,
                typeAdapter.T3_Accessor,
                typeAdapter.T3_Modifier);

            return output;
        }

        public static implicit operator TypeAdapter<T, T2, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        {
            var output = new TypeAdapter<T, T2, T3>(
                typeAdapter.T2_Accessor,
                typeAdapter.T2_Modifier,
                typeAdapter.T3_Accessor,
                typeAdapter.T3_Modifier);

            return output;
        }

        #endregion


        protected Func<T, T3> T3_Accessor { get; }
        protected Action<T, T3> T3_Modifier { get; }

        public TypeAdapter(
            Func<T, T1> t1Accessor,
            Action<T, T1> t1Modifier,
            Func<T, T2> t2Accessor,
            Action<T, T2> t2Modifier,
            Func<T, T3> t3Accessor,
            Action<T, T3> t3Modifier)
            : base(t1Accessor, t1Modifier, t2Accessor, t2Modifier)
        {
            this.T3_Accessor = t3Accessor;
            this.T3_Modifier = t3Modifier;
        }

        public T3 Get_T3(T value) => this.T3_Accessor(value);
        public void Set_T3(T tValue, T3 t3Value) => this.T3_Modifier(tValue, t3Value);
    }


    public class TypeAdapter<T, T1, T2, T3, T4> : TypeAdapter<T, T1, T2, T3>
    {
        #region Static

        public static implicit operator AccessorTypeAdapter<T, T4>(TypeAdapter<T, T1, T2, T3, T4> typeAdapter)
        {
            var output = new AccessorTypeAdapter<T, T4>(typeAdapter.T4_Accessor);
            return output;
        }

        public static implicit operator ModifyingTypeAdapter<T, T4>(TypeAdapter<T, T1, T2, T3, T4> typeAdapter)
        {
            var output = new ModifyingTypeAdapter<T, T4>(typeAdapter.T4_Modifier);
            return output;
        }

        public static implicit operator TypeAdapter<T, T4>(TypeAdapter<T, T1, T2, T3, T4> typeAdapter)
        {
            var output = new TypeAdapter<T, T4>(
                typeAdapter.T4_Accessor,
                typeAdapter.T4_Modifier);

            return output;
        }

        //public static implicit operator TypeAdapter<T, T1, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        //{
        //    var output = new TypeAdapter<T, T1, T3>(
        //        typeAdapter.T1_Accessor,
        //        typeAdapter.T1_Modifier,
        //        typeAdapter.T3_Accessor,
        //        typeAdapter.T3_Modifier);

        //    return output;
        //}

        //public static implicit operator TypeAdapter<T, T2, T3>(TypeAdapter<T, T1, T2, T3> typeAdapter)
        //{
        //    var output = new TypeAdapter<T, T2, T3>(
        //        typeAdapter.T2_Accessor,
        //        typeAdapter.T2_Modifier,
        //        typeAdapter.T3_Accessor,
        //        typeAdapter.T3_Modifier);

        //    return output;
        //}

        public static implicit operator TypeAdapter<T, T2, T3, T4>(TypeAdapter<T, T1, T2, T3, T4> typeAdapter)
        {
            var output = new TypeAdapter<T, T2, T3, T4>(
                typeAdapter.T2_Accessor,
                typeAdapter.T2_Modifier,
                typeAdapter.T3_Accessor,
                typeAdapter.T3_Modifier,
                typeAdapter.T4_Accessor,
                typeAdapter.T4_Modifier);

            return output;
        }

        #endregion


        protected Func<T, T4> T4_Accessor { get; }
        protected Action<T, T4> T4_Modifier { get; }

        public TypeAdapter(
            Func<T, T1> t1Accessor,
            Action<T, T1> t1Modifier,
            Func<T, T2> t2Accessor,
            Action<T, T2> t2Modifier,
            Func<T, T3> t3Accessor,
            Action<T, T3> t3Modifier,
            Func<T, T4> t4Accessor,
            Action<T, T4> t4Modifier)
            : base(t1Accessor, t1Modifier, t2Accessor, t2Modifier, t3Accessor, t3Modifier)
        {
            this.T4_Accessor = t4Accessor;
            this.T4_Modifier = t4Modifier;
        }

        public T4 Get_T4(T value) => this.T4_Accessor(value);
        public void Set_T4(T tValue, T4 t4Value) => this.T4_Modifier(tValue, t4Value);
    }
}
