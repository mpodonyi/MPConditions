using System;
using MPConditions.Core;

namespace MPConditions
{
    public static class ConditionBaseExtensions
    {





        //public static ConditionBase<T, V> Log<T, V>(this ConditionBase<T, V> condition, bool logAll = false)
        //{
        //    ValidationInfo execcontext = condition.GetResult();

        //    //if(execcontext.ExceptionType == ExceptionTypes.None)
        //    //    return;

        //    return condition;
        //}


        //public static void Handle<T, V>(this ConditionBase<T, V> condition)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool Pass<T, V>(this ConditionBase<T, V> condition)
        {
            return condition.GetResult().ExceptionType == ExceptionTypes.None;
        }
    }
}
