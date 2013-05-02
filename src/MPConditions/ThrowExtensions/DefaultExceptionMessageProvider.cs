using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public class DefaultExceptionMessageProvider : IExceptionMessageProvider
    {

        #region IExceptionMessageProvider Members

        public string GetExceptionMessage(ExceptionTypes exceptionType, string paramName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
