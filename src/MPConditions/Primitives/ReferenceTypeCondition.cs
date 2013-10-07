using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Core;

namespace MPConditions.Primitives
{
    public abstract class ReferenceTypeCondition<T, V, X> : ConditionBase<T, V>
        where X : ReferenceTypeCondition<T, V, X>
    {
        protected ReferenceTypeCondition(T subjectValue, V originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {

        }

        public X NotNull()
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
    }
}
