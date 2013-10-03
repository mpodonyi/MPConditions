using System;
using MPConditions.Common;
using MPConditions.Exceptions;

namespace MPConditions
{
    public static class ConditionExceptionExtensions
    {
        public static TOriginal Throw<T, TOriginal>(this T condition) where T : ICondition<TOriginal> 
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return condition.OriginalSubjectValue;

            throw ExceptionProvider.ArgumentExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }

        public static TOriginal ThrowEx<T, TOriginal>(this T condition) where T : ICondition<TOriginal> 
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return condition.OriginalSubjectValue;

            throw ExceptionProvider.ConditionExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }
       
    }
}
