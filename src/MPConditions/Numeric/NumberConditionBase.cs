using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public abstract class NumberConditionBase<T, V> : ConditionBase<T, V>
        // where T : struct, IComparable<T>
      where V : NumberConditionBase<T, V>
    {

        public NumberConditionBase(T value, string name)
            : base(value, name)
        {
        }

        public V Between(T start, T end)
        {
            ec.Enqueue(() =>
            {
                var comparer = new UniversalNumberComparer();


                if(!((comparer.Compare(_Value, start) > 0) && (comparer.Compare(_Value, start) < 0)))
                {
                    return new ExecutionContext
                    {
                        ExecutionType = ExecutionTypes.OutOfRange,
                        Message = string.Format("Is not between '{0}' and '{1}'.", start, end),
                    };
                }

                return null;
            });

            return (V)this;
        }

        public V Between(object start, object end)
        {
            ec.Enqueue(() =>
            {
                var comparer = new UniversalNumberComparer();


                if(!((comparer.Compare(_Value, start) > 0) && (comparer.Compare(_Value, start) < 0)))
                {
                    return new ExecutionContext
                    {
                        ExecutionType = ExecutionTypes.OutOfRange,
                        Message = string.Format("Is not between '{0}' and '{1}'.", start, end),
                    };
                }

                return ExecutionContext.Empty;
            });

            return (V)this;
        }

        public V Greater(object start)
        {
            ec.Enqueue(() =>
            {
                var comparer = new UniversalNumberComparer();

                if(!(comparer.Compare(_Value, start) > 0))
                {
                    return new ExecutionContext
                    {
                        ExecutionType = ExecutionTypes.OutOfRange,
                        Message = string.Format("Is not greater then '{0}'.", start),
                    };
                }

                return ExecutionContext.Empty;
            });

            return (V)this;
        }


    }
}
