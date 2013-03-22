using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NumberCondition<T, TPassthrough,TBase> : ConditionBase<T?, TPassthrough, TBase>
        , INumberCondition<T, TPassthrough>
        where T : struct, IComparable<T>
        where TBase : NumberCondition<T, TPassthrough, TBase>
    {

        public NumberCondition(T? value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }

        #region INumberCondition<T> Members

        public T Subject
        {
            get { return this._Value.Value; }
        }


        public new INumberCondition<T, TPassthrough> Or
        {
            get { return base.Or; }
        }

        #endregion
    }

    public class NumberCondition<T, TPassthrough> : NumberCondition<T, TPassthrough, NumberCondition<T, TPassthrough>>
      where T : struct, IComparable<T>
    {

        public NumberCondition(T value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }
    }

    //public class NumberCondition<T> : NumberCondition<T, T, NumberCondition<T>>
    //  where T : struct, IComparable<T>
    //{

    //    public NumberCondition(T value, string name)
    //        : base(value,value, name)
    //    {
    //    }
    //}
}
