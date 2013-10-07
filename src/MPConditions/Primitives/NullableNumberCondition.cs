using System;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public class NullableNumberCondition<T, V> : NumberCondition<T, V>
        where T : struct, IComparable<T>
    {
        internal NullableNumberCondition(T? subjectValue, string subjectName)
            : base(subjectValue ?? default(T), !subjectValue.HasValue, subjectValue, subjectName)
        {
        }

        internal NullableNumberCondition(T? subjectValue, object originalValue, string subjectName)
            : base(subjectValue ?? default(T), !subjectValue.HasValue, originalValue, subjectName)
        {
        }

        public new NullableNumberCondition<T, V> Or
        {
            get
            {
                return (NullableNumberCondition<T, V>)base.Or;
            }
        }


        public new NullableNumberCondition<T, V> Between(T start, T end)
        {
            return (NullableNumberCondition<T, V>)base.Between(start, end);
        }

        public NullableNumberCondition<T, V> NotNull()
        {
            this.Push(() =>
            {
                if(this.IsNull)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return this;
        }


    }









}
