using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public class DefaultConditionExceptionProvider : IExceptionProvider
    {
        public Exception GetException(ExceptionTypes exceptionType, string message, string paramName)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                case ExceptionTypes.Null:
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ConditionException(message, paramName);
            }

            return null;
        }
    }
}
