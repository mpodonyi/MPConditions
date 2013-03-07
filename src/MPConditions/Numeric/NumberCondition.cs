using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Numeric
{
    public class NumberCondition<T> : NumberConditionBase<T, NumberCondition<T>>
       where T : struct, IComparable<T>
    {

        public NumberCondition(T value, string name)
            : base(value, name)
        {
        }
    }
}
