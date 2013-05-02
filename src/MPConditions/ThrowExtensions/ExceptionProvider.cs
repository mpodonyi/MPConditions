using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public static class ExceptionProvider
    {
        static ExceptionProvider()
        {
            ArgumentExceptionProvider = new DefaultArgumentExceptionProvider();
            ConditionExceptionProvider = new DefaultConditionExceptionProvider();
        }

        public static IExceptionProvider ArgumentExceptionProvider
        {
            private set;
            get;
        }

        public static IExceptionProvider ConditionExceptionProvider
        {
            private set;
            get;
        }
    }
}
