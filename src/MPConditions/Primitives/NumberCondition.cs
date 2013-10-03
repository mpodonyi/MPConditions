using System;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public class NumberCondition<T, V> : ConditionBase<T, V>, IFluentInterface
        where T : struct, IComparable<T>
    {
        protected bool IsNull = false;

        internal NumberCondition(T subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
        }

        internal NumberCondition(T subjectValue, object originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

        protected NumberCondition(T subjectValue, bool isNull, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
            IsNull = isNull;
        }

        protected NumberCondition(T subjectValue, bool isNull, object originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
            IsNull = isNull;
        }

        public NumberCondition<T, V> Or
        {

            get
            {
                this.Push(() => ValidationInfo.Or);
                return this;
            }
        }

        public NumberCondition<T, V> Between(T start, T end)
        {
            this.Push(() =>
            {
                if(IsNull)
                    return new ValidationInfo(ExceptionTypes.Null);

                var comparer = new UniversalNumberComparer();

                if(!((comparer.Compare(this.SubjectValue, start) > 0) && (comparer.Compare(this.SubjectValue, end) < 0)))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, start, end);
                }

                return null;
            });

            return this;
        }


    }

}
