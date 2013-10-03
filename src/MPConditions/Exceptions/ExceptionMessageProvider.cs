
namespace MPConditions.Exceptions
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
