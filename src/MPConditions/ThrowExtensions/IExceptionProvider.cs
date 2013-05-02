using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public interface IExceptionProvider
    {
        Exception GetException(ExceptionTypes exceptionType, string message, string paramName);
    }
}
