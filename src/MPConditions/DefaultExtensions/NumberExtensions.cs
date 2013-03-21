using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.DefaultExtensions
{
    public static class NumberExtensions
    {
        //public static V Between<V, T, TPassthrough>(this V condition, T start, T end)
        //    where V : INumberCondition<T, TPassthrough>
        //    where T : struct, IComparable<T>
        //{
        //  //  condition.Subject

           
        //    int? hh = null;

        //    condition.Push(() =>
        //    {
        //        var comparer = new UniversalNumberComparer();


        //        if(!((comparer.Compare(condition.Subject, start) > 0) && (comparer.Compare(condition.Subject, end) < 0)))
        //        {
        //            return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not between '{0}' and '{1}'.", start, end);
        //        }

        //        return ExecutionContext.Empty;
        //    });

        //    return condition;
        //}

        //public static V Greater<V, T, TPassthrough>(this V condition, T start)
        //    where V : INumberCondition<T, TPassthrough>
        //    where T : struct, IComparable<T>
        //{
        //    condition.Push(() =>
        //    {
        //        var comparer = new UniversalNumberComparer();

        //        if(!(comparer.Compare(condition.Subject, start) > 0))
        //        {
        //            return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not greater then '{0}'.", start);
        //        }

        //        return ExecutionContext.Empty;
        //    });

        //    return condition;
        //}

        public static INumberCondition<T, TBase> Between<T, TBase>(this INumberCondition<T, TBase> condition, T start, T end) where T : struct, IComparable<T>
        {
            int? hh = null;

            condition.Push(() =>
            {
               
                var comparer = new UniversalNumberComparer();


                if(!((comparer.Compare(condition.Subject, start) > 0) && (comparer.Compare(condition.Subject, end) < 0)))
                {
                    return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not between '{0}' and '{1}'.", start, end);
                }

                return ExecutionContext.Empty;
            });

            return condition;
        }

        public static INumberCondition<T, TBase> Greater<T, TBase>(this INumberCondition<T, TBase> condition, object start) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                var comparer = new UniversalNumberComparer();

                if(!(comparer.Compare(condition.Subject, start) > 0))
                {
                    return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not greater then '{0}'.", start);
                }

                return ExecutionContext.Empty;
            });

            return condition;
        }



    }
}
