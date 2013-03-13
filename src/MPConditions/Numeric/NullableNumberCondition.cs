using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T, TPassthrough> : NumberConditionBase<T, TPassthrough, Nullable<T>, NullableNumberCondition<T, TPassthrough>>
        where T : struct, IComparable<T>
    {
        public NullableNumberCondition(T? value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {

        }

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
