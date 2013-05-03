using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public interface IExceptionProvider
    {
        Exception GetException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args);
    }
}
