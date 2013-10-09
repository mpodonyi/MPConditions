using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class NumberConditionBase<TSubject, TOriginalSubject, TCondition> : ConditionBase<TSubject?, TOriginalSubject>
        where TSubject : struct, IComparable<TSubject>
        where TCondition : NumberConditionBase<TSubject, TOriginalSubject, TCondition>
    {

        //internal NumberCondition(T subjectValue, string subjectName)
        //    : base(subjectValue, subjectValue, subjectName)
        //{
        //}

        //internal NumberCondition(T subjectValue, object originalValue, string subjectName)
        //    : base(subjectValue, originalValue, subjectName)
        //{
        //}

        protected NumberConditionBase(TSubject? subjectValue, string subjectName)
            : base(subjectValue, subjectValue, subjectName)
        {
        }

        protected NumberConditionBase(TSubject? subjectValue, TOriginalSubject originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

        public TCondition Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return (TCondition)this;
            }
        }

        public TCondition Between(TSubject start, TSubject end)
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

            return (TCondition)this;
        }


    }
}
