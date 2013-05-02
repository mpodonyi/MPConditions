using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public class DefaultArgumentExceptionProvider : IExceptionProvider
    {
        public Exception GetException(ExceptionTypes exceptionType, string message, string paramName)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                    return new ArgumentOutOfRangeException(paramName, message);
                case ExceptionTypes.Null:
                    return new ArgumentNullException(paramName, message);
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ArgumentException(message, paramName);
            }

            return null;
        }
    }
}
