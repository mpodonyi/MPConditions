using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.DefaultExtensions
{
    public static class ConditionExtensions
    {
        public static bool Pass(this ICondition condition)
        {
            return condition.GetResult().ExceptionType == ExceptionTypes.None;
        }
    }
}
