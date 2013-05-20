using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public static class ConditionExtensions
    {
        public static void Throw(this ICondition condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return;

            throw ExceptionProvider.ArgumentExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }

        public static void ThrowEx(this ICondition condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return;

            throw ExceptionProvider.ConditionExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }

        public static T Log<T>(this T condition, bool logAll = false) where T : ICondition
        {
            ValidationInfo execcontext = condition.GetResult();

            //if(execcontext.ExceptionType == ExceptionTypes.None)
            //    return;

            return condition;
        }

        public static void Handle(this ICondition condition)
        {
            throw new NotImplementedException();
        }


    }
}
