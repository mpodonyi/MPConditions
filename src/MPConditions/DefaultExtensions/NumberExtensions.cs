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
        private static ValidationInfo BetweenHelper<T>(T subject, T start, T end) where T : struct, IComparable<T>
        {
            var comparer = new UniversalNumberComparer();

            if(!((comparer.Compare(subject, start) > 0) && (comparer.Compare(subject, end) < 0)))
            {
                return new ValidationInfo(ExceptionTypes.OutOfRange, "Is not between '{0}' and '{1}'.", start, end);
            }

            return null;
        }

        //public static V Between<V, T, TBase>(this V condition, T start, T end) where T : struct, IComparable<T>
        //    where V:INumberCondition<T, TBase>
        //{
        //    condition.Push(() =>
        //    {
        //        T? uu = condition.Subject;

        //        var xxx=condition as INullableNumberCondition<T,TBase>;
        //        if(xxx != null)
        //            uu = xxx.Subject;

        //        if(!uu.HasValue)
        //            return new ExecutionContext(ExceptionTypes.Null, "Is 'null'.");
        //        else
        //            return BetweenHelper(uu.Value, start, end);
        //    });

        //    return condition;
        //}

        public static INumberCondition<T, TBase> Between<T, TBase>(this INumberCondition<T, TBase> condition, T start, T end) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                return BetweenHelper(condition.Subject, start, end);
            });

            return condition;
        }

        public static INullableNumberCondition<T, TBase> Between<T, TBase>(this INullableNumberCondition<T, TBase> condition, T start, T end) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                if(!condition.Subject.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null, "Is 'null'.");
                else
                    return BetweenHelper(condition.Subject.Value, start, end);
            });

            return condition;
        }

        //public static INumberCondition<T, TBase> Between<T, TBase>(this INumberCondition<T, TBase> condition, T start, T end) where T : struct, IComparable<T>
        //{
        //    condition.Push(() =>
        //    {
        //        return BetweenHelper(condition.Subject, start, end);
        //    });

        //    return condition;
        //}

        //public static INullableNumberCondition<T, TBase> Greater<T, TBase>(this INullableNumberCondition<T, TBase> condition, object start) where T : struct, IComparable<T>
        //{
        //    condition.Push(() =>
        //    {
        //        if(!condition.Subject.HasValue)
        //            return new ExecutionContext(ExceptionTypes.Null, "Is 'null'.");
        //        else
        //        {
        //            var comparer = new UniversalNumberComparer();

        //            if(!(comparer.Compare(condition.Subject, start) > 0))
        //            {
        //                return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not greater then '{0}'.", start);
        //            }

        //            return ExecutionContext.Empty;
        //        }
        //    });

        //    return condition;
        //}

        //public static INumberCondition<T, TBase> Greater<T, TBase>(this INumberCondition<T, TBase> condition, object start) where T : struct, IComparable<T>
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



    }
}
