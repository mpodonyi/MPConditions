using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public class ValidationInfo
    {
        public string ResourceKey
        {
            private set;
            get;
        }

        public object[] Args
        {
            get;
            private set;
        }

        public ExceptionTypes ExceptionType
        {
            get;
            private set;
        }

        internal ExecutionTypes ExecutionType
        {
            get;
            private set;
        }

        internal bool FailFast
        {
            get;
            set;
        }

        private ValidationInfo()
        {
        }

        //public ValidationInfo(ExceptionTypes exceptionType, string resourceKey, params object[] args)
        //{
        //    ResourceKey = resourceKey;
        //    ExceptionType = exceptionType;
        //    Args = args;
        //    ExecutionType = ExecutionTypes.Error;
        //}

        public ValidationInfo(ExceptionTypes exceptionType, params object[] args)
        {
            ExceptionType = exceptionType;
            Args = args;
            ExecutionType = ExecutionTypes.Error;
        }

        internal static ValidationInfo Empty = new ValidationInfo
        {
            ExecutionType = ExecutionTypes.None,
            ExceptionType = ExceptionTypes.None,
        };

        internal static ValidationInfo Or = new ValidationInfo
        {
            ExecutionType = ExecutionTypes.Or,
        };


    }
}
