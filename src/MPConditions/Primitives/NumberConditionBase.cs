using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class NumberConditionBase<T, V, X> : ConditionBase<T?, V>
        where T : struct, IComparable<T>
        where X : NumberConditionBase<T, V, X>
    {

        //internal NumberCondition(T subjectValue, string subjectName)
        //    : base(subjectValue, subjectValue, subjectName)
        //{
        //}

        //internal NumberCondition(T subjectValue, object originalValue, string subjectName)
        //    : base(subjectValue, originalValue, subjectName)
        //{
        //}

        protected NumberConditionBase(T? subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
        }

        protected NumberConditionBase(T? subjectValue, V originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

        public X Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return (X)this;
            }
        }

        public X Between(T start, T end)
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                    return new ValidationInfo(ExceptionTypes.Null);

                //var comparer = new UniversalNumberComparer();

                if(!((this.SubjectValue.Value.CompareTo(start) > 0) && (this.SubjectValue.Value.CompareTo(end) < 0)))
                {
                    return new ValidationInfo(ExceptionTypes.OutOfRange, start, end);
                }

                return null;
            });

            return (X)this;
        }


    }
}
