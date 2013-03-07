using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T> : NumberConditionBase<Nullable<T>,T, NullableNumberCondition<T>>
        where T : struct, IComparable<T>
    {

        public NullableNumberCondition(T? value, string name)
            : base(value, name)
        {

        }

    }
}
