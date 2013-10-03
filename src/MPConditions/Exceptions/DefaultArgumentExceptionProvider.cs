using System;

namespace MPConditions.Exceptions
{
    public class DefaultArgumentExceptionProvider : IExceptionProvider
    {
        public Exception GetException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args)
        {
            string exceptionmessage = ExceptionMessageProvider.Current.GetExceptionMessage(exceptionType, subjectName, subjectValue, resourceKey, args);

            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                    return new ArgumentOutOfRangeException(subjectName, exceptionmessage);
                case ExceptionTypes.Null:
                    return new ArgumentNullException(subjectName, exceptionmessage);
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ArgumentException(exceptionmessage, subjectName);
            }

            return null;
        }
    }
}
