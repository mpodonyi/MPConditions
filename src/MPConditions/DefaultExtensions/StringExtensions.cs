using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;
using MPConditions.Primitives;

namespace MPConditions.DefaultExtensions
{
    public static class StringExtensions
    {
        public static IStringCondition StartsWith(this IStringCondition condition, string predicate)
        {
            condition.Push(() =>
            {
                if(!condition.Subject.StartsWith(predicate))
                {
                    return new ExecutionContext(ExceptionTypes.OutOfRange, "Starts not with '{0}'", predicate);
                }

                return ExecutionContext.Empty;
            });

            return condition;
        }
    }
}
