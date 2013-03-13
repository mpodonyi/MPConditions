using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Common
{
    public class ExecutionContext<T>
    {
        public string Message
        {
            get
            {
                return string.Format(_Message, Args);
            }
        }

        public string VariableName
        {
            get;
            private set;
        }

        public T VariableValue
        {
            get;
            private set;
        }

        internal void SetNameAndValue(string variableName, T variableValue)
        {
            VariableName = variableName;
            VariableValue = variableValue;
        }

        public string _Message
        {
            get;
            private set;
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

        private ExecutionContext()
        {
        }

        internal ExecutionContext(ExceptionTypes exceptionType, string message, params object[] args)
        {
            _Message = message;
            ExceptionType = exceptionType;
            Args = args;
            ExecutionType = ExecutionTypes.Error;
        }

        internal static ExecutionContext<T> Empty = new ExecutionContext<T>
        {
            ExecutionType = ExecutionTypes.None,
            ExceptionType = ExceptionTypes.None,
        };

        internal static ExecutionContext<T> Or = new ExecutionContext<T>
        {
            ExecutionType = ExecutionTypes.Or,
        };
    }
}
