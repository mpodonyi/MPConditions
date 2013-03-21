using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NumberCondition<T, TPassthrough> : ConditionBase<T, TPassthrough, NumberCondition<T, TPassthrough>>, INumberCondition<T, TPassthrough>
       where T : struct, IComparable<T>
    {

        public NumberCondition(T value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }

        #region INumberCondition<T> Members

        public T Subject
        {
            get { return this._Value; }
        }

        public void Push(Func<Common.ExecutionContext> action)
        {
            ec.Enqueue(action);
        }




        #endregion
    }

    public class NumberCondition<T> : NumberCondition<T,T>
      where T : struct, IComparable<T>
    {

        public NumberCondition(T value, string name)
            : base(value,value, name)
        {
        }
    }
}
