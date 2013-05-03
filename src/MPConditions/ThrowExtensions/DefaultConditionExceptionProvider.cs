using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public class DefaultConditionExceptionProvider : IExceptionProvider
    {
        public Exception GetException(ExceptionTypes exceptionType, string subjectName, object subjectValue, string resourceKey, object[] args)
        {
            return new ConditionException(exceptionType, subjectName, subjectValue, resourceKey, args);
        }
    }
}
