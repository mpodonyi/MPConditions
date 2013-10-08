using System;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public class NullableNumberCondition<T, V> : NumberConditionBase<T, V, NullableNumberCondition<T, V>>
        where T : struct, IComparable<T>
    {
        internal NullableNumberCondition(T? subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

        internal NullableNumberCondition(T? subjectValue, V originalValue, string subjectName)
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

        public NullableNumberCondition<T, V> NotNull()
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
