using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T> : ConditionBase<T?>
        where T : struct, IComparable<T>
    {
        internal NullableNumberCondition(T? value, string name)
            : base(value, name)
        {
        }

        internal NullableNumberCondition(T? value, string subjectName, object originalSubject)
            : base(value, subjectName,originalSubject)
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


        //INumberCondition<T?, TPassthrough> INumberCondition<T?, TPassthrough>.Or
        //{
        //    get { return base.Or as INumberCondition<T?,TPassthrough>; }
        //}


    }









}
