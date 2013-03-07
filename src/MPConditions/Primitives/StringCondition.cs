using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Common;

namespace MPConditions.Primitives
{
    public class StringCondition : ConditionBase<string, StringCondition>
    {

        public StringCondition(string value, string name)
            : base(value, name)
        {
        }



        public StringCondition StartsWith(string predicate)
        {
            ec.Enqueue(() =>
            {
                if(!_Value.StartsWith(predicate))
                {
                    return new ExecutionContext
                    {
                        ExecutionType = ExecutionTypes.OutOfRange,
                        Message = string.Format("Starts not with '{0}'", predicate),
                    };
                }

                return ExecutionContext.Empty;
            });

            return this;
        }


    }
}
