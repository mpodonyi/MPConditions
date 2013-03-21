using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T, TPassthrough> : ConditionBase<Nullable<T>, TPassthrough, NullableNumberCondition<T, TPassthrough>>, INullableNumberCondition<T, TPassthrough>
        where T : struct, IComparable<T>
    {
        public NullableNumberCondition(T? value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {

        }


        #region INullableNumberCondition<T> Members

        public T? Subject
        {
            get { return this._Value.Value; }
        }

        public void Push(Func<ExecutionContext> action)
        {
            ec.Enqueue(action);
        }

        #endregion
    }

    public class NullableNumberCondition<T> : NullableNumberCondition<T, Nullable<T>>
       where T : struct, IComparable<T>
    {
        public NullableNumberCondition(T? value, string name)
            : base(value, value, name) 
        {

        }
    }
}
