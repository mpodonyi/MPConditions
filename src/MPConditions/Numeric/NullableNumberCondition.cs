using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NullableNumberCondition<T, TPassthrough> : ConditionBase<T?, TPassthrough>
        where T : struct, IComparable<T>
    {
        internal NullableNumberCondition(T? value, string name)
            : base(value, name)
        {
        }

        internal NullableNumberCondition(T? value, ConditionBase<TPassthrough, TPassthrough> mother)
            : base(value, mother)
        {
        }


        public NullableNumberCondition<T, TPassthrough> Or
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
