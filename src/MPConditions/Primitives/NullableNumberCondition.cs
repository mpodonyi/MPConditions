using System;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public class NullableNumberCondition<TSubject, TOriginalSubject> : NumberConditionBase<TSubject, TOriginalSubject, NullableNumberCondition<TSubject, TOriginalSubject>>
        where TSubject : struct, IComparable<TSubject>
    {
        internal NullableNumberCondition(TSubject? subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

        internal NullableNumberCondition(TSubject? subjectValue, TOriginalSubject originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

        //public new NullableNumberCondition<T, V> Or
        //{
        //    get
        //    {
        //        return (NullableNumberCondition<T, V>)base.Or;
        //    }
        //}


        //public new NullableNumberCondition<T, V> Between(T start, T end)
        //{
        //    return (NullableNumberCondition<T, V>)base.Between(start, end);
        //}

        public NullableNumberCondition<TSubject, TOriginalSubject> IsNotNull()
        {
            this.Push(() =>
            {
                if(!this.SubjectValue.HasValue)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return this;
        }


    }









}
