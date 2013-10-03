using System;
using MPConditions.Common;

namespace MPConditions
{
    public static class ConditionExtensions
    {
        public static T Log<T>(this T condition, bool logAll = false) where T : ICondition
        {
            ValidationInfo execcontext = condition.GetResult();

            //if(execcontext.ExceptionType == ExceptionTypes.None)
            //    return;

            return condition;
        }


        public static void Handle<T>(this T condition) where T : ICondition
        {
            throw new NotImplementedException();
        }

        public static bool Pass<T>(this T condition) where T : ICondition
        {
            return condition.GetResult().ExceptionType == ExceptionTypes.None;
        }
    }
}
