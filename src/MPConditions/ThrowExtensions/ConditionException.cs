using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public class ConditionException : Exception
    {
        internal ConditionException(string paramName, string message)
        {
            ParamName = paramName;
      //      Message = message;
           // ExecutionTypes = executionTypes;
        }

        public string ParamName
        {
            get;
            private set;
        }
    }
}
