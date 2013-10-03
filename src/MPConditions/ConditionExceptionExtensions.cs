using System;
using MPConditions.Common;
using MPConditions.Exceptions;
using MPConditions.Primitives;

namespace MPConditions
{
    public static class ConditionExceptionExtensions
    {
        //public static V Throw<T, V>(this NumberCondition<T, V> condition)   where T : struct, IComparable<T>
        //{
        //    ValidationInfo execcontext = condition.GetResult();

        //    if(execcontext.ExceptionType == ExceptionTypes.None)
        //        return condition.OriginalSubjectValue;

        //    throw ExceptionProvider.ArgumentExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        //}

        //public static string Throw(this StringCondition condition) 
        //{
        //    ValidationInfo execcontext = condition.GetResult();

        //    if(execcontext.ExceptionType == ExceptionTypes.None)
        //        return condition.OriginalSubjectValue;

        //    throw ExceptionProvider.ArgumentExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        //}


        //--------------

        public static V Throw<T,V>(this ConditionBase<T, V> condition) 
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return condition.OriginalSubjectValue;

            throw ExceptionProvider.ArgumentExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }

        public static V ThrowEx<T,V>(this ConditionBase<T, V> condition) 
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return condition.OriginalSubjectValue;

            throw ExceptionProvider.ConditionExceptionProvider.GetException(execcontext.ExceptionType, condition.SubjectName, condition.OriginalSubjectValue, execcontext.ResourceKey, execcontext.Args);
        }
       
    }
}
