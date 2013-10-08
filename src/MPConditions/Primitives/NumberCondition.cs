using System;
using MPConditions.Core;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public class NumberCondition<T, V> : NumberConditionBase<T, V, NumberCondition<T, V> >
       where T : struct, IComparable<T>
    {

        internal NumberCondition(T subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

        internal NumberCondition(T subjectValue, V originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

    }

  

}
