using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Numeric;

namespace MPConditions.Primitives
{
    public class StringCondition : ConditionBase<string>, IFluentInterface
    {

        internal StringCondition(string subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

        public StringCondition Or
        {
            get
            {
                ((ICondition)this).Push(() => ValidationInfo.Or);
                return this;
            }
        }
    }
}
