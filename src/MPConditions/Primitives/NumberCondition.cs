using System;
using MPConditions.Core;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public class NumberCondition<TSubject, TOriginalSubject> : NumberConditionBase<TSubject, TOriginalSubject, NumberCondition<TSubject, TOriginalSubject> >
       where TSubject : struct, IComparable<TSubject>
    {

        internal NumberCondition(TSubject subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

        internal NumberCondition(TSubject subjectValue, TOriginalSubject originalValue, string subjectName)
            : base(subjectValue, originalValue, subjectName)
        {
        }

    

    }

  

}
