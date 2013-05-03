using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public interface IExceptionMessageProvider
    {
        string GetExceptionMessage(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args);
    }
}
