
using System;
namespace MPConditions.Exceptions
{
    public static class ExceptionProvider
    {
        static ExceptionProvider()
        {
            ArgumentExceptionProvider = new DefaultArgumentExceptionProvider();
            //ConditionExceptionProvider = new DefaultConditionExceptionProvider();
        }


        public static IExceptionProvider ArgumentExceptionProvider
        {
            private set;
            get;
        }

        public static void SetArgumentExceptionProvider(IExceptionProvider argumentExceptionProvider)
        {
            if(argumentExceptionProvider == null)
                throw new ArgumentNullException("argumentExceptionProvider");

            ArgumentExceptionProvider = argumentExceptionProvider;
        }

        //public static IExceptionProvider ConditionExceptionProvider
        //{
        //    private set;
        //    get;
        //}
    }
}
