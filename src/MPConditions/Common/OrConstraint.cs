using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    //[DebuggerNonUserCode]
    public class OrConstraint<T>
    {
        private readonly T parentConstraint;

        public T Or
        {
            get
            {
                return this.parentConstraint;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// 
        /// </summary>
        public OrConstraint(T parentConstraint)
        {
            this.parentConstraint = parentConstraint;
        }
    }
}
