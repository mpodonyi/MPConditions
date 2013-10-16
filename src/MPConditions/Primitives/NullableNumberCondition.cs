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

        public NullableNumberCondition<TSubject, TOriginalSubject> HasValue()
        {
            this.Push(() =>
           {
               if(!object.ReferenceEquals(SubjectValue, null))
               {
                   return null;
               }

               return new ValidationInfo(ExceptionTypes.OutOfRange);
           });

            return this;
        }

        public NullableNumberCondition<TSubject, TOriginalSubject> HasNoValue()
        {
            this.Push(() =>
            {
                if(object.ReferenceEquals(SubjectValue, null))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return this;
        }



    }









}
