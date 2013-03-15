using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    //public abstract class NumberConditionBase<TValue, TType, TBase> : ConditionBase<TValue, TBase>
    //  where TType : struct, IComparable<TType>
    //  where TBase : NumberConditionBase<TValue, TType, TBase>
    public abstract class NumberConditionBase<TOrigin, TPassthrough, TValue, TBase> : ConditionBase<TValue, TPassthrough, TBase>
        //where TValue : struct
        where TOrigin : struct, IComparable<TOrigin>
        where TBase : NumberConditionBase<TOrigin, TPassthrough, TValue, TBase>
    {

        public NumberConditionBase(TValue value, TPassthrough origValue, string name)
            : base(value, origValue, name)
        {
        }

        //public TBase Between(TValue start, TValue end) //MP: set an argument invalid exception when null values here
        //{


        //    return (TBase)this;
        //}

        //public TBase Between(TOrigin start, TOrigin end) //MP: set an argument invalid exception when null values here
        //{
        //    ec.Enqueue(() =>
        //    {
        //        if(_Value == null)
        //        {
        //            return new ExecutionContext<TPassthrough>(ExceptionTypes.OutOfRange, "Is 'null'.", start, end);
        //        }

        //        //start.CompareTo


        //        //start.CompareTo(_Value);


        //        //if(!((comparer.Compare(_Value, start) > 0) && (comparer.Compare(_Value, end) < 0)))
        //        //{
        //        //    return new ExecutionContext
        //        //    {
        //        //        ExecutionType = ExecutionTypes.OutOfRange,
        //        //        Message = string.Format("Is not between '{0}' and '{1}'.", start, end),
        //        //    };
        //        //}

        //        return ExecutionContext<TPassthrough>.Empty;
        //    });

        //    return (TBase)this;
        //}

        public TBase Between(object start, object end) //MP: set an argument invalid exception when null values here
        {
            ec.Enqueue(() =>
            {
                var comparer = new UniversalNumberComparer();


                if(!((comparer.Compare(_Value, start) > 0) && (comparer.Compare(_Value, end) < 0)))
                {
                    return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not between '{0}' and '{1}'.", start, end);
                }

                return ExecutionContext.Empty;
            });

            return (TBase)this;
        }

        public TBase Greater(object start)
        {
            ec.Enqueue(() =>
            {
                var comparer = new UniversalNumberComparer();

                if(!(comparer.Compare(_Value, start) > 0))
                {
                    return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not greater then '{0}'.", start);
                }

                return ExecutionContext.Empty;
            });

            return (TBase)this;
        }


    }
}
