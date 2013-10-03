
namespace MPConditions.Exceptions
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
