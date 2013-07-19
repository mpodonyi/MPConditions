using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T> : ConditionBase<T?>, IFluentInterface
        where T : struct, IComparable<T>
    {
        internal NullableNumberCondition(T? subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }



        public NullableNumberCondition<T> Or
        {
            get
            {
                ((ICondition)this).Push(() => ValidationInfo.Or);
                return this;
            }
        }

    }









}
