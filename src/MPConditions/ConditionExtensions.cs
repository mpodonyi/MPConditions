using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions
{
    public static class ConditionExtensions
    {
        public static bool Pass(this ICondition condition)
        {
            return condition.GetResult() == null;
        }



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
