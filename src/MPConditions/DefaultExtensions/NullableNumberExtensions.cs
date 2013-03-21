using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.DefaultExtensions
{
    public static class NullableNumberExtensions
    {
        public static INullableNumberCondition<T, TBase> Between<T, TBase>(this INullableNumberCondition<T, TBase> condition, T start, T end) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                if(!condition.Subject.HasValue)
                    return new ExecutionContext(ExceptionTypes.Null, "Is 'null'.");
                else
                {
                    var comparer = new UniversalNumberComparer();


                    if(!((comparer.Compare(condition.Subject, start) > 0) && (comparer.Compare(condition.Subject, end) < 0)))
                    {
                        return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not between '{0}' and '{1}'.", start, end);
                    }

                    return ExecutionContext.Empty;
                }
            });

            return condition;
        }

        public static INullableNumberCondition<T, TBase> Greater<T, TBase>(this INullableNumberCondition<T, TBase> condition, object start) where T : struct, IComparable<T>
        {
            condition.Push(() =>
            {
                if(!condition.Subject.HasValue)
                    return new ExecutionContext(ExceptionTypes.Null, "Is 'null'.");
                else
                {
                    var comparer = new UniversalNumberComparer();

                    if(!(comparer.Compare(condition.Subject, start) > 0))
                    {
                        return new ExecutionContext(ExceptionTypes.OutOfRange, "Is not greater then '{0}'.", start);
                    }

                    return ExecutionContext.Empty;
                }
            });

            return condition;
        }
    }
}
