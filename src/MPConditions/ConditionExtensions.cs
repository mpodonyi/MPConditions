using System;
using MPConditions.Common;

namespace MPConditions
{
    public static class ConditionExtensions
    {
        public static ConditionBase<T, V>  Log<T, V>(this ConditionBase<T, V> condition, bool logAll = false) 
        {
            ValidationInfo execcontext = condition.GetResult();

            //if(execcontext.ExceptionType == ExceptionTypes.None)
            //    return;

            return condition;
        }


        public static void Handle<T, V>(this ConditionBase<T, V> condition) 
        {
            throw new NotImplementedException();
        }

        public static bool Pass<T,V>(this ConditionBase<T,V> condition) 
        {
            return condition.GetResult().ExceptionType == ExceptionTypes.None;
        }
    }
}
