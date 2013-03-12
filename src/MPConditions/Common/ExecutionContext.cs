using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public class ExecutionContext
    {


        public string Message
        {
            get;
            set;
        }

        public ExecutionTypes ExecutionType
        {
            get;
            set;
        }

        public bool FailFast
        {
            get;
            set;
        }

        public static ExecutionContext Empty = new ExecutionContext
        {
            ExecutionType = ExecutionTypes.None,
        };
    }
}
