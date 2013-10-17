using System;
using MPConditions.Core;
using MPConditions.Exceptions;

namespace MPConditions
{
    public static class ConditionExceptionExtensions
    {
        private static Exception GetArgumentException<TOriginalSubject>(ExceptionTypes exceptionType, string subjectName, TOriginalSubject subjectValue, string resourceKey, object[] args)
        {
            return ExceptionProvider.ArgumentExceptionProvider.GetException(exceptionType, subjectName, subjectValue, ExceptionMessageProvider.ArgumentExceptionMessageProvider.GetExceptionMessage(exceptionType, subjectName, subjectValue, resourceKey, args));
        }


        public static TOriginalSubject Throw<TSubject, TOriginalSubject>(this ConditionBase<TSubject, TOriginalSubject> condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return condition.OriginalSubjectValue;

            throw GetArgumentException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }

        //public static V ThrowEx<T, V>(this ConditionBase<T, V> condition)
        //{
        //    ValidationInfo execcontext = condition.GetResult();

        //    if(execcontext.ExceptionType == ExceptionTypes.None)
        //        return condition.OriginalSubjectValue;

        //    throw ExceptionProvider.ConditionExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        //}

    }
}
