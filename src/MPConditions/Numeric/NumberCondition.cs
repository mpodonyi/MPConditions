using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Numeric
{
    public class NumberCondition<T, TPassthrough> : NumberConditionBase<T, TPassthrough, T, NumberCondition<T, TPassthrough>>
       where T : struct, IComparable<T>
    {

        public NumberCondition(T value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }
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
