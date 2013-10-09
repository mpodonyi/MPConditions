using System;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class ReferenceTypeCondition<T, V, X> : ConditionBase<T, V>
        where T : class
        where X : ReferenceTypeCondition<T, V, X>
    {
        protected ReferenceTypeCondition(T subjectValue, V originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {

        }

        public X IsNotNull()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return new ValidationInfo(ExceptionTypes.Null, "Value can not be [null]");
                }

                return null;
            });

            return (X)this;
        }

        public X Or
        {
            get
            {
                this.Push(() => ValidationInfo.Or);
                return (X)this;
            }
        }





        //------------



        public X IsNull()
        {
            this.Push(() =>
            {
                if(this.SubjectValue == null)
                {
                    return null;

                }

                return new ValidationInfo(ExceptionTypes.OutOfRange);
            });

            return (X)this;
        }


        public X IsOfType<L>()
        {
            this.Push(() =>
            {
                if(this.SubjectValue.GetType() == typeof(L))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.WrongType);
            });

            return (X)this;
        }

        public X IsAssignableTo<L>()
        {
            this.Push(() =>
            {
                if(typeof(L).IsAssignableFrom(this.SubjectValue.GetType()))
                {
                    return null;
                }

                return new ValidationInfo(ExceptionTypes.WrongType);
            });

            return (X)this;
        }

        public X Match(Func<T, bool> predicate)
        {
            return this.Match<T>(predicate);
        }

        public X Match<L>(Func<L, bool> predicate) where L : T
        {
            this.Push(() =>
            {
                if(typeof(L).IsAssignableFrom(this.SubjectValue.GetType()))
                {
                    return null;
                }

                return predicate((L)this.SubjectValue)
                    ? null
                    : new ValidationInfo(ExceptionTypes.WrongMatch);
            });

            return (X)this;
        }


    }
}
