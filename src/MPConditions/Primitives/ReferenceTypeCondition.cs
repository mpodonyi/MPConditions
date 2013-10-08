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
            return (X)this;
        }


        public X IsOfType<L>()
        {
            return (X)this;
        }

        public X IsAssignableTo<L>()
        {
            return (X)this;
        }

        //public X Match(Expression<Func<T, bool>> predicate)
        //{
        //    return (X)this;
        //}

        //public X Match<L>(Expression<Func<L, bool>> predicate, string reason = "", params object[] reasonArgs) where L : T
        //{
        //    return (X)this;
        //}


    }
}
