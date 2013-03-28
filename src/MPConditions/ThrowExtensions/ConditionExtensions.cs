using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.ThrowExtensions
{
    public static class ConditionExtensions
    {
        private static void ThrowInternal(ValidationInfo context)
        {
            throw new Exception();
        }




        //public static T ThrowOrGet<T>(this ICondition<T> condition)
        //{
        //    ValidationInfo context=condition.GetResult();

        //    if(context.ExceptionType==ExceptionTypes.None)
        //        return (T)condition.OriginalSubject;

        //    ThrowInternal(context);
        //    return default(T);
        //}



        //public static void Throw(this ICondition condition)
        //{
        //    ExecutionContext execcontext = condition.GetResult();

        //    if(execcontext == null)
        //        return;

        //    string message = string.Format("Argument '{0}' with value '{1}': {2}", execcontext.VariableName, execcontext.VariableValue, execcontext.Message);

        //    throw new ConditionException(execcontext.VariableName, message, execcontext.ExecutionType);

        //}
    }
}
