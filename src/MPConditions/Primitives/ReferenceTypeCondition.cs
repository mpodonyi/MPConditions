using System;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class ReferenceTypeCondition<TSubject, TOriginalSubject, TCondition> : ConditionBase<TSubject, TOriginalSubject>
        where TSubject : class
        where TCondition : ReferenceTypeCondition<TSubject, TOriginalSubject, TCondition>
    {
        protected ReferenceTypeCondition(TSubject subjectValue, TOriginalSubject originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {

        }

        public TCondition IsNotNull()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return (TCondition)this;
        }

        public TCondition Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return (TCondition)this;
            }
        }





        //------------



        public TCondition IsNull()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return null;

                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (TCondition)this;
        }


        public TCondition IsOfType<T>()
        {
            this.Push(() =>
            {
                if(this.SubjectValue.GetType() == typeof(T))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.WrongType);
            });

            return (TCondition)this;
        }

        public TCondition IsAssignableTo<T>()
        {
            this.Push(() =>
            {
                if(typeof(T).IsAssignableFrom(this.SubjectValue.GetType()))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.WrongType);
            });

            return (TCondition)this;
        }

        public TCondition Matches(Func<TSubject, bool> predicate)
        {
            return this.Matches<TSubject>(predicate);
        }

        public TCondition Matches<T>(Func<T, bool> predicate) where T : TSubject
        {
            this.Push(() =>
            {
                return predicate((T)this.SubjectValue)
                    ? null
                    : new ValidationInfo(ExceptionTypes.WrongMatch);
            });

            return (TCondition)this;
        }


    }
}
