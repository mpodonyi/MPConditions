using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NumberCondition<T, TPassthrough> : ConditionBase<T, TPassthrough>
        where T : struct, IComparable<T>
    //where TBase : NumberCondition<T, TPassthrough, >
    {

        //internal NumberCondition(T? value, TPassthrough origValue, string name)
        //    : base(value, origValue, name)
        //{
        //}

        //internal NumberCondition(T? value, ConditionBase<TPassthrough, TPassthrough> mother)
        //    : base(value, mother)
        //{
        //}

        internal NumberCondition(T value, string name)
            : base(value, name)
        {
        }

        internal NumberCondition(T value, ConditionBase<TPassthrough, TPassthrough> mother)
            : base(value, mother)
        {
        }


       



        public  NumberCondition<T, TPassthrough> Or
        {

            get
            {
                ((ICondition)this).Push(() => ValidationInfo.Or);
                return this;
            }
        }

       
    }


    //public class NumberCondition<T, TPassthrough> : NumberCondition<T, TPassthrough>
    //  where T : struct, IComparable<T>
    //{


    //}

    //public class NumberCondition<T> : NumberCondition<T, T, NumberCondition<T>>
    //  where T : struct, IComparable<T>
    //{

    //    public NumberCondition(T value, string name)
    //        : base(value,value, name)
    //    {
    //    }
    //}
}
