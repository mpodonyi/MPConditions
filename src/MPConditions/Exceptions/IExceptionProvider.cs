using System;

namespace MPConditions.Exceptions
{
    public interface IExceptionProvider
    {
        Exception GetException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args);
    }
}
