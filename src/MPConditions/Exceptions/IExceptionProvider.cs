using System;

namespace MPConditions.Exceptions
{
    public interface IExceptionProvider
    {
        Exception GetException<TOriginalSubject>(ExceptionTypes exceptionType, string subjectName, TOriginalSubject subjectValue, string message);
    }
}
