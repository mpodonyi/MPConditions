using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public class ConditionException : Exception
    {
        internal ConditionException(string paramName, string message, ExecutionTypes executionTypes)
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


      
        //public ExecutionTypes ExecutionTypes
        //{
        //    get;
        //    private set;
        //}

    }
}
