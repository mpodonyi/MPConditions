using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Numeric
{
    public class NumberCondition<T> : ConditionBase<T>
        where T : struct, IComparable<T>
    
    {


        internal NumberCondition(T subjectValue, string subjectName)
            : base(subjectValue, subjectName)
        {
        }

      


       



        public  NumberCondition<T> Or
        {

            get
            {
                ((ICondition)this).Push(() => ValidationInfo.Or);
                return this;
            }
        }

       
    }
  
}
