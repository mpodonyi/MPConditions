using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.ThrowExtensions
{
    public static class ExceptionMessageProvider
    {
        static ExceptionMessageProvider()
        {
            Current = new DefaultExceptionMessageProvider();
        }

        public static void SetProvider(IExceptionMessageProvider provider)
        {
            Current = provider;
        }

        public static IExceptionMessageProvider Current
        {
            private set;
            get;
        }
    }
}
