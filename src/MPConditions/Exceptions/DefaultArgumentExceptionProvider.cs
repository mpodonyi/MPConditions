using System;

namespace MPConditions.Exceptions
{
    public class DefaultArgumentExceptionProvider : IExceptionProvider
    {
        public Exception GetException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string message)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                    return new ArgumentOutOfRangeException(subjectName, message);
                case ExceptionTypes.Null:
                    return new ArgumentNullException(subjectName, message);
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ArgumentException(message, subjectName);
            }

            return null;
        }
    }
}
