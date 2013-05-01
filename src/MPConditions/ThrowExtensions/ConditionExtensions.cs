using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public abstract class ExceptionProvider
    {
        static ExceptionProvider()
        {
            ArgumentExceptionProvider = new ArgumentExceptionProvider();
            ConditionExceptionProvider = new ConditionExceptionProvider();
        }


        public abstract Exception GetException(ExceptionTypes exceptionType, string message, string paramName);

        public static ExceptionProvider ArgumentExceptionProvider
        {
            set;
            internal get;
        }

        public static ExceptionProvider ConditionExceptionProvider
        {
            set;
            internal get;
        }
    }

    public class ArgumentExceptionProvider : ExceptionProvider
    {
        public override Exception GetException(ExceptionTypes exceptionType, string message, string paramName)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                    return new ArgumentOutOfRangeException(paramName, message);
                case ExceptionTypes.Null:
                    return new ArgumentNullException(paramName, message);
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ArgumentException(message, paramName);
            }

            return null;
        }
    }

    public class ConditionExceptionProvider : ExceptionProvider
    {
        public override Exception GetException(ExceptionTypes exceptionType, string message, string paramName)
        {
            switch(exceptionType)
            {
                case ExceptionTypes.OutOfRange:
                case ExceptionTypes.Null:
                case ExceptionTypes.StartsWith:
                case ExceptionTypes.WrongType:
                    return new ConditionException(message, paramName);
            }

            return null;
        }
    }


    internal enum ExceptionClassTypes
    {
        Argument,
        Condition,
    }



    public static class ConditionExtensions
    {
        internal static string GetMessage(ValidationInfo validationInfo)
        {
            return validationInfo.Message;
        }

        internal static Exception ExceptionBuilder(ValidationInfo validationInfo, ExceptionClassTypes exceptionClassType, string subjectName)
        {
            if(exceptionClassType == ExceptionClassTypes.Argument)
            {
                return ExceptionProvider.ArgumentExceptionProvider.GetException(validationInfo.ExceptionType, GetMessage(validationInfo), subjectName);
            }
            else
            {
                return ExceptionProvider.ConditionExceptionProvider.GetException(validationInfo.ExceptionType, GetMessage(validationInfo), subjectName);
            }
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

            throw ExceptionBuilder(execcontext, ExceptionClassTypes.Argument, condition.SubjectName);
        }

        public static void ThrowEx(this ICondition condition)
        {
            ValidationInfo execcontext = condition.GetResult();

            if(execcontext.ExceptionType == ExceptionTypes.None)
                return;

            throw ExceptionBuilder(execcontext, ExceptionClassTypes.Argument, condition.SubjectName);
        }

        public static ICondition Log(this ICondition condition, bool logAll = false)
        {
            ValidationInfo execcontext = condition.GetResult();

            //if(execcontext.ExceptionType == ExceptionTypes.None)
            //    return;

            return condition;
        }


    }
}
