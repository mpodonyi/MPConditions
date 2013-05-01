using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public class ValidationInfo
    {
        public string Message
        {
            get
            {
                return string.Format(_Message, Args);
            }
        }

        //public string VariableName
        //{
        //    get;
        //    private set;
        //}

        //public object VariableValue
        //{
        //    get;
        //    private set;
        //}

        //internal void SetNameAndValue(string variableName, object variableValue)
        //{
        //    VariableName = variableName;
        //    VariableValue = variableValue;
        //}

       

        private string _Message
        {
            get;
            set;
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

        internal ValidationInfo(ExceptionTypes exceptionType, string message, params object[] args)
        {
            _Message = message;
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
