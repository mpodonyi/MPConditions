﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public static class ConditionExtensions
    {
        internal static string GetMessage(ValidationInfo validationInfo)
        {
            return validationInfo.Message;
        }

        //public static T ThrowOrGet<T>(this ICondition<T> condition)
        //{
        //    ValidationInfo context=condition.GetResult();

        //    if(context.ExceptionType==ExceptionTypes.None)
        //        return (T)condition.OriginalSubject;

        //    ThrowInternal(context);
        //    return default(T);
        //}

        public static void Throw(this ICondition condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return;

            throw ExceptionProvider.ArgumentExceptionProvider.GetException(validationInfo.ExceptionType, GetMessage(validationInfo), subjectName);
        }

        public static void ThrowEx(this ICondition condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return;

            throw ExceptionProvider.ConditionExceptionProvider.GetException(validationInfo.ExceptionType, GetMessage(validationInfo), subjectName);
        }

        public static ICondition Log(this ICondition condition, bool logAll = false)
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
