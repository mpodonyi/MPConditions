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

        //internal void SetNameAndValue(string variableName, T variableValue)
        //{
        //    VariableName = variableName;
        //    VariableValue = variableValue;
        //}

        internal static ExecutionContext<T> CopyFrom<V>(string variableName, T variableValue, ExecutionContext<V> copyFrom)
        {
            //MP; work on typeof(T)== typeof(V) optimization

            ExecutionContext<T> retVal=new ExecutionContext<T>();
            retVal.VariableName = variableName;
            retVal.VariableValue = variableValue;

            copyFrom = copyFrom ?? ExecutionContext<V>.Empty;

            retVal._Message = copyFrom._Message;
            retVal.Args = copyFrom.Args;
            retVal.ExceptionType = copyFrom.ExceptionType;
            retVal.ExecutionType = copyFrom.ExecutionType;
            retVal.FailFast = copyFrom.FailFast;

            return retVal;
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
