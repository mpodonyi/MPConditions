
using System;
namespace MPConditions.Exceptions
{
    public static class ExceptionMessageProvider
    {
        static ExceptionMessageProvider()
        {
            Current = new ResourceLookupExceptionMessageProvider();
        }

        public static void SetProvider(IExceptionMessageProvider provider)
        {
            if(provider == null)
                throw new ArgumentNullException();

            Current = provider;
        }

        public static IExceptionMessageProvider Current
        {
            private set;
            get;
        }
    }
}
