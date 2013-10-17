
using System;
namespace MPConditions.Exceptions
{
    public static class ExceptionMessageProvider
    {
        static ExceptionMessageProvider()
        {
            ArgumentExceptionMessageProvider = new ResourceLookupExceptionMessageProvider();
        }

        public static void SetArgumentExceptionMessageProvider(IExceptionMessageProvider argumentExceptionMessageProvider)
        {
            if(argumentExceptionMessageProvider == null)
                throw new ArgumentNullException();

            ArgumentExceptionMessageProvider = argumentExceptionMessageProvider;
        }

        public static IExceptionMessageProvider ArgumentExceptionMessageProvider
        {
            private set;
            get;
        }
    }
}
